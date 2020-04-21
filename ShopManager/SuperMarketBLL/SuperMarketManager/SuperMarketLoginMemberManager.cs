using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketModel;
using SuperMarketDAL;

namespace SuperMarketBLL.SuperMarketManager
{
    public class SuperMarketLoginMemberManager : SuperMarketIBLL.SuperMarketManager.ISuperMarketLoginMemberManager
    {
        SuperMarketIDAL.SuperMarketManager.ISuperMarketLoginMemberServer server = new SuperMarketDAL.SuperMarketManager.SuperMarketLoginMemberServer();
        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="where"></param>
        /// <param name="check"></param>
        /// <returns></returns>
        public List<LoginLogs> GetLoginLogBy(DateTime startTime, DateTime endTime, string where, int check)
        {
            return server.GetLoginLogBy(startTime, endTime, where, check);
        }

        /// <summary>
        /// 日志查询
        /// </summary>
        /// <returns></returns>
        public List<LoginLogs> GetLoginLogs()
        {
            return server.GetLoginLogs();
        }
    }
}
