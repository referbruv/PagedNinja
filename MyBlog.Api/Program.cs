using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyBlog.Core.Entities;

namespace MyBlog.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<MyBlogContext>();

            if (!db.Database.EnsureCreated())
            {
            }

            for (int i = 1001; i <= 2000; i++)
            {
                var post = new Post
                {
                    Id = i,
                    Title = $"This is your sample Post on Paginating DotnetCoreAPI {i}",
                    Content = "This is some random content you might always want to ignore. Look at the other stuffs first. I'm just a substitute here",
                    CreatedOn = DateTime.UtcNow
                };
                post.Permalink = Regex.Replace(post.Title, "\\s+", "-");
                db.Posts.Add(post);
            }

            db.SaveChanges();

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
