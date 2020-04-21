using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketModel
{
    /// <summary>
    /// 会员表属性
    /// </summary>
    [Serializable]
    public class SMMembers
    {
        /// <summary>
        /// 会员卡号
        /// </summary>
        public int MemberId { get; set; }
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string MemberName { get; set; }
        /// <summary>
        /// 会员积分
        /// </summary>
        public int Points { get; set; }
        /// <summary>
        /// 电话号
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string MemberAddress { get; set; }
        /// <summary>
        /// 开户时间
        /// </summary>
        public DateTime OpenTime { get; set; }
        /// <summary>
        /// 会员状态
        /// </summary>
        public int MemberStatus { get; set; }
        /// <summary>
        /// 状态信息
        /// </summary>
        public string MemberStatu { get; set; }
    }
}
