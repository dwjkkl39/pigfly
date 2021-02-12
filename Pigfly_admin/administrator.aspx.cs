using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_BLL;
using Admin_Model;
using pigfly_admin.Ms.Common;
namespace Pigfly_admin
{
    public partial class administrator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RepeaterList();
            }
        }
        public void RepeaterList()
        {
            string Name = txtName.Value;
            string Addtime = start.Value;
            Admin_BLL.administratorBLL administratorBLL = new Admin_BLL.administratorBLL();
            Repeatertable.DataSource = administratorBLL.administators(Name, Addtime);
            Repeatertable.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            RepeaterList();
        }

        

        protected void Button1_Click1(object sender, EventArgs e)
        {
            administatorsModel administatorsModel = new administatorsModel();
            administatorsModel.midName = username.Value;
            if (newpassword2.Value == userpassword.Value)
            {
                administatorsModel.mpassword = userpassword.Value;
            }
            else 
            {
                JSHelper.Alert(this, "两次密码输入不一致");
            }
            administatorsModel.mphone = txtphone.Value;
            administatorsModel.mailbox = email.Value;
            Admin_BLL.administratorBLL administratorBLL = new Admin_BLL.administratorBLL();
            int count = administratorBLL.insert(administatorsModel);
            if (count > 0)
            {
                JSHelper.Alert(this, "添加成功");
                RepeaterList();
            }
            else 
            {
                JSHelper.Alert(this, "添加失败");
            }
        }

        protected void Repeatertable_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int mid = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Delete")
            {

                administratorBLL administratorBLL = new administratorBLL();
                int count = administratorBLL.Deleteadministators(mid);
                if (count > 0)
                {
                    RepeaterList();
                }
            }
            if (e.CommandName == "Edit")
            {

                administratorBLL administratorBLL = new administratorBLL();
                int count = administratorBLL.Updatedministators(mid);
                if (count > 0)
                {
                    RepeaterList();
                }
            }
        }
    }
}