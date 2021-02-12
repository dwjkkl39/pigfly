using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pigfly_admin.Ms.Common;

namespace Pigfly_admin
{
    public partial class shopping_detailed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetdetailsList();
            }
        }
        public void GetdetailsList()
        {
            int investid =Convert.ToInt32( Request.QueryString["investid"]);

            Admin_BLL.Shops_AuditBLL auditBLL = new Admin_BLL.Shops_AuditBLL();
            Getdetails.DataSource = auditBLL.Getdetails(investid);
            Getdetails.DataBind();
        }

        protected void PassBtn_Click(object sender, EventArgs e)
        {
            int Mid = Convert.ToInt32(Session["Mid"]);
            int investid = Convert.ToInt32(Request.QueryString["investid"]);
            Admin_BLL.Shops_AuditBLL auditBLL = new Admin_BLL.Shops_AuditBLL();
            int count = auditBLL.UpInveststate(investid,Mid);
            if (count>0)
            {
                JSHelper.Alert(this,"审核通过");
                Response.Redirect("Shops_Audit.aspx");
            }
        }

        protected void RefuseBtn_Click(object sender, EventArgs e)
        {
            int Mid = Convert.ToInt32(Session["Mid"]);
            int investid = Convert.ToInt32(Request.QueryString["investid"]);
            Admin_BLL.Shops_AuditBLL auditBLL = new Admin_BLL.Shops_AuditBLL();
            int count = auditBLL.UpRefuse(investid, Mid);
            if (count > 0)
            {
                JSHelper.Alert(this, "拒绝通过");
                Response.Redirect("Shops_Audit.aspx");
            }
        }
    }
}