using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_BLL;
using Admin_Model;
using pigfly_admin.Ms.Common;

namespace Pigfly_admin
{
    public partial class home : System.Web.UI.Page
    {
        public HomeJoininforModel JoininforModel;
        public HomeModel homeModel;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                top();

                Label1.Text = GetAddressIP();


            }
        }
        public void top()
        {
            HomeBLL bLL = new HomeBLL();
            Repeater1.DataSource = bLL.HomeTheuser();
            Repeater1.DataBind();
            Repeater2.DataSource = bLL.HomeTojoinin();
            Repeater2.DataBind();
            Repeater3.DataSource = bLL.Homeinvestment();
            Repeater3.DataBind();
            Repeater4.DataSource = bLL.HomeThe_capital();
            Repeater4.DataBind();

            JoininforModel = bLL.HomeJoininfor();
            homeModel = bLL.HomeProjectreleased();

        }
        public static string GetAddressIP()
        {
            ///获取本地的IP地址
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                }
            }
            return AddressIP;
        }
    }
}