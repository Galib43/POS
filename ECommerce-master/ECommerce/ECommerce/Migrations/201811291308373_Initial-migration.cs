namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ProductVerifieds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        AdminUserId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Ip = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdminUsers", t => t.ProductId, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.AdminUserId, cascadeDelete: false)
                .Index(t => t.ProductId)
                .Index(t => t.AdminUserId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        BrandId = c.Int(nullable: false),
                        ConditionId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        RegularPrice = c.Double(nullable: false),
                        OfferPrice = c.Double(),
                        Negotiable = c.Boolean(),
                        Links = c.String(),
                        Video = c.String(),
                        CreateDate = c.DateTime(),
                        Ip = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Conditions", t => t.ConditionId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.BrandId)
                .Index(t => t.CategoryId)
                .Index(t => t.ConditionId);
            
            CreateTable(
                "dbo.Archieves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(),
                        UserId = c.Int(nullable: false),
                        DateTime = c.DateTime(),
                        Ip = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Contact = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(nullable: false),
                        Gender = c.Boolean(),
                        JoinDate = c.DateTime(nullable: false),
                        Ip = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Address = c.String(nullable: false),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NAME = c.String(nullable: false),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        DateTime = c.DateTime(),
                        Ip = c.String(),
                        Comment1 = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.LogInHistories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Ip = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        DateTime = c.DateTime(),
                        Ip = c.String(),
                        message1 = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ProductLikes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Ip = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ProductRatings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Ip = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserVerifieds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Ip = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Origin = c.String(nullable: false),
                        Description = c.String(nullable: false, maxLength: 2000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Conditions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductCloses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        ClosingTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CloseTypes", t => t.ClosingTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ClosingTypeId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.CloseTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Decription = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Image = c.String(nullable: false),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.LoginModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(),
                        RememberMe = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductVerifieds", "AdminUserId", "dbo.Products");
            DropForeignKey("dbo.ProductImages", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductCloses", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductCloses", "ClosingTypeId", "dbo.CloseTypes");
            DropForeignKey("dbo.Products", "ConditionId", "dbo.Conditions");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.UserVerifieds", "UserId", "dbo.Users");
            DropForeignKey("dbo.Products", "UserId", "dbo.Users");
            DropForeignKey("dbo.ProductRatings", "UserId", "dbo.Users");
            DropForeignKey("dbo.ProductRatings", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductLikes", "UserId", "dbo.Users");
            DropForeignKey("dbo.ProductLikes", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Messages", "UserId", "dbo.Users");
            DropForeignKey("dbo.Messages", "ProductId", "dbo.Products");
            DropForeignKey("dbo.LogInHistories", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Users", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Archieves", "UserId", "dbo.Users");
            DropForeignKey("dbo.AdminUsers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Archieves", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductVerifieds", "ProductId", "dbo.AdminUsers");
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.ProductVerifieds", new[] { "AdminUserId" });
            DropIndex("dbo.ProductImages", new[] { "ProductId" });
            DropIndex("dbo.ProductCloses", new[] { "ProductId" });
            DropIndex("dbo.ProductCloses", new[] { "ClosingTypeId" });
            DropIndex("dbo.Products", new[] { "ConditionId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Categories", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropIndex("dbo.UserVerifieds", new[] { "UserId" });
            DropIndex("dbo.Products", new[] { "UserId" });
            DropIndex("dbo.ProductRatings", new[] { "UserId" });
            DropIndex("dbo.ProductRatings", new[] { "ProductId" });
            DropIndex("dbo.ProductLikes", new[] { "UserId" });
            DropIndex("dbo.ProductLikes", new[] { "ProductId" });
            DropIndex("dbo.Messages", new[] { "UserId" });
            DropIndex("dbo.Messages", new[] { "ProductId" });
            DropIndex("dbo.LogInHistories", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "ProductId" });
            DropIndex("dbo.Users", new[] { "CityId" });
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropIndex("dbo.Archieves", new[] { "UserId" });
            DropIndex("dbo.AdminUsers", new[] { "UserId" });
            DropIndex("dbo.Archieves", new[] { "ProductId" });
            DropIndex("dbo.ProductVerifieds", new[] { "ProductId" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.LoginModels");
            DropTable("dbo.ProductImages");
            DropTable("dbo.CloseTypes");
            DropTable("dbo.ProductCloses");
            DropTable("dbo.Conditions");
            DropTable("dbo.Categories");
            DropTable("dbo.Brands");
            DropTable("dbo.UserVerifieds");
            DropTable("dbo.ProductRatings");
            DropTable("dbo.ProductLikes");
            DropTable("dbo.Messages");
            DropTable("dbo.LogInHistories");
            DropTable("dbo.Comments");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Users");
            DropTable("dbo.Archieves");
            DropTable("dbo.Products");
            DropTable("dbo.ProductVerifieds");
            DropTable("dbo.AdminUsers");
        }
    }
}
