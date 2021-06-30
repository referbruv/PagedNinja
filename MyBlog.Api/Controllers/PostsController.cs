using Microsoft.AspNetCore.Mvc;
using MyBlog.Core;
using MyBlog.Core.Services;

namespace MyBlog.Api.Controllers
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
