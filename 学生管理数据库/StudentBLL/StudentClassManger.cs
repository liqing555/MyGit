using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentModel;
using StudentDAL;

namespace StudentBLL
{
    public class StudentClassManger
    {
        StudentClassServer server = new StudentClassServer();
        public List<StudentClass> GetStudentClasses()
        {
            return server.GetStudentClasses();
        }
    }
}
