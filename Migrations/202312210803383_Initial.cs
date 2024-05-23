namespace OnlineStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FavouriteHorses",
                c => new
                    {
                        FavouriteHorseId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        HorseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FavouriteHorseId)
                .ForeignKey("dbo.Horses", t => t.HorseId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.HorseId);
            
            CreateTable(
                "dbo.Horses",
                c => new
                    {
                        HorseId = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        Brand = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.HorseId);
            
            CreateTable(
                "dbo.HorseReviews",
                c => new
                    {
                        HorseReviewId = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        HorseId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HorseReviewId)
                .ForeignKey("dbo.Horses", t => t.HorseId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.HorseId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        ImagePath = c.String(),
                        Address = c.String(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        OrderItemId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        HorseId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderItemId)
                .ForeignKey("dbo.Horses", t => t.HorseId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.HorseId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        ShoppingCartId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        HorseId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShoppingCartId)
                .ForeignKey("dbo.Horses", t => t.HorseId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.HorseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "UserId", "dbo.Users");
            DropForeignKey("dbo.ShoppingCarts", "HorseId", "dbo.Horses");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "HorseId", "dbo.Horses");
            DropForeignKey("dbo.HorseReviews", "UserId", "dbo.Users");
            DropForeignKey("dbo.FavouriteHorses", "UserId", "dbo.Users");
            DropForeignKey("dbo.HorseReviews", "HorseId", "dbo.Horses");
            DropForeignKey("dbo.FavouriteHorses", "HorseId", "dbo.Horses");
            DropIndex("dbo.ShoppingCarts", new[] { "HorseId" });
            DropIndex("dbo.ShoppingCarts", new[] { "UserId" });
            DropIndex("dbo.OrderItems", new[] { "HorseId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.HorseReviews", new[] { "UserId" });
            DropIndex("dbo.HorseReviews", new[] { "HorseId" });
            DropIndex("dbo.FavouriteHorses", new[] { "HorseId" });
            DropIndex("dbo.FavouriteHorses", new[] { "UserId" });
            DropTable("dbo.ShoppingCarts");
            DropTable("dbo.Roles");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Orders");
            DropTable("dbo.Users");
            DropTable("dbo.HorseReviews");
            DropTable("dbo.Horses");
            DropTable("dbo.FavouriteHorses");
        }
    }
}
