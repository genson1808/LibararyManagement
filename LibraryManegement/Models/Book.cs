using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryManegement.Models
{
    public class Book
    {
        [Key]
        public long IsBn { get; set; }
        public int Number_of_copies { get; set; }
        public string Book_title { get; set; }
        public double Book_price { get; set; }

        [DataType(DataType.Date)]
        public DateTime Book_of_publictaion { get; set; }
        [ForeignKey("Genres")]
        public long Genres_id { get; set; }
        public Genres Genres { get; set; }

        public ICollection<Author> Authors { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}