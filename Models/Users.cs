using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageDemoProject.Models
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //Unique ID get generated using auto Increment
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        [RegularExpression(@"^[A-Z]{1}[a-z]{2}[a-z]*$", ErrorMessage = "Enter Valid First Name")]
        //First Name
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        [RegularExpression(@"^[A-Z]{1}[a-z]{2}[a-z]*$", ErrorMessage = "Enter Valid Last Name")]
        //Last Name
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9]{2}[a-zA-Z0-9]*[.]{0,1}[a-zA-Z0-9]*@[a-zA-Z0-9]*.{1}[a-zA-Z0-9]*[.]*[a-zA-Z0-9]*)$", ErrorMessage = "Enter Valid Email")]
        //Mail ID
        public string MailID { get; set; }
        [Required(ErrorMessage = "DriverCategory Is Required")]
        [MaxLength(50)]
        //Department
        public string Department { get; set; }
        [Required(ErrorMessage = "Password Is Required")]
        [RegularExpression(@"^.{8,15}$", ErrorMessage = "Password Length should be between 8 to 15")]
        //Password
        public string Password { get; set; }
        //Create date 
        public DateTime CreateDate { get; set; } = DateTime.Now;
        //Modified Date
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

    }
}
