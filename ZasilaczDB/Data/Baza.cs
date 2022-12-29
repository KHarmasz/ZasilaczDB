using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZasilaczDB.Models;

namespace Zasilacze
{
    public class Baza : DbContext
    {
        public Baza (DbContextOptions<Baza> options)
            : base(options)
        {
        }

        public DbSet<ZasilaczDB.Models.Zasilacz> Zasilacz { get; set; } = default!;
    }
}
