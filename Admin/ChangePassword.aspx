<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ChangePassword.aspx.vb" Inherits="Admin_ChangePassword" %>

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

            <section class="colon14">
                <div class="singleheader">
                    <div class="container">
                        <div class="col-lg-12 col-sm-12 col-md-12">
                            <div class="single-title">
                                <h3>Change Admin Password</h3>
                            </div>
                        </div>
                    </div>
                    <div class="shadow"></div>
                </div>




                <div class="container general">

                    <div id="content" class="single col-lg-12 col-md-12 col-sm-12">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>


                                <div class="row">
                                <div class="form-horizontal">
                                    <asp:Label ID="lblError" CssClass="alert alert-danger" Visible="false" runat="server" Text=""></asp:Label>
                                   
                                    <div class="form-group">
                                        <label class="col-lg-3 col-md-6 col-sm-6 control-label">Old Password</label>
                                        <div class="col-lg-2 col-md-3 col-sm-3">
                                            <asp:TextBox ID="txtOLDPass" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-lg-3 col-md-6 col-sm-6 control-label">New Password</label>
                                        <div class="col-lg-2 col-md-3 col-sm-3">
                                            <asp:TextBox ID="txtNewPass" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-lg-3 col-md-6 col-sm-6 control-label">New Password</label>
                                        <div class="col-lg-2 col-md-3 col-sm-3">
                                            <asp:TextBox ID="txtRePass" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                            <label class="col-lg-3 control-label"></label>
                                            <div class="col-lg-7">
                                                <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Change Password" />
                                                <asp:HiddenField ID="lblID" runat="server" />
                                            </div>
                                        </div>
                                </div>
                            </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="clearfix"></div>
                        <hr>
                    </div>
            </section>


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
