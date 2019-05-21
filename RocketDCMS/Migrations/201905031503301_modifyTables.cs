namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tests", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Tests", "TestViewModel_Id", c => c.Guid());
            AddColumn("dbo.Specimen", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Specimen", "SpecimenViewModel_Id", c => c.Guid());
            AddColumn("dbo.Units", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Units", "UnitViewModel_Id", c => c.Guid());
            CreateIndex("dbo.Tests", "TestViewModel_Id");
            CreateIndex("dbo.Specimen", "SpecimenViewModel_Id");
            CreateIndex("dbo.Units", "UnitViewModel_Id");
            AddForeignKey("dbo.Specimen", "SpecimenViewModel_Id", "dbo.Specimen", "Id");
            AddForeignKey("dbo.Units", "UnitViewModel_Id", "dbo.Units", "Id");
            AddForeignKey("dbo.Tests", "TestViewModel_Id", "dbo.Tests", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tests", "TestViewModel_Id", "dbo.Tests");
            DropForeignKey("dbo.Units", "UnitViewModel_Id", "dbo.Units");
            DropForeignKey("dbo.Specimen", "SpecimenViewModel_Id", "dbo.Specimen");
            DropIndex("dbo.Units", new[] { "UnitViewModel_Id" });
            DropIndex("dbo.Specimen", new[] { "SpecimenViewModel_Id" });
            DropIndex("dbo.Tests", new[] { "TestViewModel_Id" });
            DropColumn("dbo.Units", "UnitViewModel_Id");
            DropColumn("dbo.Units", "Discriminator");
            DropColumn("dbo.Specimen", "SpecimenViewModel_Id");
            DropColumn("dbo.Specimen", "Discriminator");
            DropColumn("dbo.Tests", "TestViewModel_Id");
            DropColumn("dbo.Tests", "Discriminator");
        }
    }
}
