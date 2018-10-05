using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AppApi.Models.Table;

namespace AppApi
{
    public partial class ConnectDB : DbContext
    {
        public virtual DbSet<SimpleTable> SimpleTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=paramat.work;initial catalog=TestCoreDB;persist security info=True;user id=TestDBCore;password=Addlink123!;MultipleActiveResultSets=True;App=EntityFramework;");
            }
        }
    }
}
