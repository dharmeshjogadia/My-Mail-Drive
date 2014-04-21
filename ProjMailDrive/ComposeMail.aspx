<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ComposeMail.aspx.cs" Inherits="ComposeMail" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Contet1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <asp:Button ID="btnSend" runat="server" CssClass="send btn btn-success glyphicon glyphicon-ok-circle"
                        Text="Send" OnClick="btnSend_Click" ValidationGroup="mail" />
                    <asp:Button ID="btnSave" runat="server" class="send btn btn-primary glyphicon glyphicon glyphicon-floppy-disk"
                        Text="Save" OnClick="btnSave_Click" />
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label>
                            To<asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtTOEmailId"
                                ValidationGroup="mail" ErrorMessage="To mail id is Required." Text="*" ForeColor="red"
                                Font-Size="X-Large" />
                        </label>
                        <asp:TextBox ID="txtTOEmailId" runat="server" placeholder="To Emai Id" class="form-control "
                            Rows="3" TextMode="MultiLine" />
                    </div>
                    <button type="button" class="btn-link" id="Cc">
                        Cc</button>
                    <button type="button" class="btn-link" id="Bcc">
                        Bcc</button>
                    <i class=" glyphicon glyphicon-paperclip"></i>
                    <button type="button" class="btn-link" id="Attachment" data-toggle="modal" data-target=".bs-example-modal-sm">
                        Attachment</button>
                    <div class="form-group" id="CcTxt">
                        <asp:TextBox ID="txtCCEmailId" runat="server" placeholder="Cc Emai Id" class="form-control "
                            Rows="2" TextMode="MultiLine" />
                    </div>
                    <div class="form-group" id="BccTxt">
                        <asp:TextBox ID="txtBCCEmailId" class="form-control" runat="server" placeholder="Bcc Emai Id"
                            Rows="2" TextMode="MultiLine" />
                    </div>
                    <div class="form-group" >
                    <label>Subject</label>
                        <asp:TextBox ID="txtSubject" class="form-control" runat="server" placeholder="Subject"
                             />
                    </div>
                    <div class="form-group">
                        <label>
                            Body</label>
                        <div>
                            <CKEditor:CKEditorControl ID="CKEditor1" BasePath="/ckeditor/" runat="server">
                            </CKEditor:CKEditorControl>
                        </div>
                        <%-- <asp:TextBox runat="server" ID="txtBody" class="body" Rows="10" Columns="80" 
                    TextMode="MultiLine" />
                <script>
                    // Replace the <textarea id="editor1"> with a CKEditor
                    // instance, using default configuration.
                   
                </script>--%>
                    </div>
                    <asp:ValidationSummary ID="vs" runat="server" ValidationGroup="mail" CssClass="alert text-danger bg-danger"  />
                </div>
            </div>
            <div class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel"
                aria-hidden="true" id="AddFolderDialog">
                <div class="modal-dialog moda-sm">
                    <div id="AddFolder" class="modal-content">
                        <div class="modal-header">
                            <i class="glyphicon glyphicon-cloud-upload"></i>Upload File
                        </div>
                        <div class="modal-body">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="form-group">
                                        <asp:FileUpload ID="flpuFile" placeholder="Enter Folder Name" runat="server" CssClass="form-control" />
                                    </div>
                                    <div class="form-group">
                                        <asp:FileUpload ID="FileUpload1" placeholder="Enter Folder Name" runat="server" CssClass="form-control" />
                                    </div>
                                    <div class="form-group">
                                        <asp:FileUpload ID="FileUpload2" placeholder="Enter Folder Name" runat="server" CssClass="form-control" />
                                    </div>
                                    <div class="form-group">
                                        <asp:FileUpload ID="FileUpload3" placeholder="Enter Folder Name" runat="server" CssClass="form-control" />
                                    </div>
                                    <div class="form-group">
                                        <asp:FileUpload ID="FileUpload4" placeholder="Enter Folder Name" runat="server" CssClass="form-control" />
                                    </div>
                                    <asp:Button ID="btnUploadFile" runat="server" CssClass="btn btn-success folder" Text="Upload" />
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="btnUploadFile" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSend" />
            <asp:PostBackTrigger ControlID="btnSave" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
