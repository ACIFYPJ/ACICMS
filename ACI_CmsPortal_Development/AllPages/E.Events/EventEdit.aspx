<%@ Page Title="" Language="C#" MasterPageFile="~/AllMasterPages/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="EventEdit.aspx.cs" Inherits="ACI_CmsPortal_Development.AllPages.E.Events.EventEdit" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"/>
    <link rel="stylesheet" href="/resources/demos/style.css"/>
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>--%>
    <link rel="stylesheet" type="text/css" href="../../datetimepicker/jquery.datetimepicker.css" />
<script src="../../datetimepicker/jquery.js"></script>
<script src="../../datetimepicker/build/jquery.datetimepicker.full.min.js"></script>
   <%-- <script>
        $(function () {
            $("#datepicker").datepicker();
        });
        $(function () {
            $("#datepicker2").datepicker();
        });
  </script>--%>
    <script>

        $(document).ready(function () {
            jQuery('.datetimepicker').datetimepicker({
                format: 'd/m/Y H:i'
            });
        });
    </script>
    <div>
        <h1>Edit Event</h1>

        <div>
            <asp:Label ID="Label1" runat="server" class="col-sm-2" Text="Event Title:"></asp:Label>
            <asp:TextBox ID="tbeventTitle" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="TextBoxValidator" ForeColor="Red" ControlToValidate="tbeventTitle" runat="server" ErrorMessage="Event title required!"></asp:RequiredFieldValidator>
        </div>
        <br />
        <div>
            <asp:Label ID="Label2" runat="server" class="col-sm-2" Text="Location:"></asp:Label>
            <asp:TextBox ID="tblocation" runat="server"></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:Label ID="Label3" runat="server" class="col-sm-2" Text="Start Date"></asp:Label>
            <input type="text" class="datetimepicker" runat="server" id ="startDate"/>
             <asp:RequiredFieldValidator ID="StartDateValidator" ControlToValidate="startDate" ForeColor="Red" runat="server" ErrorMessage="Start date and time required!" EnableClientScript="True"></asp:RequiredFieldValidator>
        </div>
        <br />
        <div>
            <asp:Label ID="Label4" runat="server" class="col-sm-2" Text="End Date"></asp:Label>
            <input type="text" class="datetimepicker" runat="server" id="endDate"/>
            <asp:RequiredFieldValidator ID="EndDateValidator" ControlToValidate="endDate" runat="server" ForeColor="Red" ErrorMessage="End date and time required!"></asp:RequiredFieldValidator>
        </div>
        <br />
        <div>
            <asp:Label ID="Label5" runat="server" class="col-sm-2" Text="Featured Photo"></asp:Label>
            <input type="file" id="myFile" />
        </div>
        <br />
        <div>
            <asp:Label ID="Label6" runat="server" class="col-sm-2" Text="Description"></asp:Label>
            <asp:RequiredFieldValidator ForeColor="Red" ID="DescriptionValidator" ControlToValidate="CKEditor1" runat="server" ErrorMessage="Description required!"></asp:RequiredFieldValidator>
        </div>
        <br />
        <div>

            <CKEditor:CKEditorControl ID="CKEditor1" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
        </div>
        <br />

        <div>
            <asp:Label ID="Label7" runat="server" class="col-sm-2" Text="Enable Registration Form?"></asp:Label>
            <asp:CheckBox ID="enableForm" runat="server" Text="Enabled" />
        </div>
        <br />
        <div>
            <asp:Label ID="Label8" runat="server" class="col-sm-2" Text="Registration Deadline"></asp:Label>
            <input type="text" class="datetimepicker" runat="server" id="rDeadline"/>
        </div>
        <br />
        <div>
            <asp:Label ID="Label9" runat="server" class="col-sm-2" Text="Link an Event Photo Album"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
        </div>
        <br />
        <div>
            <asp:Label ID="Label10" runat="server" class="col-sm-2" Text="Feature on Homepage?"></asp:Label>
            <asp:CheckBox ID="feature" runat="server" Text="Featured" />
        </div>
        <br />
        <div>
            <asp:Label ID="Label11" runat="server" class="col-sm-2" Text="Feature Order"></asp:Label>
            <input type="number" min="0" max="20" step="1" id ="featureorder" runat="server" />
        </div>
        <br />

        <div>
            <asp:Label ID="Label12" runat="server" class="col-sm-2" Text="Publish Status"></asp:Label>
            <asp:DropDownList ID="pStatus" runat="server">
                <asp:ListItem Text="Draft" />
                <asp:ListItem Text="Published" />
                <asp:ListItem Text="Archived" />
            </asp:DropDownList>
        </div>
        <br />
        <div>
            <asp:Button ID="Button4" runat="server" Text="Save" OnClick="Button4_Click" />
        </div>
        <br />
    </div>
</asp:Content>
