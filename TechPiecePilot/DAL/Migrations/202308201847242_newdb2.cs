namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdb2 : DbMigration
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
                        Username = c.String(maxLength: 128),
                        Quantity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CartID)
                .ForeignKey("dbo.ProductModels", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Username)
                .Index(t => t.ProductID)
                .Index(t => t.Username);
            
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
            
            CreateTable(
                "dbo.CategoryModels",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CatName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 100),
                        Gender = c.String(nullable: false, maxLength: 100),
                        Dob = c.DateTime(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.FeedbackModels",
                c => new
                    {
                        FeedbackID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Username = c.String(maxLength: 128),
                        ReplyFromAdmin = c.String(),
                    })
                .PrimaryKey(t => t.FeedbackID)
                .ForeignKey("dbo.Customers", t => t.Username)
                .Index(t => t.Username);
            
            CreateTable(
                "dbo.ReqProductModels",
                c => new
                    {
                        ReqID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        CategoryID = c.Int(nullable: false),
                        Username = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ReqID)
                .ForeignKey("dbo.CategoryModels", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Username)
                .Index(t => t.CategoryID)
                .Index(t => t.Username);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TKey = c.String(nullable: false, maxLength: 100),
                        CreatedAt = c.DateTime(nullable: false),
                        Expired = c.DateTime(),
                        Username = c.String(nullable: false, maxLength: 128),
                        UserType = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Username, cascadeDelete: true)
                .Index(t => t.Username);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        UserType = c.String(),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.WishlistModels",
                c => new
                    {
                        WishID = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 128),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WishID)
                .ForeignKey("dbo.ProductModels", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Username)
                .Index(t => t.Username)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WishlistModels", "Username", "dbo.Customers");
            DropForeignKey("dbo.WishlistModels", "ProductID", "dbo.ProductModels");
            DropForeignKey("dbo.Tokens", "Username", "dbo.Users");
            DropForeignKey("dbo.ReqProductModels", "Username", "dbo.Customers");
            DropForeignKey("dbo.ReqProductModels", "CategoryID", "dbo.CategoryModels");
            DropForeignKey("dbo.FeedbackModels", "Username", "dbo.Customers");
            DropForeignKey("dbo.CartModels", "Username", "dbo.Customers");
            DropForeignKey("dbo.CartModels", "ProductID", "dbo.ProductModels");
            DropForeignKey("dbo.ProductModels", "CategoryID", "dbo.CategoryModels");
            DropIndex("dbo.WishlistModels", new[] { "ProductID" });
            DropIndex("dbo.WishlistModels", new[] { "Username" });
            DropIndex("dbo.Tokens", new[] { "Username" });
            DropIndex("dbo.ReqProductModels", new[] { "Username" });
            DropIndex("dbo.ReqProductModels", new[] { "CategoryID" });
            DropIndex("dbo.FeedbackModels", new[] { "Username" });
            DropIndex("dbo.ProductModels", new[] { "CategoryID" });
            DropIndex("dbo.CartModels", new[] { "Username" });
            DropIndex("dbo.CartModels", new[] { "ProductID" });
            DropTable("dbo.WishlistModels");
            DropTable("dbo.Users");
            DropTable("dbo.Tokens");
            DropTable("dbo.ReqProductModels");
            DropTable("dbo.FeedbackModels");
            DropTable("dbo.Customers");
            DropTable("dbo.CategoryModels");
            DropTable("dbo.ProductModels");
            DropTable("dbo.CartModels");
        }
    }
}
