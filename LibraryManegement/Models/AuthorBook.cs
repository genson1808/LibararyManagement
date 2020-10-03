using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryManegement.Models
{
    public class AuthorBook
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Book")]
        public long Book_id { get; set; }

        [ForeignKey("Author")]
        public long Author_id { get; set; }

        public virtual Book Book { get; set; }
        public virtual Author Author { get; set; }
    }
}