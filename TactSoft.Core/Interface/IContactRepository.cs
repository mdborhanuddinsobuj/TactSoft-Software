using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TactSoft.Core.Interface.Base;
using TactSoft.Core.Model;
using TactSoft.Core.Model.Base;

namespace TactSoft.Core.Interface
{
    public interface IContactRepository:IBaseRepository<ContactModel>
    {
        IEnumerable<ContactModel> GetAll(int contactId);
    }
}
