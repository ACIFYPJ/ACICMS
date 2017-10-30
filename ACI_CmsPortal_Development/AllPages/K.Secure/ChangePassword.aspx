<%@ Page Title="" Language="C#" MasterPageFile="~/AllMasterPages/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="ACI_CmsPortal_Development.AllPages.K.Secure.ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <fieldset class ="text-center">
            <legend>Reset Password</legend>
            <div class="form-group">
                <label for="oldPass" class="col-lg-2 control-label">Old Password</label>
                <div class="col-lg-10">
                    <input type="password" runat="server" class="form-control" id="oldPass" />
                    <asp:RequiredFieldValidator ID="usernameValidator" ControlToValidate="oldPass" runat="server" ErrorMessage="Please key in your current password!" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:Label ID="oldpasserror" runat="server" Text="Old password does not match!" ForeColor="Red" Visible="False"></asp:Label>  
                </div>
                <br />
                <br />
            </div>
            <div class="form-group">
                <label for="newPass" class="col-lg-2 control-label">New Password</label>
                <div class="col-lg-10">
                    <input type="password" runat="server" class="form-control" id="newPass" />
                    <asp:RequiredFieldValidator ID="passwordValidator" ControlToValidate="newPass" runat="server" ErrorMessage="Please key in your new password!" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
            
            <br />
            <br />
           <div class="form-group">
                <label for="confirmPass" class="col-lg-2 control-label">Confirm Password</label>
                <div class="col-lg-10">
                    <input type="password" runat="server" class="form-control" id="confirmPass" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="confirmPass" runat="server" ErrorMessage="Please confirm your password!" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:CompareValidator ID="confirmPassword" runat="server" ControlToCompare="newPass" ControlToValidate="confirmPass" ForeColor="Red" ErrorMessage="Passwords do not match!"></asp:CompareValidator>
                     </div>
            </div>
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
</asp:Content>
