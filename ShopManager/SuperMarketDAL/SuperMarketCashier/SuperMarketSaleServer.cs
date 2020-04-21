using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketIDAL;
using SuperMarketModel;
using System.Data.SqlClient;
using System.Data;

namespace SuperMarketDAL.SuperMarketCashier
{
    /// <summary>
    /// 处理营业员管理
    /// </summary>
    public class SuperMarketSaleServer : SuperMarketIDAL.SuperMarketCashier.IISuperMarketSaleServer
    {
        public DateTime GetSysTime()
        {
            string procName = "GetSysTime";
            return Convert.ToDateTime(SQLHelper.ExecuteScalar(procName, null));
        }

        public SalePerson SaleLogin(SalePerson person)
        {
            string procName = "SalesLogIn";
            SqlParameter[] sp =
            {
                new SqlParameter("@LoginId",SqlDbType.Int),
                new SqlParameter("@LoginPwd",SqlDbType.NVarChar,50)
            };
            sp[0].Value = person.SalePersonId;
            sp[1].Value = person.LoginPwd;
            SqlDataReader reader = SQLHelper.GetDataReader(procName, sp);
            SalePerson sale = null;
            while (reader.Read())
            {
                sale = new SalePerson()
                {
                    LoginPwd = reader["LoginPwd"].ToString(),
                    SPName = reader["SPName"].ToString(),
                    SalePersonId = int.Parse(reader["SalePersonId"].ToString())
                };
            }
            reader.Close();
            return sale;
        }

        public int WriteSalesExitLog(int logid)
        {
            string procName = "ExitSysWriteLog";
            SqlParameter[] sp =
            {
                new SqlParameter("LogId",SqlDbType.Int)
            };
            sp[0].Value = logid;
            return SQLHelper.ExecuteNonQuery(procName, sp);
        }
        /// <summary>
        /// 日志记录成功返回本次日志的ID号
        /// </summary>
        /// <param name="logs"></param>
        /// <returns></returns>
        public int WriteSalesLog(LoginLogs logs)
        {
            string procName = "WriteLog";
            SqlParameter[] sp =
            {
                new SqlParameter("@LoginId",SqlDbType.Int),
                new SqlParameter("@SPName",SqlDbType.NVarChar),
                new SqlParameter("@ServerName",SqlDbType.NVarChar)
            };
            sp[0].Value = logs.LoginId;
            sp[1].Value = logs.SPName;
            sp[2].Value = logs.ServerName;
            object res = SQLHelper.ExecuteScalar(procName, sp);
            if (res == null)
            {
                return -1;
            }
            return int.Parse(res.ToString());
        }
    }
}
