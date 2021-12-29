using PagedNinja.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PagedNinja.Core.Models
{
    public class PaginatedPost
    {
        public PaginatedPost(IEnumerable<Post> items, int count, int pageNumber, int postsPerPage)
        {
            PageInfo = new PageInfo
            {
                CurrentPage = pageNumber,
                PostsPerPage = postsPerPage,
                TotalPages = (int)Math.Ceiling(count / (double)postsPerPage),
                TotalPosts = count
            };
            this.Posts = items;
        }

        public PageInfo PageInfo { get; set; }

        public IEnumerable<Post> Posts { get; set; }

        public static PaginatedPost ToPaginatedPost(IQueryable<Post> posts, int pageNumber, int postsPerPage)
        {
            var count = posts.Count();
            var chunk = posts.Skip((pageNumber - 1) * postsPerPage).Take(postsPerPage);
            return new PaginatedPost(chunk, count, pageNumber, postsPerPage);
        }
    }

    public class PageInfo
    {
        public bool HasPreviousPage
        {
            get
            {
                return (CurrentPage > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (CurrentPage < TotalPages);
            }
        }

        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PostsPerPage { get; set; }
        public int TotalPosts { get; set; }
    }
}
