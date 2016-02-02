using LoginBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LoginBlog.Repository
{
    public class BlogRepository:IBlogRepository
    {
        private ApplicationDbContext context;

        public BlogRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Blog> GetBlogs()
        {
            return context.Blog.ToList();
        }

        public Blog GetBlogById(int? BlogId)
        {
            return context.Blog.Find(BlogId);
        }
        public void InsertBlog(Blog blog)
        {
            context.Blog.Add(blog);

        }
        public void DeleteBlog(int? BlogId)
        {
            Blog blog = context.Blog.Find(BlogId);
            context.Blog.Remove(blog);
        }
        public void UpdateBlog(Blog blog)
        {
            context.Entry(blog).State = EntityState.Modified;

        }
        public void Save()
        {
            context.SaveChanges();
        }
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