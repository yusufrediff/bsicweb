<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Admin_Default" %>

<%@ Register Src="AdminControl/AdminFooter.ascx" TagName="adminFooter" TagPrefix="uc1" %>
<%@ Register Src="AdminControl/adminHeader.ascx" TagName="adminHeader" TagPrefix="uc2" %>

<!DOCTYPE html>
<html class="no-js" lang="en">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <title>BS Inter College : Administrator Control Panel</title>
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

    <!-- http://www.456bereastreet.com/archive/201209/tell_css_that_javascript_is_available_asap/ -->
    <script>
        document.documentElement.className = document.documentElement.className.replace(/(\s|^)no-js(\s|$)/, '$1js$2');
    </script>

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

            <uc2:adminHeader ID="adminHeader1" runat="server" />

                <section class="colon7">
    	<div class="overlay">
            <div class="container">
                <div class="divider"></div>
                <div class="col-lg-3 col-md-3 col-sm-6" data-effect="slide-bottom">
                    <div class="custom-box">
                        <div class="icn-main-container"><p class="center"><span class="icn-container"><i class="icon-user"></i></span></p></div> 
                        <h3>2500</h3>
                        <p>Total Registered</p>
                    </div>
                </div>
                
                <div class="col-lg-3 col-md-3 col-sm-6" data-effect="slide-bottom">
                    <div class="custom-box">
                        <div class="icn-main-container"><p class="center"><span class="icn-container"><i class="icon-shopping-cart"></i></span></p></div> 
                        <h3>2500</h3>
                        <p>Total Paid</p>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-6" data-effect="slide-bottom">
                    <div class="custom-box">
                        <div class="icn-main-container"><p class="center"><span class="icn-container"><i class="icon-bar-chart"></i></span></p></div> 
                       <h3>2500</h3>
                        <p>Total Enrolled</p>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-6" data-effect="slide-bottom">
                    <div class="custom-box">
                        <div class="icn-main-container"><p class="center"><span class="icn-container"><i class="icon-tags"></i></span></p></div> 
                        <h3>2500</h3>
                        <p>Total Amount</p>
                    </div>
                </div>
            </div>
            <div class="divider"></div>
        </div><!-- overlay -->
    </section>
    <br /><br /><br /><br /><br /><br /><br /><br /><br />
	<br /><br /><br /><br /><br /><br /><br /><br /><br />
    <br /><br /><br /><br /><br />


            <uc1:adminFooter ID="adminFooter1" runat="server" />

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

