<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true"
    CodeFile="AdminNewUser.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-default">
        <ul class="nav nav-tabs">
            <li class="active"><a href="#UserDetail" data-toggle="tab" class="glyphicon glyphicon-th-list">
                Users Detail</a></li>
            <li><a href="#AddNew" data-toggle="tab" class="glyphicon glyphicon-plus">Add New</a></li>
        </ul>
        <div class="tab-content">
            <div class="tab-pane fade in active" id="UserDetail">
                <div class="table-responsive">
                    <asp:GridView ID="gvUserList" runat="server" CssClass="table table-hover table-condensed"
                        AutoGenerateColumns="false" GridLines="None">
                        <HeaderStyle CssClass="text-primary " />
                       
                        <Columns>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <%# Eval("FirstName") %>
                                    <%# Eval("LastName") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Email Id" DataField="UserName" />
                            <asp:BoundField HeaderText="Phone Number" DataField="PhoneNumber" />
                            <%--<asp:TemplateField ControlStyle-CssClass="glyphicon glyphicon-paperclip">
                    <ItemTemplate>
                        <%# (String.IsNullOrEmpty(Eval("Email").ToString()) ? "<span Class='glyphicon glyphicon-paperclip'><span>" : String.Empty) %>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="tab-pane fade" id="AddNew">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        User Detail
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label class="col-sm-2 control-label">
                                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtFName"
                                        ValidationGroup="profile" ErrorMessage="Name is Required." Text="*" ForeColor="red"
                                        Font-Size="X-Large" />
                                    Name :
                                </label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtFName" runat="server" placeholder="First Name" />
                                    <asp:TextBox ID="txtLName" runat="server" placeholder="Last Name" />
                                </div>
                                <div class="col-sm-1">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmailId"
                                        ValidationGroup="profile" ErrorMessage="Email Id is Required." Text="*" ForeColor="red"
                                        Font-Size="X-Large" />
                                    Email Id :
                                </label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtEmailId" type="email" CssClass="form-control" runat="server"
                                        placeholder="Email Id" />
                                </div>
                                <div class="col-sm-1">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">
                                    Phone Number :
                                </label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtPhoneNo" CssClass="form-control" type="tel" runat="server" placeholder="Phone Number" />
                                </div>
                                <div class="col-sm-1">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">
                                    Gender :
                                </label>
                                <div class="col-sm-9">
                                    <div class="radio-inline">
                                        <asp:RadioButton ID="rbtnMale" Checked="true" Text="Male" GroupName="gender" runat="server" />
                                    </div>
                                    <div class="radio-inline">
                                        <asp:RadioButton ID="rbtnFemale" Text="Female" GroupName="gender" runat="server" />
                                    </div>
                                </div>
                                <div class="col-sm-1">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        User Privilages
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label class="col-sm-2 control-label">
                                    User Active :
                                </label>
                                <div class="col-sm-9">
                                    <div class="radio-inline">
                                        <asp:RadioButton ID="rbtnSuspend" Text="Suspend" GroupName="active" runat="server" />
                                    </div>
                                    <div class="radio-inline">
                                        <asp:RadioButton ID="rbtnActive" Text="Active" GroupName="active" runat="server"
                                            Checked="true" />
                                    </div>
                                </div>
                                <div class="col-sm-1">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">
                                    Password :
                                </label>
                                <div class="col-sm-9">
                                    <div class="checkbox-inline">
                                        <asp:CheckBox ID="chkPwdView" Text="View" runat="server" />
                                    </div>
                                    <div class="checkbox-inline">
                                        <asp:CheckBox ID="chkPwdModify" Text="Modify" runat="server" />
                                    </div>
                                </div>
                                <div class="col-sm-1">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">
                                    Spam Filter :
                                </label>
                                <div class="col-sm-9">
                                    <div class="checkbox-inline">
                                        <asp:CheckBox ID="chkSpamFView" Text="View" runat="server" />
                                    </div>
                                    <div class="checkbox-inline">
                                        <asp:CheckBox ID="chkSpamFModify" Text="Modify" runat="server" />
                                    </div>
                                </div>
                                <div class="col-sm-1">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:Button ID="btnSave" runat="server" class="btn btn-success glyphicon glyphicon glyphicon-floppy-disk"
                    Text="Save" ValidationGroup="profile" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" class="btn btn-danger glyphicon glyphicon glyphicon-floppy-remove"
                    Text="Cancel" />
                <asp:ValidationSummary ID="vs" runat="server" ValidationGroup="profile" CssClass="text-danger bg-danger alert" />
            </div>
        </div>
    </div>
</asp:Content>
