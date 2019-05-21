namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyPatientTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Patients", "PatientViewModel_Id", c => c.Guid());
            CreateIndex("dbo.Patients", "PatientViewModel_Id");
            AddForeignKey("dbo.Patients", "PatientViewModel_Id", "dbo.Patients", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "PatientViewModel_Id", "dbo.Patients");
            DropIndex("dbo.Patients", new[] { "PatientViewModel_Id" });
            DropColumn("dbo.Patients", "PatientViewModel_Id");
            DropColumn("dbo.Patients", "Discriminator");
        }
    }
}
