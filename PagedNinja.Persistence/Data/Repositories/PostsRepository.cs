using PagedNinja.Core.Data.Entities;
using PagedNinja.Core.Data.Repositories;
using PagedNinja.Core.Models;

namespace PagedNinja.Persistence.Data.Repositories
{
    public class PostsRepository : IPostsRepository
    {
        private readonly MyBlogContext _context;

        public PostsRepository(MyBlogContext context)
        {
            _context = context;
        }

        public Post Add(Post post)
        {
            _context.Posts.Add(post);
            return post;
        }

        public int Count()
        {
            return _context.Posts.Count();
        }

        public PaginatedPost GetPosts(int page = 1, int postsPerPage = 10)
        {
            return PaginatedPost.ToPaginatedPost(_context.Posts.OrderBy(x => x.Id), page, postsPerPage);
        }
    }
}
