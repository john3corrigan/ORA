using Lib.EFModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Context {
    public class RepositoryContext : DbContext {
        public DbSet<Assessment> Assessment;
        public DbSet<Assignment> Assignment;
        public DbSet<Client> Client;
        public DbSet<Employee> Employee;
        public DbSet<KPI> KPI;
        public DbSet<Position> Position;
        public DbSet<Project> Project;
        public DbSet<Role> Role;
        public DbSet<Sprint> Sprint;
        public DbSet<Story> Story;
        public DbSet<Team> Team;
        public DbSet<Profile> Profile;

        public RepositoryContext(string connectionString) : base(connectionString) {
            if (Debugger.IsAttached) {
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<RepositoryContext>());
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Assessment>().ToTable("Assessment");
            modelBuilder.Entity<Assignment>().ToTable("Assignment");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<KPI>().ToTable("KPI");
            modelBuilder.Entity<Position>().ToTable("Position");
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Sprint>().ToTable("Sprint");
            modelBuilder.Entity<Story>().ToTable("Story");
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<Profile>().ToTable("Profile");

            modelBuilder.Entity<Client>().HasMany(c => c.Story);
            modelBuilder.Entity<Client>().HasMany(c => c.Team);
            modelBuilder.Entity<Client>().HasMany(c => c.Project);
            modelBuilder.Entity<Client>().HasMany(c => c.Assignment);

            modelBuilder.Entity<Role>().HasMany(r => r.Assignment);

            modelBuilder.Entity<Employee>().HasMany(e => e.Assignment);
            modelBuilder.Entity<Employee>().HasRequired(e => e.Profile);

            modelBuilder.Entity<Position>().HasMany(p => p.Assignment);

            modelBuilder.Entity<Assignment>().HasMany(a => a.Assessment);
            modelBuilder.Entity<Assignment>().HasMany(a => a.KPI);

            modelBuilder.Entity<Story>().HasMany(s => s.KPI);

            modelBuilder.Entity<Project>().HasMany(p => p.KPI);

            modelBuilder.Entity<Sprint>().HasMany(s => s.KPI);

            modelBuilder.Entity<Team>().HasMany(t => t.Assignment);

        }
    }
}
