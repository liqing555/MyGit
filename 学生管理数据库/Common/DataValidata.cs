using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Common
{
    public class DataValidata
    {
        /// <summary>
        /// 验证正整数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInteger (string str)
        {
            Regex reg = new Regex(@"^[1-9]\d*$");
            return reg.IsMatch(str);
        }
        //验证身份证
        public static bool IsSCard(string str)
        {
            Regex reg = new Regex(@"(^\d{ 18 }$)| (^\d{ 17} (\d | X | x)$)");
            return reg.IsMatch(str);
        }
        //验证手机号
        public static bool Phone(string str)
        {
            Regex reg = new Regex(@"^1[0-9]{10}$");
            return reg.IsMatch(str);
        }
        //验证日期
        public static bool Date(string str)
        {
            Regex reg = new Regex(@"^[1-9]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])$");
            return reg.IsMatch(str);
        }
    }
}
