using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApi.Entities.Table;
using WebApi.Services;
namespace WebApi.Libraries.Pagination
{
    public partial class Context : DbContext
    {
        //Your Table
        public virtual DbSet<pagination_json> ReponseJson { get; set; }
        public virtual DbSet<installer> installer { get; set; }


        //Configuration for Connection Database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(StaticVariables.ConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
    public class pagination_json
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public int Count_row { get; set; }
    }
     public class installer
    {
        public int Id { get; set; }
        public int count_store { get; set; }
    }
}
