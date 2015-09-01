using System.Data.Entity;

namespace DormDoorMan.Models
{
    public class DDMDbContext : DbContext 
    {
        public DDMDbContext() : base("name=DDMDbContext")
        {
        }
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<Hosting> Hostings { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Resident> Residents { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }
        public virtual DbSet<Visitor> Visitors { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //}
    }
}