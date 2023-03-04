using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TactSoft.Core.Model.Base;

namespace TactSoft.Core.Model
{
    public class NoticePeriod:BaseModel
    {
        [Required]
        public string NoticeName { get; set; }
        public ICollection<CareerModel> CareerModels { get; set; }

    }
}
