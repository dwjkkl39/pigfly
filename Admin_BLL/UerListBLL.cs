using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin_DAL;
using Admin_Model;
namespace Admin_BLL
{
  public  class UerListBLL
    {

        public  List<UserpigflyModel> GetUser(string UserName, string  dateTimeReg)
        {
            UserListDAL userList = new UserListDAL();
            return userList.GetUser(UserName, dateTimeReg);


        }
        public int delete(int Id) 
        {
            UserListDAL userList = new UserListDAL();
            return userList.delete(Id);
        }

    }
}
