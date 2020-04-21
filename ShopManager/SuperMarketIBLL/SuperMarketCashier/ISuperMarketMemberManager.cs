using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketModel;

namespace SuperMarketIBLL.SuperMarketCashier
{
    public interface ISuperMarketMemberManager
    {
        SMMembers GetMembersById(int id);
    }
}
