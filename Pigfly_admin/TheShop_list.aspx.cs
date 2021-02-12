using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Admin_BLL;

namespace Pigfly_admin
{
    public partial class TheShop_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ApprovedList();
            }
        }
        public void ApprovedList()
        {
            The_capitalBLL the = new The_capitalBLL();
            Repeater1.DataSource = the.the_CapitalsList();
            Repeater1.DataBind();
            HomeBLL bLL = new HomeBLL();
            Repeater2.DataSource = bLL.HomeThe_capital();
            Repeater2.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Thename = Txtinvestname.Value;
            The_capitalBLL the = new The_capitalBLL();
            Repeater1.DataSource = the.the_Thequery(Thename);
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int Theid = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Delete")
            {
                int mid = Convert.ToInt32(Session["Mid"]);
                The_capitalBLL the = new The_capitalBLL();
                int count = the.ManagementToDelete(Theid,mid);
                if (count>0)
                {
                    ApprovedList();
                }
               
            }
        }
    }
}