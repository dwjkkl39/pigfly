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
    public partial class user_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUser();
            }
            
        }

        private void BindUser() 
        {
            string Uname = txtName.Value;
            string datetimebegin = start.Value;
            UserListBLL userListBLL = new UserListBLL();
            Repeater1.DataSource=userListBLL.GetUserpigfly(Uname, datetimebegin);
            Repeater1.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindUser();
        }


        public string GetSate(int Sate) 
        {
            string msg = "";
            switch (Sate) 
            {
                case 1:
                    return msg = "加盟";
                  break;
                case 2:
                    return msg = "投资";
                    break;
                case 3:
                    return msg = "引资";
                  break;
            }
            return msg;
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName== "Delete")
            {
                int Uid =Convert.ToInt32( e.CommandArgument);
                UserListBLL userListBLL = new UserListBLL();

              int count=  userListBLL.delete(Uid);
                if (count > 0)
                {
                    JSHelper.Alert(this, "删除成功");
                    BindUser();
                }
                else {
                    JSHelper.Alert(this, "删除失败");
                }
            }
        }
    }
}