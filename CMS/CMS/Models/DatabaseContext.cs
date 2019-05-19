using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CMS.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("CMSContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, CMS.Migrations.Configuration>());
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<PCMember> PCMembers { get; set; }
        public DbSet<CallForPapers> CallsForPapers { get; set; }
        public DbSet<Abstract> Abstracts { get; set; }
        public DbSet<Comitee> Comitees { get; set; }
        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Paper> Papers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}