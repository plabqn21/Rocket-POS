namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InvoiceCheckouts", "PaymentMethod", c => c.String());
            DropColumn("dbo.InvoiceCheckouts", "InvoiceType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InvoiceCheckouts", "InvoiceType", c => c.String());
            DropColumn("dbo.InvoiceCheckouts", "PaymentMethod");
        }
    }
}
