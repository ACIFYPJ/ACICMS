<%@ Page Title="" Language="C#" MasterPageFile="~/AllMasterPages/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="CoursesAdmin.aspx.cs" Inherits="ACI_CmsPortal_Development.AllPages.B.Courses.CoursesAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="../../js/tablejs.js" type="text/javascript"></script>
    <script src="../../js/tablejsbs.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../../css/TableCss.css" />
    <script>
        $(document).ready(function () {
            $('#courses').DataTable();
        });
    </script>
    <div class="row">
        <div class="col-sm-12">
            <h1>Manage Courses</h1>
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-heading">
            <div class="form-inline">
                <div class="form-group">
                    <asp:DropDownList ID="DDLpublish" CssClass="form-control" Width="29%" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLpublish_SelectedIndexChanged">
                        <asp:ListItem Text="All" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Published" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Draft" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Archived" Value="3"></asp:ListItem>
                    </asp:DropDownList>

                    <asp:DropDownList ID="DDLProgramme" CssClass="form-control" Width="69%" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLProgramme_SelectedIndexChanged"></asp:DropDownList>
                </div>
                 <div class="form-group">
                    <asp:Button ID="BtnShowAllApplicants" runat="server" CssClass="btn btn-info" Text="Show All Applicants" />
                </div>
            </div>
          
               
          
        </div>
        <div class="panel-body">
            <asp:Repeater ID="CoursesRPT" runat="server" OnItemCommand="CoursesRPT_ItemCommand">
                <HeaderTemplate>
                    <table id="courses" class="table table-striped table-bordered" cellspacing="0" width="100%">
                        <thead>
                            <tr>
                                <th scope="col" style="width: 200px">Program Type
                                </th>
                                <th scope="col" style="width: 400px">Course Title
                                </th>
                                <th scope="col" style="width: 50px">Version
                                </th>
                                <th scope="col" style="width: 350px"></th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="lbProgramType" runat="server" Text='<%# System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(Eval("ProgramName").ToString(),true) %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbCourseTitle" runat="server" Text='<%# System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(Eval("CourseName").ToString(), true) %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbCourseVersion" runat="server" Text='<%# System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(Eval("CourseVersion").ToString(), true) %>' />
                        </td>
                        <td>
                            <asp:Button ID="BtnView" CssClass="btn btn-info" Width="80px" CommandName="ViewCourse" CommandArgument='<%# System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(Eval("CourseID").ToString(),true) %>' runat="server" Text="View" />
                            <asp:Button ID="BtnEdit" CssClass="btn btn-primary" Width="80px" CommandName="EditCourse" CommandArgument='<%# System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(Eval("CourseID").ToString(), true) %>' runat="server" Text="Edit" />
                            <asp:Button ID="BtnClass" CssClass="btn btn-info" Width="80px" CommandName="Classes" CommandArgument='<%# System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(Eval("CourseID").ToString(), true) %>' runat="server" Text="Class" />
                            <asp:Button ID="BtnApplicants" CssClass="btn btn-info" Width="100px" CommandName="Applicants" CommandArgument='<%# System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(Eval("CourseID").ToString(), true) %>' runat="server" Text="Applicants" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
           <tfoot>
              <tr>
                                <th scope="col" style="width: 200px">Program Type
                                </th>
                                <th scope="col" style="width: 400px">Course Title
                                </th>
                                <th scope="col" style="width: 50px">Version
                                </th>
                                <th scope="col" style="width: 350px"></th>
                            </tr>
           </tfoot>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
