<%@ Page Title="" Language="C#" MasterPageFile="~/AllMasterPages/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="ManageUser.aspx.cs" Inherits="ACI_CmsPortal_Development.AllPages.I.Users.ManageUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <h2>
                <asp:Label ID="lblheading" runat="server" Text="Manage User"></asp:Label></h2>
        </div>
    </div>
    <div class="row">


        <div class="panel panel-default">
            <div class="panel-heading">
                <asp:Button ID="Btnlock" CausesValidation="false" runat="server" Text="Lock user" CssClass="btn btn-danger" OnClick="Btnlock_Click" />
                <asp:Button ID="BtnUnlock" CausesValidation="false" Visible="false" runat="server" Text="Unlock user" CssClass="btn btn-info" OnClick="BtnUnlock_Click" />
                <asp:Button ID="BtnBack" CausesValidation="false"  CssClass="btn btn-default pull-right"   runat="server" Text="Back" OnClick="BtnBack_Click" />
            </div>
            <div class="panel-body">
                <div class="panel panel-default">
                    <div class="panel-body">


                        <fieldset>
                            <ul class="nav nav-tabs">
                                <li class="active"><a href="#user" data-toggle="tab" aria-expanded="true">User</a></li>
                                <li class=""><a href="#Profile" data-toggle="tab" aria-expanded="true">Profile</a></li>
                                <li class=""><a href="#Roles" data-toggle="tab" aria-expanded="true">Roles</a></li>
                            </ul>

                            <div id="myTabContent" class="tab-content">
                                <div class="tab-pane fade active in" id="user">
                                    <br />
                                    <div class="row">
                                        <div class="col-sm-2"></div>
                                        <div class="col-sm-8">
                                            <div class="form-group">
                                                <label for="display name">
                                                    Display name:         
                        <asp:LinkButton ID="LinkBtnDisplayname" CausesValidation="False" runat="server"><span aria-hidden="true" class="glyphicon glyphicon-question-sign"></span> </asp:LinkButton>
                                                </label>
                                                <asp:TextBox ID="tbdisplayname" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                                                <asp:RequiredFieldValidator CssClass="alert-danger" Display="Dynamic" ID="RequiredFieldValidator1" ControlToValidate="tbdisplayname" runat="server" ErrorMessage="Please enter a display name"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="form-group">
                                                <label for="username">
                                                    Username:
                          <asp:LinkButton ID="LinkBtnUsername" CausesValidation="False" runat="server"><span aria-hidden="true" class="glyphicon glyphicon-question-sign"></span> </asp:LinkButton>
                                                </label>
                                                <asp:TextBox ID="tbusername" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:Label ID="lbusername" Visible="false" runat="server" CssClass="alert-danger" Text="Username already exist, please choose other username"></asp:Label>
                                                <asp:RequiredFieldValidator CssClass="alert-danger" Display="Dynamic" ID="RequiredFieldValidator2" ControlToValidate="tbusername" runat="server" ErrorMessage="Please enter a user name"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="form-group">
                                                <label for="email address">
                                                    Email Address:
                          <asp:LinkButton ID="LinkBtnEmail" CausesValidation="False" runat="server"><span aria-hidden="true" class="glyphicon glyphicon-question-sign"></span> </asp:LinkButton>
                                                </label>
                                                <asp:TextBox ID="tbemail" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RegularExpressionValidator CssClass="alert-danger" ID="RegularExpressionValidator4" Display="Dynamic" runat="server" ControlToValidate="tbEmail"
                                                    ErrorMessage="Not a Valid Email Address" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="EmailRequired" Display="Dynamic" CssClass="alert-danger" runat="server" ControlToValidate="tbEmail"
                                                    ErrorMessage="E-mail is required"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="form-group">
                                                <label for="password">
                                                    Password:
                          <asp:LinkButton ID="LinkBtnPassword" CausesValidation="False" runat="server"><span aria-hidden="true" class="glyphicon glyphicon-question-sign"></span> </asp:LinkButton>
                                                </label>
                                                <asp:TextBox ID="tbpassword" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                                <div class="pwstrength_viewport_progress"></div>
                                                <asp:RegularExpressionValidator CssClass="alert-danger" ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="tbpassword"
                                                    ErrorMessage="a password must be eight characters including one uppercase letter, one special character and alphanumeric characters." SetFocusOnError="True" ValidationExpression="((?=.*\d)(?=.*[A-Z])(?=.*\W).{8,})"></asp:RegularExpressionValidator>
                                            </div>

                                            <div class="form-group">
                                                <asp:CheckBox ID="chkchangepassword" runat="server" />
                                                <label for="chk">
                                                    User must change password?
                          <asp:LinkButton ID="LinkBtnUserChangePw" CausesValidation="False" runat="server"><span aria-hidden="true" class="glyphicon glyphicon-question-sign"></span> </asp:LinkButton>
                                                </label>
                                            </div>
                                            <div class="form-group">
                                                <asp:CheckBox ID="chkdisplaymemberlist" runat="server" />
                                                <label for="chk">
                                                    Display in member list?
                          <asp:LinkButton ID="LinkBtnUserDisplayMemberList" CausesValidation="False" runat="server"><span aria-hidden="true" class="glyphicon glyphicon-question-sign"></span> </asp:LinkButton>
                                                </label>
                                            </div>
                                            <div class="form-group">
                                                <asp:Button ID="BtnSave" runat="server" Text="Save updates" CssClass="btn btn-success" OnClick="BtnSave_Click" />

                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="tab-pane fade" id="Profile">
                                    <br />
                                    <div class="row">
                                        <div class="col-sm-2"></div>
                                        <div class="col-sm-8">
                                            <div class="form-group">
                                                <label class="control-label" for="first name">First name:</label>
                                                <asp:TextBox ID="tbfirstname" CssClass="form-control" runat="server" TextMode="SingleLine"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label" for="last name">Last name:</label>
                                                <asp:TextBox ID="tblastname" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label" for="dob">Date of birth:</label>
                                                <asp:TextBox ID="tbdob" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label" for="gender">Gender:</label>
                                                <asp:DropDownList CssClass="form-control" ID="ddlgender" runat="server">
                                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                                                    <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label" for="job title">Job title:</label>
                                                <asp:TextBox ID="tbJobtitle" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <asp:Button ID="BtnSave2" runat="server" Text="Save updates" OnClick="BtnSave_Click" CssClass="btn btn-success" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="Roles">
                                    <br />
                                    <div class="row">
                                        <div class="col-sm-2">
                                        </div>
                                        <div class="col-sm-8">
                                            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional">
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="BtnAddRole" EventName="Click" />
                                                </Triggers>
                                                <ContentTemplate>
                                                    <asp:Label runat="server" ID="label1" Text=""></asp:Label>
                                                    <div class="form-group">
                                                        <asp:DropDownList CssClass="form-control" ID="ddlroles" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:Button CssClass="btn btn-success" ID="BtnAddRole" CausesValidation="false" runat="server" Text="Add role" OnClick="BtnAddRole_Click" />
                                                    </div>
                                                    <asp:Repeater ID="UserRolesRPT" runat="server" OnItemCommand="UserRolesRPT_ItemCommand">
                                                        <HeaderTemplate>
                                                            <table id="event" class="table table-striped table-bordered" cellspacing="0" width="100%">
                                                                <thead>
                                                                    <tr>
                                                                        <th scope="col" style="width: 500px">Roles
                                                                        </th>
                                                                        <th scope="col" style="width: 90px"></th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lbroles" runat="server" Text='<%# Container.DataItem %>' />
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="BtnDelete" CssClass="btn btn-danger" CommandName="DeleteRole" CommandArgument='<%# Container.DataItem %>' runat="server" Text="Delete role" />
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            </tbody>
           <tfoot>
           </tfoot>
                                                            </table>
                                                        </FooterTemplate>
                                                    </asp:Repeater>
                                                </ContentTemplate>
                                                
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="col-sm-2"></div>
                            <div class="col-sm-8">
                                <asp:ValidationSummary DisplayMode="BulletList" ID="ValidationSummary1" CssClass="alert-danger" runat="server" />
                            </div>

                        </fieldset>
                    </div>


                           
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
                <div class="modal-header-success">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h3 class="modal-title">Success</h3>
                </div>
                <div class="modal-body ">
                    <h4>
                        <asp:Label ID="lbVsuccessmessage" runat="server"></asp:Label></h4>                   
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function ShowPopup2() {
            $("#btnShowPopup2").click();
        }
    </script>
    <button type="button" style="display: none;" id="btnShowPopup2" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#myModal2">
    </button>
    <div class="modal fade" id="myModal2" role="dialog">
        <div class="modal-dialog modal-md">
            <div class="modal-content">
                <div class="modal-header-fail">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h3 class="modal-title">
                        <asp:Label ID="lbVmodalheaderfail" runat="server" Text="Label"></asp:Label></h3>
                </div>
                <div class="modal-body ">
                    <h4>
                        <asp:Label ID="lbVmodalfailcontent" runat="server"></asp:Label></h4>                   
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

                </div>
            </div>
        </div>
    </div>


</asp:Content>
