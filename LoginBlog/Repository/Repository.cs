using LoginBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LoginBlog.Repository
{
    public class Repository<T>: IRepository<T> where T:class
    {
        private ApplicationDbContext db;
        private DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            this.db = db;
            this.dbSet = db.Set<T>();
        }
        
        public virtual IEnumerable<T> List()
        {
            return dbSet.AsEnumerable();
        }
        public virtual T GetById(int? id)
        {
            return dbSet.Find(id);
        }
        public virtual void Insert(T entity)
        {
            dbSet.Add(entity);
            db.SaveChanges();

        }
        public virtual void Delete(int? id)
        {
            T entity = dbSet.Find(id);
            dbSet.Remove(entity);
            db.SaveChanges();
        }
        public virtual void Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();

        }
        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
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