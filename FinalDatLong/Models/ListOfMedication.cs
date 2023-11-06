namespace FinalDatLong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ListOfMedication
    {
        [Key]
        [StringLength(20)]
        public string IDTreatment { get; set; }

        [StringLength(255)]
        public string medicine { get; set; }

        public string Description { get; set; }

        public virtual Treatment Treatment { get; set; }
    }
}
