﻿using DSLimp.Models;
using Microsoft.EntityFrameworkCore;

namespace DSLimp.Modulos
{

    public class LojaContext : DbContext
        {
            //Quantas classes bean vc criar deve ter um desse
            public DbSet<Cliente> clientes { get; set; }
            public DbSet<Produto> produtos { get; set; }
            //public DbSet<LoginViewModel> usuarios { get; set; }     
            public DbSet<Gasto> gastos { get; set; }
           

        //Essa parte será igual sempre
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseMySql("Server=sql139.main-hosting.eu.;User Id=u938732425_dgg;Password=uninovedgg;Database=u938732425_dslim");
              //  base.OnConfiguring(optionsBuilder);

            }

            /*protected override void OnModelCreating(ModelBuilder modelBuilder)
            { }*/
        }
}



