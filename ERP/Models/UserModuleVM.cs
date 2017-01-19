using ERP.Entities;
using ERP.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
  
 

namespace ERP.Models
{
    public class CreateUser
    {

        [System.Web.Mvc.Remote("IsUserExists", "Management", ErrorMessage = "User Name already in use")]
        [Required]
        [EmailAddress]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        [Display(Name = "User Name")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "User Name")]
        public string NameIdentifier { get; set; }

        [Display(Name = "Use Default Password")]
        public bool UseDefaultPassword { get; set; }
        public List<System.Web.Mvc.SelectListItem> AccessTypes { get; set; }
        public List<AssignedModuleVm> AssignedModules { get; set; }
    }
}