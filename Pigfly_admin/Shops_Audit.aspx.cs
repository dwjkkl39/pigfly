using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pigfly_admin
{
    public partial class Shops_Audit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetInvestlist();
                string Toaudit =Session["Toaudit1"].ToString();
                Label1.Text =Toaudit;
            }
          
        }
        public void GetInvestlist()
        {
            Admin_BLL.Shops_AuditBLL auditBLL = new Admin_BLL.Shops_AuditBLL();
            GetInvest.DataSource = auditBLL.Getinvest();
            GetInvest.DataBind();
        }

        protected void GetInvest_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int investid = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Particular")
            {
                Response.Redirect("shopping_detailed.aspx?investid="+ investid);
            }
            if (e.CommandName == "Delete")
            {
                int mid =Convert.ToInt32(Session["Mid"]);
                Admin_BLL.Shops_AuditBLL auditBLL = new Admin_BLL.Shops_AuditBLL();
                int count = auditBLL.UpDelete(investid,mid);
                if (count>0)
                {
                    GetInvestlist();
                }
            }
        }
    }
}