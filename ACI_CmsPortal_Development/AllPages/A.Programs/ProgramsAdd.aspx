<%@ Page Title="" Language="C#" MasterPageFile="~/AllMasterPages/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="ProgramsAdd.aspx.cs" Inherits="ACI_CmsPortal_Development.AllPages.A.Programs.ProgramsAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>
            Add Program
        </h1>
        <div class="col-sm-4">
            <asp:Label ID="lblParentProgram" runat="server" Text="Parent Program"></asp:Label>
            <asp:DropDownList ID="ddlParentProgram" runat="server"></asp:DropDownList>
        </div>
        <br />

        <div>
            <asp:Label ID="lblProgramName" runat="server" Text="Program Name"></asp:Label>
            <asp:TextBox ID="tbProgramName" runat="server"></asp:TextBox>
        </div>
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    </div>
</asp:Content>
