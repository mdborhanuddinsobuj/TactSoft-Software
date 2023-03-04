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
    public class LoginSignUpVM:BaseModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool IsRemember { get; set; }
    }
}
