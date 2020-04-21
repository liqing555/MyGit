using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketModel;
using SuperMarketIDAL.SuperMarketManager;
using SuperMarketDAL.SuperMarketManager;
using SuperMarketIBLL.SuperMarketManager;
using System.Net;
using SuperMarketIDAL.SuperMarketCashier;
using SuperMarketDAL.SuperMarketCashier;

namespace SuperMarketBLL.SuperMarketManager
{
    public class SuperMarketAdminManager : ISuperMarketAdminManager
    {
        ISuperMarketAdminServer manager = new SuperMarketAdminServer();
        IISuperMarketSaleServer server = new SuperMarketSaleServer();
        /// <summary>
        /// 管理员登录逻辑
        /// </summary>
        /// <param name="sys"></param>
        /// <returns></returns>
        public SysAdmins AdminLogin(SysAdmins admin)
        {
            SysAdmins sys = manager.AdminLogin(admin);
            //管理员不是空，状态时启用状态
            if (sys != null && sys.AdminStatus == 1)
            {
                //可以登录,写入日志
                LoginLogs login = new LoginLogs()
                {
                    LoginId = sys.LoginId,
                    SPName = sys.AdminName,
                    ServerName = Dns.GetHostName()
                };
                //记录日志
                sys.LoginLogId = server.WriteSalesLog(login);
            }
            else
            {
                sys = null;
            }
            return sys;
        }

        /// <summary>
        /// 修改管理员密码
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public bool AdminUpdatePwd(SysAdmins admin)
        {
            int res = manager.AdminUpdatePwd(admin);
            if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 查询管理员信息
        /// </summary>
        /// <returns></returns>
        public List<SysAdmins> GetAllTables()
        {
            return manager.GetAllTables();
        }
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="admins"></param>
        /// <returns></returns>
        public SysAdmins InsertAdmin(SysAdmins admins)
        {
            return manager.InsertAdmin(admins);
        }

        /// <summary>
        /// 禁用
        /// </summary>
        /// <param name="admins"></param>
        /// <returns></returns>
        public bool SetSysAdminRole(SysAdmins admins)
        {
            if (manager.SetSysAdminRole(admins) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public SysAdmins UpdateAdmin(SysAdmins admins)
        {
            if (manager.UpdateAdmin(admins) > 0)
            {
                return admins;
            }
            else
            {
                return null;
            }
        }
    }
}
