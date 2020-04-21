using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketIBLL.SuperMarketCashier;
using SuperMarketIDAL.SuperMarketCashier;
using SuperMarketDAL.SuperMarketCashier;
using SuperMarketModel;

namespace SuperMarketBLL.SuperMarketCashier
{
    public class SuperMarketMemberManager : ISuperMarketMemberManager
    {
        ISuperMarketMemberServer server = new SuperMarketMemberServer();
        public SMMembers GetMembersById(int id)
        {
            return server.GetMembersById(id);
        }
    }
}
