using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin_DAL;
using Admin_Model;

namespace Admin_BLL
{
   public class LoginBLL
    {
        public administatorsModel Login(string Name, string Pwd)
        {
            LoginDAL logins = new LoginDAL();
            return logins.Login(Name, Pwd);
        }
      

    }
}
