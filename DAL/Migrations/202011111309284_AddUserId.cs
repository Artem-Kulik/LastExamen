namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Results", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Results", name: "IX_User_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Results", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Results", name: "UserId", newName: "User_Id");
        }
    }
}
