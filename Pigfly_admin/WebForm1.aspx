<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Pigfly_admin.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #imgFood {
            height:150px;
            width:150px;
        }
        #fileUpLoadPic {
             height:30px;
            width:30px;
            border:1px solid red;
          background-color:aqua;
        }
    </style>
</head>
<body>
    <form method="post" runat="server">
        <div>
            
                   
                      <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("length")%>'/>
            
       <asp:Image ID="imgFood" runat="server" Height="104px" Width="106px" />
          
           <asp:FileUpload ID="fileUpLoadPic" runat="server"/> 
           <asp:Button ID="Button2" runat="server" Text="上传"  OnClick="Button2_Click1"/>
            <asp:Button ID="Button1" runat="server" Text="Button"  OnClick="Button1_Click"/>
        </div>
  
    </form>
</body>
</html>

