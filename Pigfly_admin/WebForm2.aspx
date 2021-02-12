<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Pigfly_admin.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="https://cdn.bootcss.com/jquery/2.2.4/jquery.min.js"></script>
    <title></title>
 
</head>
<body>
    <form id="form1" runat="server">
        <div>
       <input type="file" name="file0" id="file0" multiple="multiple" /><br>
			<img src="" id="img0" style="width: 20rem;height: 15rem;">
        </div>
        <script>
            $("#file0").change(function () {
                var objUrl = getObjectURL(this.files[0]); //获取文件信息  
                console.log("objUrl = " + objUrl);
                if (objUrl) {
                    $("#img0").attr("src", objUrl);
                }
            });

            function getObjectURL(file) {
                var url = null;
                if (window.createObjectURL != undefined) {
                    url = window.createObjectURL(file);
                } else if (window.URL != undefined) { // mozilla(firefox)  
                    url = window.URL.createObjectURL(file);
                } else if (window.webkitURL != undefined) { // webkit or chrome  
                    url = window.webkitURL.createObjectURL(file);
                }
                return url;
            }
        </script>
    </form>
</body>
</html>
