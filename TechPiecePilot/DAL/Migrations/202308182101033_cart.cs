namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartModels",
                c => new
                    {
                        CartID = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        ProductID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CartID)
                .ForeignKey("dbo.ProductModels", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.UserModels", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartModels", "CustomerID", "dbo.UserModels");
            DropForeignKey("dbo.CartModels", "ProductID", "dbo.ProductModels");
            DropIndex("dbo.CartModels", new[] { "CustomerID" });
            DropIndex("dbo.CartModels", new[] { "ProductID" });
            DropTable("dbo.CartModels");
        }
    }
}
