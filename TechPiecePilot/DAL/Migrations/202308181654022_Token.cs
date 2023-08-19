namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Token : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TokenModels",
                c => new
                    {
                        TokenID = c.Int(nullable: false, identity: true),
                        CreatedAt = c.DateTime(nullable: false),
                        Expired = c.DateTime(),
                        Username = c.String(nullable: false),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.TokenID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TokenModels");
        }
    }
}
