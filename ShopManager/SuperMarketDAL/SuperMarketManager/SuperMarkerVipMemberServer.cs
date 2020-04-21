using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketModel;
using System.Data.SqlClient;
using System.Data;

namespace SuperMarketDAL.SuperMarketManager
{
    public class SuperMarkerVipMemberServer : SuperMarketIDAL.SuperMarketManager.ISuperMarketVipMemberServer
    {
        /// <summary>
        /// 添加会员
        /// </summary>
        /// <param name="members"></param>
        /// <returns></returns>
        public SMMembers addMembers(SMMembers members)
        {
            string procName = "AddMember";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@memberName",members.MemberName),
                new SqlParameter("@phoneNumber",members.PhoneNumber),
                new SqlParameter("@address",members.MemberAddress)
            };
            object res = SQLHelper.ExecuteScalar(procName, sp);
            if (res != null)
            {
                members.MemberId = Convert.ToInt32(res);
            }
            else
            {
                members = null;
            }
            return members;
        }
        /// <summary>
        /// 通过姓名查询会员信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public SMMembers GetMemberByrName(string where)
        {
            string procName = "GetMemberByName";
            SqlParameter[] sp =
            {
                new SqlParameter("@memberName",where)
            };
            SMMembers sm = new SMMembers();
            SqlDataReader reader = SQLHelper.GetDataReader(procName, sp);
            while (reader.Read())
            {
                sm.MemberId = Convert.ToInt32(reader["MemberId"]);
                sm.MemberName = reader["MemberName"].ToString();
                sm.Points = Convert.ToInt32(reader["Points"]);
                sm.PhoneNumber = reader["PhoneNumber"].ToString();
                sm.MemberAddress = reader["MemberAddress"].ToString();
                sm.OpenTime = Convert.ToDateTime(reader["OpenTime"]);
                int res = Convert.ToInt32(reader["MemberStatus"]);
                if (res == 1)
                {
                    sm.MemberStatu = "正常";
                }
                else if (res == 0)
                {
                    sm.MemberStatu = "已冻结";
                }
                else
                {
                    sm.MemberStatu = "已注销";
                }
            }
            reader.Close();
            return sm;
        }

        /// <summary>
        /// 查询会员信息
        /// </summary>
        /// <returns></returns>
        public List<SMMembers> GetMembers()
        {
            string procName = "GetAllTables";
            SqlParameter[] sp =
            {
                new SqlParameter("@tableName","SMMembers")
            };
            SqlDataReader reader = SQLHelper.GetDataReader(procName, sp);
            List<SMMembers> members = new List<SMMembers>();
            while (reader.Read())
            {
                SMMembers sm = new SMMembers();
                sm.MemberId = Convert.ToInt32(reader["MemberId"]);
                sm.MemberName = reader["MemberName"].ToString();
                sm.Points = Convert.ToInt32(reader["Points"]);
                sm.PhoneNumber = reader["PhoneNumber"].ToString();
                sm.MemberAddress = reader["MemberAddress"].ToString();
                sm.OpenTime = Convert.ToDateTime(reader["OpenTime"]);
                sm.MemberStatus = Convert.ToInt32(reader["MemberStatus"]);
                if (sm.MemberStatus == 1)
                {
                    sm.MemberStatu = "正常";
                }
                else if (sm.MemberStatus == 0)
                {
                    sm.MemberStatu = "已冻结";
                }
                else
                {
                    sm.MemberStatu = "已注销";
                }
                members.Add(sm);
            }
            reader.Close();
            return members;
        }
        /// <summary>
        /// 通过卡号电话查询会员信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SMMembers GetSMMemberByIdOrNum(string id)
        {
            string procName = "GetMemberBysId";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@MemberId", SqlDbType.Int),
                new SqlParameter("@PhoneNumber", SqlDbType.NVarChar,50)
            };
            if (id.Length == 11)
            {
                sp[0].Value = -1;
                sp[1].Value = id;
            }
            else
            {
                sp[0].Value = id;
                sp[1].Value = "";
            }

            SMMembers members = new SMMembers();
            SqlDataReader reader = SQLHelper.GetDataReader(procName, sp);
            while (reader.Read())
            {
                members.MemberId = Convert.ToInt32(reader["MemberId"]);
                members.MemberAddress = reader["MemberAddress"].ToString();
                members.MemberName = reader["MemberName"].ToString();
                int res = Convert.ToInt32(reader["MemberStatus"]);
                if (res == 1)
                {
                    members.MemberStatu = "正常";
                }
                else if (res == 0)
                {
                    members.MemberStatu = "已冻结";
                }
                else
                {
                    members.MemberStatu = "已注销";
                }
                members.OpenTime = Convert.ToDateTime(reader["OpenTime"]);
                members.PhoneNumber = reader["PhoneNumber"].ToString();
                members.Points = Convert.ToInt32(reader["Points"]);
            }
            reader.Close();
            return members;
        }

        /// <summary>
        /// 获取会员的号码或电话
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SMMembers GetSMMemberByIdOrPhone(string id)
        {
            string procName = "GetMemberBysId";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@MemberId", SqlDbType.Int),
                new SqlParameter("@PhoneNumber", SqlDbType.NVarChar,50)
            };
            if (id.Length == 11)
            {
                sp[0].Value = -1;
                sp[1].Value = id;
            }
            else
            {
                sp[0].Value = id;
                sp[1].Value = "";
            }

            SMMembers members = null;
            SqlDataReader reader = SQLHelper.GetDataReader(procName, sp);
            while (reader.Read())
            {
                members = new SMMembers()
                {
                    MemberId = Convert.ToInt32(reader["MemberId"]),
                    MemberAddress = reader["MemberAddress"].ToString(),
                    MemberName = reader["MemberName"].ToString(),
                    MemberStatus = Convert.ToInt32(reader["MemberStatus"]),
                    OpenTime = Convert.ToDateTime(reader["OpenTime"]),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    Points = Convert.ToInt32(reader["Points"])
                };
            }
            reader.Close();
            return members;
        }
        /// <summary>
        /// 修改会员信息
        /// </summary>
        /// <param name="members"></param>
        /// <returns></returns>
        public int UpdateVip(SMMembers members)
        {
            string procName = "UpdateVip";
            SqlParameter[] sp =
            {
                new SqlParameter("@memberName",members.MemberName),
                new SqlParameter("@phonrNaumber",members.PhoneNumber),
                new SqlParameter("@memberAddress",members.MemberAddress),
                new SqlParameter("@memberId",members.MemberId)
            };
            return SQLHelper.ExecuteNonQuery(procName, sp);
        }
        /// <summary>
        /// 修改会员状态
        /// </summary>
        /// <param name="members"></param>
        /// <returns></returns>
        public int UpVIP(SMMembers members)
        {
            string procName = "UpVIP";
            SqlParameter[] sp =
            {
                new SqlParameter("@memberStatus",members.MemberStatus),
                new SqlParameter("@memberId",members.MemberId)
            };
            return SQLHelper.ExecuteNonQuery(procName, sp);
        }
    }
}
