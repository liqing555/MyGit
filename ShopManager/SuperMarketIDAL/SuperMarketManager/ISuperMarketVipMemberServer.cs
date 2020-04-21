using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketModel;

namespace SuperMarketIDAL.SuperMarketManager
{
    public interface ISuperMarketVipMemberServer
    {
        /// <summary>
        /// 通过会员卡号或者电话查询会员信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SMMembers GetSMMemberByIdOrPhone(string id);
        SMMembers addMembers(SMMembers members);
        /// <summary>
        /// 查询所有的会员信息
        /// </summary>
        /// <returns></returns>
        List<SMMembers> GetMembers();
        /// <summary>
        /// 通过卡号电话号查询会员具体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SMMembers GetSMMemberByIdOrNum(string id);
        /// <summary>
        /// 通过姓名查询会员信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        SMMembers GetMemberByrName(string where);
        /// <summary>
        /// 修改会员信息
        /// </summary>
        /// <param name="members"></param>
        /// <returns></returns>
        int UpdateVip(SMMembers members);
        /// <summary>
        /// 修改会员状态
        /// </summary>
        /// <param name="members"></param>
        /// <returns></returns>
        int UpVIP(SMMembers members);
    }
}
