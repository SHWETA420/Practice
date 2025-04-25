using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.USER
{
    public class User
    {
        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }
        public IFormFile? IdentityImage  { get; set; }

    }
}
