using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalDatLong.Models
{
    [Table("Medicine")]
    public class Medicine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int IDMedicine { get; set; }
        [Required]
        public string NameMidecine { get; set; }

        public string Type { get; set;}

    }
}