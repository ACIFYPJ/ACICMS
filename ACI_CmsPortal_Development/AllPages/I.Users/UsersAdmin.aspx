<%@ Page Title="" Language="C#" MasterPageFile="~/AllMasterPages/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="UsersAdmin.aspx.cs" Inherits="ACI_CmsPortal_Development.AllPages.I.Users.UsersAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <script src="../../js/tablejs.js" type="text/javascript"></script>
    <script src="../../js/tablejsbs.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../../css/TableCss.css" />

    <script>
        $(document).ready(function () {
            $('#event').DataTable();
        });
    </script>
    <div class="row">
        <div class="col-sm-12">
            <h1>
                <asp:Label ID="lblheading" runat="server" Text="Manage Admin Users"></asp:Label></h1>
        </div>
    </div>


    <div class="panel panel-default">
        <div class="panel-heading">
            <asp:Button ID="BtnAddUser" runat="server" Text="Add New User" CssClass="btn btn-success" OnClick="BtnAddUser_Click" />
            <asp:Button ID="BtnLockedUser" runat="server" Text="Show Locked Users" CssClass="btn btn-info" OnClick="BtnLockedUser_Click" />
            <asp:Button ID="BtnAllUser" runat="server" Visible="false" Text="Show Active Users" CssClass="btn btn-info" OnClick="BtnAllUser_Click" />
        </div>
        <div class="panel-body">
            <div class="panel panel-default">
                <div class="panel-body">
                    <asp:Repeater ID="UsersRPT" runat="server" OnItemCommand="UsersRPT_ItemCommand">
                        <HeaderTemplate>
                            <table id="event" class="table table-striped table-bordered" cellspacing="0" width="100%">
                                <thead>
                                    <tr>
                                        <th scope="col" style="width: 200px">Name
                                        </th>
                                        <th scope="col" style="width: 200px">Joined Date
                                        </th>
                                        <th scope="col" style="width: 100px"></th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="lbTitle" runat="server" Text='<%# Eval("displayname") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="lbName" runat="server" Text='<%# Eval("createdOn") %>' />
                                </td>
                                <td>
                                    <asp:Button ID="BtnView" CssClass="btn btn-info" Width="80px" CommandName="ViewUser" CommandArgument='<%# Eval("userID") %>' runat="server" Text="View" />
                                    <asp:Button ID="BtnManage" CssClass="btn btn-primary" Width="80px" CommandName="ManageUser" CommandArgument='<%# Eval("userID") %>' runat="server" Text="Manage" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
           <tfoot>
               <tr>
                   <th scope="col" style="width: 200px">Name
                   </th>
                   <th scope="col" style="width: 200px">Joined Date
                   </th>
                   <th scope="col" style="width: 100px"></th>
               </tr>
           </tfoot>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
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
                    <h3 class="modal-title">User Details</h3>
                </div>
                <div class="modal-body ">
                    <h4>Created On:
                        <asp:Label ID="lbVCreatedOn" runat="server" ForeColor="#0033CC"></asp:Label></h4>
                    <h4>Created By:
                        <asp:Label ID="lbVCreatedBy" runat="server" ForeColor="#0033CC" Text=""></asp:Label></h4>
                    <br />
                    <h4>Roles:
                        <asp:Label ID="lbVroles" runat="server" ForeColor="#0033CC" Text=""></asp:Label></h4>
                    <h4>User Name:
                        <asp:Label ID="lbVusername" runat="server" ForeColor="#0033CC" Text=""></asp:Label></h4>
                    <h4>Display Name:
                        <asp:Label ID="lbVDisplayname" runat="server" ForeColor="#0033CC" Text=""></asp:Label></h4>                 
                    <h4>Email:
                        <asp:Label ID="lbVEmail" runat="server" ForeColor="#0033CC" Text=""></asp:Label></h4>
                    <br />
                    <h4>First Name:
                        <asp:Label ID="lbVFirstName" ForeColor="#0033CC" runat="server" Text=""></asp:Label></h4>
                    <h4>Last Name:
                        <asp:Label ID="lbVLastName" ForeColor="#0033CC" runat="server" Text=""></asp:Label></h4>
                    <h4>Gender:
                        <asp:Label ID="lbVGender" ForeColor="#0033CC" runat="server" Text=""></asp:Label></h4>
                    <h4>Job title:
                        <asp:Label ID="lbVJobTitle" ForeColor="#0033CC" runat="server" Text=""></asp:Label></h4>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
