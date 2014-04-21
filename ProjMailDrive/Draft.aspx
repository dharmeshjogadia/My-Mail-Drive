﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Draft.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="h4">
        Draft
    </div>
    <div class="table-responsive">
        <asp:GridView ID="gvSent" runat="server" CssClass="table table-hover table-condensed grid"
            OnSelectedIndexChanging="gvInbox_OnSelectedIndexChanging" AutoGenerateColumns="false"
            GridLines="None">
            <HeaderStyle CssClass="text-primary " />
            <RowStyle CssClass="text-primary" />
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" CommandName="select">
                     <b>
                        <%# GetSenderName((Users)(Eval("Sender"))) %>
                     </b>
                     <br />
                     <%# Eval("subject") %>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:ButtonField ButtonType="Link" CommandName="select" HeaderText="Date/Time" DataTextField="send_time"
                    ControlStyle-Width="150px"/>
                <asp:TemplateField ControlStyle-Width="0">
                    <ItemTemplate>
                        <asp:HiddenField ID="hdfComposeId" runat="server" Value='<%# Eval("composeId") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField ControlStyle-CssClass="glyphicon glyphicon-paperclip">
                    <ItemTemplate>
                        <%# (String.IsNullOrEmpty(Eval("Email").ToString()) ? "<span Class='glyphicon glyphicon-paperclip'><span>" : String.Empty) %>
                    </ItemTemplate>
                </asp:TemplateField>--%>
            </Columns>
            <EmptyDataTemplate>
                No Mail Found In Spam
            </EmptyDataTemplate>
            <EmptyDataRowStyle CssClass="alert alert-info" />
        </asp:GridView>
    </div>
</asp:Content>
