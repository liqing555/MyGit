using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentModel.ObjExt;
using StudentDAL;
using System.Data;


namespace StudentBLL
{
    public class AttendanceManager
    {
        StudentServer server = new StudentServer();
        AttendanceServer attendance = new AttendanceServer();
        //班级查询
        public List<StudentExt> GetStudents(int cid)
        {
            return attendance.GetAttendance(cid);
        }
        public List<StudentExt> GetStudentsByIdOrname(string target)
        {
            return attendance.GetStudentsByIdOrname(target);
        }
        public DataTable GetDataTable(int cid)
        {
            return attendance.GetDataTable(cid);
        }
    }
}
