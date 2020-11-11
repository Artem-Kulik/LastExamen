namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTemperamentAntonimID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "TemperamentAntonimID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "TemperamentAntonimID");
        }
    }
}
