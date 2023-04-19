using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;

#nullable disable

namespace DemoCrud.Models
{
    public partial class Post
    {
        public Post()
        {
            Categories = new HashSet<Category>();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }
        public  ICollection<Category> Categories { get; set; }
    }
}
