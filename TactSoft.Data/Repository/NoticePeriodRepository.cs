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
    public class NoticePeriodRepository : BaseRepository<NoticePeriod>, INoticePeriodRepository
    {
        private readonly ApplicationDb _db;

        public NoticePeriodRepository(ApplicationDb db) : base(db)
        {
            this._db = db;
        }

        public IEnumerable<NoticePeriod> GetAll(int noticeId)
        {
            if (noticeId == 0)
                return All();
            return All().Where(x=>x.Id==noticeId);
        }

        public IEnumerable<SelectListItem> GetAllNoticePeriodForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text=x.NoticeName,
                Value=x.Id.ToString()
            });
        }
    }
}
