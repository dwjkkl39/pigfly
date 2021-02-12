using pigfly_admin.Ms.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_BLL;
using Admin_Model;
using System.Net;

namespace Pigfly_admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 登录事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {

            //string Name = username.Value;
            //string pwd = userpwd.Value;
            //if (string.IsNullOrWhiteSpace(Name))
            //{
            //    JSHelper.Alert(this, "用户名不能为空");
            //    return;
            //}
            //if (string.IsNullOrWhiteSpace(pwd))
            //{
            //    JSHelper.Alert(this, "密码不能为空");
            //    return;
            //}
            //LoginBLL loginBLL = new LoginBLL();
            //     administatorsModel result = loginBLL.Login(Name, pwd);
            //    if (result.midName != null && result.mpassword != null)
            //    {
            //    if (hua)
            //    {

            //        JSHelper.Alert(this, "登录成功");
            //        Session["Name"] = result.midName;
            //        Session["Mid"] = result.mid;
                  
            //        int Id = result.mid;
            //        string Name2 = result.midName;
            //        string Ip = GetAddressIP();
            //        LoginHistoryBLL historyBLL = new LoginHistoryBLL();
            //        historyBLL.insert(Id, Name2, Ip);
            //        Response.Redirect("~/index.aspx");

            //    }
            //    else 
            //    {
            //        JSHelper.Alert(this, "请输入正确验证码");
            //        username.Value = "";
            //        username.Value = "";
            //        userpwd.Value = "";
            //        Codes_text.Value = "";
            //    }
            //}
            //    else
            //    {
            //        JSHelper.Alert(this, "登录失败");
            //    username.Value = "";
            //    userpwd.Value = "";
            //    Codes_text.Value = "";
            //}

            }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
           // ImageButton1.ImageUrl = "Handler1.ashx?id=" + new Random().Next(100);
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

