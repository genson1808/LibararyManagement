namespace LibraryManegement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuthorBooks",
                c => new
                    {
                        Book_id = c.Long(nullable: false),
                        Author_id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_id, t.Author_id })
                .ForeignKey("dbo.Authors", t => t.Author_id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_id, cascadeDelete: true)
                .Index(t => t.Book_id)
                .Index(t => t.Author_id);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Author_first_name = c.String(),
                        Author_middle_name = c.String(),
                        Author_last_name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        IsBn = c.Long(nullable: false, identity: true),
                        Number_of_copies = c.Int(nullable: false),
                        Book_title = c.String(),
                        Book_price = c.Double(nullable: false),
                        Book_of_publictaion = c.DateTime(nullable: false),
                        Genres_id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.IsBn)
                .ForeignKey("dbo.Genres", t => t.Genres_id, cascadeDelete: true)
                .Index(t => t.Genres_id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookBorrowOnLoans",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Book_id = c.Long(nullable: false),
                        Pupils_id = c.Long(nullable: false),
                        Fine_paid = c.Double(nullable: false),
                        Lost = c.Boolean(nullable: false),
                        Overdue = c.Int(nullable: false),
                        Date_issued = c.DateTime(nullable: false),
                        Date_due_to_return = c.Int(nullable: false),
                        Date_returned = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_id, cascadeDelete: true)
                .ForeignKey("dbo.Pupils", t => t.Pupils_id, cascadeDelete: true)
                .Index(t => t.Book_id)
                .Index(t => t.Pupils_id);
            
            CreateTable(
                "dbo.Pupils",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Author_first_name = c.String(),
                        Author_middle_name = c.String(),
                        Author_last_name = c.String(),
                        Gender = c.Int(nullable: false),
                        Address = c.String(),
                        Phone_number = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookCourses",
                c => new
                    {
                        Book_id = c.Long(nullable: false),
                        Course_id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_id, t.Course_id })
                .ForeignKey("dbo.Books", t => t.Book_id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_id, cascadeDelete: true)
                .Index(t => t.Book_id)
                .Index(t => t.Course_id);
            
            CreateTable(
                "dbo.PupilsOnCourses",
                c => new
                    {
                        Pupils_id = c.Long(nullable: false),
                        Course_id = c.Long(nullable: false),
                        Date_from = c.DateTime(nullable: false),
                        Date_to = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pupils_id, t.Course_id })
                .ForeignKey("dbo.Courses", t => t.Course_id, cascadeDelete: true)
                .ForeignKey("dbo.Pupils", t => t.Pupils_id, cascadeDelete: true)
                .Index(t => t.Pupils_id)
                .Index(t => t.Course_id);
            
            CreateTable(
                "dbo.BookAuthors",
                c => new
                    {
                        Book_IsBn = c.Long(nullable: false),
                        Author_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_IsBn, t.Author_Id })
                .ForeignKey("dbo.Books", t => t.Book_IsBn, cascadeDelete: true)
                .ForeignKey("dbo.Authors", t => t.Author_Id, cascadeDelete: true)
                .Index(t => t.Book_IsBn)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.CourseBooks",
                c => new
                    {
                        Course_Id = c.Long(nullable: false),
                        Book_IsBn = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course_Id, t.Book_IsBn })
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_IsBn, cascadeDelete: true)
                .Index(t => t.Course_Id)
                .Index(t => t.Book_IsBn);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PupilsOnCourses", "Pupils_id", "dbo.Pupils");
            DropForeignKey("dbo.PupilsOnCourses", "Course_id", "dbo.Courses");
            DropForeignKey("dbo.BookCourses", "Course_id", "dbo.Courses");
            DropForeignKey("dbo.BookCourses", "Book_id", "dbo.Books");
            DropForeignKey("dbo.BookBorrowOnLoans", "Pupils_id", "dbo.Pupils");
            DropForeignKey("dbo.BookBorrowOnLoans", "Book_id", "dbo.Books");
            DropForeignKey("dbo.AuthorBooks", "Book_id", "dbo.Books");
            DropForeignKey("dbo.AuthorBooks", "Author_id", "dbo.Authors");
            DropForeignKey("dbo.Books", "Genres_id", "dbo.Genres");
            DropForeignKey("dbo.CourseBooks", "Book_IsBn", "dbo.Books");
            DropForeignKey("dbo.CourseBooks", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.BookAuthors", "Author_Id", "dbo.Authors");
            DropForeignKey("dbo.BookAuthors", "Book_IsBn", "dbo.Books");
            DropIndex("dbo.CourseBooks", new[] { "Book_IsBn" });
            DropIndex("dbo.CourseBooks", new[] { "Course_Id" });
            DropIndex("dbo.BookAuthors", new[] { "Author_Id" });
            DropIndex("dbo.BookAuthors", new[] { "Book_IsBn" });
            DropIndex("dbo.PupilsOnCourses", new[] { "Course_id" });
            DropIndex("dbo.PupilsOnCourses", new[] { "Pupils_id" });
            DropIndex("dbo.BookCourses", new[] { "Course_id" });
            DropIndex("dbo.BookCourses", new[] { "Book_id" });
            DropIndex("dbo.BookBorrowOnLoans", new[] { "Pupils_id" });
            DropIndex("dbo.BookBorrowOnLoans", new[] { "Book_id" });
            DropIndex("dbo.Books", new[] { "Genres_id" });
            DropIndex("dbo.AuthorBooks", new[] { "Author_id" });
            DropIndex("dbo.AuthorBooks", new[] { "Book_id" });
            DropTable("dbo.CourseBooks");
            DropTable("dbo.BookAuthors");
            DropTable("dbo.PupilsOnCourses");
            DropTable("dbo.BookCourses");
            DropTable("dbo.Pupils");
            DropTable("dbo.BookBorrowOnLoans");
            DropTable("dbo.Genres");
            DropTable("dbo.Courses");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
            DropTable("dbo.AuthorBooks");
        }
    }
}
