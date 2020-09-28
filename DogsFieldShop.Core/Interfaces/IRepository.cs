using DogsFieldShop.Core.Entities;
using DogsFieldShop.Core.Specyfications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DogsFieldShop.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetById(int id);
        Task<IReadOnlyList<T>> GetAll();
        Task<T> GetEntityWithSpecAsync(ISpecyfication<T> spec);
        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecyfication<T> spec);
    }
}
