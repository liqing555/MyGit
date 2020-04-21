using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModel
{
    /// <summary>
    /// 管理员实体对象
    /// </summary>
    [Serializable]
    public class Admins
    {
        /// <summary>
        /// 登录ID
        /// </summary>
        public int Aid { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string Apwd { get; set; }
        /// <summary>
        /// 管理员姓名
        /// </summary>
        public string Aname { get; set; }
    }
}
