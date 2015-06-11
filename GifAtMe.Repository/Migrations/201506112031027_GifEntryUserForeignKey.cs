namespace GifAtMe.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GifEntryUserForeignKey : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.GifEntryDb", name: "UserDb_Id", newName: "UserDbId");
            RenameIndex(table: "dbo.GifEntryDb", name: "IX_UserDb_Id", newName: "IX_UserDbId");
            DropColumn("dbo.GifEntryDb", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GifEntryDb", "UserId", c => c.String());
            RenameIndex(table: "dbo.GifEntryDb", name: "IX_UserDbId", newName: "IX_UserDb_Id");
            RenameColumn(table: "dbo.GifEntryDb", name: "UserDbId", newName: "UserDb_Id");
        }
    }
}
