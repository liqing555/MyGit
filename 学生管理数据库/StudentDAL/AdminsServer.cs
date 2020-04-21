using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentModel;
using System.Data.SqlClient;

namespace StudentDAL
{
    
    public class AdminsServer
    {
        //管理员登录
        public Admins GetAdmins(Admins adm)
        {
            //string sql = string.Format("SELECT * FROM Admins WHERE Aid={0}", adm.Aid);
            string procName = "AdminLog";
            SqlParameter[] parameters =
            {
                new SqlParameter("@id", System.Data.SqlDbType.Int),
                new SqlParameter("@Pwd", System.Data.SqlDbType.VarChar,50)
            };
            parameters[0].Value = adm.Aid;
            parameters[1].Value = adm.Apwd;
            SqlDataReader reader = DBHepler.SQLHelper.GetReaderByPROC(procName, parameters);
            Admins use = null;
            while (reader.Read())
            {
                use = new Admins()
                {
                    Aname = reader["Aname"].ToString(),
                    Aid = Convert.ToInt32(reader["Aid"]),
                    Apwd = reader["Apwd"].ToString()
                };
            }
            reader.Close();
            return use;
        }
    }
}
