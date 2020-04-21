using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketIBLL;
using SuperMarketIDAL;
using SuperMarketDAL;
using SuperMarketModel;

namespace SuperMarketBLL.SuperMarketCashier
{
    public class SuperMarketSaleManager : SuperMarketIBLL.SuperMarketCashier.IISuperMarketSaleManager
    {
        SuperMarketIDAL.SuperMarketCashier.IISuperMarketSaleServer saleServer=new SuperMarketDAL.SuperMarketCashier.SuperMarketSaleServer();

        public DateTime GetSysTime()
        {
            return saleServer.GetSysTime();
        }

        public SalePerson SaleLogin(SalePerson person)
        {
            return saleServer.SaleLogin(person);
        }

        public bool WriteSalesExitLog(int logid)
        {
            if (saleServer.WriteSalesExitLog(logid) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int WriteSalesLog(LoginLogs logs)
        {
            return saleServer.WriteSalesLog(logs);
        }
    }
}
