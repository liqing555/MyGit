using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using StudentModel.ObjExt;
using StudentModel;
using StudentDAL;
using System.Data;
using Common;

namespace StudentDAL
{
    public class StudentServer
    {
        public List<StudentExt> GetStudents(int cid)
        {
            string sql = "SELECT Sid,Sname,Ssex,Birthday,SidNo,CardNO,SImage,Sage,Sphone,Saddress,StudentClass.Scname FROM Student INNER JOIN StudentClass ON StudentClass.Scid=Student.Sclassid WHERE StudentClass.Scid=" + cid;
            SqlDataReader reader = DBHepler.SQLHelper.GetReader(sql);
            List<StudentExt> list = DateReturnObj(reader);
            reader.Close();
            return list;
        }

        public DataTable GetDataTable(int cid)
        {
            string sql = "SELECT Sid,Sname,Ssex,Birthday,SidNo,CardNO,Sage,Sphone,Saddress,StudentClass.Scname FROM Student INNER JOIN StudentClass ON StudentClass.Scid=Student.Sclassid WHERE StudentClass.Scid=" + cid;
            DataTable table = DBHepler.SQLHelper.GetDataSet(sql).Tables[0];
            return table;
        }

        private static List<StudentExt> DateReturnObj(SqlDataReader reader)
        {
            List<StudentExt> list = new List<StudentExt>();
            while (reader.Read())
            {
                list.Add(new StudentExt()
                {
                    Sid = Convert.ToInt32(reader["Sid"]),
                    Sage = Convert.ToInt32(reader["Sage"]),
                    Birthday = Convert.ToDateTime(reader["Birthday"]),
                    CardNo = reader["CardNo"].ToString(),
                    Scname = reader["Scname"].ToString(),
                    Ssex = reader["Ssex"].ToString(),
                    Sphone = reader["Sphone"].ToString(),
                    Saddress = reader["Saddress"].ToString(),
                    SidNo = reader["SidNo"].ToString(),
                    Sname = reader["Sname"].ToString(),
                    SImage = reader["SImage"].ToString()
                });
            }
            return list;
        }

        public int DeleteStudentById(int sid)
        {
            string sql = "DELETE FROM Student WHERE Sid=" + sid;
            return DBHepler.SQLHelper.ExecuteNonQuery(sql);
        }

        //根据ID或者名称模糊查询
        public List<StudentExt> GetStudentByIdOrName(string target)
        {
            string sql = string.Format("SELECT Sid,Sname,Ssex,Birthday,SidNo,CardNO,SImage,Sage,Sphone,Saddress,StudentClass.Scname FROM Student INNER JOIN StudentClass ON StudentClass.Scid=Student.Sclassid WHERE Sid LIKE '%{0}%' OR Sname LIKE '%{0}%'",target);
            SqlDataReader reader = DBHepler.SQLHelper.GetReader(sql);
            List<StudentExt> list = DateReturnObj(reader);
            reader.Close();
            return list;
        }
        public StudentExt GetStudentById(int id)
        {
            string sql = string.Format("SELECT Sid,Sname,Ssex,Birthday,SidNo,CardNo,SImage,Sage,Sphone,Saddress,Student.Sclassid,StudentClass.Scname FROM Student INNER JOIN StudentClass ON StudentClass.Scid=Student.Sclassid WHERE Sid = {0}", id);
            SqlDataReader reader = DBHepler.SQLHelper.GetReader(sql);
            StudentExt student = null;
            while (reader.Read())
            {
                student = new StudentExt()
                {
                    Sid = Convert.ToInt32(reader["Sid"]),
                    Sage = Convert.ToInt32(reader["Sage"]),
                    Birthday = Convert.ToDateTime(reader["Birthday"]),
                    CardNo = reader["CardNo"].ToString(),
                    Scname = reader["Scname"].ToString(),
                    Ssex = reader["Ssex"].ToString(),
                    Sphone = reader["Sphone"].ToString(),
                    Saddress = reader["Saddress"].ToString(),
                    SidNo = reader["SidNo"].ToString(),
                    Sname = reader["Sname"].ToString(),
                    SImage = reader["SImage"].ToString(),
                    Sclassid = Convert.ToInt32(reader["Sclassid"])
                };
            }
            return student;
        }
        public int UpdateStudentInfor(StudentExt student)
        {
            string sql = string.Format("UPDATE Student SET Sname='{0}',Ssex='{1}',Birthday='{2}',SidNo='{3}',CardNo='{4}',SImage='{5}',Sage={6},Sphone='{7}',Saddress='{8}',Sclassid={9}WHERE Sid={10}", student.Sname, student.Ssex, student.Birthday, student.SidNo, student.CardNo, student.SImage, student.Sage, student.Sphone, student.Saddress, student.Sclassid, student.Sid);
            return DBHepler.SQLHelper.ExecuteNonQuery(sql);
        }
        StudentClassServer classServer = new StudentClassServer();
        //从Excel文件中读取数据
        public List<StudentExt> GetStudentByExcel(string path)
        {
            List<StudentExt> list = new List<StudentExt>();
            string sql = string.Format("SELECT * FROM [{0}$] ", Common.ImportOrExportData.SheetName(path));
            DataSet ds = Common.OleDbHelper.GetDataSet(sql, path);
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new StudentExt()
                {
                    Sname = row["姓名"].ToString(),
                    Ssex = row["性别"].ToString(),
                    Birthday = Convert.ToDateTime(row["出生日期"]),
                    Sage = DateTime.Now.Year - Convert.ToDateTime(row["出生日期"]).Year,
                    CardNo = row["考勤卡号"].ToString(),
                    SidNo = row["身份证号"].ToString(),
                    Sphone = row["电话号码"].ToString(),
                    Saddress = row["家庭住址"].ToString(),
                    Scname = row["班级名称"].ToString(),
                    Sclassid = classServer.GetClassIdByName(row["班级名称"].ToString())
                });
            }
            return list;
        }

        public int InsertStudent(StudentExt stu)
        {
            string sql = string.Format("INSERT INTO Student(Sname,Ssex,Birthday,SidNo,CardNo,Sage,Sphone,Saddress,Sclassid) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', {5}, '{6}', '{7}', {8})", stu.Sname, stu.Ssex, stu.Birthday, stu.SidNo, stu.CardNo, stu.Sage, stu.Sphone, stu.Saddress, stu.Sclassid);
            return DBHepler.SQLHelper.ExecuteNonQuery(sql);
        }

        public int AddStudent(StudentExt stu)
        {
            string sql = string.Format("INSERT INTO Student(Sname,Ssex,Birthday,SidNo,CardNo,Sage,Sphone,Saddress,Sclassid) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', {5}, '{6}', '{7}', {8})", stu.Sname, stu.Ssex, stu.Birthday, stu.SidNo, stu.CardNo, stu.Sage, stu.Sphone, stu.Saddress, stu.Sclassid);
            return DBHepler.SQLHelper.ExecuteNonQuery(sql);
        }
        public int CheckStuId(string id)
        {
            string sql = "SELECT COUNT(*) FROM Student WHERE SidNo='" + id + "'";
            object res = DBHepler.SQLHelper.ExecuteScalar(sql);
            return (int)res;
        }
    }
}
