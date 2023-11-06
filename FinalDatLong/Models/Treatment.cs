namespace FinalDatLong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Treatment")]
    public partial class Treatment
    {
        [Key]
        [StringLength(20)]
        public string IDTreatment { get; set; }

        [StringLength(20)]
        public string IDDoctor { get; set; }

        [StringLength(20)]
        public string IDPartient { get; set; }

        public string Description { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual Partient Partient { get; set; }

        public virtual ListOfMedication ListOfMedication { get; set; }
    }
}
