<%@ Page Title="" Language="C#" MasterPageFile="~/AllMasterPages/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ACI_CmsPortal_Development.AllPages.L.Home.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../js/tablejs.js" type="text/javascript"></script>
    <script src="../../js/tablejsbs.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../../css/TableCss.css" />
    <script>
        $(document).ready(function () {
            $('#modalevent').DataTable();
        });
    </script>
    <div class="row">
        <div class="col-lg-12">
            <h1>Manage carousel image</h1>

            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="form-inline">
                        <div class="form-group">
                            <asp:Button ID="BtnAddImage" runat="server" CssClass="btn btn-success" Text="Upload new image" OnClick="BtnAddImage_Click" />
                        </div>
                    </div>

                </div>
                <div class="panel-body">
                    <asp:Repeater ID="CarouselRPT" runat="server" OnItemCommand="CarouselRPT_ItemCommand">
                        <HeaderTemplate>
                            <table id="courses" class="table table-striped table-bordered" cellspacing="0" width="100%">
                                <thead>
                                    <tr>
                                        <th scope="col" style="width: 200px">Image
                                        </th>
                                        <th scope="col" style="width: 400px">File name
                                        </th>
                                        <th scope="col" style="width: 100px"></th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <img src='<%# "../../images/" + Eval("FileName") %>' style="max-height: 150px" />
                                </td>
                                <td>
                                    <asp:Label ID="lblfilename" runat="server" Text='<%# Eval("FileName") %>'></asp:Label>
                                </td>

                                <td>
                                    <asp:Button ID="BtnDelete" CssClass="btn btn-danger" Width="100px" CommandName="CarouselRemove" CommandArgument='<%# Eval("ImageID") %>' runat="server" Text="Remove" />
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
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-6">
            <h1>Manage featured events</h1>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="form-inline">
                        <div class="form-group">
                            <asp:Button ID="btnSearchEvents" runat="server" CssClass="btn btn-success" Text="Add new event" OnClick="btnSearchEvents_Click" />

                        </div>
                    </div>

                </div>
                <div class="panel-body">
                    <asp:Repeater ID="EventRPT" runat="server" OnItemCommand="EventRPT_ItemCommand">
                        <HeaderTemplate>
                            <table id="courses" class="table table-striped table-bordered" cellspacing="0" width="100%">
                                <thead>
                                    <tr>
                                        <th scope="col" style="width: 200px">Event title
                                        </th>
                                        <th scope="col" style="width: 200px">Event date
                                        </th>
                                        <th scope="col" style="width: 100px"></th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="lbleventtitle" runat="server" Text='<%# Eval("EventTitle") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbleventdate" runat="server" Text='<%# ((DateTime)Eval("EventStart")).ToString("dd/MM/yyyy hh:mm tt") + " To " + ((DateTime)Eval("EventEnd")).ToString("dd/MM/yyyy hh:mm tt")  %>'></asp:Label>
                                </td>

                                <td>
                                    <asp:Button ID="BtnDeleteEvent" CssClass="btn btn-danger" Width="100px" CommandName="EventRemove" CommandArgument='<%# Eval("EventID") %>' runat="server" Text="Remove" />
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
                </div>
            </div>
        </div>





        <div class="col-lg-6">
            <h1>Manage featured courses</h1>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="form-inline">
                        <div class="form-group">
                            <asp:Button ID="BtnCourses" runat="server" CssClass="btn btn-success" Text="Add new course" OnClick="BtnCourses_Click" />

                        </div>
                    </div>

                </div>
                <div class="panel-body">
                    <asp:Repeater ID="CoursesRPT" runat="server" OnItemCommand="CoursesRPT_ItemCommand">
                        <HeaderTemplate>
                            <table id="courses" class="table table-striped table-bordered" cellspacing="0" width="100%">
                                <thead>
                                    <tr>
                                        <th scope="col" style="width: 200px">Course title
                                        </th>
                                        <th scope="col" style="width: 200px">Course type
                                        </th>
                                        <th scope="col" style="width: 100px"></th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="lblcoursename" runat="server" Text='<%# Eval("CourseName") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblcoursetype" runat="server" Text='<%# Eval("ProgramName") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Button ID="BtnDeleteCourse" CssClass="btn btn-danger" Width="100px" CommandName="CoursesRemove" CommandArgument='<%# Eval("CourseID") %>' runat="server" Text="Remove" />
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
                </div>
            </div>
        </div>





    </div>




    <div class="row">
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
                        <button type="button" class="close" id="closeModel" data-dismiss="modal" data-target="#myModal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title text-center" id="myModalLabel">Upload new images</h4>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <div>
                                    <asp:FileUpload runat="server" ID="UploadImages" AllowMultiple="true" />
                                    <br />
                                    <asp:Button runat="server" ID="uploadedFile" CssClass="btn btn-success" Text="Upload" OnClick="uploadFile_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
        </div>
    </div>





    <div class="row">
        <script type="text/javascript">
            function ShowPopupevent() {
                $("#btnShowEventPop").click();
            }
        </script>
        <button type="button" style="display: none;" id="btnShowEventPop" class="btn btn-primary btn-lg"
            data-toggle="modal" data-target="#myModalevent">
        </button>
        <div class="modal fade" id="myModalevent" role="dialog">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" id="closeModelevent" data-dismiss="modal" data-target="#myModalevent" aria-hidden="true">&times;</button>
                        <h4 class="modal-title text-center" id="myModalLabelevent">Add new event</h4>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <div>
                                    <asp:Repeater ID="ModalEventRPT" runat="server" OnItemCommand="ModalEventRpt_ItemCommand">
                                        <HeaderTemplate>
                                            <table id="modalevent" class="table table-striped table-bordered" cellspacing="0" width="100%">
                                                <thead>
                                                    <tr>

                                                        <th scope="col" style="width: 250px">Event Title
                                                        </th>

                                                        <th scope="col" style="width: 60px">Start Date
                                                        </th>
                                                        <th scope="col" style="width: 60px">End Date
                                                        </th>
                                                        <th scope="col" style="width: 80px">Registration
                                                        </th>
                                                        <th scope="col" style="width: 80px">Status
                                                        </th>
                                                        <th scope="col" style="width: 250px"></th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>

                                                <td>
                                                    <asp:Label ID="lbEventTitle" runat="server" Text='<%# Eval("EventTitle") %>' />
                                                </td>

                                                <td>
                                                    <asp:Label ID="lbStartDate" runat="server" Text='<%# Eval("EventStart") %>' />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbEndDate" runat="server" Text='<%# Eval("EventEnd") %>' />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbRegistration" runat="server" Text='<%#((int)Eval("RegistrationStatus") == 1) ? "Yes" : "No" %>' />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text='<%#((int)Eval("PublishStatus") == 2) ? "Published" : "UnPublished" %>' />
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnEventAdd" CssClass="btn btn-success" Width="170px" CommandName="ModalAddEvent" CommandArgument='<%# Eval("EventID") %>' runat="server" Text="Add to featured event" />

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
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
        </div>
    </div>

    <div class="row">
        <script>
            $(document).ready(function () {
                $('#Modalcourses').DataTable();
            });
        </script>
        <script type="text/javascript">
            function ShowPopupcourse() {
                $("#btnShowCoursePop").click();
            }
        </script>
        <button type="button" style="display: none;" id="btnShowCoursePop" class="btn btn-primary btn-lg"
            data-toggle="modal" data-target="#myModalcourse">
        </button>
        <div class="modal fade" id="myModalcourse" role="dialog">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" id="btnmyModalcourse" data-dismiss="modal" data-target="#myModalcourse" aria-hidden="true">&times;</button>
                        <h4 class="modal-title text-center" id="myModalLabelcourse">Add new course</h4>
                    </div>
                    <div class="modal-body">

                        <div class="row">
                            <div class="col-lg-12">
                                <div>
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

                                            </div>



                                        </div>
                                        <div class="panel-body">
                                            <asp:UpdatePanel ID="uppanel" runat="server">
                                                <ContentTemplate>
                                                    <asp:Repeater ID="ModalcoursesRPT" runat="server" OnItemCommand="ModalCoursesRpt_ItemCommand">
                                                        <HeaderTemplate>
                                                            <table id="Modalcourses" class="table table-striped table-bordered" cellspacing="0" width="100%">
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
                                                                    <asp:Label ID="lbProgramType" runat="server" Text='<%# Eval("ProgramName") %>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lbCourseTitle" runat="server" Text='<%# Eval("CourseName") %>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lbCourseVersion" runat="server" Text='<%# Eval("CourseVersion") %>' />
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="btnAddCourse" CssClass="btn btn-success" Width="170px" CommandName="ModalAddCourse" CommandArgument='<%# Eval("CourseID") %>' runat="server" Text="Add to featured course" />
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
                                                </ContentTemplate>
                                                <Triggers>

                                                    <asp:AsyncPostBackTrigger ControlID="ModalcoursesRPT" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
        </div>
    </div>

</asp:Content>
