using pigfly_admin.Ms.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pigfly_admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List();
            }
          
        }
        public void List()
        {
            
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            if (fileUpLoadPic.HasFile) //文件存在
            {
                SaveFile(fileUpLoadPic.PostedFile);//保存上传文件
            }
            else
            {
                Response.Write("<script>alert('上传文件不存在！')</script>");
            }

            if (fileUpLoadPic.PostedFile.FileName == "")  //文件名字
            {
                Response.Write("<script>alert('你还没有选择图片！')</script>");
            }
            else
            {
                string filepath = fileUpLoadPic.PostedFile.FileName;
                string filename = filepath.Substring(filepath.LastIndexOf("\\") + 1);//第一个\转义字符
                Session["filename"] = filename;
                string fileEx = filepath.Substring(filepath.LastIndexOf(".") + 1);//从.开始截至最后得到图片格式.jpg。。。
                string serverpath = Server.MapPath("\\images\\") + filename;
                if (fileEx == "jpg" || fileEx == "bmp" || fileEx == "gif")
                {
                    imgFood.ImageUrl = "images/" + filename;
                    Response.Write("<script>alert('上传成功！')</script>");
                    return;
                }
                else
                {
                    Response.Write("<script>alert('上传的格式有问题！'）</script>");
                    return;
                }
            }


            string ii=fileUpLoadPic.AppRelativeTemplateSourceDirectory;
            JSHelper.Alert(this,ii);
        }

        public void SaveFile(HttpPostedFile file)
        {
            string savePath = "C:\\Users\\💻\\Desktop\\6组项目\\pigfly_admin.-ms\\Pigfly_admin.Ms\\Pigfly_admin\\images\\";
            string fileName = fileUpLoadPic.FileName;

            string pathToCheck = savePath + fileName;
            string tempfilename = "";
            if (System.IO.File.Exists(pathToCheck))
            {
                int counter = 2;
                while (System.IO.File.Exists(pathToCheck))
                {
                    tempfilename = counter.ToString() + fileName;
                    pathToCheck = savePath + tempfilename;
                    counter++;
                }
                fileName = tempfilename;
                Response.Write("<script>alert('你上传了两个相同文件！')</script>");
            }
            savePath += fileName;
            fileUpLoadPic.SaveAs(savePath);
            //string F_Pic = Convert.ToString(Session["filename"]);
            //string f_pic = F_Pic.Substring(0, F_Pic.LastIndexOf("."));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string filepath = Session["filename"].ToString();
            string serverpath ="\\images\\" + filepath;
            Admin_BLL.CeshiBLL ceshi = new Admin_BLL.CeshiBLL();
            int count = ceshi.Addseshi(serverpath);
            if (count>0)
            {
                JSHelper.Alert(this,"添加成功");
            }
        }
    }
}
