using System;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PagedNinja.Core.Data.Entities;
using PagedNinja.Core.Data.Services;

namespace PagedNinja.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<IDataService>();

                if(db.Posts.Count() == 0)
                {
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

                        db.SaveChanges();
                    }
                }
            }


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
