namespace LibraryManegement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.AuthorBooks");
            DropPrimaryKey("dbo.BookCourses");
            DropPrimaryKey("dbo.PupilsOnCourses");
            AddColumn("dbo.AuthorBooks", "Id", c => c.Long(nullable: false, identity: true));
            AddColumn("dbo.BookCourses", "Id", c => c.Long(nullable: false, identity: true));
            AddColumn("dbo.PupilsOnCourses", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.AuthorBooks", "Id");
            AddPrimaryKey("dbo.BookCourses", "Id");
            AddPrimaryKey("dbo.PupilsOnCourses", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PupilsOnCourses");
            DropPrimaryKey("dbo.BookCourses");
            DropPrimaryKey("dbo.AuthorBooks");
            DropColumn("dbo.PupilsOnCourses", "Id");
            DropColumn("dbo.BookCourses", "Id");
            DropColumn("dbo.AuthorBooks", "Id");
            AddPrimaryKey("dbo.PupilsOnCourses", new[] { "Pupils_id", "Course_id" });
            AddPrimaryKey("dbo.BookCourses", new[] { "Book_id", "Course_id" });
            AddPrimaryKey("dbo.AuthorBooks", new[] { "Book_id", "Author_id" });
        }
    }
}
