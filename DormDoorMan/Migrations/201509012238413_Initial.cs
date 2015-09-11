namespace DormDoorMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        CPF = c.String(),
                        RG = c.String(),
                        PassportNumber = c.String(),
                        NaturalityCity = c.String(),
                        NaturalityState = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        CEP = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Street = c.String(),
                        Number = c.String(),
                        Room = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Resident_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Resident_Id)
                .Index(t => t.Resident_Id);
            
            CreateTable(
                "dbo.Hostings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Double(nullable: false),
                        ProofOfPayment = c.Binary(),
                        HostingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hostings", t => t.HostingID, cascadeDelete: true)
                .Index(t => t.HostingID);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GuestID = c.Int(nullable: false),
                        GuestNumber = c.Int(nullable: false),
                        PaymentID = c.Int(nullable: false),
                        CheckIn = c.DateTime(nullable: false),
                        CheckOut = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.GuestID, cascadeDelete: true)
                .ForeignKey("dbo.Payments", t => t.PaymentID, cascadeDelete: true)
                .Index(t => t.GuestID)
                .Index(t => t.PaymentID);
            
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddresseID = c.Int(nullable: false),
                        PickUpPersonID = c.Int(nullable: false),
                        CheckIn = c.DateTime(nullable: false),
                        CheckOut = c.DateTime(nullable: false),
                        Resident_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Resident_Id)
                .ForeignKey("dbo.People", t => t.AddresseID, cascadeDelete: false)
                .ForeignKey("dbo.People", t => t.PickUpPersonID, cascadeDelete: false)
                .Index(t => t.AddresseID)
                .Index(t => t.PickUpPersonID)
                .Index(t => t.Resident_Id);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResidentID = c.Int(nullable: false),
                        VisitorID = c.Int(nullable: false),
                        CheckIn = c.DateTime(nullable: false),
                        CheckOut = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.ResidentID, cascadeDelete: false)
                .ForeignKey("dbo.People", t => t.VisitorID, cascadeDelete: false)
                .Index(t => t.ResidentID)
                .Index(t => t.VisitorID);
            
            CreateTable(
                "dbo.HostingGuests",
                c => new
                    {
                        Hosting_Id = c.Int(nullable: false),
                        Guest_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Hosting_Id, t.Guest_Id })
                .ForeignKey("dbo.Hostings", t => t.Hosting_Id, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Guest_Id, cascadeDelete: true)
                .Index(t => t.Hosting_Id)
                .Index(t => t.Guest_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Packages", "PickUpPersonID", "dbo.People");
            DropForeignKey("dbo.Packages", "AddresseID", "dbo.People");
            DropForeignKey("dbo.Visits", "VisitorID", "dbo.People");
            DropForeignKey("dbo.Visits", "ResidentID", "dbo.People");
            DropForeignKey("dbo.People", "Resident_Id", "dbo.People");
            DropForeignKey("dbo.Packages", "Resident_Id", "dbo.People");
            DropForeignKey("dbo.Reservations", "PaymentID", "dbo.Payments");
            DropForeignKey("dbo.Reservations", "GuestID", "dbo.People");
            DropForeignKey("dbo.Payments", "HostingID", "dbo.Hostings");
            DropForeignKey("dbo.HostingGuests", "Guest_Id", "dbo.People");
            DropForeignKey("dbo.HostingGuests", "Hosting_Id", "dbo.Hostings");
            DropIndex("dbo.HostingGuests", new[] { "Guest_Id" });
            DropIndex("dbo.HostingGuests", new[] { "Hosting_Id" });
            DropIndex("dbo.Visits", new[] { "VisitorID" });
            DropIndex("dbo.Visits", new[] { "ResidentID" });
            DropIndex("dbo.Packages", new[] { "Resident_Id" });
            DropIndex("dbo.Packages", new[] { "PickUpPersonID" });
            DropIndex("dbo.Packages", new[] { "AddresseID" });
            DropIndex("dbo.Reservations", new[] { "PaymentID" });
            DropIndex("dbo.Reservations", new[] { "GuestID" });
            DropIndex("dbo.Payments", new[] { "HostingID" });
            DropIndex("dbo.People", new[] { "Resident_Id" });
            DropTable("dbo.HostingGuests");
            DropTable("dbo.Visits");
            DropTable("dbo.Packages");
            DropTable("dbo.Reservations");
            DropTable("dbo.Payments");
            DropTable("dbo.Hostings");
            DropTable("dbo.People");
        }
    }
}
