namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyItemTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemCatagories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Code = c.Int(),
                        Details = c.String(),
                        TransactionMethod = c.String(maxLength: 100),
                        BranchId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Code = c.Int(),
                        Details = c.String(),
                        ItemCatagoryId = c.Guid(),
                        ItemSubCatagoryId = c.Guid(),
                        ItemUnitId = c.Guid(),
                        SupplierId = c.Guid(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        BranchId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.ItemCatagories", t => t.ItemCatagoryId)
                .ForeignKey("dbo.ItemSubCatagories", t => t.ItemSubCatagoryId)
                .ForeignKey("dbo.ItemUnits", t => t.ItemUnitId)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId)
                .Index(t => t.ItemCatagoryId)
                .Index(t => t.ItemSubCatagoryId)
                .Index(t => t.ItemUnitId)
                .Index(t => t.SupplierId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.ItemSubCatagories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Code = c.Int(),
                        Details = c.String(),
                        ItemCatagoryId = c.Guid(),
                        BranchId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.ItemCatagories", t => t.ItemCatagoryId)
                .Index(t => t.ItemCatagoryId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.ItemUnits",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Code = c.Int(),
                        CompanyName = c.String(nullable: false, maxLength: 100),
                        Account = c.String(maxLength: 200),
                        Address = c.String(maxLength: 200),
                        MobileNumber = c.String(maxLength: 20),
                        Email = c.String(maxLength: 100),
                        Remarks = c.String(maxLength: 200),
                        BranchId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .Index(t => t.BranchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Suppliers", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Items", "ItemUnitId", "dbo.ItemUnits");
            DropForeignKey("dbo.Items", "ItemSubCatagoryId", "dbo.ItemSubCatagories");
            DropForeignKey("dbo.ItemSubCatagories", "ItemCatagoryId", "dbo.ItemCatagories");
            DropForeignKey("dbo.ItemSubCatagories", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Items", "ItemCatagoryId", "dbo.ItemCatagories");
            DropForeignKey("dbo.Items", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.ItemCatagories", "BranchId", "dbo.Branches");
            DropIndex("dbo.Suppliers", new[] { "BranchId" });
            DropIndex("dbo.ItemSubCatagories", new[] { "BranchId" });
            DropIndex("dbo.ItemSubCatagories", new[] { "ItemCatagoryId" });
            DropIndex("dbo.Items", new[] { "BranchId" });
            DropIndex("dbo.Items", new[] { "SupplierId" });
            DropIndex("dbo.Items", new[] { "ItemUnitId" });
            DropIndex("dbo.Items", new[] { "ItemSubCatagoryId" });
            DropIndex("dbo.Items", new[] { "ItemCatagoryId" });
            DropIndex("dbo.ItemCatagories", new[] { "BranchId" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.ItemUnits");
            DropTable("dbo.ItemSubCatagories");
            DropTable("dbo.Items");
            DropTable("dbo.ItemCatagories");
        }
    }
}
