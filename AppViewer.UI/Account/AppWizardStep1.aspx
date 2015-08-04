<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="AppWizardStep1.aspx.cs" Inherits="AppViewer.UI.Account.AppWizardStep1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src='<%= ResolveUrl("~/Scripts/AddAppWizardStep1.js")%>'></script>
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

            <div class="whitebox" style="height:270px;">
                <h2>Step 1: App Details</h2>
                <div class="divide"></div>

                <table style="margin-top: 10px; margin-left: 10px; float: left;">
                    <tr>
                        <td>
                        <div class="greybox" style="width:330px">
                            <label style="margin-bottom: 3px;">SELECT APP TYPE:</label>
                            <br />
                            <div style="margin-top:-18px; margin-left:130px;">
                            <asp:DropDownList ID="drpAppType" runat="server" ClientIDMode="Static" AutoPostBack="false" Width="200px"></asp:DropDownList>
                               <br />
                                <asp:Label ID="lblAppType" runat="server" ClientIDMode="Static" Text="Please select an app type." CssClass="txtboxerror" style="display: none;"></asp:Label>
                            </div> 
                           </div>  
                       </td>
                    </tr> 
                </table>

                 <table style="margin-top: 10px; margin-left: 100px; float: left">
                     
                <tr><td colspan="2" style="padding-top:10px;"></td></tr>
                    <tr>
                        <td style="width: 150px; vertical-align: top;">
                            NAME:
                        </td>
                        <td style="padding-left: 5px; height: 40px; vertical-align: top;">
                            <asp:TextBox ID="txtName" runat="server" ClientIDMode="Static" CssClass="txtboxWizard"></asp:TextBox>
                            <br />
                            <asp:Label ID="lblName" runat="server" ClientIDMode="Static" Text="Please enter a name for the new app." CssClass="txtboxerror" style="display: none;"></asp:Label>
                        </td>
                    </tr>
                    <tr><td colspan="2" style="padding-top:5px;"></td></tr>
                    <tr>
                        <td style="width: 150px; vertical-align: top;">
                            DESCRIPTION:
                        </td>
                        <td style="padding-left: 5px; height: 40px; vertical-align: top;">
                            <asp:TextBox ID="txtDescription" runat="server" ClientIDMode="Static" CssClass="txtboxWizard"></asp:TextBox>
                            <br />
                            <asp:Label ID="lblDescription" runat="server" ClientIDMode="Static" Text="Please enter a description for the new app." CssClass="txtboxerror" style="display: none;"></asp:Label>
                        </td>
                    </tr>
                    <tr><td colspan="2" style="padding-top:5px;"></td></tr>
                    <tr>
                        <td style="width: 150px; vertical-align: top;">
                            URL:
                        </td>
                        <td style="padding-left: 5px; height: 40px; vertical-align: top;">
                            <asp:TextBox ID="txtURL" runat="server" ClientIDMode="Static" CssClass="txtboxWizard">
                            </asp:TextBox>
                            <br />


                            
                           <asp:Label ID="lblURL" runat="server" ClientIDMode="Static" Text="Please enter a url for the new app." CssClass="txtboxerror" style="display: none;"></asp:Label></td>
                    </tr>

                     <tr><td colspan="2" style="padding-top:5px;"></td></tr>
                    <tr>
                        <td style="width: 150px; vertical-align: top;">
                        </td>
                        <td style="padding-left: 250px; height: 40px; vertical-align: top;">
                            <asp:Button ID="btnAddAppWizard" runat="server" ClientIDMode="Static" OnClick="btnAddAppWizard_Click" OnClientClick="return AddApp();" CssClass="buttongrey" Text="Next"></asp:Button>
                            <br />
                           </td>
                    </tr>
                     <asp:HiddenField ID="hdnAppType" runat="server" ClientIDMode="Static"/>
            
            </div>
        </div>
    </div>
    
</asp:Content>
