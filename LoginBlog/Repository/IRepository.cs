using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginBlog.Repository
{
    public interface IRepository<T> : IDisposable 
    {
        IEnumerable<T> List();
        T GetById(int? id);
        void Insert(T entity);
        void Delete(int? id);
        void Update(T entity);
        void Save();
    }
}