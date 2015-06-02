namespace GifAtMe.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoreSpecificSlackAttributeNames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserId", c => c.String());
            AddColumn("dbo.AspNetUsers", "SlackTeamId", c => c.String());
            AddColumn("dbo.AspNetUsers", "SlackTeamName", c => c.String());
            AddColumn("dbo.AspNetUsers", "SlackTeamUrl", c => c.String());
            DropColumn("dbo.AspNetUsers", "UserId");
            DropColumn("dbo.AspNetUsers", "TeamId");
            DropColumn("dbo.AspNetUsers", "TeamName");
            DropColumn("dbo.AspNetUsers", "TeamUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "TeamUrl", c => c.String());
            AddColumn("dbo.AspNetUsers", "TeamName", c => c.String());
            AddColumn("dbo.AspNetUsers", "TeamId", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserId", c => c.String());
            DropColumn("dbo.AspNetUsers", "SlackTeamUrl");
            DropColumn("dbo.AspNetUsers", "SlackTeamName");
            DropColumn("dbo.AspNetUsers", "SlackTeamId");
            DropColumn("dbo.AspNetUsers", "UserId");
        }
    }
}
