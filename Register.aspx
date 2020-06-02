<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Register.aspx.vb" Inherits="Register" %>

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
    <script type="text/javascript">

        function ValidateSubmit() {
            if (document.getElementById("cmbClass").value == "Select") {
                alert("Please Select Class  !");
                document.getElementById("cmbClass").focus();
                return false;
            }
            else if (document.getElementById("txtName").value == "") {
                alert("Please enter Name  !");
                document.getElementById("txtName").focus();
                return false;
            }
            else if (document.getElementById("txtDOB").value == "") {
                alert("Please enter DOB  !");
                document.getElementById("txtDOB").focus();
                return false;
            }
            else if (document.getElementById("txtMotherName").value == "") {
                alert("Please enter Mother Name  !");
                document.getElementById("txtMotherName").focus();
                return false;
            }
            else if (document.getElementById("txtFatherName").value == "") {
                alert("Please enter Father Name  !");
                document.getElementById("txtFatherName").focus();
                return false;
            }
            else if (document.getElementById("txtFatherMobile").value == "") {
                alert("Please enter Father Mobile  !");
                document.getElementById("txtFatherMobile").focus();
                return false;
            }
        }
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                //alert("Please enter only Numbers.");
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">





<uc2:Header ID="Header1" runat="server" />
            






            <!-- /header wrapper -->

            <section class="colon14">

                <!-- START CONTENT AND SIDEBAR -->
                <div class="container general">

                    <div id="content" class="single col-lg-12 col-md-12 col-sm-12">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>--%>


                                <div class="row">
                                    <div class="form-horizontal">
                                        <asp:Label ID="lblError" CssClass="alert alert-danger" Visible="false" runat="server" Text=""></asp:Label>
                                        <br />
                                        <br />
                                        <h4><i>Student Details</i></h4>
                                         <hr>
                                        <div class="form-group">
                                            <label class="col-lg-2 control-label">Class / कक्षा <span style="color:red;">*</span></label>
                                            <div class="col-lg-4">
                                                <asp:DropDownList ID="cmbClass" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                            <label class="col-lg-2 control-label">Name/नाम<span style="color:red;">*</span></label>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtName" CssClass="form-control" placeholder="Name/नाम" runat="server"></asp:TextBox>
                                            </div>
                                           
                                           
                                        </div>
                                        <div class="form-group">
                                             
                                            <label class="col-lg-2 control-label">DOB/जन्म तिथि<span style="color:red;">*</span></label>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtDOB" autocomplete="off" CssClass="form-control" BackColor="White" placeholder="Date of Birth/जन्म तिथि" runat="server" AutoCompleteType="Notes"></asp:TextBox>
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
                                            <label class="col-lg-2 control-label">Mother Name/माता का नाम<span style="color:red;">*</span></label>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtMotherName" CssClass="form-control" placeholder="Mother Name/माता का नाम" runat="server"></asp:TextBox>
                                            </div>
                                            <label class="col-lg-2 control-label">Father Name/पिता का नाम <span style="color:red;">*</span></label>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtFatherName" CssClass="form-control" placeholder="Father Name/पिता का नाम " runat="server"></asp:TextBox>
                                            </div>
                                            

                                        </div>

                                        <div class="form-group">

                                            <label class="col-lg-2 control-label">Mob. No./मोबाइल नंबर<span style="color:red;">*</span></label>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtFatherMobile" onkeypress="return isNumber(event)" CssClass="form-control" placeholder="Mob. No./अभिभावक का मोबाइल नंबर" runat="server"></asp:TextBox>
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
                                            <label class="col-lg-2 control-label">Uplod Photo/फोटो अपलोड</label>
                                            <div class="col-lg-4">
                                                <asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server"></asp:FileUpload>
                                            </div>
                                           
                                        </div>

                                        <div class="form-group">
                                            <label class="col-lg-1 control-label"></label>
                                            <div class="col-lg-10">
                                                <asp:Button ID="btnSave" OnClientClick="return ValidateSubmit()" CssClass="btn btn-primary" runat="server" Text="Submit Form" />
                                                <asp:HiddenField ID="lblID" runat="server" />
                                            </div>
                                        </div>
                                        
                                    </div>
                                </div>
                           <%-- </ContentTemplate>
                        </asp:UpdatePanel>--%>
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

        <link type="text/css" href="/css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
        <script type="text/javascript" src="/js/jquery-1.7.2.min.js"></script>
        <script type="text/javascript" src="/js/jquery-ui-1.8.19.custom.min.js"></script>
        <script type="text/javascript">
            $(function () {
                $("#txtDOB").datepicker({
                    dateFormat: 'dd/mm/yy'
                });
            });
        </script>
    </form>
</body>
</html>
