using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AppApi.Entities.Table;
using AppApi.Services;
namespace AppApi.Entities
{
    public partial class ConnectDB : DbContext
    {
        //Your Table
        public virtual DbSet<Users> Users { get; set; }
        

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
