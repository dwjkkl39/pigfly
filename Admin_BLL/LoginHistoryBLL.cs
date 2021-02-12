using Admin_DAL;
using Admin_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_BLL
{
    public class LoginHistoryBLL
    {
        public List<LoginHistoryModel> SelectLogin()
        {
            LoginHistoryDAL loginHistory = new LoginHistoryDAL();
            return loginHistory.SelectLogin();
        }
        public int insert(int Id, string Name, string IP)
        {
            LoginHistoryDAL logins = new LoginHistoryDAL();
            return logins.insert(Id, Name, IP);
        }
    }
}
