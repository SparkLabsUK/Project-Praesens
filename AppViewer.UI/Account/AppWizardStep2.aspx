<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="AppWizardStep2.aspx.cs" Inherits="AppViewer.UI.Account.AppWizardStep2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src='<%= ResolveUrl("~/Scripts/AddAppWizardStep2.js")%>'></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="centercontainer">
        <div class="whitebox">
        
            <asp:LinkButton ID="btnBack" runat="server" style="float:right; margin-top: 5px;" 
                CssClass="anchor" OnClientClick="" OnClick="btnBack_Click">Back to Manage Apps</asp:LinkButton>

            <h1>App Wizard</h1>
            <div class="divide"></div>
            <div style="padding-bottom:5px;">
            <p>
                Fill in the form below to add a new app.
            </p>
            </div>

            <div class="whitebox" style="height:260px;">
                <h2>Step 2: Create Pages</h2>
                <div class="divide"></div>

                <table style="margin-top: 10px; margin-left: 6px; float:left;">
                    <tr>
                        <p>
                Please select the type of page you want to create:
            </p>
                    </tr>
                     <tr><td colspan="2"></td></tr>
                    <tr>
                        <td style="width: 80px; vertical-align: top;"> 
                         <asp:Button ID="btnImage" OnClick="btnImage_Click" runat="server" ClientIDMode="Static" CssClass="buttongrey" Text="Upload Images"></asp:Button> 
                        <br />
                        </td>

                        <td style="padding-left:85px;">
                            <asp:LinkButton ID="lnkImage" runat="server" OnClick="lnkImage_Click" ClientIDMode="Static" Visible="false">Close</asp:LinkButton>
                        </td>

                        <td style="padding-left:100px;"> 
                         <asp:Button ID="btnVideo" OnClick="btnVideo_Click" runat="server" ClientIDMode="Static" CssClass="buttongrey" Text="Upload Video"></asp:Button> 
                        <br />
                       </td>

                        <td style="padding-left:90px;">
                            <asp:LinkButton ID="lnkVideo" OnClick="lnkVideo_Click" runat="server" ClientIDMode="Static" Visible="false">Close</asp:LinkButton>
                        </td>

                        <td style="padding-left:95px;"> 
                         <asp:Button ID="btnPowerpoint" OnClick="btnPowerpoint_Click" runat="server" ClientIDMode="Static" CssClass="buttongrey" Text="Upload PowerPoint"></asp:Button> 
                        <br />
                       </td>

                        <td style="padding-left:55px;">
                            <asp:LinkButton ID="lnkPowerpoint" OnClick="lnkPowerpoint_Click" runat="server" ClientIDMode="Static" Visible="false">Close</asp:LinkButton>
                        </td>
                    </tr> 

                </table>

                 <table style="margin-top: 10px; margin-left: 5px; float: left">
                     
                <tr><td colspan="2" style="padding-top:20px;"></td></tr>
                    <tr>
                        <td style="width: 100px; vertical-align: top;">
                        <asp:FileUpload ID="fileImageUploader" runat="server" ClientIDMode="Static" AllowMultiple="true" Visible="false"></asp:FileUpload>
                        </td>

                        <td style="width: 150px; vertical-align: top; padding-left: 70px;">
                            <asp:FileUpload ID="fileVideoUploader" runat="server" ClientIDMode="Static" Visible="false"></asp:FileUpload>
                          </td>

                        <td style="width: 150px; vertical-align: top; padding-left: 130px;">
                            <asp:FileUpload ID="filePowerpointUploader" runat="server" ClientIDMode="Static" Visible="false"></asp:FileUpload>
                          </td>
                    </tr>
                    <tr><td colspan="2" style="padding-top:5px;"></td></tr>
                    <tr>
                        <td style="width: 150px; vertical-align: top;">
                    </td>

                    </tr>

                     <tr><td colspan="2" style="padding-top:24px;"></td></tr>
                    <tr>
                        <td style="width: 150px; vertical-align: top; padding-left:78px; padding-top:20px;">
                            <asp:Button ID="btnImageUpload" runat="server" ClientIDMode="Static" CssClass="buttongrey" Text="Upload" Visible="false"></asp:Button>
                            
                             </td>
                        <td style="width: 150px; vertical-align: top; padding-left:78px; padding-top:20px;">
                            <asp:Button ID="btnVideoUpload" runat="server" ClientIDMode="Static" CssClass="buttongrey" Text="Upload" Visible="false"></asp:Button>
                            
                             </td>

                        <td style="width: 150px; vertical-align: top; padding-left:78px; padding-top:20px;">
                            <asp:Button ID="btnPowerpointUpload" runat="server" ClientIDMode="Static" CssClass="buttongrey" Text="Upload" Visible="false"></asp:Button>
                            
                             </td>
                    </tr>
                 
            </div>
        </div>
    </div>
    
</asp:Content>
