<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Pigfly_admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="assets/css/font-awesome.min.css" />
    <!--[if IE 7]>
		  <link rel="stylesheet" href="assets/css/font-awesome-ie7.min.css" />
		<![endif]-->
    <link rel="stylesheet" href="assets/css/ace.min.css" />
    <link rel="stylesheet" href="assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="assets/css/ace-skins.min.css" />
    <link rel="stylesheet" href="css/style.css" />
    <!--[if lte IE 8]>
		  <link rel="stylesheet" href="assets/css/ace-ie.min.css" />
		<![endif]-->
    <script src="assets/js/ace-extra.min.js"></script>
    <!--[if lt IE 9]>
		<script src="assets/js/html5shiv.js"></script>
		<script src="assets/js/respond.min.js"></script>
		<![endif]-->
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/verify.js"></script>
    <link rel="stylesheet" type="text/css" href="css/verify.css">
    <%--<script type="text/javascript" src="js/jquery-1.3.1.js"></script>--%>
</head>
<body class="login-layout Reg_log_style">
    <form id="form1" runat="server">
        <div class="logintop">
            <span>欢迎后台管理界面平台</span>
            <ul>
                <li><a href="#">返回首页</a></li>
                <li><a href="#">帮助</a></li>
                <li><a href="#">关于</a></li>
            </ul>
        </div>
        <div class="loginbody">
            <div class="login-container">
                <div class="center">
                    <%--   <img src="images/logo1.png" />    登录主logo--%>
                </div>

                <div class="space-6"></div>

                <div class="position-relative">
                    <div id="login-box" class="login-box widget-box no-border visible">
                        <div class="widget-body">
                            <div class="widget-main">
                                <h4 class="header blue lighter bigger">
                                    <i class="icon-coffee green"></i>
                                    管理员登录
                                </h4>

                                <div class="login_icon">
                                    <img src="images/login.png" /></div>


                                <fieldset>
                                 <%--   <ul>
                                  <li class="frame_style form_error">
                                            <label class="user_icon"></label>
                                            <input name="用户名" type="text" id="txtName" runat="server" /><i>用户名</i></li>
                                        <li class="frame_style form_error">
                                            <label class="password_icon"></label>
                                            <input name="密码" type="password" id="txtPwd" runat="server" /><i>密码</i></li>




                                    </ul>      --%>

                                   <%-- <div id="mpanel1"></div>--%>
                                    <div id="mpanel4" ></div>

                                    <div class="space"></div>
                                    <div class="clearfix">
                                        <label class="inline">
                                            <input type="checkbox" class="ace" id="ckRemember" runat="server" />
                                            <span class="lbl">保存密码</span>
                                        </label>


                                        <input type="button" id="button" value="登录" runat="server" onclick="sumbmit()" />
                                    </div>

                                    <div class="space-4"></div>
                                </fieldset>


                                <div class="social-or-login center">
                                    <span class="bigger-110">通知</span>
                                </div>




                                <div class="toolbar clearfix">
                                </div>
                            </div>
                            <!-- /widget-body -->
                        </div>
                        <!-- /login-box -->
                    </div>
                    <!-- /position-relative -->
                </div>
            </div>
    </form>
</body>
</html>
<script type="text/javascript">
    var state = 0;
    //$('#mpanel1').slideVerify({
    //    type: 1,		//类型
    //    vOffset: 5,	//误差量，根据需求自行调整
    //    barSize: {
    //        width: '80%',
    //        height: '40px',
    //    },
    //    ready: function () {

    //    },
    //    success: function () {
    //        state = 1;
    //    },
    //    error: function () {
    //        state = 0;
    //        alert('验证失败！');
    //    }

    //});
    $('#mpanel4').slideVerify({
        type: 2,   //类型
        vOffset: 5,  //误差量，根据需求自行调整
        vSpace: 5, //间隔
        imgName: ['1.jpg', '2.jpg'],
        imgSize: {
            width: '400px',
            height: '200px',
        },
        blockSize: {
            width: '40px',
            height: '40px',
        },
        barSize: {
            width: '400px',
            height: '40px',
        },
        ready: function () {
        },
        success: function () {
            alert('验证成功，添加你自己的代码！');
            //......后续操作
        },
        error: function () {
            //              alert('验证失败！');
        }

    });       

    function sumbmit() {
        var Username = $("#txtName").val();
        var pwd = $("#txtPwd").val();
        if (state == 1) {
            $.ajax
                ({
                    type: "get",
                    url: "/Handler2.ashx",
                    data: { Username: Username, pwd: pwd },
                    success: function (msg) {
                        if (msg == "成功") {
                            alert(msg);
                            location.href = "/index.aspx";
                        } else {
                            alert(msg);
                        }
                    }
                });
        }

        else {
            alert('请先滑动解锁！');
        }
    }






    $('#login_btn').on('click', function () {
        var num = 0;
        var str = "";
        $("input[type$='text'],input[type$='password']").each(function (n) {
            if ($(this).val() == "") {

                layer.alert(str += "" + $(this).attr("name") + "不能为空！\r\n", {
                    title: '提示框',
                    icon: 0,
                });
                num++;
                return false;
            }
        });
        if (num > 0) { return false; }
        else {
            layer.alert('登录成功！', {
                title: '提示框',
                icon: 1,
            });
            location.href = "index.aspx";
            layer.close(index);
        }

    });
    $(document).ready(function () {
        $("input[type='text'],input[type='password']").blur(function () {
            var $el = $(this);
            var $parent = $el.parent();
            $parent.attr('class', 'frame_style').removeClass(' form_error');
            if ($el.val() == '') {
                $parent.attr('class', 'frame_style').addClass(' form_error');
            }
        });
        $("input[type='text'],input[type='password']").focus(function () {
            var $el = $(this);
            var $parent = $el.parent();
            $parent.attr('class', 'frame_style').removeClass(' form_errors');
            if ($el.val() == '') {
                $parent.attr('class', 'frame_style').addClass(' form_errors');
            } else {
                $parent.attr('class', 'frame_style').removeClass(' form_errors');
            }
        });
    })

</script>
