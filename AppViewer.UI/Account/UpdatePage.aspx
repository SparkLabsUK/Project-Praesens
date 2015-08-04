<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="UpdatePage.aspx.cs" Inherits="AppViewer.UI.Account.UpdatePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="centercontainer">
        <div class="whitebox">
          
            <asp:LinkButton ID="btnBack" runat="server" style="float:right; margin-top: 5px;" 
                CssClass="anchor" OnClientClick="" OnClick="btnBack_Click">Back to Manage Page</asp:LinkButton>
            
            <h1>Change Image</h1>
            <div class="divide"></div>
             
            <p>
                To change the page image, fill out the form below and select a new image.
            </p>
                       
            <table style="margin-top: 20px; margin-left: 50px;">
                <tr>
                    <td colspan="2" style="padding-top: 10px;"></td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;">
                        IMAGE SIZE:
                    </td>
                    <td style="vertical-align: top;">
                       <asp:Label ID="appImageSize" runat="server">Image Size</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-top: 10px;"></td>
                </tr>
                <tr>
                    <td style="width: 120px; vertical-align: top;">
                        IMAGE:
                    </td>
                    <td style="vertical-align: top;">
                        <asp:FileUpload ID="updImage" runat="server" />
                        <br />
                        <asp:Label ID="lblPageImage" runat="server" ClientIDMode="Static" Text="Please select an image." CssClass="txtboxerror" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-top: 10px;"></td>
                </tr>
                <tr>
                    <td></td>
                    <td style="vertical-align: top;">
                        <asp:LinkButton ID="btnCancel" runat="server" CssClass="anchor" OnClick="btnBack_Click">Cancel</asp:LinkButton>
                        <asp:LinkButton ID="btnAddPage" runat="server" CssClass="buttongrey" OnClick="btnAddPage_Click">Upload New Image</asp:LinkButton>
                    </td>
                </tr>
            </table>
            <div style="clear: both;"></div>
        </div>
    </div> 
</asp:Content>
