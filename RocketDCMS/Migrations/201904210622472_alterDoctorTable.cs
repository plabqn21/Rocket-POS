namespace RamsoftBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterDoctorTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "Type", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "Type");
        }
    }
}
