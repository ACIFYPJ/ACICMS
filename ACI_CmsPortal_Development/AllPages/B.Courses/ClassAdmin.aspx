<%@ Page Title="" Language="C#" MasterPageFile="~/AllMasterPages/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="ClassAdmin.aspx.cs" Inherits="ACI_CmsPortal_Development.AllPages.B.Courses.ClassAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <script src="../../datetimepicker/jquery.datetimepicker.min.js"></script>
    <div class="row">
        <div class="col-sm-12">
            <h1>Manage Classes</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-default">
                <div class="row">
                    <div class="col-sm-2">
                    </div>
                    <div class="col-sm-8">
                        <asp:UpdatePanel ID="uppanel" runat="server">
                            <ContentTemplate>
                                <asp:Repeater ID="ClassPublishRPT" runat="server" OnItemCommand="ClassPublishRPT_ItemCommand" >
                                    <HeaderTemplate>
                                        <h3>
                                            <asp:Label runat="server" ID="label1" Text="Published classes"></asp:Label></h3>
                                        <div class="panel panel-default">
                                            <table id="ModuleCore" class="table table-striped table-bordered" cellspacing="0" width="100%">
                                                <thead>
                                                    <tr>
                                                        <th scope="col" style="width: 300px">Published Class
                                                        </th>
                                                        <th scope="col" style="width: 300px">Start Date
                                                        </th>
                                                        <th scope="col" style="width: 300px">End Date
                                                        </th>
                                                        <th scope="col" style="width: 150px"></th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbroles" runat="server" Text='<%#System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(Eval("ClassCode").ToString(),true) %>' />
                                            </td>
                                             <td>
                                                <asp:Label ID="Label2" runat="server" Text='<%# System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(Eval("StartDate").ToString(),true) %>'  />
                                            </td>
                                             <td>
                                                <asp:Label ID="Label3" runat="server" Text='<%# System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(Eval("EndDate").ToString(),true)   %>'  />
                                            </td>
                                            <td>
                                                  <asp:Button ID="BtnEdit" Width="100px" CssClass="btn btn-primary" CommandName="Edit" CommandArgument='<%# System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(Eval("ClassID").ToString(),true) %>'  runat="server" Text="Edit" />                                                                                    
                                              </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody>
                                                                </table></div>
                                    </FooterTemplate>
                                </asp:Repeater>

                                <asp:Repeater ID="ClassUnPublishRPT" runat="server" OnItemCommand="ClassUnPublishRPT_ItemCommand">
                                    <HeaderTemplate>
                                        <h3>
                                            <asp:Label runat="server" ID="lblElective" Text="Unpublished classes"></asp:Label></h3>
                                        <div class="panel panel-default">
                                            <table id="ModuleElective" class="table table-striped table-bordered" cellspacing="0" width="100%">
                                                <thead>
                                                      <tr>
                                                        <th scope="col" style="width: 300px">Unpublished Class
                                                        </th>
                                                        <th scope="col" style="width: 300px">Start Date
                                                        </th>
                                                        <th scope="col" style="width: 300px">End Date
                                                        </th>
                                                       <th scope="col" style="width: 150px"></th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbroles" runat="server" Text='<%# System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(Eval("ClassCode").ToString(),true) %>' />
                                            </td>
                                             <td>
                                                <asp:Label ID="Label2" runat="server" Text='<%# System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(Eval("StartDate").ToString(),true) %>'  />
                                            </td>
                                             <td>
                                                <asp:Label ID="Label3" runat="server" Text='<%# System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(Eval("EndDate").ToString(), true) %>'  />
                                            </td>
                                            <td>
                                                  <asp:Button ID="BtnEdit2" Width="100px" CssClass="btn btn-primary" CommandName="Edit" CommandArgument='<%# System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(Eval("ClassID").ToString(),true) %>'  runat="server" Text="Edit" />
                                               
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody>
                                          </table></div>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ClassPublishRPT" />
                                <asp:AsyncPostBackTrigger ControlID="ClassUnPublishRPT" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
