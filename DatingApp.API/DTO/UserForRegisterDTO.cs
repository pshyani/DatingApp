using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebSiteAPI.DTO
{
    public class UserForRegisterDTO
    {
        [Required]
        public string userName { get; set; }
        
        [EmailAddress]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
    }
}
