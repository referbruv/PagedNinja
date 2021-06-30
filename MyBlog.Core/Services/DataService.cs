using MyBlog.Core.Entities;
using MyBlog.Core.Repositories;

namespace MyBlog.Core.Services
{
    public interface IDataService
    {
        IPostsRepository Posts { get; }
    }

    public class DataService : IDataService
    {
        private readonly MyBlogContext _context;

        public DataService(MyBlogContext context)
        {
            _context = context;
        }

        public IPostsRepository Posts => new PostsRepository(_context);
    }
}
