using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;

#nullable disable

namespace DemoCrud.Models
{
    public partial class Category
    {
        public Category()
        {
            Posts = new HashSet<Post>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
