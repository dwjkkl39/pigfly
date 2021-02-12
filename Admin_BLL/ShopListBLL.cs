using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin_DAL;
using Admin_Model;
namespace Admin_BLL
{
  public  class ShopListBLL
    {
        public List<investModel> GetInvests() 
        {
            ShopLIstDAL shopLIstDAL = new ShopLIstDAL();
          return  shopLIstDAL.GetInvests();
        }
        public int UpDelete(int investid, int mid)
        {
            ShopLIstDAL shopLIstDAL = new ShopLIstDAL();
            return shopLIstDAL.UpDelete(investid, mid);
        }
        public List<investModel> QueryInvests(string investname, string investprice, string investcontent, string investtime)
        {
            ShopLIstDAL shopLIstDAL = new ShopLIstDAL();
            return shopLIstDAL.QueryInvests(investname,investprice, investcontent, investtime);
        }
    }
}
