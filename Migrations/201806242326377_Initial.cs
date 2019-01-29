namespace ProjetJB2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumGroup = c.Int(nullable: false),
                        ProjectId = c.Int(),
                        StudentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.ProjectId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        TeacherId = c.Int(),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Steps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Rate = c.Int(),
                        Notable = c.Boolean(nullable: false),
                        ProjectId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        State = c.Boolean(nullable: false),
                        ProjectId = c.Int(),
                        StudentId = c.Int(),
                        StepId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .ForeignKey("dbo.Steps", t => t.StepId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.ProjectId)
                .Index(t => t.StudentId)
                .Index(t => t.StepId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Tasks", "StepId", "dbo.Steps");
            DropForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Steps", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Groups", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Groups", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Tasks", new[] { "StepId" });
            DropIndex("dbo.Tasks", new[] { "StudentId" });
            DropIndex("dbo.Tasks", new[] { "ProjectId" });
            DropIndex("dbo.Steps", new[] { "ProjectId" });
            DropIndex("dbo.Projects", new[] { "TeacherId" });
            DropIndex("dbo.Groups", new[] { "StudentId" });
            DropIndex("dbo.Groups", new[] { "ProjectId" });
            DropTable("dbo.Tasks");
            DropTable("dbo.Steps");
            DropTable("dbo.Students");
            DropTable("dbo.Teachers");
            DropTable("dbo.Projects");
            DropTable("dbo.Groups");
        }
    }
}
