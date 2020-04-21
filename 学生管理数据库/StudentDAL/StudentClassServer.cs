using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentModel;
using System.Data.SqlClient;

namespace StudentDAL
{
    
    public class StudentClassServer
    {
        /// <summary>
        /// 查询所有班级
        /// </summary>
        public List<StudentClass> GetStudentClasses()
        {
            string sql = "SELECT * FROM StudentClass";
            SqlDataReader reader = DBHepler.SQLHelper.GetReader(sql);
            List<StudentClass> list = new List<StudentClass>();
            while (reader.Read())
            {
                list.Add(new StudentClass()
                {
                    Scid=Convert.ToInt32(reader["Scid"]),
                    Scname=reader["Scname"].ToString()
                });
            }
            reader.Close();
            return list;
        }
        //根据班级名称获取对应的Id
        public int GetClassIdByName(string name)
        {
            string sql = "SELECT Sclassid FROM StudentClass WHERE Scname='" + name + "'";
            object res = DBHepler.SQLHelper.ExecuteScalar(sql);
            if (res == null)
            {
                return -1;
            }
            else
            {

                return Convert.ToInt32(res);
            }
        }
    }
}
