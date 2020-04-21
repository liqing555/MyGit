using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentModel;
using StudentModel.ObjExt;
using System.Data;
using System.Data.SqlClient;

namespace StudentDAL
{
    //学生考勤管理模块
    public class AttendanceServer
    {
        //查看所有考勤
        public List<Attendance> GetAttendances()
        {
            string sql = "SELECT * FROM Attendance";
            SqlDataReader reader = DBHepler.SQLHelper.GetReader(sql);
            List<Attendance> list = new List<Attendance>();
            while (reader.Read())
            {
                list.Add(new Attendance()
                {
                    CardNo = (reader["CardNo"]).ToString(),
                    DTime = (DateTime)reader["DTime"]
                });
            }
            reader.Close();
            return list;
        }
        public List<StudentExt> GetAttendance(int cid)
        {
            string sql = "SELECT SiD,Sname,Ssex,Birthday,SidNo,Attendance.CardNo,SImage,Sage,Sphone,Saddress,StudentClass.Scname,Attendance.DTime FROM Student , StudentClass , Attendance WHERE StudentClass.Scid=Student.Sclassid  AND Attendance.CardNo=Student.CardNo and StudentClass.Scid=" + cid;
            SqlDataReader reader = DBHepler.SQLHelper.GetReader(sql);
            List<StudentExt> list = DataReturnObj(reader);
            return list;
        }
        private static List<StudentExt> DataReturnObj(SqlDataReader reader)
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
                    SImage = reader["SImage"].ToString(),
                    DTime = (DateTime)reader["DTime"]
                });
            }
            reader.Close();
            return list;
        }
        //根据ID或者名称模糊查询
        public List<StudentExt> GetStudentsByIdOrname(string target)
        {
            string sql = string.Format("SELECT Sid, Sname, Ssex, Birthday, SidNo, Attendance.CardNo,StudentClass.Scname, SImage, Sage, Sphone, Saddress,Attendance.DTime FROM Student,StudentClass INNER JOIN Attendance ON Attendance.CardNo=Student.CardNo WHERE Sid LIKE '%{0}%'OR Sname LIKE  '%{0}%'", target);
            SqlDataReader reader = DBHepler.SQLHelper.GetReader(sql);
            List<StudentExt> list = DataReturnObj(reader);
            reader.Close();
            return list;
        }
        public DataTable GetDataTable(int cid)
        {
            string sql = "SELECT Sid,Sname,Ssex,Birthday,SidNo,Attendance.CardNo,Age,Sphone,Saddress,StudentClass.Scname,Attendance.DTime FROM Student , StudentClass , Attendance WHERE StudentClass.Scid=Student.Sclassid  AND Attendance.CardNo=Student.CardNo and StudentClass.Scid=" + cid;
            DataTable table = DBHepler.SQLHelper.GetDataSet(sql).Tables[0];
            return table;
        }
    }
}
