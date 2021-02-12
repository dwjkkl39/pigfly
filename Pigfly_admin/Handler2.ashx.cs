using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.SessionState;
using Admin_BLL;
using Admin_Model;
namespace Pigfly_admin
{
    /// <summary>
    /// Handler2 的摘要说明
    /// </summary>
    public class Handler2 : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {

            string Name = context.Request.QueryString["Username"];
            string pwd = context.Request.QueryString["pwd"];
            if (string.IsNullOrWhiteSpace(Name))
              {
                context.Response.Write("用户名不能为空");
                return;
              }
               if (string.IsNullOrWhiteSpace(pwd))
               {
                context.Response.Write("密码不能为空");
                return;
                }
                LoginBLL loginBLL = new LoginBLL();
             administatorsModel result = loginBLL.Login(Name, pwd);
            if (result.midName != null && result.mpassword != null)
            {
               context. Session["Name"] = result.midName;
                context.Session["Mid"] = result.mid;

                   int Id = result.mid;
                    string Name2 = result.midName;
                    string Ip = GetAddressIP();
                     LoginHistoryBLL historyBLL = new LoginHistoryBLL();
                     historyBLL.insert(Id, Name2, Ip);
                context.Response.Write("成功");
            }
            else
            {
                context.Response.Write("用户名或密码输入错误");
            }

            context.Response.ContentType = "text/plain";



         
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
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}