<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Admin_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <title>Welcome to Administrator Login :: BS Inter College</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="keywords" content="">
    <meta name="author" content="">

   <!-- Bootstrap Styles -->
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/style.css" rel="stylesheet" />

    <!-- RS PLUGIN Styles -->
    <link rel="stylesheet" type="text/css" href="/rs-plugin/css/settings.css" media="screen" />
    <script src="/js/modernizr.custom.js"></script>

    <!-- Support for HTML5 -->
    <!--[if lt IE 9]>
    <script src="//html5shim.googlecode.com/svn/trunk/html5.js"></script>
  <![endif]-->

    <!-- Enable media queries on older browsers -->
    <!--[if lt IE 9]>
    <script src="assets/js/respond.min.js"></script>
  <![endif]-->
</head>
<body>
    <form id="form1" runat="server">

        <div id="wrapper">


            <header class="header-wrapper">
                <div class="container">
                    <div class="col-lg-2 col-md-2 col-sm-2">
                        <a class="cssLogo" href="/Default">
                            <img style="height:90px;" src="/images/bsic_logo.png" alt="" /></a>
                    </div>
                    <!-- /col10 -->
                </div>
                <!-- /container -->
            </header>
            <!-- /header wrapper -->

            <section class="colon14">

                <div class="singleheader">
                    <div class="container">
                        <div class="col-lg-6 col-sm-6 col-md-6">
                            <div class="single-title">
                                <h3>Administrator Login</h3>
                            </div>
                        </div>
                    </div>
                    <div class="shadow"></div>
                </div>

                <!-- START CONTENT AND SIDEBAR -->
                <div class="container general">

                    <div id="content" class="single col-lg-8 col-md-8 col-sm-12">

                        <div class="login-form" data-effect="slide-bottom">
                            <h3>Enter Administrator Login Credential</h3>

                            <asp:Label ID="lblError" CssClass="alert alert-danger" Visible="false" runat="server" Text=""></asp:Label>
                            <br /><br />
                            <div class="col-sm-6 col-lg-6 col-md-6">
                                <asp:TextBox ID="txtUserName" CssClass="form-control" placeholder="Enter User Name" runat="server"></asp:TextBox>
                                <br />
                                <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" placeholder="Enter Password" runat="server"></asp:TextBox>
                                <br />
                                <asp:Button ID="btnLogin" CssClass="btn btn-primary" runat="server" Text="Login" />
                                <br />
                                <br />
                            </div>


                        </div>

                        <div class="clearfix"></div>
                    </div>
                    <!-- end content -->


                </div>
                <!-- end container -->

                <!-- END CONTENT AND SIDEBAR -->

            </section>
            <!-- end colon1 -->



            <div class="copyright-wrapper">
                <div class="container">
                    <div class="col-lg-6 col-md-6 col-sm-6">
                        <span class="copyright">Designed By <a href="http://www.mohdwebsolution.com">MWS</a>
                        </span>
                    </div>
                </div>
            </div>
            <div class="dmtop">Scroll to Top</div>
        </div>
        <!-- /wrapper -->

              <!-- Main Scripts-->
        <script type="text/javascript" src="/js/jquery.js"></script>
        <script type="text/javascript" src="/js/bootstrap.min.js"></script>
        <script type="text/javascript" src="/js/jquery.transit.min.js"></script>
        <script type="text/javascript" src="/js/retina-1.1.0.js"></script>
        <script type="text/javascript" src="/js/jquery.unveilEffects.min.js"></script>
        <script type="text/javascript" src="/js/fhmm.js"></script>
        <script type="text/javascript" src="/js/application.js"></script>

    </form>
</body>
</html>
