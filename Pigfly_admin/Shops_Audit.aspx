﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shops_Audit.aspx.cs" Inherits="Pigfly_admin.Shops_Audit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="renderer" content="webkit|ie-comp|ie-stand">
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<meta http-equiv="Cache-Control" content="no-siteapp" />
 <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
        <link rel="stylesheet" href="css/style.css"/>       
        <link href="assets/css/codemirror.css" rel="stylesheet">
        <link rel="stylesheet" href="assets/css/ace.min.css" />
        <link rel="stylesheet" href="font/css/font-awesome.min.css" />
        <!--[if lte IE 8]>
		  <link rel="stylesheet" href="assets/css/ace-ie.min.css" />
		<![endif]-->
		<script src="js/jquery-1.9.1.min.js"></script>
        <script src="assets/js/bootstrap.min.js"></script>
		<script src="assets/js/typeahead-bs2.min.js"></script>           	
		<script src="assets/js/jquery.dataTables.min.js"></script>
		<script src="assets/js/jquery.dataTables.bootstrap.js"></script>
        <script src="assets/layer/layer.js" type="text/javascript" ></script>          
        <script src="assets/laydate/laydate.js" type="text/javascript"></script>
        <script src="js/displayPart.js" type="text/javascript"></script>
<title>交易金额</title>
</head>

<body>
    <form  runat="server">
<div class="margin clearfix">
 <div class="Shops_Audit">
   <div class="prompt">当前共有<b> <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> </b>条信息待审核</div>
   <!--申请列表-->
   <div class="audit_list">
     <table class="table table-striped table-bordered table-hover" id="sample-table">
       <thead>
		 <tr>
            <th width="180px">公司名称</th>
            <th width="120px">投资分类</th>
            <th width="120px">投资资金</th>
            <th width="">简介</th>
            <th width="150px">添加时间</th>
            <th width="100px">审核状态</th>                
            <th width="250px">操作</th>
			</tr>
		</thead>
         <asp:Repeater ID="GetInvest" runat="server" OnItemCommand="GetInvest_ItemCommand">

             <ItemTemplate>
        <tbody>
        <tr>
         <td><%#Eval("investname") %></td>
         <td><%#Eval("investcontent") %></td>
         <td><%#Eval("investprice") %></td>
         <td class="displayPart" displayLength="80"><%#Eval("investProjectContent") %></td>
         <td><%# Eval("investtime")%></td>
         <td><%#Convert.ToInt32(Eval("investstate"))==0?"<p style='color:red'>未审核</p>":"已审核" %></td>
          <td class="td-manage">
<%--           <a title="店铺详细" href="shopping_detailed.html?investid+'=<%#Eval("investid") %>'" class="btn btn-xs btn-info Refund_detailed">详细</a>   --%>
        <asp:LinkButton ID="Particular" runat="server"   class="btn btn-xs btn-info Refund_detailed" CommandName="Particular" CommandArgument='<%#Eval("investid")%>'>详细</asp:LinkButton>
        <asp:LinkButton ID="IdDelete" runat="server"   class="btn btn-xs btn-danger" CommandName="Delete" CommandArgument='<%#Eval("investid")%>'>删除</asp:LinkButton>

        <%--   <a title="删除" href="javascript:;"  onclick="member_del(this,'1')" class="btn btn-xs btn-danger" >删除</a>--%>
           
          </td>
        </tr>
        </tbody>
                   </ItemTemplate>
         </asp:Repeater>
        </table>
   
   </div>
 </div>
</div>
         </form>
</body>
   
</html>
<script>
$(function () {  
        $(".displayPart").displayPart();  
   });
$(function() {
		var oTable1 = $('#sample-table').dataTable( {
		//"aaSorting": [],//默认第几个排序
		"bStateSave": true,//状态保存
		//"dom": 't',
		"bFilter":false,
		"aoColumnDefs": [
		  //{"bVisible": false, "aTargets": [ 3 ]} //控制列的隐藏显示
		  {"orderable":false,"aTargets":[0,1,2,3,4,5,6]}// 制定列不参与排序
		] } );
				$('table th input:checkbox').on('click' , function(){
					var that = this;
					$(this).closest('table').find('tr > td:first-child input:checkbox')
					.each(function(){
						this.checked = that.checked;
						$(this).closest('tr').toggleClass('selected');
					});
						
				});
})
/*店铺-删除*/
function member_del(obj,id){
	layer.confirm('确认要删除吗？',{icon:0,},function(index){
		$(obj).parents("tr").remove();
		layer.msg('已删除!',{icon:1,time:1000});
	});
}
//面包屑返回值
var index = parent.layer.getFrameIndex(window.name);
parent.layer.iframeAuto(index);
$('.Refund_detailed').on('click', function(){
	var cname = $(this).attr("title");
	var chref = $(this).attr("href");
	var cnames = parent.$('.Current_page').html();
	var herf = parent.$("#iframe").attr("src");
    parent.$('#parentIframe').html(cname);
    parent.$('#iframe').attr("src",chref).ready();;
	parent.$('#parentIframe').css("display","inline-block");
	parent.$('.Current_page').attr({"name":herf,"href":"javascript:void(0)"}).css({"color":"#4c8fbd","cursor":"pointer"});
	//parent.$('.Current_page').html("<a href='javascript:void(0)' name="+herf+" class='iframeurl'>" + cnames + "</a>");
    parent.layer.close(index);
	
});
</script>
