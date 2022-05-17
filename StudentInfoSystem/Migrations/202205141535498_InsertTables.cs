namespace StudentInfoSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        LogId = c.Int(nullable: false, identity: true),
                        LogContent = c.String(),
                    })
                .PrimaryKey(t => t.LogId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        userName = c.String(),
                        password = c.String(),
                        facNumber = c.String(),
                        role = c.Int(nullable: false),
                        created = c.DateTime(nullable: false),
                        activeUntil = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Logs");
        }
    }
}
