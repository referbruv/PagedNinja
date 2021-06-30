using MyBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBlog.Core
{
    public class PaginatedPost
    {
        public PaginatedPost(IEnumerable<Post> items, int count, int pageNumber, int postsPerPage)
        {
            Metadata = new Metadata
            {
                CurrentPage = pageNumber,
                PostsPerPage = postsPerPage,
                TotalPages = (int)Math.Ceiling(count / (double)postsPerPage),
                TotalPosts = count
            };
            this.Posts = items;
        }

        public Metadata Metadata { get; set; }

        public IEnumerable<Post> Posts { get; set; }

        public static PaginatedPost ToPaginatedPost(IQueryable<Post> posts, int pageNumber, int postsPerPage)
        {
            var count = posts.Count();
            var chunk = posts.Skip((pageNumber - 1) * postsPerPage).Take(postsPerPage);
            return new PaginatedPost(chunk, count, pageNumber, postsPerPage);
        }
    }

    public class Metadata
    {
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PostsPerPage { get; set; }
        public int TotalPosts { get; set; }
    }

    public class QueryParams
    {
        private const int _maxPageSize = 50;

        private int _page = 10;

        public int Page { get; set; } = 1;

        public int PostsPerPage
        {
            get
            {
                return _page;
            }
            set
            {
                if (value > _maxPageSize) _page = _maxPageSize;
                else _page = value;
            }
        }
    }
}
