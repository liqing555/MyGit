using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketIBLL.SuperMarketCashier;
using SuperMarketModel;
using SuperMarketDAL.SuperMarketCashier;
using SuperMarketIDAL.SuperMarketCashier;

namespace SuperMarketBLL.SuperMarketCashier
{
    public class SuperMarketProductManager : ISuperMarketProductManager
    {
        ISuperMarketProductServer server = new SuperMarketProductServer();
        public Produts GetProductWithId(string productId)
        {
            return server.GetProductWithId(productId);
        }

        public bool SaveSalerInfo(SalesList sales, SMMembers members)
        {
            return server.SaveSalerInfo(sales, members);
        }
    }
}
