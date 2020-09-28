using DogsFieldShop.Core.Entities;
using DogsFieldShop.Core.Interfaces;
using DogsFieldShop.Core.Specyfications;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogsFieldShop.Infrastructure.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;

        public Repository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetEntityWithSpec(ISpecyfication<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync(); 
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecyfication<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecyfication<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }
}
