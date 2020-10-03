using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryManegement.Models
{
    public class PupilsOnCourse
    {

        [Key]
        public long Id { get; set; }

        [ForeignKey("Pupils")]
        public long Pupils_id { get; set; }
        
        public virtual Pupils Pupils { get; set; }

        [ForeignKey("Course")]
        public long Course_id { get; set; }
        public virtual Course Course { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date_from { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date_to { get; set; }
    }
}