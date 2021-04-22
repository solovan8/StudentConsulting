using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace StudentConsulting.Models
{
    public class StudentIdentityUser : IdentityUser
    {
        public string Name { get; set; }

        public string Group { get; set; }

        public bool IsBanned { get; set; }
    }
}
