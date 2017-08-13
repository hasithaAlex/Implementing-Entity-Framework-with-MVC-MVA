using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _03_MVA_Ex_RepoPatern.Models.Repositories
{
    public class Repository<T> where T : class
    {
        private MyDbContext context = new MyDbContext();

        protected DbSet<T> DbSet
        {
            get; set;
        }

        public Repository()
        {
            DbSet = context.Set<T>();
        }

        public List<T> GetAll()
        {
            return DbSet.ToList();
        }

        public T Get(int? id)
        {
            return DbSet.Find(id);
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        //public void Delete(int entityID, T entity)
        //{
        //    entity student = context.entity.Find(entityID);
        //    context.entity.Remove(student);
        //}

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}