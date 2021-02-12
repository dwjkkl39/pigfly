using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_BLL;
namespace Pigfly_admin
{
    public partial class Shop_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindShopList();
            }
        }
        private void BindShopList() 
        {
            ShopListBLL shopListBLL = new ShopListBLL();
            Repeater1.DataSource = shopListBLL.GetInvests();
            Repeater1.DataBind();
            HomeBLL bLL = new HomeBLL();
           
            Repeater2.DataSource = bLL.Homeinvestment();
            Repeater2.DataBind();
           
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int investid = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Delete")
            {
                int mid = Convert.ToInt32(Session["Mid"]);
                ShopListBLL shopListBLL = new ShopListBLL();
                int count = shopListBLL.UpDelete(investid, mid);
                if (count > 0)
                {
                    BindShopList();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string investname = Txtinvestname.Value;
            string investprice = Txtinvestprice.Value;
            string investcontent = Txtinvestcontent.Value;
            string investtime =start.Value;
            ShopListBLL shopListBLL = new ShopListBLL();
            Repeater1.DataSource = shopListBLL.QueryInvests(investname, investprice, investcontent, investtime);
            Repeater1.DataBind();
           
        }
    }
}