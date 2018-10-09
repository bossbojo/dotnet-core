using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AppApi.Models.Table;
using AppApi.Services;
namespace AppApi.Configs
{
    public partial class ConnectDB : DbContext
    {
        //Your Table
        public virtual DbSet<SimpleTable> SimpleTable { get; set; }
        

        //Configuration for Connection Database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(StaticVariables.ConnectionString);
            }
        }
    }
}
