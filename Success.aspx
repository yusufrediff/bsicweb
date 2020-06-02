<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Success.aspx.vb" Inherits="Success" %>

<%@ Register src="Controls/Footer.ascx" tagname="Footer" tagprefix="uc1" %>
<%@ Register src="Controls/Header.ascx" tagname="Header" tagprefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Form : B S Inter College</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="keywords" content="">
    <meta name="author" content="">

    <!-- Bootstrap Styles -->
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/style.css" rel="stylesheet" />

    <!-- RS PLUGIN Styles -->
    <link rel="stylesheet" type="text/css" href="/rs-plugin/css/settings.css" media="screen" />

    <!-- http://www.456bereastreet.com/archive/201209/tell_css_that_javascript_is_available_asap/ -->

    <script type="text/javascript" src="js/modernizr.custom.js"></script>

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







            <uc2:Header ID="Header1" runat="server" />
            






            <!-- /header wrapper -->

             <section class="colon14">

                <div class="singleheader">
                    <div class="container">
                        <div class="col-lg-6 col-sm-6 col-md-6">
                            <div class="single-title">
                                <h3>Registration Successfull</h3>
                            </div>
                        </div>

                    </div>
                    <div class="shadow"></div>
                </div>

                <!-- START CONTENT AND SIDEBAR -->
                <div class="container general">

                    <div id="content" class="single col-lg-12 col-md-12 col-sm-12">

                                <div class="row">
                                    <h2 style="color:red;">Ref No : <%=iRefNo %></h2>
                                    <h4>Name : <%=iName%></h4>
                                    <h4>Mobile No : <%=iMobile%></h4>
                                    <br />
                                    <p>Please note the above details for further communication.</p>
                                    <br />
                                    <p>click <a href="#">here</a> to Pay fees </p>
                                </div>
                           
                        <div class="clearfix"></div>
                        <hr>
                    </div>
                </div>
                <!-- end container -->

                <!-- END CONTENT AND SIDEBAR -->

            </section>
            <br />
            <br />
            <br />
            <!-- end colon1 -->






<uc1:Footer ID="Footer1" runat="server" />
            






        </div>
        <!-- /wrapper -->

        <div class="dmtop">Scroll to Top</div>


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
