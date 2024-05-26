using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using portifolio_web_site.Models;

namespace portifolio_web_site.Data
{
    public class portifolio_web_siteContext : DbContext
    {
        public portifolio_web_siteContext (DbContextOptions<portifolio_web_siteContext> options)
            : base(options)
        {
        }

        public DbSet<portifolio_web_site.Models.ProfileModel> ProfileModel { get; set; } = default!;
        public DbSet<portifolio_web_site.Models.PostModel> PostModel { get; set; } = default!;
    }
}
