<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="ManageApps.aspx.cs" Inherits="AppViewer.UI.Account.ManageApps" %>
  
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../Scripts/AppHome.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<div class="centercontainer">
        <div class="viewerSettings">
            
            <table>
                <tr>
                    <td id="td1" runat="server" style="padding: 10px; ">
                        <asp:Label ID="Label1" runat="server" Style="margin-right: 4px;">Admin Options:</asp:Label>
                    </td>
                    <td id="td2" runat="server" style="padding: 10px; border-left: 1px solid #AAAAAA;">
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="anchor" OnClick="lnkManageUsers_Click">Manage Users</asp:LinkButton>
                    </td>
                    <td id="td3" runat="server" style="padding: 10px; border-left: 1px solid #AAAAAA;">
                        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="anchor" OnClick="lnkManageTeams_Click">Manage Teams</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
    </div>--%>
     
    <div class="centercontainer">
        <div class="whiteboxnew">
            <asp:LinkButton ID="btnBack" runat="server" CssClass="anchor" OnClick="btnBack_Click"
                Style="float: right; margin-top: 5px;">Back to App Selection Screen</asp:LinkButton>

            <h1>Manage Apps</h1>

            <div class="dividenew"></div>
            <div style="padding-left: 15px; float:right;">
                <a href="AddApp.aspx" class="buttongrey">Add New App</a>
            </div>
            <div style="padding-right:10px;">
                <a href="AppWizardStep1.aspx" class="buttongrey">App Creation Wizard</a>
            </div>
            <p>
                To edit an App select it below.
            </p>
            <div style="clear: both;"></div>
        </div>
        </div>
    <div class="centercontainer">
        <div id="divApps" runat="server">
            </div>
        </div>
        

   
</asp:Content>
