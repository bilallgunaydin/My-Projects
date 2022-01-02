namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LastMigration : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Lesson", name: "Teacher_ID", newName: "TeacherID");
            RenameIndex(table: "dbo.Lesson", name: "IX_Teacher_ID", newName: "IX_TeacherID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Lesson", name: "IX_TeacherID", newName: "IX_Teacher_ID");
            RenameColumn(table: "dbo.Lesson", name: "TeacherID", newName: "Teacher_ID");
        }
    }
}
