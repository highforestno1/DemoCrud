using System;
using System.Collections.Generic;

#nullable disable

namespace DemoCrud.Models
{
    public partial class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int? CategoryId { get; set; }
        public List<Category> CategoryIds { get; set; } = new List<Category>();
    }
}
