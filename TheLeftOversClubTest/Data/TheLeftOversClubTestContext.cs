using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TheLeftOversClubTest.Models
{
    public class TheLeftOversClubTestContext : DbContext
    {
        public TheLeftOversClubTestContext (DbContextOptions<TheLeftOversClubTestContext> options)
            : base(options)
        {
        }

        public DbSet<TheLeftOversClubTest.Models.Product> Product { get; set; }
    }
}
