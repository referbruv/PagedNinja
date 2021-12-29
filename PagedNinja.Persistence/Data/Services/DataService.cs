using PagedNinja.Core.Data.Repositories;
using PagedNinja.Core.Data.Services;
using PagedNinja.Persistence.Data.Repositories;

namespace PagedNinja.Persistence.Data.Services
{
    public class DataService : IDataService
    {
        private readonly MyBlogContext _context;

        public DataService(MyBlogContext context)
        {
            _context = context;
        }

        public IPostsRepository Posts => new PostsRepository(_context);

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
