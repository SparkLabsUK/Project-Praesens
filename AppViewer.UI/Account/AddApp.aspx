<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="AddApp.aspx.cs" Inherits="AppViewer.UI.Account.AddApp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src='<%= ResolveUrl("~/Scripts/AddApp.js")%>'></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="centercontainer">
        <div class="whitebox">
        
            <asp:LinkButton ID="btnBack" runat="server" style="float:right; margin-top: 5px;" 
                CssClass="anchor" OnClientClick="" OnClick="btnBack_Click">Back to Manage Apps</asp:LinkButton>

            <h1>Add New App</h1>
            <div class="divide"></div>
            <div style="padding:5px;">
            <p>
                Fill in the form below to add a new app.
            </p>
            </div>

            <div class="whitebox">
                <h2>App Details</h2>
                <div class="divide"></div>

                <table style="margin-top: 20px; margin-left: 10px; float: left;">
                    <tr>
                        <td style="width: 150px; vertical-align: top;">

                        </td>
                        <td style="padding-left: 5px; height: 46px; vertical-align: top;">
                            
                        </td>
                    </tr>
                    <tr><td colspan="2" style="padding-top:5px;"></td></tr>
                    <tr>
                        <td style="width: 150px; vertical-align: top;">
                            NAME:
                        </td>
                        <td style="padding-left: 5px; height: 40px; vertical-align: top;">
                            <asp:TextBox ID="txtAppName" runat="server" ClientIDMode="Static" CssClass="txtbox"></asp:TextBox>
                            <br />
                            <asp:Label ID="lblAppName" runat="server" ClientIDMode="Static" Text="Please enter a name for the new app." CssClass="txtboxerror" style="display: none;"></asp:Label>
                        </td>
                    </tr>
                    <tr><td colspan="2" style="padding-top:5px;"></td></tr>
                    <tr>
                        <td style="width: 150px; vertical-align: top;">
                            DESCRIPTION:
                        </td>
                        <td style="padding-left: 5px; height: 40px; vertical-align: top;">
                            <asp:TextBox ID="txtAppDescription" runat="server" ClientIDMode="Static" CssClass="txtbox"></asp:TextBox>
                            <br />
                            <asp:Label ID="lblAppDescription" runat="server" ClientIDMode="Static" Text="Please enter a description for the new app." CssClass="txtboxerror" style="display: none;"></asp:Label>
                        </td>
                    </tr>
                    <tr><td colspan="2" style="padding-top:5px;"></td></tr>
                    <tr>
                        <td style="width: 150px; vertical-align: top;">
                            URL:
                        </td>
                        <td style="padding-left: 5px; height: 40px; vertical-align: top;">
                            <asp:TextBox ID="txtAppUrl" runat="server" ClientIDMode="Static" CssClass="txtbox">
                            </asp:TextBox>
                            <br />
                            <asp:Label ID="lblAppUrl" runat="server" ClientIDMode="Static" Text="Please enter a url for the new app." CssClass="txtboxerror" style="display: none;"></asp:Label>
                        </td>
                    </tr>
                </table>

                <table style="margin-top: 0px; margin-left: 40px; float: left">
                <tr>
                    <td colspan="2">
                        <div class="greybox">
                            <label style="margin-bottom: 3px;">Select a pre-configured device size</label>
                            <br />
                            <asp:DropDownList ID="drpDevices" runat="server" ClientIDMode="Static" AutoPostBack="false"></asp:DropDownList>
                        </div>
                    </td>
                </tr>
                <tr><td colspan="2" style="padding-top:10px;"></td></tr>
                 <tr>
                    <td style="width: 150px; vertical-align: top;">
                        WIDTH:
                    </td>
                    <td style="padding-left: 10px; height: 40px; vertical-align: top;">
                        <asp:TextBox ID="txtDeviceWidth" runat="server" ClientIDMode="Static" CssClass="txtbox"></asp:TextBox>
                        <br />
                        <asp:Label ID="lblWidth" runat="server" ClientIDMode="Static" Text="Please enter a valid width" CssClass="txtboxerror" style="display: none;"></asp:Label>
                    </td>
                </tr>
                <tr><td colspan="2" style="padding-top:5px;"></td></tr>
                <tr>
                    <td style="width: 150px; vertical-align: top;">
                        HEIGHT:
                    </td>
                    <td style="padding-left: 10px; height: 40px; vertical-align: top;">
                        <asp:TextBox ID="txtDeviceHeight" runat="server" ClientIDMode="Static" CssClass="txtbox">
                        </asp:TextBox>
                        <br />
                        <asp:Label ID="lblHeight" runat="server" ClientIDMode="Static" Text="Please enter a valid height" CssClass="txtboxerror" style="display: none;"></asp:Label>
                    </td>
                </tr>
                <tr><td colspan="2" style="padding-top:5px;"></td></tr>
                <tr>
                    <td style="width: 150px; vertical-align: top;">
                        FULLSCREEN SIZE:
                    </td>
                    <td style="padding-left: 10px; height: 40px; vertical-align: top;">
                        <asp:TextBox ID="txtFull" runat="server" ClientIDMode="Static" CssClass="txtbox">
                        </asp:TextBox>
                        <br />
                        <asp:Label ID="lblFullscreen" runat="server" ClientIDMode="Static" Text="Please enter a valid Fullscreen Size" CssClass="txtboxerror" style="display: none;"></asp:Label>
                    </td>
                </tr> 
                </table>

                <div style="clear: both;"></div>

                <div style="float: right;">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btnAddApp_Click"
                           CssClass="buttongrey" OnClientClick="return AddApp();">Add New App</asp:LinkButton>
                </div>

                <div style="clear: both;"></div>

            </div>
        </div>
    </div>
</asp:Content>
