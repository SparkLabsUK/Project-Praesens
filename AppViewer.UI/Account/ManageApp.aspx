<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="ManageApp.aspx.cs" Inherits="AppViewer.UI.Account.EditApp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src='<%= ResolveUrl("~/Scripts/AddApp.js")%>'></script>
    <script src='<%= ResolveUrl("~/jscolor/jscolor.js")%>'></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        &nbsp;
    </p>
    <div class="centercontainer">
            <script>
                $("[id*=btnPopup]").live("click", function () {
                    $("#dialog").dialog({
                        title: "Chnages",
                        width: "900px",
                        buttons: {
                            Close: function () {
                                $(this).dialog('close');
                            }
                        },
                        modal: true,
                        dialogClass: 'myDialogClass'
                    });
                    return false;
                });
    </script>
        <div id="dialog" style="display: none; width:900px;" title="Changes">
  <p>Below are all the changes made to this app, to view this information in detail please visit the Audits Dashboard.</p>
            <br />
            <asp:Label ID="lblNoChanges" runat="server" Text="No changes to display..." Visible="false"></asp:Label>
            <asp:GridView ID="AuditGrid" runat="server"></asp:GridView>
      

</div>
        <div class="whitebox">
            <asp:LinkButton ID="btnBack" runat="server" style="float:right; margin-top: 5px;" 
                CssClass="anchor" OnClientClick="" OnClick="btnBack_Click">Back to Manage Apps</asp:LinkButton>
            <h1 id="h1PageHeader" runat="server">Manage App</h1>
            <div class="divide"></div>

            <p id="pPageInstructions" runat="server">
                To edit, delete or view an app's details select from the options below.
            </p>

            <div style="float: left; padding-right: 10px;">
                 <table style="margin-top: 20px; margin-left: 50px;">
                <tr>
                    <td style="width: 150px; vertical-align: middle;">
                        NAME:
                    </td>
                    <td style="padding-left: 10px; height: 40px; vertical-align: middle;">
                        <asp:TextBox ID="txtAppName" runat="server" ClientIDMode="Static" CssClass="txtbox" Width="400px"></asp:TextBox>
                        <br />
                        <asp:Label ID="lblAppName" runat="server" ClientIDMode="Static" Text="Please enter a name for the new app." CssClass="txtboxerror" Style="display: none;"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-top: 1px;"></td>
                </tr>
                     <tr>
                    <td style="width: 150px; vertical-align: middle;">
                        IMAGE SIZE:
                    </td>
                    <td style="padding-left: 10px; height: 40px; vertical-align: middle;">
                        <asp:Label ID="appImageSize" runat="server">Image Size</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-top: 1px;"></td>
                </tr>
                <tr>
                    <td style="width: 150px; height: 40px; vertical-align: middle;">DESCRIPTION:</td>
                    <td style="padding-left: 10px; vertical-align: middle;">
                        <asp:TextBox ID="txtAppDescription" runat="server" ClientIDMode="Static" CssClass="txtbox" TextMode="MultiLine" Height="50px" Width="400px"></asp:TextBox>
                        <br />
                        <asp:Label ID="lblAppDescription" runat="server" ClientIDMode="Static" Text="Please enter a description for the new app." CssClass="txtboxerror" Style="display: none;"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-top: 3px;"></td>
                </tr>
                <tr>
                    <td style="width: 150px; height: 40px; vertical-align: middle;">URL:</td>
                    <td style="padding-left: 10px; vertical-align: middle;">
                        <asp:TextBox ID="txtAppUrl" runat="server" ClientIDMode="Static" CssClass="txtbox" Width="400px">
                        </asp:TextBox>
                        <br />
                        <asp:Label ID="lblAppUrl" runat="server" ClientIDMode="Static" Text="Please enter a url for the new app." CssClass="txtboxerror" Style="display: none;"></asp:Label>
                    </td>
                </tr>
               <tr>
                    <td colspan="2" style="padding-top: 3px;"></td>
                </tr>
                <tr>
                    <td>
                       IS LIVE:
                    </td>
                    <td style="padding-left: 10px; vertical-align: middle;">
                        <asp:CheckBox ID="chkLive" Text="" runat="server"></asp:CheckBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-top: 3px;"></td>
                </tr>
                <tr>
                    <td>
                      SHOW LINKS ON LOAD:
                    </td>
                    <td style="padding-left: 10px; vertical-align: middle;">
                        <asp:CheckBox ID="chkShowLinks" Text="" runat="server"></asp:CheckBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-top: 3px;"></td>
                </tr>
                <tr>
                    <td>
                      LINK COLOUR:
                    </td>
                    <td style="padding-left: 10px; vertical-align: middle;">
                        <asp:TextBox ID="txtLinkColour" runat="server" CssClass="txtbox color" ClientIDMode="Static" Width="100px"></asp:TextBox>
                     </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-top: 3px;"></td>
                </tr>
                <tr>
                    <td>
                      SHOW INSTRUCTIONS ON LOAD:
                    </td>
                    <td style="padding-left: 10px; vertical-align: middle;">
                        <asp:CheckBox ID="chkShowInstructions" Text="" runat="server"></asp:CheckBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-top: 3px;"></td>
                </tr>
                <tr>
                    <td style="width: 150px; height: 40px; vertical-align: middle;">INSTRUCTIONS:</td>
                    <td style="padding-left: 10px; vertical-align: top;">
                        <asp:TextBox ID="txtInstructions" runat="server" ClientIDMode="Static" CssClass="txtbox" TextMode="MultiLine" Height="50px" Width="400px"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label1" runat="server" ClientIDMode="Static" Text="Please enter instructions." CssClass="txtboxerror" Style="display: none;"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                      SHOW LINK BACKGROUND COLOUR ON LOAD:
                    </td>
                    <td style="padding-left: 10px; vertical-align: middle;">
                        <asp:CheckBox ID="chkShowLinkBackground" Text="" runat="server"></asp:CheckBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-top: 3px;"></td>
                </tr>
                <tr>
                    <td>
                      LINK BACKGROUND COLOUR:
                    </td>
                    <td style="padding-left: 10px; vertical-align: middle;">
                        <asp:TextBox ID="txtLinkBackgroundColour" runat="server" CssClass="txtbox color" ClientIDMode="Static" Width="100px"></asp:TextBox>
                     </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-top: 5px;"></td>
                </tr>
                <tr>
                    <td>
                        
                    </td>
                    <td style="text-align: right;">
                        <asp:LinkButton ID="btnSaveApp" runat="server" OnClick="btnSaveApp_Click"
                           CssClass="buttongrey" OnClientClick="return ManageApp();">Save App</asp:LinkButton>
                    </td>
                </tr>
                </table>
            </div>
            <div style="float: right; padding-left: 10px; margin-right: 10px; width: 150px;">
                <h3>Options</h3>
                <div class="divide"></div>
                <asp:LinkButton ID="btnPreview" runat="server" OnClick="btnPreview_Click" style="float: right;"
                    CssClass="anchor">Preview in Viewer<br /><br /></asp:LinkButton>
                
                <asp:LinkButton ID="btnDemoCreate" runat="server" OnClick="btnDemoCreate_Click" style="float: right"
                    CssClass="anchor" visible="false">Create Demo</asp:LinkButton>                
                <!-- Removed while Create Demo button is hidden: <br /><br /> -->
                <asp:LinkButton ID="lnkAppDelete" OnClick="btnDeleteApp_Click" OnClientClick="return confirm('Are you sure you want to delete this App?');" runat="server" style="float: right;"
                    CssClass="anchor">Delete App<br /><br /></asp:LinkButton>                
                <asp:LinkButton ID="btnAddPage" runat="server" OnClick="btnAddPage_Click" style="float: right;"
                    CssClass="anchor">Add New Page<br /><br /></asp:LinkButton>                
                 <%--<asp:LinkButton ID="btnSecOptions" runat="server" data-rel="dialog" onClientClick="$('#secOptions').dialog(); return false;" data-position-to="window" style="float: right;"
                    CssClass="anchor">Security Options<br /><br /></asp:LinkButton>--%>

                  <asp:LinkButton ID="btnPopup" runat="server" Style="float: right;"
                    CssClass="anchor">View Changes</asp:LinkButton>
       
            </div>
            <div style="clear: both;"></div>
        </div>

        <div id="pageContainer" runat="server">
        </div>

        <br /><br />

        </div>

    <!-- Security Dialog -->
	<div data-role="dialog" id="secOptions" style="display: none" title="Security Options" data-transition="pop" data-close-btn="none" class="dialog">
		<div data-role="content">
		</div>
	</div>
</asp:Content>
