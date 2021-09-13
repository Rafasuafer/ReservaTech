using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Core
{
    public class ApplicationUser: IdentityUser
    {
        public virtual List<Business> Businesses { get; set; }
    }
}
