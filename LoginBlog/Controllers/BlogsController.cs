using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LoginBlog.Models;
using Microsoft.AspNet.Identity;
using LoginBlog.Repository;

namespace LoginBlog.Controllers
{
    [Authorize]
    public class BlogsController : Controller
    {
                                                                                         //normal implementation
       // private ApplicationDbContext db = new ApplicationDbContext();

                                                                                        //using blog Repository
        //private IBlogRepository blogRepository;

        //public BlogsController()
        //{
        //    this.blogRepository = new BlogRepository(new ApplicationDbContext());
        //}
        //public BlogsController(IBlogRepository blogRepository)
        //{
        //  this.blogRepository = blogRepository;
        //}

                                                                                                //using Generic Repository
        private IRepository<Blog> repository;

        public BlogsController(IRepository<Blog> repository)
        {
            this.repository = repository;
        }

        //public BlogsController()
        //{
        //    repository = new Repository<Blog>(new ApplicationDbContext());
        //}
        

        // GET: Blogs
        public ActionResult Index(string searchString)
        {
            //var userList = new List
             
                                                                                   //normal implementation
           // var blogs = from m in db.Blog
             //           select m;
            //var blogs = db.Blog.Select(b => b);
            
                                                                                    //using Blog Repository

           // var userQuery = blogRepository.GetBlogs().OrderBy(b => b.User.UserName).Select(b => b.User.UserName);
            //var blogs = blogRepository.GetBlogs();

                                                                                     //using generic repository

            var userQuery = repository.List().OrderBy(b => b.User.UserName).Select(b => b.User.UserName);
            var blogs = repository.List();


            if (!string.IsNullOrEmpty(searchString))
            {
                blogs = blogs.Where(b => b.BlogName.StartsWith(searchString));
            }
            return View(blogs);
        }

        public ActionResult Index1()
        {
                                                                                    //normal implementation 
          //  var blog = db.Blog.Include(b => b.User);
           // return View(blog.ToList());

                                                                                    //using Blog Repository
            //return View(blogRepository.GetBlogs());

                                                                                    //using genric repository
            return View(repository.List());
        }

        // GET: Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

                                                                                    //normal implementation
            //Blog blog = db.Blog.Find(id);

                                                                                    //using Blog Repository
           // Blog blog = blogRepository.GetBlogById(id);

                                                                                     //using generic repository
            Blog blog = repository.GetById(id);


            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blogs/Create
        public ActionResult Create()
        {
                                                                                   //normal implementation
           // ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            //return View();

                                                                                    //using Blog Repository
            //ViewBag.UserId = new SelectList(blogRepository.GetBlogs(), "Id", "Email");                                                                        //using Blog Repository
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogId,BlogName,BlogDescription,BlogDate")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                                                                                    //using normal implementation
            //    db.Blog.Add(blog);
            //    blog.UserId = User.Identity.GetUserId();
            //    db.SaveChanges();
              

                                                                                    //using Blog Repository
            //blogRepository.InsertBlog(blog);
            //blog.UserId = User.Identity.GetUserId();
            //blogRepository.Save();

                                                                                    //using generic repository

                repository.Insert(blog);
                blog.UserId = User.Identity.GetUserId();
                repository.Save();

               return RedirectToAction("Index");
            }

            //ViewBag.UserId = new SelectList(db.Users, "Id", "Email", blog.UserId);
            return View(blog);
          
     }

        // GET: Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
                                                                                             //using normal implementation
          //  Blog blog = db.Blog.Find(id);


                                                                                             //using Blog Repository
            //Blog blog = blogRepository.GetBlogById(id);

                                                                                               //using generic repository
            Blog blog = repository.GetById(id);

            if (blog == null)
            {
                return HttpNotFound();
            }
          //  ViewBag.UserId = new SelectList(db.Users, "Id", "Email", blog.UserId);
            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogId,BlogName,BlogDescription,BlogDate,UserId")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                                                                                                         //normal implementation
                //db.Entry(blog).State = EntityState.Modified;
                //db.SaveChanges();

                                                                                                         //using blog Repository
                //blogRepository.UpdateBlog(blog);
                //blogRepository.Save();

                                                                                                        //using generic repository
                blog.UserId = User.Identity.GetUserId();
                repository.Update(blog);
                repository.Save();

                return RedirectToAction("Index");
            }
            //ViewBag.UserId = new SelectList(db.Users, "Id", "Email", blog.UserId);
            return View(blog);
        }

        // GET: Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
                                                                                                  //normal implementation
            //Blog blog = db.Blog.Find(id);

                                                                                                 //using blog Repository
          //  Blog blog = blogRepository.GetBlogById(id);

                                                                                                  //using Generic repository
            Blog blog = repository.GetById(id);

            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
                                                                                                  //normal implementation
            //Blog blog = db.Blog.Find(id);
            //db.Blog.Remove(blog);
            //db.SaveChanges();

                                                                                                    //using blog Repository
            //Blog blog = blogRepository.GetBlogById(id);
            //blogRepository.DeleteBlog(id);
            //blogRepository.Save();

                                                                                                    //using grneric repository
            repository.Delete(id);
            repository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                                                                                                    //normal implementation
                //db.Dispose();

                                                                                                        //using blog Repository
                //blogRepository.Dispose();

                                                                                                     //using Generic Repository
                repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
