namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modify : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InvoiceCheckouts", "Discount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InvoiceCheckouts", "Discount", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
