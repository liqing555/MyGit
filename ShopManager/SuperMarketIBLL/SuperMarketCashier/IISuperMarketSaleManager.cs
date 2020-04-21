using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketModel;

namespace SuperMarketIBLL.SuperMarketCashier
{
    public interface IISuperMarketSaleManager
    {
        /// <summary>
        /// 销售员登录
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        SalePerson salesLogin(SalePerson person);
        /// <summary>
        /// 记录系统登录日志
        /// </summary>
        /// <param name="logs"></param>
        /// <returns></returns>
        int WriteSalesLog(LoginLogs logs);
        /// <summary>
        /// 记录系统退出日志
        /// </summary>
        /// <param name="logId"></param>
        /// <returns></returns>
        bool WriteSalesExitLog(int logId);
        /// <summary>
        /// 获取时间--流水账号
        /// </summary>
        /// <returns></returns>
        DateTime GetSysTime();
        /// <summary>
        /// 获取销售员的业务逻辑
        /// </summary>
        /// <returns></returns>
        List<SalePerson> GetSales();
        /// <summary>
        /// 添加销售员
        /// </summary>
        /// <param name="sales"></param>
        /// <returns></returns>
        SalePerson InsertSale(SalePerson sales);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sales"></param>
        /// <returns></returns>
        SalePerson UpdateSale(SalePerson sales);
    }
}
