namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InvoiceCheckouts", "TotalPayable", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InvoiceCheckouts", "TotalPayable");
        }
    }
}
