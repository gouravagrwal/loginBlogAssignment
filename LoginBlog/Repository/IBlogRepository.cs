using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoginBlog.Models;

namespace LoginBlog.Repository
{
    public interface IBlogRepository:IDisposable
    {
        IEnumerable<Blog> GetBlogs();
        Blog GetBlogById(int? BlogId);
        void InsertBlog(Blog blog);
        void DeleteBlog(int? BlogId);
        void UpdateBlog(Blog blog);
        void Save();

    }
}