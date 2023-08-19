namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PModel : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.HistoryModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.HistoryModels",
                c => new
                    {
                        HistoryID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.HistoryID);
            
        }
    }
}
