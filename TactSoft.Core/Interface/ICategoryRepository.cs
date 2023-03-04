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
    public interface ICategoryRepository:IBaseRepository<Category>
    {
        IEnumerable<Category> GetAll(int categoryId);
        IEnumerable<SelectListItem> GetAllCategoryForDropDown();
    }
}
