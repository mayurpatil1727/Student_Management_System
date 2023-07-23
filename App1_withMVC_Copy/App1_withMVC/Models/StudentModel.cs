using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App1_withMVC.Models
{
    public class StudentModel
    {
        [Key]
        public int StudentID { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        [DisplayName("Email ID")]
        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression("^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$", ErrorMessage = "Follow proper mailing convention")]
        public string StudentEmail { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(20, ErrorMessage = "Must be between 6 and 20 characters", MinimumLength = 6)]

        public string StudentPassword { get; set; }

        [DisplayName("Security Question")]
        [Required(ErrorMessage = "Security Question is required.")]
        public string Sque { get; set; }

        [DisplayName("Security Answer")]
        [Required(ErrorMessage = "Security answer is required.")]
        public string Sans { get; set; }

        [DisplayName("Qualification")]
        [Required(ErrorMessage = "Qualification is required.")]
        public string Qualification { get; set; }

        [DisplayName("Institute Name")]
        [Required(ErrorMessage = "Institute Name is required.")]
        public string InstName { get; set; }


        [DisplayName("Passing year")]
        [Required(ErrorMessage = "Passing year is required.")]
        [Range(2015, 2023)]
        public int PassYear { get; set; }

        [DisplayName("Score")]
        [Required(ErrorMessage = "Score is required.")]
        [Range(60, 100) ]
        public int Score { get; set; }
        public List<StudentModel> lststud { get; set; }
    }
}
