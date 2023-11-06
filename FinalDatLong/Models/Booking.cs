namespace FinalDatLong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string IDPartient { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string IDDoctor { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime Datetime { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual Partient Partient { get; set; }
    }
}
