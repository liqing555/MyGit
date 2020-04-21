using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentDAL;
using StudentModel.ObjExt;
using System.Data;

namespace StudentBLL
{
    public class GradeManager
    {
        GradeServer server = new GradeServer();
        public List<GradeExt> GetGrades(int cid)
        {
            return server.GetGradeList(cid);
        }
        public List<GradeExt> GetStudentByldOrName(string target)
        {
            return server.GetStudentByldOrName(target);
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
        public GradeExt GetStudentById(int id)
        {
            return server.GetStudentById(id);
        }
        public bool UpdateStudentInfor(GradeExt student)
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
        public DataTable GetDataTable(int cid)
        {
            return server.GetDataTable(cid);
        }
        public int Getdaa(GradeExt student)
        {
            return server.Getdaa(student);
        }
    }
}
