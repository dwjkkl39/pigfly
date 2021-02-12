using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Admin_BLL;
using Admin_Model;

namespace Pigfly_admin
{
    public partial class Products_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Repeater1List();
            }
        }
        public void Repeater1List()
        {
            JoinTheManagementBLL joinThe = new JoinTheManagementBLL();
            Repeater1.DataSource = joinThe.joininfors();
            Repeater1.DataBind();
            HomeBLL bLL = new HomeBLL();
            Repeater2.DataSource = bLL.HomeTojoinin();
            Repeater2.DataBind();

        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int JId = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Disable")
            {
                int Jshow = 1;
                JoinTheManagementBLL joinThe = new JoinTheManagementBLL();
                int count = joinThe.Disable(Jshow, JId);
                if (count > 0)
                {
                    Repeater1List();
                }
            }

            if (e.CommandName == "JoinDelete")
            {
                int Jdelete = Convert.ToInt32(Session["Mid"]);
                JoinTheManagementBLL joinThe = new JoinTheManagementBLL();
                int count = joinThe.Joindelete(Jdelete, JId);
                if (count > 0)
                {
                    Repeater1List();
                }
            }

        }


        //protected void rptTruckList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        HtmlTableCell cell = null;
        //        LogisticsAdmin.Model.TruckListModel truck = new TruckListModel();
        //        truck = (TruckListModel)e.Item.DataItem;
        //        cell = e.Item.FindControl("tbState") as HtmlTableCell;
        //        switch (truck.State)
        //        {
        //            case 1:
        //                cell.InnerHtml = "<font color='red'>承运中<font>";
        //                break;
        //            case 2:
        //                cell.InnerHtml = "空闲中";
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //}

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlTableCell cell = null;
                JoininforModel truck = new JoininforModel();
                truck = (JoininforModel)e.Item.DataItem;
                cell = e.Item.FindControl("JshowId") as HtmlTableCell;
                switch (truck.Jshow)
                {
                    case 1:
                        cell.InnerHtml = "<font color='red'>展示<font>";
                        break;
                    case 0:
                        cell.InnerHtml = "关闭";
                        break;
                    default:
                        break;
                }

            }
            }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = TxtName.Value;
            JoinTheManagementBLL joinThe = new JoinTheManagementBLL();
            Repeater1.DataSource = joinThe.Thequery(name);
            Repeater1.DataBind();
        }
    }
}