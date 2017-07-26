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
            else {
                Database.SetInitializer(new CreateDatabaseIfNotExists<RepositoryContext>());
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

            modelBuilder.Entity<Assignment>().HasRequired(a => a.KPI).WithMany().WillCascadeOnDelete(false);

            modelBuilder.Entity<KPI>().HasRequired(k => k.Assignment).WithMany(a => a.KPI).HasForeignKey(k => k.AssignmentID).WillCascadeOnDelete(false);

            modelBuilder.Entity<Story>().HasRequired(s => s.Client).WithMany().WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>().HasRequired(t => t.Client).WithMany().WillCascadeOnDelete(false);

            modelBuilder.Entity<Profile>().HasRequired(p => p.Position).WithMany().WillCascadeOnDelete(false);
        }
    }
}
