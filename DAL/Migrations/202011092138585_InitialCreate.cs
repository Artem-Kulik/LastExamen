namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        TemperamentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Temperaments", t => t.TemperamentId, cascadeDelete: true)
                .Index(t => t.TemperamentId);
            
            CreateTable(
                "dbo.Temperaments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SanguinePercent = c.Int(nullable: false),
                        PhlegmaticPercent = c.Int(nullable: false),
                        CholericPercent = c.Int(nullable: false),
                        MelancholicPercent = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Admin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Results", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Questions", "TemperamentId", "dbo.Temperaments");
            DropIndex("dbo.Results", new[] { "User_Id" });
            DropIndex("dbo.Questions", new[] { "TemperamentId" });
            DropTable("dbo.Users");
            DropTable("dbo.Results");
            DropTable("dbo.Temperaments");
            DropTable("dbo.Questions");
        }
    }
}
