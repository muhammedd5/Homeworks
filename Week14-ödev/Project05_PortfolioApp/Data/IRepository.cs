using System;

namespace Project05_PortfolioApp.Data;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(bool? isActive = null);//Tüm kayıtları getir
    Task<T?> GetAsync(int id);//id id'li kaydı getir
    Task<int> AddAsync(T entity);//yeni kayıt
    Task<int> UpdateAsync(T entity);//güncelleme
    Task<int> DeleteAsync(int id);//id id'li kaydı sil
}
