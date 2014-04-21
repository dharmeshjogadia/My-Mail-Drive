<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="UserContact.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-default">
        <ul class="nav nav-tabs">
            <li class="active"><a href="#Contacts" data-toggle="tab" class="glyphicon glyphicon-th-list">
                Contacts</a></li>
            <li><a href="#AddNew" data-toggle="tab" class="glyphicon glyphicon-plus">Add New</a></li>
        </ul>
        <div class="tab-content">
            <div class="tab-pane fade in active" id="Contacts">
                <div class="table-responsive">
                    <asp:GridView ID="gvContacts" runat="server" CssClass="table table-hover table-condensed"
                    AutoGenerateColumns="false"
                    GridLines="None"

                    >
                        <HeaderStyle CssClass="text-primary" />
                        <Columns>
                            <asp:BoundField HeaderText="Name" DataField="firstname" />
                            <asp:BoundField HeaderText="Email Id" DataField="emailId" />
                            <asp:BoundField HeaderText="Phone Number" DataField="phoneNumber" />
                            <asp:BoundField HeaderText="Organizationr" DataField="organization" />
                        </Columns>
                        <EmptyDataTemplate>
                            No User Contact found
                        </EmptyDataTemplate>
                        <EmptyDataRowStyle CssClass="info alert" />
                    </asp:GridView>
                    
                </div>
            </div>
            <div class="tab-pane fade" id="AddNew">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-sm-2 control-label">
                            <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtFName"
                                ValidationGroup="contact" ErrorMessage="First Name is Required." Text="*" ForeColor="red"
                                Font-Size="X-Large" />
                            Name :
                        </label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="txtFName" runat="server" placeholder="First Name" />
                            <asp:TextBox ID="txtLName" runat="server" placeholder="Last Name" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label">
                            Phone Number :
                        </label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="txtPhoneNo" CssClass="form-control" type="tel" runat="server" placeholder="Phone Number" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmailId"
                                ValidationGroup="contact" ErrorMessage="Email Id is Required." Text="*" ForeColor="red"
                                Font-Size="X-Large" />
                            Email Id :
                        </label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="txtEmailId" type="email" CssClass="form-control" runat="server"
                                placeholder="Email Id" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label">
                            Organization :
                        </label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="txtOrgnization" CssClass="form-control" runat="server" placeholder="Oranization Name" />
                        </div>
                    </div>
                </div>
                <asp:Button ID="btnSave" runat="server" class="btn btn-success glyphicon glyphicon glyphicon-floppy-disk"
                    Text="Save" ValidationGroup="contact" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" class="btn btn-danger glyphicon glyphicon glyphicon-floppy-remove"
                    Text="Cancel" />
                <asp:ValidationSummary ID="vs" runat="server" ValidationGroup="contact" CssClass="text-danger bg-danger alert" />
            </div>
        </div>
    </div>
</asp:Content>
