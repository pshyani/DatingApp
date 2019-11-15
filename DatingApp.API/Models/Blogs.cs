using System;
using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public partial class Blogs
    {
        public Blogs()
        {
            BlogComments = new HashSet<BlogComments>();
        }

        public int BlogId { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Datecreated { get; set; }

        public virtual ICollection<BlogComments> BlogComments { get; set; }
    }
}
