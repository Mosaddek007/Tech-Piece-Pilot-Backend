namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tokenupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TokenModels", "TokenKey", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TokenModels", "TokenKey");
        }
    }
}
