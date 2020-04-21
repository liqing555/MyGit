using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModel
{
    /// <summary>
    /// 成绩实体对象
    /// </summary>
    [Serializable]
    public class GradeList
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Gid { get; set; }
        /// <summary>
        /// 学号
        /// </summary>
        public int Sid { get; set; }
        /// <summary>
        /// C#成绩
        /// </summary>
        public int CSharp { get; set; }
        /// <summary>
        /// SQL成绩
        /// </summary>
        public int SQLServerDB { get; set; }
        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
