namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTestTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TestName = c.String(nullable: false, maxLength: 100),
                        TestCode = c.Int(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        DepartmentId = c.Guid(),
                        SpecimenId = c.Guid(),
                        Remarks = c.String(maxLength: 100),
                        ReferenceValue = c.Decimal(precision: 18, scale: 2),
                        UnitId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Specimen", t => t.SpecimenId)
                .ForeignKey("dbo.Units", t => t.UnitId)
                .Index(t => t.DepartmentId)
                .Index(t => t.SpecimenId)
                .Index(t => t.UnitId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tests", "UnitId", "dbo.Units");
            DropForeignKey("dbo.Tests", "SpecimenId", "dbo.Specimen");
            DropForeignKey("dbo.Tests", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Tests", new[] { "UnitId" });
            DropIndex("dbo.Tests", new[] { "SpecimenId" });
            DropIndex("dbo.Tests", new[] { "DepartmentId" });
            DropTable("dbo.Tests");
        }
    }
}
