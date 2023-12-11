namespace FinalDatLong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Patient")]
    public partial class Patient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patient()
        {
            Appointment = new HashSet<Appointment>();
            Booking = new HashSet<Booking>();
            Feedback = new HashSet<Feedback>();
            Treatment = new HashSet<Treatment>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDPatient { get; set; }


        [Required(ErrorMessage = "Tài khoản không được đỡ trống")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mật khẩu kông được để trống")]
        [StringLength(255, ErrorMessage = " Mật Khẩu từ 8 đến 255 kí tự ", MinimumLength = 8)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$",
     ErrorMessage = "Mật khẩu tối thiểu tám ký tự, ít nhất một chữ hoa, một chữ thường, một số và một ký tự đặc biệt")]
        public string Password { get; set; }


        [NotMapped]
        //[Compare("Password")]
        public string MatKhauNL { get; set; }

        [StringLength(255)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = " Số điện thoại không đúng , không vượt quá 11 số ", MinimumLength = 11)]

        public string PhoneNumber { get; set; }
    

        public string Avatar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment> Appointment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Booking { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedback { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Treatment> Treatment { get; set; }
    }
}
