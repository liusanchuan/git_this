<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>登陆</title>
<link type="text/css" rel="stylesheet" href="style/reset.css">
<link type="text/css" rel="stylesheet" href="style/main.css">
<!--[if IE 6]>
<script type="text/javascript" src="js/DD_belatedPNG_0.0.8a-min.js"></script>
<script type="text/javascript" src="js/ie6Fixpng.js"></script>
<![endif]-->
</head>

<body>
<div class="headerBar">
	<div class="logoBar login_logo">
		<div class="comWidth">
			<div class="logo fl">
				<a href="#"></a>
			</div>
			<h3 class="welcome_title">欢迎登陆</h3>
		</div>
	</div>
</div>

<div class="loginBox">
	<div class="login_cont">
		<ul class="login">

			<li class="l_tit">邮箱/用户名/手机号</li>
			<li class="mb_10"><input id="Admin_n" type="text" class="login_input user_icon" name="name"></li>
			<li class="l_tit">密码</li>
			<li class="mb_10"><input id="Admin_p" type="text" class="login_input user_icon" name="password"></li>
			<li class="autoLogin"><input type="checkbox" id="a1" class="checked"><label for="a1">自动登陆</label></li>
			
			<li><img alt="../images/login_btn.jpg" onclick="MakeForm()" src="./img/images/login_btn.jpg"> </li>

		</ul>
<script type="text/javascript">
//JavaScript 构建一个 form

function MakeForm()
{

    // 创建一个 form
    var form1 = document.createElement("form");
    form1.id = "form1";
    form1.name = "form1";

    // 添加到 body 中
    document.body.appendChild(form1);

    // 创建一个输入
    var input = document.createElement("input");
    // 设置相应参数
    input.type = "text";
    input.name = "Admin_name";
//     input.value = "1234567";
    input.value = document.getElementById("Admin_n").value;
    // 将该输入框插入到 form 中
    form1.appendChild(input);

    var inputpsd = document.createElement("input");
    // 设置相应参数
    inputpsd.type = "text";
    inputpsd.name = "Admin_password";
//     inputpsd.value = "890";
    inputpsd.value = document.getElementById("Admin_p").value;
    // 将该输入框插入到 form 中
    form1.appendChild(inputpsd);

    // form 的提交方式
    form1.method = "POST";
    // form 提交路径
    form1.action = "dologin.php";

    // 对该 form 执行提交
    form1.submit();
    // 删除该 form
    document.body.removeChild(form1);
}
</script>
		<div class="login_partners">
			<p class="l_tit">使用合作方账号登陆网站</p>
			<ul class="login_list clearfix">
				<li><a href="#">QQ</a></li>
				<li><span>|</span></li>
				<li><a href="#">网易</a></li>
				<li><span>|</span></li>
				<li><a href="#">新浪微博</a></li>
				<li><span>|</span></li>
				<li><a href="#">腾讯微薄</a></li>
				<li><span>|</span></li>
				<li><a href="#">新浪微博</a></li>
				<li><span>|</span></li>
				<li><a href="#">腾讯微薄</a></li>
			</ul>
		</div>
	</div>
	<a class="reg_link" href="#"></a>
</div>

<div class="hr_25"></div>

</body>
</html>
