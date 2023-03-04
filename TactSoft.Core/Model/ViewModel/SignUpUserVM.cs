using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TactSoft.Core.Model.Base;

namespace TactSoft.Core.Model.ViewModel
{
    public class SignUpUserVM:BaseModel
    {
        [Required(ErrorMessage = "Please Enter UserName"), Display(Name = "User Name")]
        [Remote(action: "userNameIsExist", controller: "Account")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        //[RegularExpression(@"^[a - z0 - 9][-a - z0 - 9._] +@([-a - z0 - 9] +.) +[a - z]{2, 5}$]", ErrorMessage = "Invalid Email....")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Phone Number")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]

        public string Password { get; set; }
        [Compare("Password")]
        [Required(ErrorMessage = "ConfirmPassword can't Match !!!")]
        public string ConfirmPassword { get; set; }
    }
}
