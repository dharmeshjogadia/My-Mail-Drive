<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="UserProfile.aspx.cs" Inherits="UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <span class="glyphicon glyphicon-user"></span>My Profile
        </div>
        <div class="panel-body">
            <div class="row" id="UserProfile">
                <div class="col-md-2">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Image ID="imgProfilePic" runat="server" CssClass="img-thumbnail"
                            ImageUrl="image/account.png" />
                            <%--<img src="image/account.png" id="imgUserPhoto" class="img-thumbnail" alt="User Img" />--%>
                            <button type="button" id="btnProfileEdit" class="glyphicon glyphicon-pencil btn btn-block btn-primary">
                            </button>
                        </div>
                    </div>
                </div>
                <div class="col-md-10">
                    <div class="row">
                        <div class="col-md-12 h3">
                            <asp:Label ID="lblFirstName" runat="server"></asp:Label> <asp:Label ID="lblLastName" runat="server"></asp:Label> <small>&lt<asp:Label ID="lblEmailId" runat="server"></asp:Label>&gt</small>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Label ID="lblGender" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Label ID="lblBirthDate" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                           <asp:Label ID="lblMobileNumber" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div id="EditProfile">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-md-2 col-sm-4">
                                    <asp:Image ID="imgEditProfile" runat="server" CssClass="img-thumbnail"
                            ImageUrl="image/account.png" />
                            
                                </div>
                                <div class="col-md-10 col-sm-8">
                                    <div class="form-group">
                                        <div>
                                            Name :
                                            <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtFName"
                                                ValidationGroup="profile" ErrorMessage="Name is Required." Text="*" ForeColor="red"
                                                Font-Size="X-Large" />
                                        </div>
                                        <asp:TextBox ID="txtFName" placeholder="First Name" runat="server"></asp:TextBox>
                                        <asp:TextBox ID="txtLName" placeholder="Last Name" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <div>
                                            Phone No :
                                        </div>
                                        <asp:TextBox ID="txtPhoneNo" CssClass="form-control" placeholder="Phone No" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <div>
                                           Alternate Email Id :
                                        </div>
                                        <asp:TextBox ID="txtEmailId" CssClass="form-control" placeholder="Alternate  Id" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <div>
                                            Photo :
                                        </div>
                                        <asp:FileUpload ID="flupPhoto" runat="server" />
                                    </div>
                                    <asp:Button ID="btnSave" ValidationGroup="profile" CssClass="btn btn-success" 
                                        runat="server" Text="Save" onclick="btnSave_Click" />
                                    <asp:Button ID="btnBack" CssClass="btn btn-danger" runat="server" Text="Back" 
                                        onclick="btnBack_Click" />
                                    <asp:ValidationSummary id="vs" runat="server" ValidationGroup="profile" 
                                        CssClass="alert text-danger bg-danger"
                                    />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnSave" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
