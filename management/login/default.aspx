<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="management_login_default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="head">
    <meta charset="utf-8" />
    <meta name="viewport" content="target-densitydpi=device-dpi, width=device-width, initial-scale=1.0, maximum-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="kingpauloaquino@mail.com" />
    <meta name="keywords" content="cms, windows 8, modern style, Metro UI, style, modern, css, framework" />

    <link href="../css/modern.css" rel="stylesheet" />
   	<link href="../css/mystyle.css" rel="stylesheet" />
    <link rel="shortcut icon" href="../images/Visualpharm-Icons8-Metro-Style-Management-Statistics.ico" />
    <script type="text/javascript" src="../js/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="../js/modern/dropdown.js"></script>
    	
	<!-- Google WebFonts -->
	<link href='http://fonts.googleapis.com/css?family=PT+Sans:regular,italic,bold,bolditalic' rel='stylesheet' type='text/css' />
	<script type='text/css' src='javascripts/admin/modernizr-1.7.min.js'></script>
	<script type="text/javascript" src="../js/cms_script.js"></script>
	<script type="text/javascript" src="../js/customPaging.js"></script>
    <title>SMSLauncher Management | Login</title>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#noti").hide();
        });
        function block_sel(str) { localStorage.clickcount = str; }
        function clear_cache() { localStorage.clickcount = 0; localStorage.cho = ""; }
        function sub_cho(str) { localStorage.cho = str; }
	</script>
    <style>
        a:hover
        {
           text-decoration: underline;
        }
        img { float: right; margin-right: 0px; }
    </style>
     <link href="../css/bootstrap-combined.min.css" rel="stylesheet">
</head>
<body id="admin_login_body" class="metrouicss">
    <form id="form1" runat="server">
    <div>
        <br />
        <div id="admin_login_nav">
		    <a href="../../../">
			    <img src="../images/back-button.png" >
		    </a>
		    <p>SMSLauncher Management System <small>1.0.0</small></p>
	    </div>
	    <div style="height: 300px; margin-top: -35px;">
		    
            <asp:Label ID="lblScript" runat="server"></asp:Label>
             <div class="login_class"> 
	            <h2>Please use your admin account to login </h2>
	            <table border="0" cellspacing="0" cellpadding="0">
		            <tr>
			            <td style="width: 120px;">Username</td>
			            <td>
                            <asp:TextBox ID="txtUser" runat="server"  class="large" placeholder="Username" ></asp:TextBox>
			            </td>
		            </tr>
		            <tr>
			            <td>Password</td>
			            <td>
                            <asp:TextBox ID="txtPass" runat="server" TextMode="Password" placeholder="Password" class="large"  ></asp:TextBox>
			            </td>
		            </tr>
		            <tr>
			            <td></td>
			            <td><input type="checkbox" name="remember_me" id="field-remember" /> Remember me</td>
		            </tr>
	            </table>
                 <a href="#" class="shower" data-source="#showme">I can't access my account </a>
                 <asp:Button ID="btnLog" runat="server" Text="Login" OnClick="btnLog_Click" />
                 <br /><br />
                 <asp:Label ID="lblerr" runat="server"></asp:Label>
            </div>
            <!-- JS Libs at the end for faster loading -->
            <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.5.1/jquery.min.js"></script>
            <script>!window.jQuery && document.write(unescape('%3Cscript src="js/jquery/jquery-1.5.1.min.js"%3E%3C/script%3E'))</script>
            <script src='javascripts/admin/selectivizr.js' type='text/javascript'></script>
            <script src='javascripts/admin/jquery.tipsy.js' type='text/javascript'></script>
            <script src='javascripts/admin/script.js' type='text/javascript'></script>
	    </div>

        <div id="showme" class="modal hide fade">
	      <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                <img src="../images/delete-icon.png" />
            </button>
		    <h3>I have a problem with my password</h3>
	      </div>
	      <div class="modal-body">
		    <p>Enter your Username!</p>
              <asp:TextBox ID="txtID" runat="server" placeholder="Username" ></asp:TextBox>
	      </div>
	      <div class="modal-footer">
                <asp:LinkButton class="btn" ID="lbSend" runat="server" OnClick="btnRecovery_Click">Send</asp:LinkButton>
	      </div>
	    </div>
	
	    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
	    <script src="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.3.2/js/bootstrap.min.js"></script>
	    <script type="text/javascript">
	        $(document).ready(function () {
	            $('.shower').click(function (event) {
	                var id = $(this).attr('data-source');
	                $(id).modal('toggle');
	            });
	        });
	    </script>

	    <%--footer--%>
        <%--footer--%>
        <div id="footer">
            <div class="container">
                <div class="left">SMSLauncher Management &copy; <% Response.Write(DateTime.Now.Year); %></div>
                <div class="right">Developed by <a href="http://facebook.com/kingpauloaquino" target="_blank"> KING PAULO AQUINO (iPaopaoworx) </a></div>
            </div>
        </div>

    </div>
    </form>
</body>
</html>
