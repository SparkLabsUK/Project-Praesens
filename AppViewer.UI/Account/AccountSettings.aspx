<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="AccountSettings.aspx.cs" Inherits="AppViewer.UI.Account.AccountSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../Scripts/AccountSettings.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="centercontainer">
        <div class="whitebox">
            
            <asp:LinkButton ID="btnBack" runat="server" CssClass="anchor" OnClick="btnBack_Click" 
                style="float:right; margin-top: 5px;">Back</asp:LinkButton>

            <h1>Account Settings</h1>

            <div class="divide"></div>

            <div style="margin-left:100px; width:760px; overflow: hidden; border: 1px solid #aaaaaa;">
             <div id="imgContainer" runat="server">
                 
                </div>
                  <div style="margin-left:20px; margin-top:10px;">
            <h3>Change Password</h3>
                <div class="divide" style="width:720px"></div>
                <div style="margin-top:-10px;">
                <p>
                To Change your password, fill in the form below
            </p>
            <table style="margin-top: 30px; margin-left: 140px;">
                <tr>
                    <td style="width: 220px; vertical-align: top;">
                        CURRENT PASSWORD:
                    </td>
                    <td style="padding-left: 10px; height: 40px; vertical-align: top;">
                        <asp:TextBox ID="txtOldPass" runat="server" ClientIDMode="Static" TextMode="Password" CssClass="txtbox" Width="200px"></asp:TextBox>
                        <br />
                        <asp:Label ID="lblOldPass" runat="server" ClientIDMode="Static" Text="Please enter your current password" CssClass="txtboxerror" style="display: none;"></asp:Label>
                    </td>
                </tr>
                <tr><td colspan="2" style="padding-top:5px;"></td></tr>
                <tr>
                    <td style="width: 150px; vertical-align: top;">
                        NEW PASSWORD:
                    </td>
                    <td style="padding-left: 10px; height: 40px; vertical-align: top;">
                        <asp:TextBox ID="txtNewPass" runat="server" ClientIDMode="Static" TextMode="Password" CssClass="txtbox" Width="200px"></asp:TextBox>
                        <br />
                        <asp:Label ID="lblNewPass" runat="server" ClientIDMode="Static" Text="Please enter a new password" CssClass="txtboxerror" style="display: none;"></asp:Label>
                    </td>
                </tr>
                <tr><td colspan="2" style="padding-top:5px;"></td></tr>
                <tr>
                    <td style="width: 150px; vertical-align: top;">
                        CONFIRM NEW PASSWORD:
                    </td>
                    <td style="padding-left: 10px; height: 40px; vertical-align: top;">
                        <asp:TextBox ID="txtConfirmPass" runat="server" ClientIDMode="Static" TextMode="Password" CssClass="txtbox" Width="200px">
                        </asp:TextBox>
                        <br />
                        <asp:Label ID="lblConfirmPass" runat="server" ClientIDMode="Static" Text="Please confirm your new password" CssClass="txtboxerror" style="display: none;"></asp:Label>
                    </td>
                </tr>
                <tr><td colspan="2" style="padding-top:10px;"></td></tr>
                <tr>
                    <td colspan="2" align="right">
                       
                        <asp:Label ID="lblSuccess" runat="server" Text="Password Successfully Changed" CssClass="txtboxsuccess" style=" margin-right:10px;" Visible="false"></asp:Label>
                        <asp:Label ID="lblFail" runat="server" Text="Current password incorrect, Please try again." CssClass="txtboxfail" style=" margin-right:10px;" Visible="false"></asp:Label>
                        
                        <asp:LinkButton ID="btnChangePass" runat="server" OnClick="btnChangePass_Click" CssClass="buttongreysmall" ClientIDMode="Static" OnClientClick="return ChangePassword();"> Save </asp:LinkButton>
                    </td>
                </tr>
            </table>

            <br />

            </div> 
      </div>         
    </div>
    </div> 
        

</asp:Content>