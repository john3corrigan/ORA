using AutoMapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using Repository.Context;

namespace Repository.Repositories {
    public class BaseRespository<TEntity> : IDisposable where TEntity : class {
        protected RepositoryContext Context;
        protected DbSet<TEntity> DbSet;
        protected MapperConfiguration config;

        public BaseRespository(RepositoryContext context) {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll() {
            return DbSet.ToList();
        }

        public virtual TEntity GetByID(int id) {
            return DbSet.Find(id);
        }

        public virtual void Add(TEntity entity) {
            if (entity != null) {
                DbSet.Add(entity);
            }
        }

        public virtual void Update(TEntity entity) {
            TEntity updatedEntity = DbSet.Find(entity);
            if (updatedEntity != null) {
                Context.Entry(updatedEntity).CurrentValues.SetValues(entity);
            }
        }

        public virtual void Delete(int id) {
            TEntity entity = DbSet.Find(id);
            DbSet.Remove(entity);
        }

        public void Save() {
            Context.SaveChanges();
        }

        protected void Dispose(bool disposing) {
            if (disposing) {
                if(Context != null) {
                    Context.Dispose();
                    Context = null;
                }
            }
        }

        public void Dispose() {
            Dispose(true);
        }
    }
}
