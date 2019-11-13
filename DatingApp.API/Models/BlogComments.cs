using System;
using System.Collections.Generic;

namespace BlogWebSiteAPI.Models
{
    public partial class BlogComments
    {
        public int BlogCommentsId { get; set; }
        public string UserName { get; set; }
        public int BlogId { get; set; }
        public string Comment { get; set; }
        public DateTime? Datecreated { get; set; }

        public Blogs Blog { get; set; }
    }
}
