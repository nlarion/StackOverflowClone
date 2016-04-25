using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace StackOverflowClone.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
    }
}
