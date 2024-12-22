using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CaioDexelop.Models;

namespace CaioDexelop.Data
{
    public class CaioDexelopContext : DbContext
    {
        public CaioDexelopContext (DbContextOptions<CaioDexelopContext> options)
            : base(options)
        {
        }

        public DbSet<CaioDexelop.Models.Utente> Utente { get; set; } = default!;
    }
}
