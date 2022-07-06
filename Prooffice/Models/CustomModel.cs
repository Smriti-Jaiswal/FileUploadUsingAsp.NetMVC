using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prooffice.Models
{
    public class CustomModel
    {
        public System.Guid transid { get; set; }
        [Display(Name = "Student Name")]
        [Required(ErrorMessage = "Please enter student name.")]
        public string studentname { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please enter address.")]
        public string address { get; set; }
        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Please enter mobile number.")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
           ErrorMessage = "Entered mobile number is not valid.")]
        public string mobile { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter email.")]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
              ErrorMessage = "Please enter a valid email.")]
        public string email { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please enter gender.")]
        public string gender { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Please enter country.")]
        public string country { get; set; }
        [Display(Name = "File")]
        [Required(ErrorMessage = "Please upload a file.")]
        public HttpPostedFileBase fileupload { get; set; }
        public string url { get; set; }
    }

    public class TableModel
    {
        public System.Guid transid { get; set; }
        [Display(Name = "Student Name")]
        [Required(ErrorMessage = "Please enter student name.")]
        public string studentname { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please enter address.")]
        public string address { get; set; }
        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Please enter mobile number.")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
           ErrorMessage = "Entered mobile number is not valid.")]
        public string mobile { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter email.")]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
              ErrorMessage = "Please enter a valid email.")]
        public string email { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please enter gender.")]
        public string gender { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Please enter country.")]
        public string country { get; set; }
        [Display(Name = "File")]
        [Required(ErrorMessage = "Please upload a file.")]
        public string fileupload { get; set; }

    }
    public class chklist
    {
        public bool checkbox { get; set; }
    }

    public class chkall
    { 
        public string name { get; set; }
        public List<chklist> test { get; set; }
    }

    public class parent
    {
        public List<chkall> demo { get; set; }
    }
}