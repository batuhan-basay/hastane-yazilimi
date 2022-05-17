using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hastane_yazilimi.Models
{
    public class Context: DbContext
    {
        public DbSet<HastaTable> HastaTables { get; set; }
        public DbSet<RandevuTable> RandevuTables { get; set; }
        public DbSet<FaturaTable> FaturaTables { get; set; }
        public DbSet<IslemTable> IslemTables { get; set; }
        public DbSet<DoktorTable> DoktorTables { get; set; }
        public DbSet<UnvanTable> UnvanTables { get; set; }
        public DbSet<PolikinlikTable> PolikinlikTables { get; set; }
        public DbSet<KlinikTable> KlinikTables { get; set; }

    }
}