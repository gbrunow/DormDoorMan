using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DormDoorMan.Models
{
    public class DDMContext : DbContext 
    {
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Hosting> Hostings { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Resident> Residents { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Visitor> Visitors { get; set; } 
    }
}