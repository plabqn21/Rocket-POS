namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyPatientAndDoctorTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "DoctorCode", c => c.Int());
            AddColumn("dbo.Patients", "PatientCode", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "PatientCode");
            DropColumn("dbo.Doctors", "DoctorCode");
        }
    }
}
