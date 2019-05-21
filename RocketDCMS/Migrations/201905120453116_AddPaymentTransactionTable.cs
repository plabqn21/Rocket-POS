namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPaymentTransactionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaymentTransactions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Doctor_Id = c.Guid(),
                        Patient_Id = c.Guid(),
                        OrderNumber = c.Long(nullable: false),
                        Branch_Id = c.Guid(),
                        PaymentDate = c.DateTime(),
                        Transtype = c.String(maxLength: 20),
                        TransAmount = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PaymentTransactions");
        }
    }
}
