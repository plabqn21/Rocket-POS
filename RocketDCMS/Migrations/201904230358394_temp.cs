namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class temp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Doctors", "DoctorViewModel_Id", c => c.Guid());
            CreateIndex("dbo.Doctors", "DoctorViewModel_Id");
            AddForeignKey("dbo.Doctors", "DoctorViewModel_Id", "dbo.Doctors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "DoctorViewModel_Id", "dbo.Doctors");
            DropIndex("dbo.Doctors", new[] { "DoctorViewModel_Id" });
            DropColumn("dbo.Doctors", "DoctorViewModel_Id");
            DropColumn("dbo.Doctors", "Discriminator");
        }
    }
}
