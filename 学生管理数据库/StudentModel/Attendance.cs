using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModel
{
    /// <summary>
    /// 打卡实体对象
    /// </summary>
    [Serializable]
    public class Attendance
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Aid { get; set; }
        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNo { get; set; }
        /// <summary>
        /// 打卡时间
        /// </summary>
        public DateTime DTime { get; set; }
    }
}
