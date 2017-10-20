<%@ Page Title="" Language="C#" MasterPageFile="~/AllMasterPages/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="ACI_CmsPortal_Development.AllPages.I.Users.AddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
     <script src="../../js/passwordstrength.js" type="text/javascript"></script>

    <div class="row">
        <div class="col-sm-12">
            <h2 class="text-center">
                <asp:Label ID="lblheading" runat="server" Text="Add New User"></asp:Label></h2>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-2"></div>
        <div class="col-sm-8">
            <fieldset>
                <div class="form-group">
                    <label for="display name">
                        Display name:         
                        <asp:LinkButton ID="LinkBtnDisplayname" CausesValidation="False" runat="server" OnClick="LinkBtnDisplayname_Click"><span aria-hidden="true" class="glyphicon glyphicon-question-sign"></span> </asp:LinkButton>
                    </label>
                    <asp:TextBox ID="tbdisplayname" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="btnsubmit" CssClass="alert-danger" Display="Dynamic" ID="RequiredFieldValidator1" ControlToValidate="tbdisplayname" runat="server" ErrorMessage="Please enter a display name"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="username">
                        Username:
                          <asp:LinkButton ID="LinkBtnUsername" CausesValidation="False" runat="server" OnClick="LinkBtnUsername_Click"><span aria-hidden="true" class="glyphicon glyphicon-question-sign"></span> </asp:LinkButton>
                    </label>
                    <asp:TextBox ID="tbusername" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="lbusername" Visible="false" runat="server" CssClass="alert-danger" Text="Username already exist, please choose other username"></asp:Label>
                    <asp:RequiredFieldValidator ValidationGroup="btnsubmit" CssClass="alert-danger" Display="Dynamic" ID="RequiredFieldValidator2" ControlToValidate="tbusername" runat="server" ErrorMessage="Please enter a user name"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="email address">
                        Email Address:
                          <asp:LinkButton ID="LinkBtnEmail"  CausesValidation="False" runat="server" OnClick="LinkBtnEmail_Click"><span aria-hidden="true" class="glyphicon glyphicon-question-sign"></span> </asp:LinkButton>
                    </label>
                    <asp:TextBox ID="tbemail" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ValidationGroup="btnsubmit" CssClass="alert-danger" ID="RegularExpressionValidator4" Display="Dynamic" runat="server" ControlToValidate="tbEmail"
                        ErrorMessage="Not a Valid Email Address" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ValidationGroup="btnsubmit" ID="EmailRequired" Display="Dynamic" CssClass="alert-danger" runat="server" ControlToValidate="tbEmail"
                        ErrorMessage="E-mail is required"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="password">
                        Password:
                          <asp:LinkButton ID="LinkBtnPassword" CausesValidation="False" runat="server" OnClick="LinkBtnPassword_Click"><span aria-hidden="true" class="glyphicon glyphicon-question-sign"></span> </asp:LinkButton>
                    </label>
                    <asp:TextBox ID="tbpassword" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                    <div class="pwstrength_viewport_progress"></div>
                    <asp:RequiredFieldValidator ValidationGroup="btnsubmit" CssClass="alert-danger" Display="Dynamic" ID="RequiredFieldValidator3" ControlToValidate="tbpassword" runat="server" ErrorMessage="Please enter a password"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ValidationGroup="btnsubmit" CssClass="alert-danger" ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="tbpassword"
                        ErrorMessage="a password must be eight characters including one uppercase letter, one special character and alphanumeric characters." SetFocusOnError="True" ValidationExpression="((?=.*\d)(?=.*[A-Z])(?=.*\W).{8,})"></asp:RegularExpressionValidator>
                </div>

                <div class="form-group">
                    <asp:CheckBox ID="chkchangepassword" runat="server" />
                    <label for="chk">
                        User must change password?
                          <asp:LinkButton ID="LinkBtnUserChangePw" CausesValidation="False" runat="server" OnClick="LinkBtnUserChangePw_Click"><span aria-hidden="true" class="glyphicon glyphicon-question-sign"></span> </asp:LinkButton>
                    </label>
                </div>
                <asp:Button ID="btnSubmit" ValidationGroup="btnsubmit" CausesValidation="True" CssClass="btn btn-success" runat="server" Text="Create new user" OnClick="btnSubmit_Click1" />
            </fieldset>
            <asp:Label ID="lblerror" runat="server" Text=""></asp:Label>
        </div>
    </div>

    <script type="text/javascript">
        function ShowPopup() {
            $("#btnShowPopup").click();
        }
    </script>
    <button type="button" style="display: none;" id="btnShowPopup" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#myModal">
    </button>
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog modal-md">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h3 class="modal-title">Help</h3>
                </div>
                <div class="modal-body ">
                    <h2>
                        <asp:Label ID="lbVhelpguide" runat="server" ForeColor="#0033CC"></asp:Label></h2>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
