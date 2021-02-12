using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_BLL;

namespace Pigfly_admin
{
    public partial class TheShops_Audit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TheList();

                string Toaudit = Session["Toaudit"].ToString();
                Label1.Text = Toaudit;
            }
        }
        public void TheList()
        {
            The_capitalBLL capitalBLL = new The_capitalBLL();
            RepeaterTheList.DataSource = capitalBLL.the_CapitalsList();
            RepeaterTheList.DataBind();
        }

        protected void RepeaterTheList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int Theid = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Particular")
            {
                Response.Redirect("Theshopping.aspx?Theid=" + Theid);
            }
            if (e.CommandName == "Delete")
            {
                int mid = Convert.ToInt32(Session["Mid"]);
               
                The_capitalBLL the = new The_capitalBLL();
                int count = the.ManagementToDelete(Theid, mid);
                if (count > 0)
                {
                    TheList();
                }
            }
        }
    }
}