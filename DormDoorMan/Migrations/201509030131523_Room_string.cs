namespace DormDoorMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Room_string : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "Room", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "Room", c => c.Int());
        }
    }
}
