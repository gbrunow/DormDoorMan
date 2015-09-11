namespace DormDoorMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adjustments : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservations", "CheckOut", c => c.DateTime());
            AlterColumn("dbo.Packages", "CheckOut", c => c.DateTime());
            AlterColumn("dbo.Visits", "CheckOut", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Visits", "CheckOut", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Packages", "CheckOut", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Reservations", "CheckOut", c => c.DateTime(nullable: false));
        }
    }
}
