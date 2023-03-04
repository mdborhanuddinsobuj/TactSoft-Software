using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TactSoft.Core.Model.Base;

namespace TactSoft.Core.Model
{
    public class CareerModel:BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string University { get; set; }
        public string TotalExperience { get; set; }
        public string ExpertiseArea { get; set; }
        public string CurrentCompany { get; set; }
        public double CurrentSalary { get; set; }
        public double ExpectedSalary { get; set; }
        public string CoverLetter { get; set; }

        public string Resume { get; set; }

        [Required]
        [NotMapped]
        public IFormFile ResumeUrl { get; set; }
        
        [ForeignKey("NoticePeriod")]
        public int NoticePeriodId { get; set; }
        public virtual NoticePeriod NoticePeriod { get; set; }
        [ForeignKey("Category")]
        public  int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
