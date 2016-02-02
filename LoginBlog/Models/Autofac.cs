using Autofac;
using Autofac.Integration.Mvc;
using LoginBlog.Controllers;
using LoginBlog.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginBlog.Models
{
    public static class AutoFac
    {
        public static void Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();         //Register Generic repository
            builder.RegisterControllers(typeof(BlogsController).Assembly);                                              //Register BlogsController
            builder.RegisterType<ApplicationDbContext>();                                                               //Register ApplicationDbContext

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));                                   //Resolve Dependency
        }
    }
}