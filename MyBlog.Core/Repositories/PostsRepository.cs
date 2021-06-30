using MyBlog.Core.Entities;
using System.Linq;

namespace MyBlog.Core.Repositories
{
    public interface IPostsRepository
    {
        PaginatedPost GetPosts(int page = 1, int postsPerPage = 10);
    }

    public class PostsRepository : IPostsRepository
    {
        private readonly MyBlogContext _context;

        public PostsRepository(MyBlogContext context)
        {
            _context = context;
        }

        public PaginatedPost GetPosts(int page = 1, int postsPerPage = 10)
        {
            return PaginatedPost.ToPaginatedPost(_context.Posts.OrderBy(x => x.Id), page, postsPerPage);
        }
    }
}
