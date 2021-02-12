using Admin_BLL;
using Admin_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pigfly_admin
{
    public partial class index : System.Web.UI.Page
    {
        public HomeJoininforModel JoininforModel;
        public HomeModel homeModel;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Name = Session["Name"].ToString();
                LabelName.Text = Name;
                HomeBLL bLL = new HomeBLL();
                JoininforModel = bLL.HomeJoininfor();
                homeModel = bLL.HomeProjectreleased();
                int Toaudit1 = homeModel.Toaudit1;
                Session["Toaudit1"] = Toaudit1;
                int Toaudit = homeModel.Toaudit;
                Session["Toaudit"] = Toaudit;
            }

        }
    }
}