<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Form : B S Inter College</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="keywords" content="">
    <meta name="author" content="">

    <!-- Bootstrap Styles -->
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="style.css" rel="stylesheet" />

    <!-- RS PLUGIN Styles -->
    <link rel="stylesheet" type="text/css" href="rs-plugin/css/settings.css" media="screen" />

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
    <script language=javascript>
        function redirect() {
            window.location = "/Register";
        }
</script>
</head>
<body onload="redirect()">
    <form id="form1" runat="server">
        <div id="wrapper">







            <header class="header-wrapper">
    <div class="container">
        <div class="col-lg-12 col-md-12 col-sm-12" style="text-align:center;">
            <img style="height:90px;" src="images/bsic_logo.png" alt="" />
        </div>
        <div class="col-lg-12 col-md-12 col-sm-12" style="text-align:center;">
            <h3><strong>B. S. INTER COLLEGE, PAIGAMBARPUR, SARNATH, VARNASI</strong> </h3>
            <h4><strong> ADMISSION FORM SESSION 2020 - 2021</strong></h4>
        </div>
        <!-- /col10 -->
    </div>
    <!-- /container -->
</header>








            <!-- /header wrapper -->

            <section class="colon14">

                <!-- START CONTENT AND SIDEBAR -->
                <div class="container general">

                    <div id="content" class="single col-lg-12 col-md-12 col-sm-12">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>


                                <div class="row">
                                    <div class="form-horizontal">
                                        <asp:Label ID="lblError" CssClass="alert alert-danger" Visible="false" runat="server" Text=""></asp:Label>
                                        <br />
                                        <br />
                                        <h4><i>Student Details</i></h4>
                                         <hr>
                                        <div class="form-group">
                                            <label class="col-lg-2 control-label">Class / कक्षा</label>
                                            <div class="col-lg-4">
                                                <asp:DropDownList ID="cmbClass" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                            <label class="col-lg-2 control-label">Name/नाम</label>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtName" CssClass="form-control" placeholder="Name/नाम" runat="server"></asp:TextBox>
                                            </div>
                                           
                                           
                                        </div>
                                        <div class="form-group">
                                             
                                            <label class="col-lg-2 control-label">DOB/जन्म तिथि</label>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtDOB" CssClass="form-control" placeholder="Date of Birth/जन्म तिथि" runat="server"></asp:TextBox>
                                            </div>
                                           <label class="col-lg-2 control-label">Gender/लिंग</label>
                                            <div class="col-lg-4">
                                                <asp:DropDownList ID="cmbSex" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="M">Male</asp:ListItem>
                                                    <asp:ListItem Value="F">Female</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>

                                          
                                            
                                             </div>
                                        <div class="form-group">
                                              <label class="col-lg-2 control-label">Mob. No./मोबाइल नंबर</label>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtMobile" CssClass="form-control" placeholder="Mobile No./मोबाइल नंबर" runat="server"></asp:TextBox>
                                            </div>
                                             <label class="col-lg-2 control-label">Aadhar/आधार</label>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtAadhar" CssClass="form-control" placeholder="Aadhar No/आधार नंबर" runat="server"></asp:TextBox>
                                            </div>
                                       

                                             </div>
                                        

                                         <h4><i> Parent Details</i></h4>
                                         <hr>
                                        <div class="form-group">
                                            <label class="col-lg-2 control-label">Mother Name/माता का नाम</label>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtMotherName" CssClass="form-control" placeholder="Mother Name/माता का नाम" runat="server"></asp:TextBox>
                                            </div>
                                            <label class="col-lg-2 control-label">Father Name/पिता का नाम </label>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtFatherName" CssClass="form-control" placeholder="Father Name/पिता का नाम " runat="server"></asp:TextBox>
                                            </div>
                                            

                                        </div>

                                        <div class="form-group">

                                            <label class="col-lg-2 control-label">Mob. No./मोबाइल नंबर</label>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtFatherMobile" CssClass="form-control" placeholder="Mob. No./अभिभावक का मोबाइल नंबर" runat="server"></asp:TextBox>
                                            </div>

                                              <label class="col-lg-2 control-label">Occupation/व्यवसाय</label>
                                            <div class="col-lg-4">
                                                 <asp:TextBox ID="txtOccupation" CssClass="form-control" placeholder="Occupation/अभिभावक का व्यवसाय" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                              <label class="col-lg-2 control-label">Religion/धर्म</label>
                                            <div class="col-lg-4">
                                                 <asp:DropDownList ID="cmbReligion" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                            <label class="col-lg-2 control-label">Caste/जाति</label>
                                            <div class="col-lg-4">
                                                 <asp:DropDownList ID="cmbCast" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        
                                        <h4><i> Previous Address Details</i></h4>
                                         <hr>
                                        <div class="form-group">
                                            <label class="col-lg-2 control-label">Permanent Address/स्थाई पता</label>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtPermanentAddress" CssClass="form-control" placeholder="Permanent Address/स्थाई पता" runat="server"></asp:TextBox>
                                            </div>
                                            <label class="col-lg-2 control-label">Residential Address/स्थानीय पता</label>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtResidentialAddress" CssClass="form-control" placeholder="Residential Address/स्थानीय पता" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-lg-2 control-label">District/जिला</label>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtCity" CssClass="form-control" placeholder="District/जिला" runat="server"></asp:TextBox>
                                            </div>
                                            <label class="col-lg-2 control-label">State/प्रदेश</label>
                                            <div class="col-lg-4">
                                                <asp:DropDownList ID="cmbState" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-lg-2 control-label">Village/गाँव</label>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtVillage" CssClass="form-control" placeholder="Village/गाँव" runat="server"></asp:TextBox>
                                            </div>
                                            <label class="col-lg-2 control-label">Pin Code/पिन कोड</label>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtPinCode" CssClass="form-control" placeholder="Pin Code/पिन कोड" runat="server"></asp:TextBox>
                                            </div>
                                        </div>


                                        <h4><i> Previous Education Details</i></h4>
                                         <hr>
                                        <div class="form-group">
                                            <label class="col-lg-2 control-label">Previous Institution/पूर्व विद्यालय</label>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtPrevSchool" CssClass="form-control" placeholder="Previous Institution/पूर्व विद्यालय" runat="server"></asp:TextBox>
                                            </div>
                                            <label class="col-lg-2 control-label">Previous Class/पूर्व कक्षा</label>
                                            <div class="col-lg-4">
                                                <asp:DropDownList ID="cmbPrevClass" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-lg-2 control-label">Passing Year/उत्तीर्ण वर्ष</label>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtPassingYear" CssClass="form-control" placeholder="Passing Year/उत्तीर्ण वर्ष" runat="server"></asp:TextBox>
                                            </div>
                                            <label class="col-lg-2 control-label">Previous Mark/पूर्व प्राप्तांक</label>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtObMarks" CssClass="form-control" placeholder="Previous Mark/पूर्व प्राप्तांक" runat="server"></asp:TextBox>
                                            </div>
                                        </div>


                                        <div class="form-group">
                                            <label class="col-lg-1 control-label"></label>
                                            <div class="col-lg-10">
                                                <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Submit Form" />
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
                </div>
                <!-- end container -->

                <!-- END CONTENT AND SIDEBAR -->

            </section>
            <br />
            <br />
            <br />
            <!-- end colon1 -->







            <div class="copyright-wrapper">
                <div class="container">

                    <div class="col-lg-6 col-md-6 col-sm-6">
                        <nav>
                    <ul class="footer-menu">
                  		<li><a href="Default.aspx" title="#">Home</a></li>
                  		<li><a href="AboutUs.aspx" title="#">About</a></li>
                  		<li><a href="Strategy.aspx" title="#">Strategy</a></li>
                  		<li><a href="Packages.aspx" title="#">Packages</a></li>
                  		<li><a href="Gallery.aspx" title="#">Gallery</a></li>
                  		<li><a href="Contact.aspx" title="#">Contact us</a></li>
                    </ul>
                </nav>
                    </div>

                    <div class="col-lg-6 col-md-6 col-sm-6">
                        <span class="copyright">Designed By <a href="http://www.mohdwebsolution.in/" target="_blank">MWS</a>
                        </span>
                    </div>
                </div>
            </div>









        </div>
        <!-- /wrapper -->

        <div class="dmtop">Scroll to Top</div>


        <!-- Main Scripts-->
        <script type="text/javascript" src="js/jquery.js"></script>
        <script type="text/javascript" src="js/bootstrap.min.js"></script>
        <script type="text/javascript" src="js/jquery.transit.min.js"></script>
        <script type="text/javascript" src="js/retina-1.1.0.js"></script>
        <script type="text/javascript" src="js/jquery.unveilEffects.min.js"></script>
        <script type="text/javascript" src="js/fhmm.js"></script>
        <script type="text/javascript" src="js/application.js"></script>

        <link type="text/css" href="css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
        <script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
        <script type="text/javascript" src="js/jquery-ui-1.8.19.custom.min.js"></script>
        <script type="text/javascript">
            $(function () {
                $("#txtFromDate").datepicker({
                    dateFormat: 'dd/mm/yy'
                });
                $("#txtToDate").datepicker({
                    dateFormat: 'dd/mm/yy'
                });
            });
        </script>
    </form>
</body>
</html>
