using Admin_BLL;
using Admin_Model;
using pigfly_admin.Ms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pigfly_admin
{
    public partial class admin_info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                QuerymidName();
                BindLogin();
            }
        }
        public void QuerymidName()
        {
            string Name = Session["Name"].ToString();
            Admin_BLL.admin_infoBLL infoBLL = new Admin_BLL.admin_infoBLL();
            administatorsModel model = infoBLL.QuerymidName(Name);
            IdmidName.Value = model.midName;
            IdSex.Value = model.Sex.ToString();
            IdAge.Value = model.Age.ToString();
            Idmphone.Value = model.mphone;
            Idmailbox.Value = model.mailbox;
            IdAddtime.Value = model.Addtime.ToString();
        }

        protected void UPdate_Click(object sender, EventArgs e)
        {
            IdmidName.Value ="";
            IdSex.Value = "";
            IdAge.Value = "";
            Idmphone.Value ="";
            Idmailbox.Value = "";
            UPdateEdit.Visible = true;


        }

        protected void UPdateEdit_Click(object sender, EventArgs e)
        {
            string SessionName = Session["Name"].ToString();

            administatorsModel model = new administatorsModel();
            model.midName = IdmidName.Value;
            model.Sex =Convert.ToInt32( IdSex.Value);
            model.Age= Convert.ToInt32(IdAge.Value);
            model.mphone = Idmphone.Value;
            model.mailbox = Idmailbox.Value;
            Admin_BLL.admin_infoBLL infoBLL = new Admin_BLL.admin_infoBLL();
            int count = infoBLL.Updateadministators(model, SessionName);
            if (count>0)
            {
                JSHelper.Alert(this,"修改成功");
            }
        }
        private void BindLogin()
        {
            LoginHistoryBLL loginHistorybll = new LoginHistoryBLL();
            List<LoginHistoryModel> logins = loginHistorybll.SelectLogin();
            Repeater1.DataSource = logins;
            Repeater1.DataBind();

        }
    }
}