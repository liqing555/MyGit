using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketIDAL.SuperMarketCashier;
using SuperMarketModel;
using System.Data.SqlClient;

namespace SuperMarketDAL.SuperMarketCashier
{
    public class SuperMarketMemberServer : ISuperMarketMemberServer
    {
        public SMMembers GetMembersById(int id)
        {
            string procName = "GetMembersById";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@MemberId", System.Data.SqlDbType.Int)
            };
            sp[0].Value = id;
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
    }
}
