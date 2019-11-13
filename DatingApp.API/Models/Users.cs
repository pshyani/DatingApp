using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogWebSiteAPI.Models
{
    public partial class Users
    {
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }
        
        public string Email { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
