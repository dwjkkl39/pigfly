using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_BLL;
using pigfly_admin.Ms.Common;

namespace Pigfly_admin
{
    public partial class Theshopping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GitList();
            }
        }
        public void GitList()
        {
            int Theid = Convert.ToInt32(Request.QueryString["Theid"]);
            The_capitalBLL capitalBLL = new The_capitalBLL();
            Getdetails.DataSource = capitalBLL.GetTheusList(Theid);
            Getdetails.DataBind();
        }

        protected void PassBtn_Click(object sender, EventArgs e)
        {
            int mid = Convert.ToInt32(Session["Mid"]);
            int Theid = Convert.ToInt32(Request.QueryString["Theid"]);
            The_capitalBLL capitalBLL = new The_capitalBLL();
            int count = capitalBLL.through(Theid, mid);
            if (count>0)
            {
                JSHelper.Alert(this, "审核通过");
                Response.Redirect("TheShops_Audit.aspx");
            }
        }

        protected void RefuseBtn_Click(object sender, EventArgs e)
        {
            int mid = Convert.ToInt32(Session["Mid"]);
            int Theid = Convert.ToInt32(Request.QueryString["Theid"]);
            The_capitalBLL capitalBLL = new The_capitalBLL();
            int count = capitalBLL.RefusedTo(Theid, mid);
            if (count > 0)
            {
                JSHelper.Alert(this, "拒绝通过");
                Response.Redirect("TheShops_Audit.aspx");
            }
        }
    }
}