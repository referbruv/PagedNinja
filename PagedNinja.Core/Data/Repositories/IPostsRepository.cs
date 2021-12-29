using PagedNinja.Core.Data.Entities;
using PagedNinja.Core.Models;

namespace PagedNinja.Core.Data.Repositories
{
    public interface IPostsRepository
    {
        PaginatedPost GetPosts(int page = 1, int postsPerPage = 10);
        Post Add(Post post);
        int Count();
    }
}
