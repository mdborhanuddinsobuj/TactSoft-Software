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
    public class ContactRepository : BaseRepository<ContactModel>, IContactRepository
    {
        public ContactRepository(ApplicationDb db) : base(db)
        {
        }

        public IEnumerable<ContactModel> GetAll(int contactId)
        {
            if(contactId==0)
            return All();
            return All().Where(x => x.Id == contactId);
        }
    }
}
