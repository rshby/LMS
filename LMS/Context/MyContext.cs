using LMS.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<SubDistrict> SubDistricts { get; set; }
        public DbSet<TakenClass> TakenClasses { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<User> Users { get; set; }
    }      
}
