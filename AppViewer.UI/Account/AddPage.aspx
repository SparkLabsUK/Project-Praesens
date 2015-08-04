<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="AddPage.aspx.cs" Inherits="AppViewer.UI.Account.AddPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src='<%= ResolveUrl("~/Scripts/AddPage.js")%>'></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="centercontainer">
        <div class="whitebox">

            <asp:LinkButton ID="btnBack" runat="server" Style="float: right; margin-top: 5px;"
                CssClass="anchor" OnClientClick="" OnClick="btnBack_Click">Back to Manage App</asp:LinkButton>

            <h1>Add New Page</h1>
            <div class="divide"></div>

            <p>
                To add a page, fill out the form below and select an image.
            </p>

            <table style="margin-top: 20px; margin-left: 50px;">
                <tr>
                    <td style="width: 150px; vertical-align: top;">NAME:
                    </td>
                    <td style="padding-left: 10px; vertical-align: top;">
                        <asp:TextBox ID="txtPageName" runat="server" ClientIDMode="Static" CssClass="addpagetxt"></asp:TextBox>
                        <br />
                        <asp:Label ID="lblPageName" runat="server" ClientIDMode="Static" Text="Please enter a name for the new page." CssClass="txtboxerror" Style="display: none;"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-top: 10px;"></td>
                </tr>
                <tr>
                    <td style="width: 150px; vertical-align: top;">
                        IMAGE SIZE:
                    </td>
                    <td style="padding-left: 10px; vertical-align: top;">
                       <asp:Label ID="appImageSize" runat="server">Image Size</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-top: 10px;"></td>
                </tr>
                <tr>
                    <td style="width: 150px; vertical-align: top;">IMAGE:
                    </td>
                    <td style="padding-left: 10px; vertical-align: top;">
                        <asp:FileUpload ID="updImage" runat="server" />
                        <br />
                        <asp:Label ID="lblPageImage" runat="server" ClientIDMode="Static" Text="Please select an image." CssClass="txtboxerror" Visible="false"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td colspan="2" style="padding-top: 10px;"></td>
                </tr>
                <tr>
                    <td style="width: 150px; vertical-align: top;">NOTES:
                    </td>
                    <td style="padding-left: 10px; vertical-align: top;">

                        <asp:TextBox ID="txtPageNotes" runat="server" ClientIDMode="Static" CssClass="notestxtbox" TextMode="MultiLine"> </asp:TextBox>
                        <br />
                        <asp:Label ID="lblPageNotes" runat="server" ClientIDMode="Static" Text="Please enter notes for the new page." CssClass="txtboxerror" Style="display: none;"></asp:Label>
                    </td>
                </tr>
                <tr>
                <td colspan="2" style="padding-top: 10px;"></td>
                </tr>
                <tr>
                    <td></td>
                    <td style="padding-left: 10px; vertical-align: top;">
                        <asp:Button ID="btnAddPage" runat="server" CssClass="buttongrey" OnClick="btnAddPage_Click" Text="Add Page" OnClientClick="return AddPage();" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
            </table>
            <div style="clear: both;"></div>
        </div>
    </div>
</asp:Content>
