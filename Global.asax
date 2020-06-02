<%@ Application Language="VB" %>
<%@ Import Namespace="System.Web.Routing" %>
<script RunAt="server">
    Private Sub Application_Start(sender As Object, e As EventArgs)
        RegisterRoutes(RouteTable.Routes)
    End Sub

    Private Shared Sub RegisterRoutes(routes As RouteCollection)
        
        
        
        routes.MapPageRoute("", "Home", "~/Home.aspx")
        routes.MapPageRoute("", "Success/{RefNo}/{Name}/{Number}", "~/Success.aspx")
        routes.MapPageRoute("", "Register", "~/Register.aspx")
        
        routes.MapPageRoute("", "Login", "~/Login.aspx")
        routes.MapPageRoute("", "Logout", "~/Logout.aspx")
        routes.MapPageRoute("", "Default", "~/Default.aspx")
        routes.MapPageRoute("", "Error", "~/ErrPage.aspx")
        
        
        
        routes.MapPageRoute("", "Admin/Enrolled", "~/Admin/Enrolled.aspx")
        routes.MapPageRoute("", "Admin/Paid", "~/Admin/Paid.aspx")
        routes.MapPageRoute("", "Admin/Registered", "~/Admin/Registered.aspx")
        routes.MapPageRoute("", "Admin/ChangePassword", "~/Admin/ChangePassword.aspx")
        routes.MapPageRoute("", "Admin/Default", "~/Admin/Default.aspx")
        routes.MapPageRoute("", "Admin/Login", "~/Admin/Login.aspx")
        routes.MapPageRoute("", "Admin/Logout", "~/Admin/Logout.aspx")
        
    End Sub
</script>
