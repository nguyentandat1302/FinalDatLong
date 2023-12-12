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

        private string _feedback1;

        [Column("Feedback")]
        [StringLength(255)]
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string Feedback1
        {
            get { return _feedback1; }
            set
            {
                // Thực hiện kiểm tra lỗi spam ở đây
                if (IsSpam(value))
                {
                    throw new ArgumentException("Nội dung phản hồi chứa lời không cho phép.");
                }

                _feedback1 = value;
            }
        }

        private bool IsSpam(string text)
        {
            // Thực hiện kiểm tra lời không cho phép ở đây
            // Ví dụ: kiểm tra từ khóa, cấu trúc lời nội dung, etc.

            // Return true nếu có lỗi spam, ngược lại return false
            return false;
        }
        //Feedback1 la comment a
        [Range(1,5, ErrorMessage = "Phai chon rating")] // Sua model phai addmigrae => updatedatavase
        public int Rating { get; set; }
      
        public virtual Patient Patient { get; set; }
    }
}
