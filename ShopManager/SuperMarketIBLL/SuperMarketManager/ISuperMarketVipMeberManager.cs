using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketModel;

namespace SuperMarketIBLL.SuperMarketManager
{
    public interface ISuperMarketVipMeberManager
    {

        SMMembers addMembers(SMMembers members);
        SMMembers GetSMMemberByIdOrPhone(string id);
        /// <summary>
        /// 查询会员信息
        /// </summary>
        /// <returns></returns>
        List<SMMembers> GetMembers();
        /// <summary>
        /// 通过姓名查询会员
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        SMMembers GetMemberByrName(string where);
        /// <summary>
        /// 通过卡号电话查询会员的具体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SMMembers GetSMMemberByIdOrNum(string id);
        /// <summary>
        /// 修改会员信息
        /// </summary>
        /// <param name="members"></param>
        /// <returns></returns>
        bool UpdateVip(SMMembers members);
        /// <summary>
        /// 修改会员状态
        /// </summary>
        /// <param name="members"></param>
        /// <returns></returns>
        bool UpVIP(SMMembers members);
    }
}
