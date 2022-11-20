using System;
using Microsoft.EntityFrameworkCore;
using MyMedicine.Models;

namespace MyMedicine.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<med> meds { get; set; }
        public virtual DbSet<RegistrationViewModel> registrations { get; set; }
        public virtual DbSet<LoginViewModel> logins { get; set; }
        public virtual DbSet<Userdetails> users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
    }
}