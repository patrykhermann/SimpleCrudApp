namespace SimpleCrudApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        Position = c.String(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Age = c.Int(nullable: false),
                        Address = c.String(),
                        Code = c.String(),
                        City = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
