using StudentDAL;
using StudentModel.ObjExt;
using System.Collections.Generic;
using System.Data;

namespace StudentBLL
{
    /// <summary>
    /// 学生管理的业务逻辑
    /// </summary>
    public class StudentManager
    {
        StudentServer server = new StudentServer();
        public List<StudentExt> GetStudents(int cid)
        {
            return server.GetStudents(cid);
        }
        public DataTable GetDataTable(int cid)
        {
            return server.GetDataTable(cid);
        }
        public List<StudentExt> GetStudentByIdOrName(string target)
        {
            return server.GetStudentByIdOrName(target);
        }
        public StudentExt GetStudentById(int id)
        {
            return server.GetStudentById(id);
        }
        public bool UpdateStudentInfor(StudentExt student)
        {
            if (server.UpdateStudentInfor(student) <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool DeleteStudentById(int sid)
        {
            if (server.DeleteStudentById(sid) <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public List<StudentExt> GetStudentByExcel(string path)
        {
            return server.GetStudentByExcel(path);
        }
        public int InsertStudent(StudentExt stu)
        {
            if (server.CheckStuId(stu.SidNo) > 0)
            {
                return -1;
            }
            return server.InsertStudent(stu);
        }
        public bool AddStudent(StudentExt stu)
        {
            if (server.AddStudent(stu) <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
