using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketModel;
using SuperMarketDAL;

namespace SuperMarketBLL.SuperMarketManager
{
    public class SuperMarketVipMemberManager : SuperMarketIBLL.SuperMarketManager.ISuperMarketVipMeberManager
    {
        SuperMarketIDAL.SuperMarketManager.ISuperMarketVipMemberServer server = new SuperMarketDAL.SuperMarketManager.SuperMarkerVipMemberServer();
        /// <summary>
        /// 添加会员
        /// </summary>
        /// <param name="members"></param>
        /// <returns></returns>
        public SMMembers addMembers(SMMembers members)
        {
            return server.addMembers(members);
        }
        /// <summary>
        /// 通过姓名查询会员
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public SMMembers GetMemberByrName(string where)
        {
            return server.GetMemberByrName(where);
        }

        /// <summary>
        /// 查询会员信息
        /// </summary>
        /// <returns></returns>
        public List<SMMembers> GetMembers()
        {
            return server.GetMembers();
        }

        public SMMembers GetSMMemberByIdOrNum(string id)
        {
            return server.GetSMMemberByIdOrNum(id);
        }

        /// <summary>
        /// 会员的编号或者电话号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SMMembers GetSMMemberByIdOrPhone(string id)
        {
            return server.GetSMMemberByIdOrPhone(id);
        }
        /// <summary>
        /// 修改会员信息
        /// </summary>
        /// <param name="members"></param>
        /// <returns></returns>
        public bool UpdateVip(SMMembers members)
        {
            if (server.UpdateVip(members) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 修改会员状态
        /// </summary>
        /// <param name="members"></param>
        /// <returns></returns>
        public bool UpVIP(SMMembers members)
        {
            if (server.UpVIP(members) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
