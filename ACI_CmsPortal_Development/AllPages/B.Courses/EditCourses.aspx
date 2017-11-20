<%@ Page Title="" Language="C#" MasterPageFile="~/AllMasterPages/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="EditCourses.aspx.cs" Inherits="ACI_CmsPortal_Development.AllPages.B.Courses.EditCourses" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-sm-12">
            <h1>Edit Course
                <asp:Label ID="lblheading" runat="server" Text="Label"></asp:Label></h1>
            <asp:Label ID="lblpublishbefore1" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <asp:Button ID="BtnSave" CausesValidation="false" runat="server" Text="Save" CssClass="btn btn-success" OnClick="BtnSave_Click" />
                    <asp:Button ID="BtnDraft" CausesValidation="false" runat="server" Text="Clear all changes" CssClass="btn btn-warning" OnClick="BtnDraft_Click" />
                    <asp:Button ID="BtnArchive" CausesValidation="false" CssClass="btn btn-default pull-right" runat="server" Text="Back" OnClick="BtnArchive_Click" />
                </div>
                <div class="panel-body">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <fieldset>
                                <ul class="nav nav-tabs">
                                    <li class="active"><a href="#Details" data-toggle="tab" aria-expanded="true">Course Info</a></li>
                                    <li class=""><a href="#Description" data-toggle="tab" aria-expanded="true">Description</a></li>
                                    <li class=""><a href="#Modules" data-toggle="tab" aria-expanded="true">Modules</a></li>

                                    <li class=""><a href="#TargetAudience" data-toggle="tab" aria-expanded="true">Target Audience</a></li>
                                   
                                     <li class=""><a href="#OtherInfo" data-toggle="tab" aria-expanded="true">Other Info</a></li>
                                    <li class=""><a href="#EntryRequirements" data-toggle="tab" aria-expanded="true">Entry Requirements</a></li>
                                    <li class=""><a href="#CourseFees" data-toggle="tab" aria-expanded="true">Course Fees</a></li>
                                    <li class=""><a href="#RefundPolicy" data-toggle="tab" aria-expanded="true">Refund Policy</a></li>


                                </ul>

                                <div id="myTabContent" class="tab-content">
                                    <div class="tab-pane fade active in" id="Details">
                                        <br />
                                        <div class="row">
                                            <div class="col-sm-2"></div>
                                            <div class="col-sm-8">
                                                <div class="form-group">
                                                    <label>
                                                   Publish Status :
                                             </label>
                                                    <asp:DropDownList ID="DDLpublish" CssClass="form-control" Width="100%" runat="server">
                                                        <asp:ListItem Text="Published" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Draft" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Archived" Value="3"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>

                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-2"></div>
                                            <div class="col-sm-8">
                                                <div class="form-group">
                                                     <label>
                                                    Programme :
                                             </label>
                                                   
                                                    <asp:DropDownList ID="DDLProgramme" CssClass="form-control" Width="100%" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="tab-pane fade" id="Description">
                                        <br />
                                        <div class="row">

                                            <CKEditor:CKEditorControl ID="CKEditorDescription" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                                        </div>
                                    </div>

                                    <div class="tab-pane fade" id="TargetAudience">
                                        <br />
                                        <div class="row">
                                            <CKEditor:CKEditorControl ID="CKEditorTargetAudience" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                                        </div>
                                    </div>
                                    <div class="tab-pane fade" id="Modules">
                                        <br />
                                        <div class="row">
                                            <div class="col-sm-2">
                                            </div>
                                            <div class="col-sm-8">                                                      
                                                <asp:UpdatePanel ID="uppanel" runat="server">
                                                    <ContentTemplate>                                               
                                                        <asp:Repeater ID="CoreModuleRPT" runat="server" OnItemCommand="CoreModuleRPT_ItemCommand" OnItemCreated="CoreModuleRPT_ItemCreated">
                                                            <HeaderTemplate>
                                                               <h3> <asp:Label runat="server" ID="label1" Text="Core Module"></asp:Label></h3>
                                                                <div class="panel panel-default">
                                                                <table id="ModuleCore" class="table table-striped table-bordered" cellspacing="0" width="100%">
                                                                    <thead>
                                                                        <tr>
                                                                            <th scope="col" style="width: 500px">Core Modules
                                                                            </th>
                                                                            <th scope="col" style="width: 200px"></th>
                                                                        </tr>
                                                                    </thead>
                                                                    <tbody>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lbroles" runat="server" Text='<%# System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(Container.DataItem.ToString(),true) %>' />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="BtnChangeToElective" Width="200px" CssClass="btn btn-success" CommandName="ChangeToElective" CommandArgument='<%# System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(Container.DataItem.ToString(),true) %>' runat="server" Text="Set as elective module" />
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                </tbody>
                                                                </table></div>
                                                            </FooterTemplate>
                                                        </asp:Repeater>

                                                         <asp:Repeater ID="ElectiveRPT" runat="server" OnItemCommand="ElectiveRPT_ItemCommand">
                                                            <HeaderTemplate>
                                                               <h3> <asp:Label runat="server" ID="lblElective" Text="Elective Module"></asp:Label></h3>
                                                                <div class="panel panel-default">
                                                                <table id="ModuleElective" class="table table-striped table-bordered" cellspacing="0" width="100%">
                                                                    <thead>
                                                                        <tr>
                                                                            <th scope="col" style="width: 500px">Elective Modules
                                                                            </th>
                                                                            <th scope="col" style="width: 200px"></th>
                                                                        </tr>
                                                                    </thead>
                                                                    <tbody>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lbroles" runat="server" Text='<%# System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(Container.DataItem.ToString(),true) %>' />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="BtnChangeToCore" Width="200px" CssClass="btn btn-success" CommandName="ChangeToCore" CommandArgument='<%# System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(Container.DataItem.ToString(),true) %>' runat="server" Text="Set as core module" />
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
                                                        <asp:AsyncPostBackTrigger ControlID="ElectiveRPT" />
                                                        <asp:AsyncPostBackTrigger ControlID="CoreModuleRPT" />
                                                    </Triggers>
                                                </asp:UpdatePanel>                            
                                            </div>
                                        </div>
                                    </div>
                                    <div class="tab-pane fade" id="RefundPolicy">
                                        <br />
                                        <div class="row">
                                            <CKEditor:CKEditorControl ID="CKEditorRefundPolicy" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                                        </div>
                                    </div>
                                    <div class="tab-pane fade" id="EntryRequirements">
                                        <br />
                                        <div class="row">
                                            <CKEditor:CKEditorControl ID="CKEditorEntryRequirements" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                                        </div>
                                    </div>
                                    <div class="tab-pane fade" id="OtherInfo">
                                        <br />
                                        <div class="row">
                                            <CKEditor:CKEditorControl ID="CKEditorOtherInfo" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                                        </div>
                                    </div>
                                    <div class="tab-pane fade" id="CourseFees">
                                        <br />
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <h4>Course Fee:
                                                    <asp:Label ID="lblcoursefee" runat="server" Text=""></asp:Label></h4>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <CKEditor:CKEditorControl ID="CKEditorCourseFees" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                                        </div>
                                    </div>

                                </div>

                            </fieldset>
                        </div>



                    </div>
                </div>



            </div>
        </div>




    </div>

</asp:Content>
