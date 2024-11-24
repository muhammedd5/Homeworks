using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Project05_PortfolioApp.Data;

public class DapperRepository<T> : IRepository<T> where T : class
{
    private readonly string _connectionString;
    private readonly string _tableName;
    public DapperRepository()
    {
        _connectionString = "Server=localhost,1433;Database=PortfolioDb;User=SA;Password=YourStrong@Passw0rd;TrustServerCertificate=true";
        _tableName = typeof(T).Name;
        if (_tableName.EndsWith("y"))
        {
            _tableName = _tableName.Substring(0, _tableName.Length - 1) + "ies";
        }
        else
        {
            _tableName += "s";
        }
    }

    private IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }

    public async Task<int> AddAsync(T entity)
    {
        using var connection = CreateConnection();
        var query = GenerateInsertQuery(entity);
        return await connection.ExecuteAsync(query, entity);
    }

    public async Task<int> DeleteAsync(int id)
    {
        using var connection = CreateConnection();
        var query = $"DELETE FROM {_tableName} WHERE Id = {id}";
        return await connection.ExecuteAsync(query, new { Id = id });
    }

    public async Task<IEnumerable<T>> GetAllAsync(bool? isActive = null)
    {
        using var connection = CreateConnection();
        string query;
        if (isActive == null)
        {
            query = $"SELECT * FROM {_tableName}";
        }
        else
        {
            query = $"SELECT * FROM {_tableName} WHERE IsActive=@IsActive";
        }
        return await connection.QueryAsync<T>(query, new { IsActive = isActive });
    }

    public async Task<T?> GetAsync(int id)
    {
        using var connection = CreateConnection();
        var query = $"SELECT * FROM {_tableName} WHERE Id=@Id";
        var result = await connection.QueryFirstOrDefaultAsync<T>(query, new { Id = id });
        return result ?? null;
    }

    public async Task<int> UpdateAsync(T entity)
    {
        using var connection = CreateConnection();
        var query = GenerateUpdateQuery(entity);
        return await connection.ExecuteAsync(query, entity);
    }

    private string GenerateInsertQuery(T entity)
    {
        // Buraya gelen entity nesnesinin property'lerini alıyoruz
        var properties = typeof(T).GetProperties();

        // Kolon isimlerini ve değerlerini tutacağımız listeyi tanımlıyoruz
        var columnNames = new List<string>();
        var parameterNames = new List<string>();

        //Id,CreatedDate,ModifiedDate ve SendingTime dışındaki propertyleri, kolon adı listesine ekliyor ve değerlerini de parametre listesine ekliyoruz.
        foreach (var property in properties)
        {
            if (property.Name == "Id" || property.Name == "CreatedDate" || property.Name == "ModifiedDate" || property.Name == "SendingTime") continue;
            columnNames.Add(property.Name); // Kolon ismi ekleniyor
            parameterNames.Add("@" + property.Name); // Değer ekleniyor
        }

        var columns = string.Join(", ", columnNames);
        var parameters = string.Join(", ", parameterNames);

        //Sorguyu yaratıyoruz
        var query = $"INSERT INTO {_tableName}({columns}) VALUES ({parameters})";

        return query;
    }

    private string GenerateUpdateQuery(T entity)
    {
        var properties = typeof(T).GetProperties();
        var setClauses = new List<string>();
        int? idValue = null;
        foreach (var property in properties)
        {
            if (property.Name == "CreatedDate") continue;
            if (property.Name == "Id")
            {
                idValue = Convert.ToInt32(property.GetValue(entity));
                continue;
            }
            setClauses.Add($"{property.Name}=@{property.Name}");
        }
        var clauses = string.Join(", ", setClauses);
        var query = $"UPDATE {_tableName} SET {clauses} WHERE Id=@Id";
        return query;
    }

}


