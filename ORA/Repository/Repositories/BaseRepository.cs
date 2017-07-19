using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Repository.Repositories {
    public class BaseRespository<TEntity, TEntityVM> : IDisposable where TEntity : class {
        protected static DbContext context;
        protected DbSet<TEntity> dbset;
        protected bool dispose = false;
        protected Mapper Mapper;

        public BaseRespository() {
            InitContext();
            InitMap();
        }

        private void InitContext() {
            if (context == null) {
                context = new DbContext("ora");
            }
            if (context != null) {
                dbset = context.Set<TEntity>();
            }
        }

        private void InitMap() {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TEntity, TEntityVM>().ReverseMap());
            Mapper = new Mapper(config);
        }

        public virtual IEnumerable<TEntity> GetAll() {
            return dbset.Include("Metadata").ToList();
        }

        public virtual TEntity GetByID(int id) {
            return dbset.Find(id);
        }

        public virtual void Add(TEntity entity) {
            if (entity != null) {
                dbset.Add(entity);
            }
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
