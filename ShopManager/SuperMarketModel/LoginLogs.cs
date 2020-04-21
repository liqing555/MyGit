using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketModel
{
    /// <summary>
    /// 销售员登录日志对象
    /// </summary>
    [Serializable]
    public class LoginLogs
    {
        public int LogId { get; set; }
        /// <summary>
        /// 登录员ID
        /// </summary>
        public int LoginId { get; set; }
        /// <summary>
        /// 登录员姓名
        /// </summary>
        public string SPName { get; set; }
        /// <summary>
        /// 登录服务器名
        /// </summary>
        public string ServerName { get; set; }
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime { get; set; }
        /// <summary>
        /// 退出时间
        /// </summary>
        public DateTime? ExitTime { get; set; }
    }
}
