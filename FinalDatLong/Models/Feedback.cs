namespace FinalDatLong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedback")]
    public partial class Feedback
    {
        [Key]
        [StringLength(20)]
        public string IDPartient { get; set; }

        [Column("Feedback")]
        public string Feedback1 { get; set; }

        public virtual Partient Partient { get; set; }
    }
}
