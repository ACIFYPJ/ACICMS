<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ACI_CmsPortal_Development.AllPages.K.Secure.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>ACI CMS</title>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link href="../../css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../css/custom.css" rel="stylesheet" type="text/css" />
    <link rel="Shortcut Icon" href="images/favicon.ico" />
    <link href="../../css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="http://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css"
        rel="stylesheet" type="text/css" />
    <link href="http://fonts.googleapis.com/css?family=Lato:300,400,700,300italic,400italic,700italic" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .affix {
            top: 0;
            width: 100%;
            -webkit-transition: all .5s ease-in-out;
            transition: all .5s ease-in-out;
            background-color: grey;
            border-color: #000;
            z-index: 9999 !important;
        }

            .affix a {
                color: #000 !important;
                padding: 15px !important;
                -webkit-transition: all .5s ease-in-out;
                transition: all .5s ease-in-out;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <script src="/js/bootstrap.js" type="text/javascript"></script>
        <!--/#footer-->
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Scripts>
                <%--To learn more about bundling scripts in ScriptManager see http://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="respond" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />

                <%--Site Scripts--%>
            </Scripts>
        </asp:ScriptManager>
        <div class="container">
        </div>
        <!-- Navigation -->
        <nav class="navbar navbar-default" data-spy="affix" data-offset-top="197" role="navigation">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNav">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                </div>
                <div class="collapse navbar-collapse" id="myNav">
                </div>
            </div>
        </nav>
        <div class="col-sm-offset-4 col-sm-4 text-center">
        <fieldset>
            <legend>Log in</legend>
            <div class="form-group">
                <label for="inputUsername" class="col-lg-2 control-label">Username</label>
                <div class="col-lg-10">
                    <input type="text" runat="server" class="form-control" id="inputUsername" />
                    <asp:RequiredFieldValidator ID="usernameValidator" ControlToValidate="inputUsername" runat="server" ErrorMessage="Please key in username!" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <br />
                <br />
            </div>
            <div class="form-group">
                <label for="inputPassword" class="col-lg-2 control-label">Password</label>
                <div class="col-lg-10">
                    <input type="password" runat="server" class="form-control" id="inputPassword" />
                    <asp:RequiredFieldValidator ID="passwordValidator" ControlToValidate="inputPassword" runat="server" ErrorMessage="Please key in password!" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
            
            <br />
            <br />
           
            <div class="form-group">
                <asp:Label ID="ErrorMsg" runat="server" Text="Invalid username/password" ForeColor="Red" Visible="False"></asp:Label>
                <div>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                </div>
            </div>
        </fieldset>
            </div>
    </form>
</body>
</html>
