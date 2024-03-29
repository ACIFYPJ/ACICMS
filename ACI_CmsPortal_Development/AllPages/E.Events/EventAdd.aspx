﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AllMasterPages/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="EventAdd.aspx.cs" Inherits="ACI_CmsPortal_Development.AllPages.E.Events.EventAdd" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
<link rel="stylesheet" type="text/css" href="../../datetimepicker/jquery.datetimepicker.css" />
<script src="../../datetimepicker/jquery.js"></script>
<script src="../../datetimepicker/build/jquery.datetimepicker.full.min.js"></script>
    <script>
        $(document).ready(function () {
            jQuery('.datetimepicker').datetimepicker({
                format: 'd/m/Y H:i'
            });
        });
    </script>
    <div>
        <h1>Add new Event</h1>

        
        <div>
            <asp:Label ID="Label1" runat="server" class="col-sm-2" Text="Event Title:"></asp:Label>
            <asp:TextBox ID="tbeventTitle" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="TextBoxValidator" ForeColor="red" ControlToValidate="tbeventTitle" runat="server" ErrorMessage="Event Title required!"></asp:RequiredFieldValidator>
            
        </div>
        <br />
        
        <div>
            <asp:Label ID="Label2" runat="server" class="col-sm-2" Text="Location:"></asp:Label>
            <asp:TextBox ID="tblocation" runat="server"></asp:TextBox>
        </div>
        <br />
        
        <div>
            <asp:Label ID="Label3" runat="server" class="col-sm-2" Text="Start Date"></asp:Label>
            <input class="datetimepicker" type="text" id="startDate" runat="server"/>
            <asp:RequiredFieldValidator ID="StartDateValidator" ControlToValidate="startDate" ForeColor="Red" runat="server" ErrorMessage="Start date and time required!" EnableClientScript="True"></asp:RequiredFieldValidator>
        </div>
        <br />
        <div>
            <asp:Label ID="Label4" runat="server" class="col-sm-2" Text="End Date"></asp:Label>
            <input type="text" class="datetimepicker" id="endDate" runat="server" />
            <asp:RequiredFieldValidator ID="EndDateValidator" ControlToValidate="endDate" runat="server" ForeColor="Red" ErrorMessage="End date and time required!"></asp:RequiredFieldValidator>
        </div>
        <br />
        <div>
            
            <asp:Label ID="Label5" runat="server" class="col-sm-2" Text="Featured Photo"></asp:Label>
            <asp:FileUpload ID="imgUpload" runat="server" />
            <%--<input type="file" id="myImg" runat="server"/>--%>
            <br />
            <asp:Image ID="imgResult" runat="server" />
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
            <asp:CheckBox ID="CheckBox1" runat="server" Text="Enabled" />
        </div>
        <br />
        <div>
            <asp:Label ID="Label8" runat="server" class="col-sm-2" Text="Registration Deadline"></asp:Label>
            <input type="text" class="datetimepicker" runat="server" id="rDeadline"/>
        </div>
        <br />
      <%--  <div>
            <asp:Label ID="Label9" runat="server" class="col-sm-2" Text="Link an Event Photo Album"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
        </div>
        <br />
        <div>
            <asp:Label ID="Label10" runat="server" class="col-sm-2" Text="Feature on Homepage?"></asp:Label>
            <asp:CheckBox ID="CheckBox2" runat="server" Text="Featured" />
        </div>
        <br />
        <div>
            <asp:Label ID="Label11" runat="server" class="col-sm-2" Text="Feature Order"></asp:Label>
            <input type="number" id="featureorder" min="1" step="1" runat="server"/>
        </div>
        <br />--%>

        <div>
            <asp:Label ID="Label12" runat="server" class="col-sm-2" Text="Publish Status"></asp:Label>
            <asp:DropDownList ID="DropDownList2" runat="server">
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
