<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="AppViewer.UI.Account.ManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="centercontainer">
        <div class="whitebox">
            <asp:LinkButton ID="btnBack" runat="server" CssClass="anchor" OnClick="btnBack_Click"
                Style="float: right; margin-top: 5px;">Back to Manage Apps screen</asp:LinkButton>

            <h1>Manage Users</h1>

            <div class="divide"></div>
            <div style="padding-left: 15px;">
            </div>
        </div>
    </div>
</asp:Content>
