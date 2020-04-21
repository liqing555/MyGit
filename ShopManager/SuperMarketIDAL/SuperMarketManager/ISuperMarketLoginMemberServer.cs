using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketModel;

namespace SuperMarketIDAL.SuperMarketManager
{
    public interface ISuperMarketLoginMemberServer
    {
        /// <summary>
        /// 查询日志
        /// </summary>
        /// <returns></returns>
        List<LoginLogs> GetLoginLogs();
        /// <summary>
        /// 根据条件查询日志
        /// </summary>
        /// <returns></returns>
        List<LoginLogs> GetLoginLogBy(DateTime startTime, DateTime endTime, string where, int check);
    }
}
