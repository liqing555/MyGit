using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentModel;
using System.Data.SqlClient;
using System.Data;
using StudentModel.ObjExt;


namespace StudentDAL
{
    //成绩管理数据访问服务
    public class GradeServer
    {
       public List<GradeExt> GetGradeList(int cid)
        {
            string sql = "SELECT GradeList.Sid, Student.Sname ,CSharp,SQLServerDB,UpdateTime,StudentClass.Scname FROM GradeList INNER JOIN Student ON Student.Sid=GradeList.Sid INNER JOIN StudentClass ON StudentClass.Scid=Student.Sclassid WHERE StudentClass.Scid=" + cid;
            SqlDataReader reader = DBHepler.SQLHelper.GetReader(sql);
            List<GradeExt> list = DataReturnObj(reader);
            reader.Close();
            return list;
        }
        private static List<GradeExt> DataReturnObj(SqlDataReader reader)
        {
            List<GradeExt> list = new List<GradeExt>();
            while (reader.Read())
            {
                list.Add(new GradeExt()
                {
                    Sid = Convert.ToInt32(reader["Sid"]),
                    Sname = reader["Sname"].ToString(),
                    CSharp = Convert.ToInt32(reader["CSharp"]),
                    Scname = reader["Scname"].ToString(),
                    SQLServerDB = Convert.ToInt32(reader["SQLServerDB"]),
                    UpdateTime = Convert.ToDateTime(reader["UpdateTime"])
                });
            }
            return list;
        }
        public List<GradeExt> GetStudentByldOrName(string target)
        {
            string sql = string.Format("SELECT GradeList.Sid,Student.Sname ,CSharp,SQLServerDB,UpdateTime,StudentClass.Scname FROM GradeList INNER JOIN Student ON Student.Sid=GradeList.Sid INNER JOIN StudentClass ON StudentClass.Scid=Student.Sclassid WHERE GradeList.Sid LIKE '%{0}%' OR Sname LIKE '%{0}%'", target);
            SqlDataReader reader = DBHepler.SQLHelper.GetReader(sql);
            List<GradeExt> list = DataReturnObj(reader);
            reader.Close();
            return list;
        }
        public int DeleteStudentById(int sid)
        {
            string sql = "DELETE FROM GradeList WHERE Sid=" + sid;
            return DBHepler.SQLHelper.ExecuteNonQuery(sql);
        }
        public GradeExt GetStudentById(int id)
        {
            string sql = "SELECT GradeList.Sid, Student.Sname ,CSharp,SQLServerDB,UpdateTime,StudentClass.Scname FROM GradeList INNER JOIN Student ON Student.Sid=GradeList.Sid INNER JOIN StudentClass ON StudentClass.Scid=Student.Sclassid WHERE GradeList.Sid=" + id;
            SqlDataReader reader = DBHepler.SQLHelper.GetReader(sql);
            GradeExt student = null;
            while (reader.Read())
            {
                student = (new GradeExt()
                {
                    Sid = Convert.ToInt32(reader["Sid"]),
                    Sname = reader["Sname"].ToString(),
                    CSharp = Convert.ToInt32(reader["CSharp"]),
                    Scname = reader["Scname"].ToString(),
                    SQLServerDB = Convert.ToInt32(reader["SQLServerDB"]),
                    UpdateTime = Convert.ToDateTime(reader["UpdateTime"])
                });
            }
            return student;
        }
        public int UpdateStudentInfor(GradeExt student)
        {
            string sql = string.Format("UPDATE GradeList SET CSharp={0},SQLServerDB={1} WHERE Sid={2}", student.CSharp, student.SQLServerDB, student.Sid);
            return DBHepler.SQLHelper.ExecuteNonQuery(sql);
        }
        public DataTable GetDataTable(int cid)
        {
            string sql = "SELECT GradeList.Sid, Student.Sname ,CSharp,SQLServer,UpdateTime,StudentClass.Scname FROM GradeList INNER JOIN Student ON Student.Sid=GradeList.Sid INNER JOIN StudentClass ON StudentClass.Scid=Students.Sclassid WHERE StudentClass.Scid=" + cid;
            DataTable table = DBHepler.SQLHelper.GetDataSet(sql).Tables[0];
            return table;
        }
        public int Getdaa(GradeExt student)
        {
            string sql = string.Format("INSERT INTO GradeList VALUES ({0}, {1}, {2}, {3})", student.Sid, student.CSharp, student.SQLServerDB, student.UpdateTime);
            return DBHepler.SQLHelper.ExecuteNonQuery(sql);
        }
    }
}
