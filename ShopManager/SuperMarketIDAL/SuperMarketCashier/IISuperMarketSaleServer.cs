using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketModel;

namespace SuperMarketIDAL.SuperMarketCashier
{
    public interface IISuperMarketSaleServer
    {
        SalePerson SaleLogin(SalePerson person);
        int WriteSalesLog(LoginLogs logs);
        int WriteSalesExitLog(int logid);
        DateTime GetSysTime();
    }
}
