using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModel
{
    /// <summary>
    /// 学生实体对象
    /// </summary>
    [Serializable]
    public class Student
    {
        /// <summary>
        /// 学号
        /// </summary>
        public int Sid { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Sname { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Ssex { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string SidNo { get; set; }
        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNo { get; set; }
        /// <summary>
        /// 照片
        /// </summary>
        public string SImage { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Sage { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Sphone { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Saddress { get; set; }
        /// <summary>
        /// 班级编号
        /// </summary>
        public int Sclassid { get; set; }
    }
}
