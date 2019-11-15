﻿using System;
using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public partial class Photos
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime? DateAdded { get; set; }
        public bool? IsMain { get; set; }
        public int UserId { get; set; }

        public Users User { get; set; }
    }
}
