using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketModel;

namespace SuperMarketIDAL.SuperMarketManager
{
    public interface ISuperMarketAdminServer
    {
        SysAdmins AdminLogin(SysAdmins admin);

        int AdminUpdatePwd(SysAdmins admin);
        /// <summary>
        /// 查询管理员信息
        /// </summary>
        /// <returns></returns>
        List<SysAdmins> GetAllTables();
        /// <summary>
        /// 禁用
        /// </summary>
        /// <param name="admins"></param>
        /// <returns></returns>
        int SetSysAdminRole(SysAdmins admins);
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="admins"></param>
        /// <returns></returns>
        SysAdmins InsertAdmin(SysAdmins admins);
        /// <summary>
        /// 修改管理员
        /// </summary>
        /// <param name="admins"></param>
        /// <returns></returns>
        int UpdateAdmin(SysAdmins admins);
    }
}
