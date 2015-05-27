﻿using System.Linq;
using Microsoft.Data.Entity;
using Xunit;

namespace ErikEJ.Data.Entity.SqlServerCe.FunctionalTests
{
    public class BasicEndToEndScenarioForNoIdentity
    {
        [Fact]
        public void Can_run_end_to_end_scenario()
        {
            using (var db = new BloggingContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                db.Blogs.Add(new Blog { Id = 99, Url = "http://erikej.blogspot.com" });
                db.SaveChanges();

                var blogs = db.Blogs.ToList();

                Assert.Equal(blogs.Count, 1);
                Assert.Equal(blogs[0].Url, "http://erikej.blogspot.com");
                Assert.Equal(blogs[0].Id, 99);
            }
        }

        public class BloggingContext : DbContext
        {
            public DbSet<Blog> Blogs { get; set; }

            protected override void OnConfiguring(EntityOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlCe(@"Data Source=BloggingNoIdentity.sdf");
            }
        }

        public class Blog
        {
            public int Id { get; set; }
            public string Url { get; set; }
        }
    }
}
