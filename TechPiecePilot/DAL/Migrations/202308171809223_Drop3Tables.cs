namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Drop3Tables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReqProductModels", "CategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.UserModels", "Role", c => c.String(nullable: false));
            CreateIndex("dbo.FeedbackModels", "CustomerID");
            CreateIndex("dbo.ReqProductModels", "CategoryID");
            CreateIndex("dbo.ReqProductModels", "CutomerID");
            CreateIndex("dbo.WishlistModels", "CustomerID");
            CreateIndex("dbo.WishlistModels", "ProductID");
            AddForeignKey("dbo.FeedbackModels", "CustomerID", "dbo.UserModels", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.ReqProductModels", "CategoryID", "dbo.CategoryModels", "CategoryID", cascadeDelete: true);
            AddForeignKey("dbo.ReqProductModels", "CutomerID", "dbo.UserModels", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.WishlistModels", "ProductID", "dbo.ProductModels", "ProductID", cascadeDelete: true);
            AddForeignKey("dbo.WishlistModels", "CustomerID", "dbo.UserModels", "UserID", cascadeDelete: true);
            DropColumn("dbo.ReqProductModels", "CatName");
            DropTable("dbo.CartModels");
            DropTable("dbo.OrderModels");
            DropTable("dbo.PaymentModels");
            DropTable("dbo.ReviewsModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ReviewsModels",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewID);
            
            CreateTable(
                "dbo.PaymentModels",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        PaymentType = c.String(nullable: false),
                        GrandTotal = c.Int(nullable: false),
                        InvoiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentID);
            
            CreateTable(
                "dbo.OrderModels",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Status = c.String(),
                        CartID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateTable(
                "dbo.CartModels",
                c => new
                    {
                        CartID = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        ProductID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        GrandTotal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CartID);
            
            AddColumn("dbo.ReqProductModels", "CatName", c => c.String());
            DropForeignKey("dbo.WishlistModels", "CustomerID", "dbo.UserModels");
            DropForeignKey("dbo.WishlistModels", "ProductID", "dbo.ProductModels");
            DropForeignKey("dbo.ReqProductModels", "CutomerID", "dbo.UserModels");
            DropForeignKey("dbo.ReqProductModels", "CategoryID", "dbo.CategoryModels");
            DropForeignKey("dbo.FeedbackModels", "CustomerID", "dbo.UserModels");
            DropIndex("dbo.WishlistModels", new[] { "ProductID" });
            DropIndex("dbo.WishlistModels", new[] { "CustomerID" });
            DropIndex("dbo.ReqProductModels", new[] { "CutomerID" });
            DropIndex("dbo.ReqProductModels", new[] { "CategoryID" });
            DropIndex("dbo.FeedbackModels", new[] { "CustomerID" });
            AlterColumn("dbo.UserModels", "Role", c => c.String());
            DropColumn("dbo.ReqProductModels", "CategoryID");
        }
    }
}
