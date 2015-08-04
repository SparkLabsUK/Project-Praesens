<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="CreateNewUser.aspx.cs" Inherits="AppViewer.UI.Account.CreateNewUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="loginboxcontainer">
        
        <div class="loginbox">
            <asp:LinkButton ID="btnBack" runat="server" CssClass="anchor" OnClick="btnBack_Click" 
                style="float:right; margin-top: 5px;">Back to Settings</asp:LinkButton>

            <h1>Create New User</h1>

            <div class="divide"></div>

            <p style="margin-left: 50px;">
                To create a new user, fill in the form below
            </p>
            <table style="margin-top: 20px; margin-left: 50px;">
                <tr>
                    <td style="width: 150px; vertical-align: top;">
                        USERNAME
                    </td>
                    <td style="padding-left: 10px; height: 40px; vertical-align: top;">
                        <asp:TextBox ID="txtNewUsername" runat="server" ClientIDMode="Static" CssClass="txtbox"></asp:TextBox>
                        <br />
                        <asp:Label ID="lblNewUsername" runat="server" ClientIDMode="Static" Text="Please enter a username." CssClass="txtboxerror" style="display: none;"></asp:Label>
                    </td>
                </tr>
                <tr><td colspan="2" style="padding-top:5px;"></td></tr>
                <tr>
                    <td style="width: 150px; vertical-align: top;">
                        PASSWORD
                    </td>
                    <td style="padding-left: 10px; height: 40px; vertical-align: top;">
                        <asp:TextBox ID="txtNewPassword" runat="server" ClientIDMode="Static" TextMode="Password" CssClass="txtbox">
                        </asp:TextBox>
                        <br />
                        <asp:Label ID="lblNewPassword" runat="server" ClientIDMode="Static" Text="Please enter a password." CssClass="txtboxerror" style="display: none;"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 150px; vertical-align: top;">
                        USER ROLE
                    </td>
                    <td style="padding-left: 10px; height: 40px; vertical-align: top;">
                        <asp:DropDownList ID="drpUserRole" runat="server"></asp:DropDownList>
                        <br />
                        <asp:Label ID="Label1" runat="server" ClientIDMode="Static" Text="Please Select a Role." CssClass="txtboxerror" style="display: none;"></asp:Label>
                    </td>
                </tr>
                <tr><td colspan="2" style="padding-top:10px;"></td></tr>
                <tr>
                    <td colspan="2" align="right">
                        <asp:LinkButton ID="btnCreateUser" runat="server" OnClick="btnCreateUser_Click" CssClass="buttongreysmalluser" ClientIDMode="Static"> 
                            Create User
                        </asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
        <div class="loginboxerror" id="loginErrorBox" runat="server" visible="false">
            Invalid login information. Please try again or contact the site administrator.
        </div>
    </div>
</asp:Content>

