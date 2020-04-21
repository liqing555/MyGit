using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketModel;

namespace SuperMarketIBLL.SuperMarketManager
{
    public interface ISuperMarketAdminManager
    {
        SysAdmins AdminLogin(SysAdmins admin);
        bool AdminUpdatePwd(SysAdmins admin);
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
        bool SetSysAdminRole(SysAdmins admins);
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
        SysAdmins UpdateAdmin(SysAdmins admins);
    }
}
