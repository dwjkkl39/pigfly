using Admin_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin_DAL;
namespace Admin_BLL
{
 public   class advertisingBLL
    {


        public List<advertisingModel> Getadvertising() 
        {
            advertisingDAL advertisingDAL = new advertisingDAL();
           return advertisingDAL.Getadvertising();
        }
        public int Update(int Id, int sbefore) 
        {
            advertisingDAL advertisingDAL = new advertisingDAL();
            return advertisingDAL.Update(Id, sbefore);
        }
        public int delete(int Id) 
        {
            advertisingDAL advertisingDAL = new advertisingDAL();
            return advertisingDAL.delete(Id);
        }
    }
}
