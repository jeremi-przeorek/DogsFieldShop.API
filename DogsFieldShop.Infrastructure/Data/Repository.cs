using DogsFieldShop.Core.Entities;
using DogsFieldShop.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DogsFieldShop.Infrastructure.Data
{
    class Repository<T> : IRepository<T> where T : BaseEntity
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

    }
}
