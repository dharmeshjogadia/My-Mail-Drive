<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MailDetail.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <nav class="navbar innerManu">
    <ul class="nav nav-pills bg-info">
        <li class="">
            <asp:LinkButton ID="btnReply" runat="server" OnClick="btnReplay_Click">
                <span class="glyphicon glyphicon-arrow-left"></span> Reply
            </asp:LinkButton>
        </li>
        <li>
            <asp:LinkButton ID="btnForvard" runat="server" OnClick="btnForvard_Click">
                <span class="glyphicon glyphicon-share"></span> Forward
                </asp:LinkButton>
        </li>
        <li>
            <asp:LinkButton ID="btnSpam" runat="server" OnClick="btnSpam_Click">
                <span class="glyphicon glyphicon-fire"></span> Spam
                </asp:LinkButton>
        </li>
        <li>
            <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click">
                <span class="glyphicon glyphicon-trash"></span> Delete
                </asp:LinkButton>
        </li>
        <li>
            <asp:LinkButton ID="LinkButton1" runat="server" >
                <span class="glyphicon glyphicon-folder-open"></span> 
                Move To
                </asp:LinkButton>
        </li>
        <li>
            <a href="Inbox.aspx">
                <span class="glyphicon glyphicon-backward"></span> Back
                </a>
        </li>

    </ul>
                    
</nav>
    <div class="panel panel-default">
        <div class="panel-heading">
            <asp:Literal runat="server" ID="ltlSenderName" /></asp:Literal> <small class="text-info">&lt<asp:Literal runat="server" ID="ltlSenderId" />&gt</small>
            <small class="pull-right"><asp:Literal runat="server" ID="ltlDateTime" /> </small>
        </div>
        <div class="panel-body">
            <div class="table-responsive">
                <table class="table table-hover table-condensed">
                    <tr>
                        <th class="col-sm-2">
                            Subject :
                        </th>
                        <td>
                            <asp:Literal runat="server" ID="ltlSubject" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            To :
                        </th>
                        <td>
                            <asp:Literal ID="ltlTo" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Cc :
                        </th>
                        <td>
                            <asp:Literal ID="ltlCc" runat="server"  />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Attachment :
                        </th>
                        <td>
                            <asp:Panel runat="server" ID="pnlAttachment">      

                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <th colspan="2">
                            Body
                        </th>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Literal Mode="Transform"  ID="ltlBody" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
