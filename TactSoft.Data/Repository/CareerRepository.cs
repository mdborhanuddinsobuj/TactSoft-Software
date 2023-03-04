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
	public class CareerRepository:BaseRepository<CareerModel>,ICareerRepository
	{
        private readonly ApplicationDb _db;
        public CareerRepository(ApplicationDb db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<CareerModel> GetAll(int careerId)
        {
            if (careerId == 0)
                return All();
            return All().Where(x => x.Id == careerId);
        }
    }
}
