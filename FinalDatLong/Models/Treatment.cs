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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Treatment()
        {
            ListOfMedications = new HashSet<ListOfMedications>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDTreatment { get; set; }

        public int? IDDoctor { get; set; }

        [Required(ErrorMessage = "Trường này không được để trống")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Chỉ được nhập số không được nhập kí tự hoặc chữ cái")]
        public int? IDPatient { get; set; }

        [Required(ErrorMessage = "Trường này không được để trống")]
        [StringLength(255)]
        public string Description { get; set; }
        
        public virtual Doctor Doctor { get; set; }

        [Required(ErrorMessage = "Trường này không được để trống")]
        public string TreatmentDescription { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListOfMedications> ListOfMedications { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
