using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManegement.Models
{
    public class Author
    {
        [Key]
        public long Id { get; set; }
        public string Author_first_name { get; set; }
        public string Author_middle_name { get; set; }
        public string Author_last_name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}