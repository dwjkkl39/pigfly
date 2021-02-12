using Admin_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_BLL
{
    public class Shops_AuditBLL
    {
        public List<investModel> Getinvest()
        {
            Admin_DAL.Shops_AuditDAL auditDAL = new Admin_DAL.Shops_AuditDAL();
            return auditDAL.Getinvest();
        }
        public List<UserpigflyModel> Getdetails(int investid)
        {
            Admin_DAL.Shops_AuditDAL auditDAL = new Admin_DAL.Shops_AuditDAL();
            return auditDAL.Getdetails(investid);
        }
        public int UpDelete(int investid, int mid)
        {
            Admin_DAL.Shops_AuditDAL auditDAL = new Admin_DAL.Shops_AuditDAL();
            return auditDAL.UpDelete(investid,mid);
        }
        public int UpInveststate(int investid, int mid)
        {
            Admin_DAL.Shops_AuditDAL auditDAL = new Admin_DAL.Shops_AuditDAL();
            return auditDAL.UpInveststate(investid, mid);
        }
        public int UpRefuse(int investid, int mid)
        {
            Admin_DAL.Shops_AuditDAL auditDAL = new Admin_DAL.Shops_AuditDAL();
            return auditDAL.UpRefuse(investid, mid);
        }
    }
}
