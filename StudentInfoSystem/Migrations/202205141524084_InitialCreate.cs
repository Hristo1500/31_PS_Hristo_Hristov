namespace StudentInfoSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        LastName = c.String(),
                        Faculty = c.String(),
                        Speciality = c.String(),
                        Degree = c.String(),
                        Status = c.String(),
                        FacultyNumber = c.String(),
                        Course = c.Int(nullable: false),
                        Flow = c.Int(nullable: false),
                        Group = c.Int(nullable: false),
                        Photo = c.Binary(),
                    })
                .PrimaryKey(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
