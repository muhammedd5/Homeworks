using System;

namespace Project05_PortfolioApp.Data;

public class EfCoreRepository<T> : IRepository<T> where T : class
{
    //Burası EfCore için yazıldı, biz kullanmayacağız, örnek olsun diye yazdık.
    public Task<int> AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetAllAsync(bool? isActive = null)
    {
        throw new NotImplementedException();
    }

    public Task<T?> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
}
