namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyTestTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tests", "ReferenceValueMale", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Tests", "ReferenceValueFeMale", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Tests", "ReferenceValueChildren", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Tests", "ReferenceValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tests", "ReferenceValue", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Tests", "ReferenceValueChildren");
            DropColumn("dbo.Tests", "ReferenceValueFeMale");
            DropColumn("dbo.Tests", "ReferenceValueMale");
        }
    }
}
