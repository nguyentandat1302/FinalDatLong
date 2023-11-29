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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDFeedback { get; set; }

        public int? IDPatient { get; set; }

        [Column("Feedback")]
        [StringLength(255)]
        public string Feedback1 { get; set; }

        public int Rating { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
