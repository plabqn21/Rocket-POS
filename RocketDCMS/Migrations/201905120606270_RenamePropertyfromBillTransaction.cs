namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamePropertyfromBillTransaction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BillTransactions", "BillDate", c => c.DateTime());
            AddColumn("dbo.BillTransactions", "BillAmount", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.BillTransactions", "PaymentDate");
            DropColumn("dbo.BillTransactions", "TransAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BillTransactions", "TransAmount", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.BillTransactions", "PaymentDate", c => c.DateTime());
            DropColumn("dbo.BillTransactions", "BillAmount");
            DropColumn("dbo.BillTransactions", "BillDate");
        }
    }
}
