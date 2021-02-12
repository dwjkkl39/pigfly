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
    public partial class Feedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FeedbackBLL bLL = new FeedbackBLL();
                Repeater1.DataSource = bLL.OpinionsList();
                Repeater1.DataBind();
              
            }
        }

        protected void HaveToreply_Click(object sender, EventArgs e)
        {
            Session["opBrowsed"] = 1;
            FeedbackBLL bLL = new FeedbackBLL();
            Repeater1.DataSource = bLL.Havetoreply();
            Repeater1.DataBind();
        }

        protected void DidNotReturn_Click(object sender, EventArgs e)
        {
            Session["opBrowsed"] = 0;
            FeedbackBLL bLL = new FeedbackBLL();
            Repeater1.DataSource = bLL.Didnotreturn();
            Repeater1.DataBind();
        }

        protected void Advice_Click(object sender, EventArgs e)
        {
            int opBrowsed =Convert.ToInt32( Session["opBrowsed"]);
            int opType = 1;
            FeedbackBLL bLL = new FeedbackBLL();
            Repeater1.DataSource = bLL.Complaints(opBrowsed,opType);
            Repeater1.DataBind();
        }

        protected void Complaints_Click(object sender, EventArgs e)
        {
            int opBrowsed = Convert.ToInt32(Session["opBrowsed"]);
            int opType = 0;
            FeedbackBLL bLL = new FeedbackBLL();
            Repeater1.DataSource = bLL.Complaints(opBrowsed, opType);
            Repeater1.DataBind();
        }

        protected void Thequery_Click(object sender, EventArgs e)
        {
            string opContent = TxtopContent.Value;
            FeedbackBLL bLL = new FeedbackBLL();
            Repeater1.DataSource = bLL.Thequery(opContent);
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int opId = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Delete")
            {
                int mid = Convert.ToInt32(Session["Mid"]);
                FeedbackBLL bLL = new FeedbackBLL();
                int count = bLL.DeleteFeedback(opId,mid);
                if (count>0)
                {
                    Repeater1.DataSource = bLL.OpinionsList();
                    Repeater1.DataBind();
                }
            }
            if (e.CommandName == "Reply")
            {
              
            }
        }
    }
}