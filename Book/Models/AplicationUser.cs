using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Models
{
    public class AplicationUser : IdentityUser
    {
        public string Pass{ get; set; }
        public string FullName { get; set; }
    }
}
