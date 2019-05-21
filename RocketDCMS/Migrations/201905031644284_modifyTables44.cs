namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTables44 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Specimen", "SpecimenCode", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Specimen", "SpecimenCode", c => c.Int(nullable: false));
        }
    }
}
