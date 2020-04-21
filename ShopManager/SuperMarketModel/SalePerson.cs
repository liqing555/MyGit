using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketModel
{
    [Serializable]
    public class SalePerson
    {
        public int SalePersonId { get; set; }
        public string SPName { get; set; }
        public string LoginPwd { get; set; }
        public int LogId { get; set; }
    }
}
