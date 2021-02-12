using Admin_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_BLL
{
    public class CeshiBLL
    {
        public List<CeshiModel> Listceshi()
        {
            Admin_DAL.Ceshi ceshi = new Admin_DAL.Ceshi();
            return ceshi.Listceshi();
        }
        public int Addseshi(string length)
        {
            Admin_DAL.Ceshi ceshi = new Admin_DAL.Ceshi();
            return ceshi.Addseshi(length);
        }
    }
}
