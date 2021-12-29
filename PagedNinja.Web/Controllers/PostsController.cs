using Microsoft.AspNetCore.Mvc;
using PagedNinja.Core.Data.Services;
using PagedNinja.Core.Models;

namespace PagedNinja.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IDataService _db;

        public PostsController(IDataService db)
        {
            _db = db;
        }

        [HttpGet]
        public PaginatedPost Get([FromQuery] QueryParams qp)
        {
            return _db.Posts.GetPosts(qp.Page, qp.PostsPerPage);
        }
    }
}
