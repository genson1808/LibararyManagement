using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryManegement.Models
{
    public class BookBorrowOnLoan
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Book")]
        public long Book_id { get; set; }
        public Book Book { get; set; }

        [ForeignKey("Pupils")]
        public long Pupils_id { get; set; }

        public Pupils Pupils { get; set; }
        public double Fine_paid { get; set; }
        public bool Lost { get; set; }
        public int Overdue { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date_issued { get; set; }
        public int Date_due_to_return { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date_returned { get; set; }
    }
}