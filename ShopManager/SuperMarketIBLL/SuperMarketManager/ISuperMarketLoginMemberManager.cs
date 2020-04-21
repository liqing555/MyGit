using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketModel;

namespace SuperMarketIBLL.SuperMarketManager
{
    public interface ISuperMarketLoginMemberManager
    {
        List<LoginLogs> GetLoginLogs();
        List<LoginLogs> GetLoginLogBy(DateTime startTime, DateTime endTime, string where, int check);
    }
}
