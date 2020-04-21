using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketModel;


namespace SuperMarketIDAL.SuperMarketCashier
{
    public interface ISuperMarketMemberServer
    {
        SMMembers GetMembersById(int id);
    }
}
