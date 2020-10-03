using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManegement.Models
{
    public class Pupils
    {
        [Key]
        public long Id { get; set; }
        public string Author_first_name { get; set; }
        public string Author_middle_name { get; set; }
        public string Author_last_name { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public string Phone_number { get; set; }
        public string Email { get; set; }

    }

    public enum Gender
    {
        male,
        female,
        other
    }
}