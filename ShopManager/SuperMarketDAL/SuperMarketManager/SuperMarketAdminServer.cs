using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketIDAL.SuperMarketManager;
using SuperMarketModel;
using System.Data.SqlClient;

namespace SuperMarketDAL.SuperMarketManager
{
    public class SuperMarketAdminServer : ISuperMarketAdminServer
    {
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public SysAdmins AdminLogin(SysAdmins admin)
        {
            string procName = "SysAdminLogin";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@logId", admin.LoginId),
                new SqlParameter("@logPwd", admin.LoginPwd)
            };
            SqlDataReader reader = SQLHelper.GetDataReader(procName, sp);
            SysAdmins admins = null;
            while (reader.Read())
            {
                admins = new SysAdmins()
                {
                    AdminName = reader["AdminName"].ToString(),
                    LoginId = Convert.ToInt32(reader["LoginId"]),
                    LoginPwd = reader["LoginPwd"].ToString(),
                    RoleId = Convert.ToInt32(reader["RoleId"]),
                    AdminStatus = Convert.ToInt32(reader["AdminStatus"])
                };
            }
            reader.Close();
            return admins;
        }

        /// <summary>
        /// 修改管理员密码
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public int AdminUpdatePwd(SysAdmins admin)
        {
            string procName = "UpdateSysPwd";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@logId",admin.LoginId),
                new SqlParameter("@logPwd",admin.LoginPwd)
            };
            return SQLHelper.ExecuteNonQuery(procName, sp);
        }

        /// <summary>
        /// 查询管理员信息
        /// </summary>
        /// <returns></returns>
        public List<SysAdmins> GetAllTables()
        {
            string procName = "GetAllTables";
            SqlParameter[] sp =
            {
                new SqlParameter("@tableName","SysAdmins")
            };
            SqlDataReader reader = SQLHelper.GetDataReader(procName, sp);
            List<SysAdmins> list = new List<SysAdmins>();
            while (reader.Read())
            {
                SysAdmins sys = new SysAdmins();
                sys.AdminName = reader["AdminName"].ToString();
                sys.LoginId = Convert.ToInt32(reader["LoginId"]);
                sys.LoginPwd = reader["LoginPwd"].ToString();
                sys.RoleId = Convert.ToInt32(reader["RoleId"]);
                sys.AdminStatus = Convert.ToInt32(reader["AdminStatus"]);
                sys.StatusName = sys.AdminStatus == 1 ? "启用" : "禁用";
                sys.RoleName = sys.RoleId == 1 ? "超级管理员" : "普通管理员";
                list.Add(sys);
            }
            reader.Close();
            return list;
        }

        public SysAdmins InsertAdmin(SysAdmins admins)
        {
            string procName = "InsertAdmin";
            SqlParameter[] sp =
            {
                new SqlParameter("@adminName",admins.AdminName),
                new SqlParameter("@loginPwd",admins.LoginPwd),
                new SqlParameter("@roleId",admins.RoleId)
            };
            object res = SQLHelper.ExecuteScalar(procName, sp);
            if (res != null)
            {
                admins.LoginId = Convert.ToInt32(res);
            }
            else
            {
                admins = null;
            }
            return admins;
        }

        /// <summary>
        /// 禁用
        /// </summary>
        /// <param name="admins"></param>
        /// <returns></returns>
        public int SetSysAdminRole(SysAdmins admins)
        {
            string procName = "SetSysAdminRole";
            SqlParameter[] sp =
            {
                new SqlParameter("@role",admins.AdminStatus),
                new SqlParameter("@id",admins.LoginId)
            };
            return SQLHelper.ExecuteNonQuery(procName, sp);
        }

        /// <summary>
        /// 修改管理员
        /// </summary>
        /// <param name="admins"></param>
        /// <returns></returns>
        public int UpdateAdmin(SysAdmins admins)
        {
            string procName = "UpdateAdmin";
            SqlParameter[] sp =
                {
                new SqlParameter("@adminName",admins.AdminName),
                new SqlParameter("@loginPwd",admins.LoginPwd),
                new SqlParameter("@roleId",admins.RoleId),
                new SqlParameter("@loginId",admins.LoginId)
            };
            return SQLHelper.ExecuteNonQuery(procName, sp);
        }
    }
}
