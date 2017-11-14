<%@ Page Title="" Language="C#" MasterPageFile="~/AllMasterPages/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="EditClass.aspx.cs" Inherits="ACI_CmsPortal_Development.AllPages.B.Courses.EditClass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="../../bootstrap-timepicker/js/bootstrap-timepicker.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../../bootstrap-timepicker/css/bootstrap-timepicker.min.css" />
    
    <script>
        $(function () {
            $("#txtstarttime").timepicker({
                showInputs: false //Set showInputs to false
            });
        })
        $(function () {
            $("#txtendtime").timepicker({
                showInputs: false //Set showInputs to false
            });
        })
    </script>


    <div class="row">
        <div class="col-sm-12">
            <h1>Edit Class
                <asp:Label ID="lblHeading" runat="server" Text=""></asp:Label></h1>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <asp:Button ID="BtnSave" runat="server" Text="Save updates" CssClass="btn btn-success" OnClick="BtnSave_Click" />
                    <asp:Button ID="BtnUnpublish" CausesValidation="false" Visible="false"  runat="server" Text="Unpublish" CssClass="btn btn-danger" OnClick="BtnUnpublish_Click"  />
                <asp:Button ID="BtnPublish" CausesValidation="false" Visible="true" runat="server" Text="Publish" CssClass="btn btn-warning" OnClick="BtnPublish_Click"  />
                  <asp:Button ID="BtnBack" CausesValidation="false"  CssClass="btn btn-default pull-right"   runat="server" Text="Back" OnClick="BtnBack_Click"/>
            
                </div>
                <div class="panel-body">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="col-sm-2"></div>
                            <div class="col-sm-8">

                                <div class="row">
                                <div class="col-sm-6">
                                 <div class="form-group">
                                    <label>Registration period:</label>                          
                                        <asp:TextBox ID="txtRegPeriod" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>             
                                </div>
                                    </div>
                                 </div>

                                <div class="row">
                                <div class="col-sm-6">
                                <div class="form-group">
                                    <label>Class start time:</label>
                                    <div class="input-group bootstrap-timepicker timepicker">
                                        <asp:TextBox ID="txtstarttime" data-provide="timepicker" CssClass="form-control timepicker" runat="server"></asp:TextBox>
                                        <span class="input-group-addon"><i class="glyphicon glyphicon-time"></i></span>
                                    </div>
                                    <asp:Label ID="lblstarttimevalid" runat="server" Text="" CssClass="alert-danger"></asp:Label>
                                </div>
                                    </div>
                                </div>
                                 <div class="row">
                                <div class="col-sm-6">
                                 <div class="form-group">
                                    <label>Class end time:</label>
                                    <div class="input-group bootstrap-timepicker timepicker">
                                        <asp:TextBox ID="txtendtime" data-provide="timepicker" CssClass="form-control timepicker" runat="server"></asp:TextBox>
                                        <span class="input-group-addon"><i class="glyphicon glyphicon-time"></i></span>
                                    </div>
                                     <asp:Label ID="lblendtimevalid" runat="server" Text="" CssClass="alert-danger"></asp:Label>
                                </div>
                                    </div>
                                 </div>
                                <div class="row">
                                <div class="col-sm-12">
                                 <div class="form-group">
                                    <label>Language:</label>
                                     <asp:TextBox ID="txtLanguage" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                                </div>
                                    </div>
                                 </div>
                                 <div class="row">
                                <div class="col-sm-12">
                                 <div class="form-group">
                                    <label>Remarks:</label>
                                     <asp:TextBox ID="txtremarks" CssClass="form-control" runat="server" MaxLength="200" TextMode="MultiLine"></asp:TextBox>
                                </div>
                                    </div>
                                 </div>
                            </div>                           
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
