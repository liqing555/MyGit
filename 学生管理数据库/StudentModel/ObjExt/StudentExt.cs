using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModel.ObjExt
{
    public class StudentExt:Student
    {
        public string Scname { get; set; }
        public string ImgPath { get; set; }
        public DateTime DTime { get; set; }
    }
}
