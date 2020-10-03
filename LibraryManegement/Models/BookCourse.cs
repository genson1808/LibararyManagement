using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryManegement.Models
{
    public class BookCourse
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Book")]
        public long Book_id { get; set; }

        [ForeignKey("Course")]
        public long Course_id { get; set; }

        public virtual Book Book { get; set; }

        public virtual Course Course { get; set; }
    }
}