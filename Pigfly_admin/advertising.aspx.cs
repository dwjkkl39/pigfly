using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_BLL;
using pigfly_admin.Ms.Common;
using Admin_Model;
namespace Pigfly_admin
{
    public partial class advertising : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAdv();
            }
        }
        private void BindAdv() 
        {
            advertisingBLL advertisingBLL = new advertisingBLL();
            Repeater1.DataSource = advertisingBLL.Getadvertising();
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "update")
            {

                int sbefore = 0;
                int Id = Convert.ToInt32(e.CommandArgument);
                advertisingBLL advertisingBLL = new advertisingBLL();
                int count = advertisingBLL.Update(Id, sbefore);
                if (count > 0)
                {
                    BindAdv();
                }
            }
            if (e.CommandName =="delete")
            {
                int Id = Convert.ToInt32(e.CommandArgument);
                advertisingBLL advertisingBLL = new advertisingBLL();
                int count = advertisingBLL.delete(Id);
                if (count > 0)
                {
                    JSHelper.Alert(this, "删除成功");
                    BindAdv();
                }
                else
                {
                    JSHelper.Alert(this, "删除失败");
                }
            }
            
            if (e.CommandName == "update1")
            {
                int sbefore = 1;
                int Id = Convert.ToInt32(e.CommandArgument);
                advertisingBLL advertisingBLL = new advertisingBLL();

                int count = advertisingBLL.Update(Id, sbefore);
                if (count > 0)
                {
                    BindAdv();
                }
            }
        }
    }
}