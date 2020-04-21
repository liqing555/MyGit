using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentDAL;
using StudentModel;

namespace StudentBLL
{
    public class AdminsManager
    {
        AdminsServer server = new AdminsServer();
        public Admins GetAdmins(Admins adm)
        {
            return server.GetAdmins(adm);
        }
    }
}
