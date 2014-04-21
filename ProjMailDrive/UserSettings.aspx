<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="UserSettings.aspx.cs" Inherits="UserSettings" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-default">
        <!-- Nav tabs -->
        <ul class="nav nav-tabs" id="myTab">
            <li class="active"><a href="#general" data-toggle="tab">General</a></li>
            <%--<li><a href="#mail" data-toggle="tab">Mail</a></li>--%>
            <li><a href="#signature" data-toggle="tab">Signature</a></li>
            <li><a href="#account" data-toggle="tab">Account</a></li>
        </ul>
        <!-- Tab panes -->
        <div class="tab-content">
            <div class="tab-pane active fade" id="general">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-sm-2 control-label">
                            Max Page Size :
                        </label>
                        <div class="col-sm-10">
                            <div class="dropdown">
                                <asp:DropDownList ID="ddlPageSize" runat="server" CssClass="form-control">
                                    <asp:ListItem>--Select Page Size--</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                    <asp:ListItem>50</asp:ListItem>
                                    <asp:ListItem>70</asp:ListItem>
                                    <asp:ListItem>100</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label">
                            Theme :
                        </label>
                        <div class="col-sm-10">
                            <div class="dropdown">
                                <asp:DropDownList ID="ddlTheme" runat="server" CssClass="form-control">
                                    <asp:ListItem>--Select Theme--</asp:ListItem>
                                    <asp:ListItem Value="bootstrap.min.css">Default</asp:ListItem>
                                    <asp:ListItem Value="superbhero.css">Superb Hero</asp:ListItem>
                                    <asp:ListItem Value="cosmo.css">Cosmo</asp:ListItem>
                                    <asp:ListItem Value="lumen.css" >Lumen</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label">
                            Notification :
                        </label>
                        <div class="col-sm-10">
                            <div class="radio-inline">
                                <label>
                                    <asp:RadioButton ID="rbtnON" runat="server" GroupName="Notify" Text="ON" />
                                </label>
                            </div>
                            <div class="radio-inline">
                                <label>
                                    <asp:RadioButton ID="rbtnOFF" runat="server" GroupName="Notify" Text="OFF" />
                                </label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label">
                            Auto Create Contact :
                        </label>
                        <div class="col-sm-10">
                            <div class="radio-inline">
                                <label>
                                    <asp:RadioButton ID="rbtnON1" runat="server" GroupName="Contact" Text="ON" />
                                </label>
                            </div>
                            <div class="radio-inline">
                                <label>
                                    <asp:RadioButton ID="rbtnOFF1" runat="server" GroupName="Contact" Text="OFF" />
                                </label>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:Button ID="btnSaveGeneral" runat="server" class="btn btn-success glyphicon glyphicon glyphicon-floppy-disk"
                    Text="Save" onclick="btnSaveGeneral_Click1" />
                <asp:Button ID="Button3" runat="server" class="btn btn-danger glyphicon glyphicon glyphicon-floppy-remove"
                    Text="Cancel" PostBackUrl="~/Inbox.aspx" />
            </div>
            <%-- <div class="tab-pane fade" id="mail">
                Mail</div>--%>
            <div class="tab-pane fade" id="signature">
                <div class="form-group">
                    <label class="control-label">
                        Signature
                        <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="CKEditor1"
                            ValidationGroup="Signature" ErrorMessage="Signature is Required." Text="*" ForeColor="red"
                            Font-Size="X-Large" />
                    </label>
                    <CKEditor:CKEditorControl ID="CKEditor1" BasePath="/ckeditor/" runat="server">
                    </CKEditor:CKEditorControl>
                    <asp:ValidationSummary ID="vs" runat="server" ValidationGroup="Signature" CssClass="text-danger bg-danger alert" />
                </div>
                <asp:Button ID="btnSaveSignature" runat="server" class="btn btn-success glyphicon glyphicon glyphicon-floppy-disk"
                    Text="Save" ValidationGroup="Signature" OnClick="btnSaveSignature_Click" />
                <asp:Button ID="Button2" runat="server" class="btn btn-danger glyphicon glyphicon glyphicon-floppy-remove"
                    Text="Cancel" PostBackUrl="~/Inbox.aspx" />
            </div>
            <div class="tab-pane fade" id="account">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Change Password
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label class="col-sm-2 control-label">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOldPwd"
                                        ValidationGroup="chgPwd" ErrorMessage="Old Password is Required." Text="*" ForeColor="red"
                                        Font-Size="X-Large" />
                                    Old Password :
                                </label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtOldPwd" runat="server" CssClass="form-control" placeholder="Old Password"
                                        TextMode="Password" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPwd"
                                        ValidationGroup="chgPwd" ErrorMessage="New Password is Required." Text="*" ForeColor="red"
                                        Font-Size="X-Large" />
                                    New Password :
                                </label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtNewPwd" runat="server" CssClass="form-control" placeholder="New Password"
                                        TextMode="Password" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">
                                    Confirm Password :
                                </label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtConfPwd" runat="server" CssClass="form-control" placeholder="Confirm Password"
                                        TextMode="Password" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Security Question
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label class="col-sm-2">
                                    Question :
                                </label>
                                <div class="col-sm-10">
                                    <div class="dropdown">
                                        <asp:DropDownList ID="ddlQuestion" runat="server" CssClass="form-control">
                                            <asp:ListItem>--Select Question--</asp:ListItem>
                                            <asp:ListItem>Que 1</asp:ListItem>
                                            <asp:ListItem>Que 2</asp:ListItem>
                                            <asp:ListItem>Que 3</asp:ListItem>
                                            <asp:ListItem>Que 4</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2">
                                    Answer :
                                </label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtAnswer" runat="server" CssClass="form-control" placeholder="Answer" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                
                <asp:Button ID="btnSaveAct" runat="server" class="btn btn-success glyphicon glyphicon glyphicon-floppy-disk"
                    Text="Save" ValidationGroup="chgPwd" OnClick="btnSaveAct_OnClick" />
                <asp:Button ID="btnCancel" runat="server" class="btn btn-danger glyphicon glyphicon glyphicon-floppy-remove"
                    Text="Cancel" PostBackUrl="~/Inbox.aspx" />
                    
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="chgPwd"
                    CssClass="text-danger bg-danger alert" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfPwd"
                    ValidationGroup="chgPwd" ErrorMessage="Confirm Password is Required." Text=" "
                    ForeColor="white" />
                <asp:CompareValidator ID="cv" runat="server" ControlToValidate="txtConfPwd" ControlToCompare="txtNewPwd"
                    ValidationGroup="chgPwd" ErrorMessage="Confirm does not mach with New password." Text=" "
                    ForeColor="white" />
            </div>
        </div>
    </div>
</asp:Content>
