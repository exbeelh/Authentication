using EmployeeApp.Models;
using Exercise.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Exercise.Context
{
    public class ManagementContext : DbContext
    {
        public ManagementContext(DbContextOptions<ManagementContext> options):base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Profilling> Profillings { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<University>()
                .HasMany(e => e.Educations)
                .WithOne(e => e.Universities)
                .HasForeignKey(e => e.UniversityId);

            modelBuilder.Entity<AccountRole>()
                .HasOne(e => e.Accounts)
                .WithMany(e => e.AccountRoles)
                .HasForeignKey(e => e.Nik);

            modelBuilder.Entity<AccountRole>()
                .HasOne(e => e.Roles)
                .WithMany(e => e.AccountRoles)
                .HasForeignKey(e => e.RoleId);

            modelBuilder.Entity<Profilling>()
                .HasOne(e => e.Employee)
                .WithOne(e => e.Profillings)
                .HasForeignKey<Profilling>(e => e.EmployeeNik);

            modelBuilder.Entity<Profilling>()
                .HasOne(e => e.Education)
                .WithOne(e => e.Profillings)
                .HasForeignKey<Profilling>(e => e.EducationId);

            modelBuilder.Entity<Account>()
                .HasOne(e => e.Employees)
                .WithOne(e => e.Accounts)
                .HasForeignKey<Account>(e => e.Nik);

            modelBuilder.Entity<RegisterVM>()
                .HasNoKey();

            /* modelBuilder.Entity<LoginVM>()
                .HasNoKey();
            */
        }

        public DbSet<Exercise.ViewModels.RegisterVM>? RegisterVM { get; set; }
    }
}
