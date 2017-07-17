using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Repository.Repositories {
    public class BaseRespository<TEntity> : IDisposable where TEntity : class {
        protected DbContext context ;
        protected DbSet<TEntity> dbset;
        protected bool dispose = false;

        public BaseRespository() {
            context = new DbContext("");
            dbset = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll() {
            return dbset.ToList();
        }

        public virtual TEntity GetByID(int id) {
            return dbset.Find(id);
        }

        public virtual void Add(TEntity entity) {
            dbset.Add(entity);
        }

        public virtual void Update(TEntity entity) {
            TEntity updatedEntity = dbset.Find(entity);
            if (updatedEntity != null) {
                context.Entry(updatedEntity).CurrentValues.SetValues(entity);
            }
        }

        public virtual void Delete(int id) {
            TEntity entity = dbset.Find(id);
            dbset.Remove(entity);
        }

        public void Save() {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing) {
            if (!dispose) {
                if (disposing) {
                    context.Dispose();
                }
            }
            dispose = true;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
