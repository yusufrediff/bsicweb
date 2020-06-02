<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Registered.aspx.vb" Inherits="Admin_Registered" %>

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

    <link href='https://fonts.googleapis.com/css?family=Roboto:400,300,300italic,500,700,900' rel='stylesheet' type='text/css'>
    <link href="/Datatables/media/css/demo_page.css" rel="stylesheet" type="text/css" />
    <link href="/Datatables/media/css/demo_table.css" rel="stylesheet" type="text/css" />
    <link href="/Datatables/media/css/demo_table_jui.css" rel="stylesheet" type="text/css" />

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
                                <h3>Registered Students List</h3>
                            </div>
                        </div>
                    </div>
                    <div class="shadow"></div>
                </div>
                <div class="container general">
                    <div id="content" class="single col-lg-12 col-md-12 col-sm-12">
                        <asp:Label ID="lblError" CssClass="alert alert-danger" Visible="false" runat="server" Text=""></asp:Label>
                        <div class="clearfix"></div>
                        <hr>
                    
                        <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                            CellPadding="0" border="0" class="display">
                            <Columns>
                                <asp:BoundField DataField="fldDate" HeaderText="Date" SortExpression="fldDate" HtmlEncode="false" DataFormatString="{0:d}">
                                    <HeaderStyle HorizontalAlign="Left" CssClass="small_white_bold" />
                                    <ItemStyle CssClass="white_text" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RefNo" HeaderText="Ref No" SortExpression="RefNo">
                                    <HeaderStyle HorizontalAlign="Left" CssClass="small_white_bold" />
                                    <ItemStyle CssClass="white_text" />
                                </asp:BoundField>
                                <asp:BoundField DataField="fldName" HeaderText="Class" SortExpression="fldName">
                                    <HeaderStyle HorizontalAlign="Left" CssClass="small_white_bold" />
                                    <ItemStyle CssClass="white_text" />
                                </asp:BoundField>
                                <asp:BoundField DataField="StudentName" HeaderText="Name" SortExpression="StudentName">
                                    <HeaderStyle CssClass="small_white_bold" />
                                    <ItemStyle CssClass="white_text" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DOB" HeaderText="DOB" SortExpression="DOB" HtmlEncode="false" DataFormatString="{0:d}">
                                    <HeaderStyle HorizontalAlign="Left" CssClass="small_white_bold" />
                                    <ItemStyle CssClass="white_text" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AadhaarNo" HeaderText="Aadhaar" SortExpression="AadhaarNo">
                                    <HeaderStyle HorizontalAlign="Left" CssClass="small_white_bold" />
                                    <ItemStyle CssClass="white_text" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FatherName" HeaderText="Father Name" SortExpression="FatherName">
                                    <HeaderStyle HorizontalAlign="Left" CssClass="small_white_bold" />
                                    <ItemStyle CssClass="white_text" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FatherMobileNo" HeaderText="Mobile No" SortExpression="FatherMobileNo">
                                    <HeaderStyle HorizontalAlign="Left" CssClass="small_white_bold" />
                                    <ItemStyle CssClass="white_text" />
                                </asp:BoundField>
                                <asp:BoundField DataField="LocalCity" HeaderText="District" SortExpression="LocalCity">
                                    <HeaderStyle HorizontalAlign="Left" CssClass="small_white_bold" />
                                    <ItemStyle CssClass="white_text" />
                                </asp:BoundField>
                                <asp:BoundField DataField="LocalVillage" HeaderText="Area/Village" SortExpression="LocalVillage">
                                    <HeaderStyle HorizontalAlign="Left" CssClass="small_white_bold" />
                                    <ItemStyle CssClass="white_text" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PrevSchool" HeaderText="Prev School" SortExpression="PrevSchool">
                                    <HeaderStyle HorizontalAlign="Left" CssClass="small_white_bold" />
                                    <ItemStyle CssClass="white_text" />
                                </asp:BoundField>

                            </Columns>
                            <EmptyDataTemplate>
        <div align="center">No records found.</div>
    </EmptyDataTemplate>
                            <%-- Mandatory--%><RowStyle CssClass="rowStyle" />
                            <%-- Mandatory--%><HeaderStyle CssClass="headerStyle" />
                            <%-- optional--%><FooterStyle CssClass="footerStyle" />
                        </asp:GridView>
                        <div class="clearfix"></div>
                        <hr>
                    </div>
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

        <script src="/Datatables/media/js/jquery.dataTables.min.js" type="text/javascript"></script>
        <script src="/Datatables/media/js/jquery.dataTables.js" type="text/javascript"></script>
        <script src="/js/GridviewFix.js" type="text/javascript"></script>
        <script type="text/javascript">
            //without passing class names.
            $("#grd").GridviewFix().dataTable();
            //Passing class names
            //$("#grd").GridviewFix({header:"headerStyle",row:"rowStyle",footer:"footerStyle"}).dataTable();
        </script>

    </form>
</body>
</html>
