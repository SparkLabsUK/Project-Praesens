<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AppViewer.UI.Account.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src='<%= ResolveUrl("~/Scripts/Login.js")%>'></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="loginboxcontainer">
        
        <div class="loginbox">
            <asp:LinkButton ID="btnBack" runat="server" CssClass="anchor" OnClick="btnBack_Click" 
                style="float:right; margin-top: 5px;">Back to App Selection Screen</asp:LinkButton>

            <h1>Login</h1>

            <div class="divide"></div>

            <p style="margin-left: 50px;">
                Please enter your username and password to log in.
            </p>
            <table style="margin-top: 20px; margin-left: 50px;">
                <tr>
                    <td style="width: 150px; vertical-align: top;">
                        USERNAME
                    </td>
                    <td style="padding-left: 10px; height: 40px; vertical-align: top;">
                        <asp:TextBox ID="txtUsername" runat="server" ClientIDMode="Static" CssClass="txtbox"></asp:TextBox>
                        <br />
                        <asp:Label ID="lblUsername" runat="server" ClientIDMode="Static" Text="Please enter a username." CssClass="txtboxerror" style="display: none;"></asp:Label>
                    </td>
                </tr>
                <tr><td colspan="2" style="padding-top:5px;"></td></tr>
                <tr>
                    <td style="width: 150px; vertical-align: top;">
                        PASSWORD
                    </td>
                    <td style="padding-left: 10px; height: 40px; vertical-align: top;">
                        <asp:TextBox ID="txtPassword" runat="server" ClientIDMode="Static" TextMode="Password" CssClass="txtbox" OnKeyDown="if (event.keyCode == 13) document.getElementById('btnLogin').click()">
                        </asp:TextBox>
                        <br />
                        <asp:Label ID="lblPassword" runat="server" ClientIDMode="Static" Text="Please enter a password." CssClass="txtboxerror" style="display: none;"></asp:Label>
                    </td>

               
                </tr>

                <tr><td colspan="2" style="padding-top:10px;"></td></tr>

                <tr>
                    
                
                    <td colspan="2">
                        <asp:LinkButton ID="btnLogin" runat="server" OnClick="btnLogin_Click" CssClass="buttongreysmall" ClientIDMode="Static" 
                            OnClientClick="if ($('#txtPassword').val().length == 0){ $('#lblPassword').show().focus(); }else{ $('#lblPassword').hide(); } if ($('#txtUsername').val().length == 0){ $('#lblUsername').show().focus(); }else{ $('#lblUsername').hide(); } return ($('#txtUsername').val().length > 0 && $('#txtPassword').val().length > 0);">
                            Login
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

