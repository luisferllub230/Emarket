using E_Market.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_market.Infrastruture.Persistence.Context
{
    public class ApplicationContext : DbContext 
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}

        //property 
        public DbSet<Users> Users { get; set; }
        public DbSet<Comercial> Comercial { get; set; }
        public DbSet<Categories> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            //fluent API name tables 
            #region tables
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Comercial>().ToTable("Comercial");
            modelBuilder.Entity<Categories>().ToTable("Categories");
            #endregion

            //fluent API primary key 
            //#region primaryKey
            //modelBuilder.Entity<Users>().HasKey(u => u.id);
            //modelBuilder.Entity<Comercial>().HasKey(c => c.id);
            //modelBuilder.Entity<Categories>().HasKey(ca => ca.id);
            //#endregion

            //fluent API relationship
            //#region relationship
            //modelBuilder.Entity<Users>()
            //    .HasMany<Comercial>(u => u.comercials)
            //    .WithOne(u => u.comercialUsers)
            //    .HasForeignKey(u => u.comercialUsersID)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Categories>()
            //    .HasMany<Comercial>(u => u.comercials)
            //    .WithOne(u => u.comercialCategories)
            //    .HasForeignKey(u => u.comercialCategoriesID)
            //    .OnDelete(DeleteBehavior.Cascade);
            //#endregion

            //flued API property configuration
            #region "property configuration"

            #region Users
            modelBuilder.Entity<Users>().Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Users>().Property(u => u.UserLastName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Users>().Property(u => u.UserEmail)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Users>().Property(u => u.UsersPasswork)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Users>().Property(u => u.UsersPhone)
                .IsRequired()
                .HasMaxLength(10);
            #endregion

            #region Comercial
            modelBuilder.Entity<Comercial>().Property(c => c.comercialName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Comercial>().Property(c => c.comercialDesciption)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Comercial>().Property(c => c.comercialDate)
                .IsRequired();

            modelBuilder.Entity<Comercial>().Property(c => c.comercialImage1)
                .IsRequired();
            #endregion

            #region Categories
            modelBuilder.Entity<Categories>().Property(ca => ca.categoriesName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Categories>().Property(ca => ca.categoriesDescrition)
                .IsRequired()
                .HasMaxLength(50);
            #endregion

            #endregion
        }
    }
}
