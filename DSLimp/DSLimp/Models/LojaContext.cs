using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.Entity;

namespace DSLimp.Models
{
    
        public class LojaContext : DbContext
        {
            //Quantas classes bean vc criar deve ter um desse
            public DbSet<Cliente> Clientes { get; set; }


            //Essa parte será igual sempre
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseMySql("Server=localhost;User Id=root;Password=;Database=ds_limp");
                //base.OnConfiguring(optionsBuilder);

            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            { }
        }
}



