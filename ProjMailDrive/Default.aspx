<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="shortcut icon" href="../../assets/ico/favicon.ico">
    <title>Mail Drive</title>
    <!-- Bootstrap core CSS -->
    <link href="css-yeti/bootstrap.min.css" rel="stylesheet" />
    <link href="css-yeti/mycss.css" rel="stylesheet" />
    <!-- Custom styles for this template -->
    <!-- Just for debugging purposes. Don't actually copy this line! -->
    <!--[if lt IE 9]><script src="../../assets/js/ie8-responsive-file-warning.js"></script><![endif]-->
    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <style type="text/css"></style>
</head>
<body>
    <div class="navbar-default" role="banner">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed btn btn-info" data-toggle="collapse"
                    data-target=".navbar-collapse">
                    <span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span><span
                        class="icon-bar"></span><span class="icon-bar"></span>
                </button>
                <h3>
                    <a href="#" class="text-primary">
                        <img class="img-responsive pull-left" src="image/mymaildrive3.png" height="45px"
                            width="35px" />
                        <span>My Mail Drive</span></a>
                </h3>
            </div>
        </div>
    </div>  
    <div class="container-fluid">
        <div class="container loginPage">
            <form runat="server" rol="form">
            <div class="panel">
                <div class="panel-body">
                    <div class="form-group input-group-lg">
                        <label>
                            Email Id :</label>
                        <asp:TextBox ID="txtUserName" runat="server" type="email" class="form-control" placeholder="Enter Email Id"
                            required="required" />
                    </div>
                    <div class="form-group input-group-lg">
                        <label>
                            Password :</label>
                        <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" class="form-control"
                            placeholder="Enter Password" required="required" />
                    </div>
                    <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary btn-block" OnClick="btnLogin_Click"
                        Text="Login"></asp:Button>
                </div>
                <asp:Label ID="Msg" ClientIDMode="Static" runat="server" CssClass="hidden navbar-fixed-top msg" />
            </div>
            </form>
        </div>
        <footer>
        
        <p>© 2014 Company, Inc. · <a href="#">Privacy</a> · <a href="#">Terms</a></p>
      </footer>
    </div>
    <script src="js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script src="js/myJS.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            if ($("#Msg").hasClass("show"))
                $("#Msg").removeClass("hidden");
            $("*").click(function () {
                $("#Msg").removeClass("show").addClass("hidden");
            });

        });
    </script>
</body>
</html>
