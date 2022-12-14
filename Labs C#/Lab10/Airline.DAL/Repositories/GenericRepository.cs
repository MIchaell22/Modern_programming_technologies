using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Airline.DAL.DBContext;
using Airline.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Airline.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly AirlineContext db;

        public GenericRepository(AirlineContext db)
        {
            this.db = db;
        }

        public async Task Add(TEntity entity)
        {
            await db.Set<TEntity>().AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task<bool> Any(int Id)
        {
            return await db.Set<TEntity>().AnyAsync(e => e.Id == Id);
        }

        public async Task Delete(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
            await db.SaveChangesAsync();
        }

        public async Task<TEntity> Get(int Id)
        {
            return await db.Set<TEntity>().FirstOrDefaultAsync(t => t.Id == Id);
        }


        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await db.Set<TEntity>().ToListAsync();
        }

        public async Task Update(TEntity entity)
        {
            db.Set<TEntity>().Update(entity);
            await db.SaveChangesAsync();
        }
    }
}
