using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModel
{
    /// <summary>
    /// 班级实体对象
    /// </summary>
    [Serializable]
    public class StudentClass
    {
        /// <summary>
        /// 班级编号
        /// </summary>
        public int Scid { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        public string Scname { get; set; }
    }
}
