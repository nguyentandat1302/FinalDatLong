namespace FinalDatLong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ListOfMedications
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDListOfMedications { get; set; }

        public int? IDTreatment { get; set; }

        public int Rating { get; set; }
        [StringLength(255)]
        public string Medicine { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public virtual Treatment Treatment { get; set; }
    }
}
