<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DriveHome.aspx.cs" Inherits="DriveHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="tree">
        <asp:Literal ID="ltlTree" runat="server" />
    </div>
    <div class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel"
        aria-hidden="true" id="AddFolderDialog">
        <div class="modal-dialog moda-sm">
            <div id="AddFolder" class="modal-content">
                <div class="modal-header">
                    <i class="glyphicon glyphicon-plus-sign"></i>Add New Folder
                </div>
                <div class="modal-body">
                    <div id="Div1" class="">
                        <div>
                            Path:<asp:Label ID="lblPathFolder" ClientIDMode="Static" runat="server" />
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtFolderName" placeholder="Enter Folder Name" runat="server" CssClass="form-control"
                                Text="sdg" />
                        </div>
                        <asp:Button ID="btnAddFolder" runat="server" CssClass="btn btn-success folder" Text="Save"
                            OnClick="btnAddFolder_Click" />
                    </div>
                </div>
            </div>
            <div id="AddFile" class="modal-content">
                <div class="modal-header">
                    <i class="glyphicon glyphicon-cloud-upload"></i>Upload New File
                </div>
                <div class="modal-body">
                    <div>
                        Path:<asp:Label ID="lblFilePath" ClientIDMode="Static" runat="server" />
                    </div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="form-group">
                                <asp:FileUpload ID="flpuFile" placeholder="Enter Folder Name" runat="server" CssClass="form-control" />
                            </div>
                            <asp:Button ID="btnUploadFile" runat="server" CssClass="btn btn-success folder" Text="Upload"
                                OnClick="btnAddFile_Click" />
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnUploadFile" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            
            <div id="DeleteFile" class="modal-content">
                <div class="modal-header">
                    <i class="glyphicon glyphicon-question-sign"></i> Are you sure you want to delete?
                </div>
                <div class="modal-body">
                    <div>
                        Path:<asp:Label ID="lblDelete" ClientIDMode="Static" runat="server" />
                    </div>
                    <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-success folder" Text="Delete"
                        OnClick="btnDelete_Click"
                    />
                    <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger folder" Text="Cancel"
                         />
                </div>
            </div>
        </div>
    
    </div>
    <asp:HiddenField ID="hdPath" ClientIDMode="Static" Value="dsbv" runat="server" />
</asp:Content>
