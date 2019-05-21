namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyDoctorT : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "NewPatientFee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Doctors", "OldPatientFee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "OldPatientFee");
            DropColumn("dbo.Doctors", "NewPatientFee");
        }
    }
}
