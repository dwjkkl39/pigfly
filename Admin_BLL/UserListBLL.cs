using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin_DAL;
using Admin_Model;
namespace Admin_BLL
{
  public  class UserListBLL
    {
        public List<UserpigflyModel> GetUserpigfly(string Uname, string udatetamebegin)
        {
            UserListDAL userListDAL = new UserListDAL();
            return userListDAL.GetUser(Uname, udatetamebegin);
        }
        public int delete(int Uid) 
        {
            UserListDAL userListDAL = new UserListDAL();
            return userListDAL.delete(Uid);
        }
    }
}
