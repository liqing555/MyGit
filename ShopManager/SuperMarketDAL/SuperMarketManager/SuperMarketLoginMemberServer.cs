using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketModel;
using System.Data.SqlClient;

namespace SuperMarketDAL.SuperMarketManager
{
     public class SuperMarketLoginMemberServer : SuperMarketIDAL.SuperMarketManager.ISuperMarketLoginMemberServer
    {
        /// <summary>
        /// 根据条件查询日志
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<LoginLogs> GetLoginLogBy(DateTime startTime, DateTime endTime, string where, int check)
        {
            string procName = "GetLoginLogBy";
            SqlParameter[] sp =
             {
                new SqlParameter("@startTime",startTime),
                new SqlParameter("@endTime",endTime),
                new SqlParameter("@where",where),
                new SqlParameter("@check",check)
            };
            List<LoginLogs> logs = new List<LoginLogs>();
            SqlDataReader reader = SQLHelper.GetDataReader(procName, sp);
            while (reader.Read())
            {
                LoginLogs login = new LoginLogs();
                login.LogId = Convert.ToInt32(reader["LogId"]);
                if (string.IsNullOrEmpty(reader["ExitTime"].ToString()))
                {
                    login.ExitTime = null;
                }
                else
                {
                    login.ExitTime = Convert.ToDateTime(reader["ExitTime"]);
                }
                login.LoginId = Convert.ToInt32(reader["LoginId"]);
                login.SPName = reader["SPName"].ToString();
                login.ServerName = reader["ServerName"].ToString();
                login.LoginTime = Convert.ToDateTime(reader["LoginTime"]);
                logs.Add(login);
            }
            reader.Close();
            return logs;
        }

        /// <summary>
        /// 查询日志
        /// </summary>
        /// <returns></returns>
        public List<LoginLogs> GetLoginLogs()
        {
            string procName = "GetLoginLogs";
            SqlDataReader reader = SQLHelper.GetDataReader(procName, null);
            List<LoginLogs> logs = new List<LoginLogs>();
            while (reader.Read())
            {
                LoginLogs login = new LoginLogs();
                login.LogId = Convert.ToInt32(reader["LogId"]);
                if (string.IsNullOrEmpty(reader["ExitTime"].ToString()))
                {
                    login.ExitTime = null;
                }
                else
                {
                    login.ExitTime = Convert.ToDateTime(reader["ExitTime"]);
                }
                login.LoginId = Convert.ToInt32(reader["LoginId"]);
                login.SPName = reader["SPName"].ToString();
                login.ServerName = reader["ServerName"].ToString();
                login.LoginTime = Convert.ToDateTime(reader["LoginTime"]);
                logs.Add(login);
            }
            reader.Close();
            return logs;
        }
    }
}
