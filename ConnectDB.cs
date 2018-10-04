using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AppApi.Models.Table;

namespace AppApi
{
    public partial class ConnectDB : DbContext
    {
        public ConnectDB()
        {
        }

        public ConnectDB(DbContextOptions<ConnectDB> options)
            : base(options)
        {
        }

        public virtual DbSet<SimpleTable> SimpleTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("");
            }
        }
    }
}
