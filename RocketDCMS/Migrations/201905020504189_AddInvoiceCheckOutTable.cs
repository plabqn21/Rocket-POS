namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInvoiceCheckOutTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvoiceCheckouts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Doctor_Id = c.Guid(),
                        Patient_Id = c.Guid(),
                        OrderNumber = c.Long(),
                        Branch_Id = c.Guid(),
                        Bill_Generator = c.Guid(),
                        InvoiceDate = c.DateTime(),
                        PaymentMode = c.String(),
                        InvoiceType = c.String(),
                        TotalBill = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        SampleReceiveDate = c.DateTime(),
                        SampleReceiveTime = c.String(),
                        IsCorporateCustomer = c.String(),
                        ReferelLabId = c.Guid(),
                        Remarks = c.String(),
                        ReportDeliveryDate = c.DateTime(),
                        ReportDeliveryTime = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReferelLabs", t => t.ReferelLabId)
                .Index(t => t.ReferelLabId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceCheckouts", "ReferelLabId", "dbo.ReferelLabs");
            DropIndex("dbo.InvoiceCheckouts", new[] { "ReferelLabId" });
            DropTable("dbo.InvoiceCheckouts");
        }
    }
}
