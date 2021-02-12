using Admin_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_BLL
{
    public class administratorBLL
    {
        public List<administatorsModel> administators(string Name,string Addtime)
        {
            Admin_DAL.administratorDAL administratorDAL = new Admin_DAL.administratorDAL();
            return administratorDAL.administators(Name, Addtime);
        }
        public int insert(administatorsModel administators) 
        {
            Admin_DAL.administratorDAL administratorDAL = new Admin_DAL.administratorDAL();
            return administratorDAL.insert(administators);
        }
        public int Deleteadministators(int mid)
        {
            Admin_DAL.administratorDAL administratorDAL = new Admin_DAL.administratorDAL();
            return administratorDAL.Deleteadministators(mid);
        }
       
        public int Updatedministators(int mid)
        {
            Admin_DAL.administratorDAL administratorDAL = new Admin_DAL.administratorDAL();
            return administratorDAL.Updatedministators(mid);
        }
    }
}
