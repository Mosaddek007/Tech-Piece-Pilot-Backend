namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class models : DbMigration
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
                        GrandTotal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CartID);
            
            CreateTable(
                "dbo.FeedbackModels",
                c => new
                    {
                        FeedbackID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CustomerID = c.Int(nullable: false),
                        ReplyFromAdmin = c.String(),
                    })
                .PrimaryKey(t => t.FeedbackID);
            
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
                "dbo.ReqProductModels",
                c => new
                    {
                        ReqID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        CatName = c.String(),
                        CutomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReqID);
            
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
                "dbo.UserModels",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Role = c.String(),
                        Firstname = c.String(nullable: false),
                        Lastname = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.Int(nullable: false),
                        Gender = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.WishlistModels",
                c => new
                    {
                        WishID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WishID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WishlistModels");
            DropTable("dbo.UserModels");
            DropTable("dbo.ReviewsModels");
            DropTable("dbo.ReqProductModels");
            DropTable("dbo.PaymentModels");
            DropTable("dbo.OrderModels");
            DropTable("dbo.FeedbackModels");
            DropTable("dbo.CartModels");
        }
    }
}
