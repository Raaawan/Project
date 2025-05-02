using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccessLayer.Data.Contexts;
using Demo.DataAccessLayer.Models.Shared;
using Demo.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Demo.DataAccessLayer.Repositories.Classes
{
    public class GenericRepository<TEntity>(ApplicationDbContext _dbContext) : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        #region get by id
        public TEntity? GetById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }
        #endregion

        #region Get all
        public IEnumerable<TEntity> GetAll(bool WithTracking = false)
        {
            if (WithTracking)
            {
                return _dbContext.Set<TEntity>().Where(E=>E.IsDeleted!=true).ToList();
            }
            else
            {
                return _dbContext.Set<TEntity>().Where(E => E.IsDeleted != true).AsNoTracking().ToList();
            }

        }
        #endregion

        #region Update 
        public int Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            return _dbContext.SaveChanges();
        }
        #endregion

        #region Delete
        public int Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            return _dbContext.SaveChanges();
        }
        #endregion

        #region Add   
        public int Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            return _dbContext.SaveChanges();
        }


        #endregion

        #region Difference between IEnumerable and IQueryable
        public IEnumerable<TEntity> GetIEnumerable()
        {
            return _dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _dbContext.Set<TEntity>();
        }
        #endregion
    }
}
