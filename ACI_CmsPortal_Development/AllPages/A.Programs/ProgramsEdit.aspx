<%@ Page Title="" Language="C#" MasterPageFile="~/AllMasterPages/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="ProgramsEdit.aspx.cs" Inherits="ACI_CmsPortal_Development.AllPages.A.Programs.ProgramsEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>
            Edit Program
        </h1>
        <div class="col-sm-4">
            <asp:Label ID="lblParentProgram" runat="server" Text="Parent Program"></asp:Label>
            <asp:DropDownList ID="ddlParentProgram" runat="server"></asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="lblProgramName" runat="server" Text="Program Name"></asp:Label>
            <asp:TextBox ID="tbProgramName" runat="server"></asp:TextBox>
        </div>
        <br />

    </div>
</asp:Content>
