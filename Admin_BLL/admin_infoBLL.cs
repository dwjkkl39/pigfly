using Admin_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_BLL
{
   public class admin_infoBLL
    {
        public administatorsModel  QuerymidName(string midName)
        {
            Admin_DAL.admin_infoDAL infoDAL = new Admin_DAL.admin_infoDAL();
            return infoDAL.QuerymidName(midName);
        }
        public int Updateadministators(administatorsModel administators, string SessionName)
        {

            Admin_DAL.admin_infoDAL infoDAL = new Admin_DAL.admin_infoDAL();
            return infoDAL.Updateadministators(administators, SessionName);
        }
    }
}
