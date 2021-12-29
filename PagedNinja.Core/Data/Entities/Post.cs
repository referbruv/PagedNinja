using System;
using System.ComponentModel.DataAnnotations;

namespace PagedNinja.Core.Data.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Permalink { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
