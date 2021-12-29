using PagedNinja.Core.Data.Repositories;

namespace PagedNinja.Core.Data.Services
{
    public interface IDataService
    {
        IPostsRepository Posts { get; }

        void SaveChanges();
    }
}
