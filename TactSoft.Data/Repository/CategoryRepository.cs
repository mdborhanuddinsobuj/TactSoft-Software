using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TactSoft.Core.Interface;
using TactSoft.Core.Model;
using TactSoft.Data.Data;
using TactSoft.Data.Repository.Base;

namespace TactSoft.Data.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDb _db;
        public CategoryRepository(ApplicationDb db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<Category> GetAll(int categoryId)
        {
            if (categoryId == 0)
                return All();
            return All().Where(x => x.Id==categoryId);
        }

        public IEnumerable<SelectListItem> GetAllCategoryForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text=x.CategoryName,
                Value=x.Id.ToString()
            });
        }
    }
}
