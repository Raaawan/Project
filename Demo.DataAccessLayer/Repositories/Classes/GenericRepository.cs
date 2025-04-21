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

        #region Get all Depts
        public IEnumerable<TEntity> GetAll(bool WithTracking = false)
        {
            if (WithTracking)
            {
                return _dbContext.Set<TEntity>().ToList();
            }
            else
            {
                return _dbContext.Set<TEntity>().AsNoTracking().ToList();
            }

        }
        #endregion

        #region Update Dept
        public int Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            return _dbContext.SaveChanges();
        }
        #endregion

        #region Delete Dept
        public int Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            return _dbContext.SaveChanges();
        }
        #endregion

        #region Add Dept  
        public int Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            return _dbContext.SaveChanges();
        }
        #endregion
    }
}
