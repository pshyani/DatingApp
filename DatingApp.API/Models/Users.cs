﻿using System;
using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public partial class Users
    {
        public Users()
        {
            Photos = new HashSet<Photos>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string KnownAs { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? LastActive { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Photos> Photos { get; set; }
    }
}
