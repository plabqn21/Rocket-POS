namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyDoctorT2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "OldPatientFeeDuration", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "OldPatientFeeDuration");
        }
    }
}
