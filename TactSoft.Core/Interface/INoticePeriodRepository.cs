using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TactSoft.Core.Interface.Base;
using TactSoft.Core.Model;

namespace TactSoft.Core.Interface
{
    public interface INoticePeriodRepository:IBaseRepository<NoticePeriod>
    {
        IEnumerable<NoticePeriod> GetAll(int noticeId);
        IEnumerable<SelectListItem> GetAllNoticePeriodForDropDown();
    }
}
