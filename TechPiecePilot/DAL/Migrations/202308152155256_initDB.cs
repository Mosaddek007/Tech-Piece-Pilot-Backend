namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryModels",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CatName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.ProductModels",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        ProductPicture = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ProductStatus = c.String(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.CategoryModels", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductModels", "CategoryID", "dbo.CategoryModels");
            DropIndex("dbo.ProductModels", new[] { "CategoryID" });
            DropTable("dbo.ProductModels");
            DropTable("dbo.CategoryModels");
        }
    }
}
