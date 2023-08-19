namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UModels : DbMigration
    {
        public override void Up()
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
        
        public override void Down()
        {
            DropTable("dbo.HistoryModels");
        }
    }
}
