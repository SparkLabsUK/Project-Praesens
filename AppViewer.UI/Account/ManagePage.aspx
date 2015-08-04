<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="ManagePage.aspx.cs" Inherits="AppViewer.UI.Account.ManagePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src='<%= ResolveUrl("~/Scripts/ManagePage.js")%>'></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        &nbsp;
    </p>

    
    
    <div class="centercontainer">
        <div id="dialog" style="display: none; width:900px;" title="Changes">
  <p>Below are all the changes made to this page, to view this information in detail please visit the Audits Dashboard.</p>
            <br />
            <asp:Label ID="lblNoChanges" runat="server" Text="No changes to display..." Visible="false"></asp:Label>
            <asp:GridView ID="AuditGrid" runat="server"></asp:GridView>
      

</div>
        <div class="whitebox">

            <asp:LinkButton ID="btnBack" runat="server" Style="float: right; margin-top: 5px;"
                CssClass="anchor" OnClientClick="" OnClick="btnBack_Click">Back to Manage App</asp:LinkButton>

            <h1 id="h1PageHeader" runat="server">Manage Page</h1>
            <div class="divide"></div>

            <h2 id="h2PageName" runat="server" style="float: left">page name</h2>
            <asp:Label ID="manPageSize" runat="server" Style="float: right">Image size</asp:Label>

            <br />
            <br />
            
            <div style=" float: left; margin-right: 20px; margin-bottom: 20px;">
                <div id="imgSizeContainer" runat="server">
                    <div id="imgOuterContainer" runat="server">
                        <div id="imgContainer" runat="server">
                        </div>
                    </div>
                </div>
            </div>

            <div style="float: left;">

            <div style="float: left; border: 1px solid #cccccc; padding: 10px;">

                <h3>Manage Links</h3>
                <div class="divide"></div>

                <div style="width: 100%; text-align: right;">
                    <asp:LinkButton ID="lnkAdd" runat="server" CssClass="anchor" OnClientClick="AddLink(); return false;">Add Link</asp:LinkButton>
                </div>

                <br />

                <table>
                    <tr>
                        <td style="text-align: right;">X: 
                        </td>
                        <td style="padding-left: 10px;">
                            <asp:TextBox ID="txtX" runat="server" TextMode="Number" ClientIDMode="Static" CssClass="txtbox" Width="50px"></asp:TextBox>
                        </td>
                        <td style="padding-left: 10px; text-align: right;">Y: 
                        </td>
                        <td style="padding-left: 10px;">
                            <asp:TextBox ID="txtY" runat="server" TextMode="Number" ClientIDMode="Static" CssClass="txtbox" Width="50px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="padding-top: 10px;"></td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">Width: 
                        </td>
                        <td style="padding-left: 10px;">
                            <asp:TextBox ID="txtWidth" runat="server" TextMode="Number" ClientIDMode="Static" CssClass="txtbox" Width="50px"></asp:TextBox>
                        </td>
                        <td style="padding-left: 10px; text-align: right;">Height: 
                        </td>
                        <td style="padding-left: 10px;">
                            <asp:TextBox ID="txtHeight" runat="server" TextMode="Number" ClientIDMode="Static" CssClass="txtbox" Width="50px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="padding-top: 10px;"></td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">Transition: 
                        </td>
                        <td style="padding-left: 10px;">
                            <asp:DropDownList ID="drpTransition" runat="server" ClientIDMode="Static">
                            </asp:DropDownList>
                        </td>
                        <td style="padding-left: 10px; text-align: right;">Page: 
                        </td>
                        <td style="padding-left: 10px;">
                            <asp:DropDownList ID="drpTransitionToPage" runat="server" ClientIDMode="Static" Width ="95px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>

                <br />

                <table style="float: right;">
                    <tr>
                        <td>
                            <%--<asp:LinkButton ID="lnkPreview" CssClass="anchor" runat="server" OnClientClick="PreviewLink(); return false;">Preview Link</asp:LinkButton>--%>
                        </td>
                        <td style="padding-left: 20px;">
                            <asp:LinkButton ID="btnSaveLink" runat="server" CssClass="buttongrey" OnClientClick="return SaveLink();" OnClick="Save_Click">Save Link</asp:LinkButton>
                        </td>
                    </tr>
                </table>

                <br />
                
                <asp:Label ID="lblLinkError" runat="server" ClientIDMode="Static" Text="Please fill in the form" ForeColor="Red" Style="display: none;"></asp:Label>

                <br /><br />

                <table style="width: 100%;">
                    <tr>
                        <td>
                            <h4>Existing Links</h4>
                        </td>
                        <td style="text-align: right;">
                            <asp:LinkButton ID="btnDeleteLink" CssClass="anchor" runat="server" OnClientClick="if ($('#hdnSelectedLink').val() == -1){ alert('Link not selected!'); return false; } else { return confirm('Are you sure you want to delete the selected link?'); }" OnClick="btnDeleteLink_Click">Delete Link</asp:LinkButton>
                        </td>
                    </tr>
                </table>

                <asp:ListBox ID="lstLinks" runat="server" ClientIDMode="Static" Width="100%" Height="150px" style="margin-top: 5px;"></asp:ListBox>

                <asp:HiddenField ID="hdnSelectedLink" runat="server" ClientIDMode="Static" />

                <asp:HiddenField ID="hdnDrpTranstoPage" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdnTransition" runat="server" ClientIDMode="Static" />

            </div>

            <div style="float: left; margin-left: 30px; padding-top: 11px; width: 180px;">
                <h3>Options</h3>
                <div class="divide"></div>
                <asp:LinkButton ID="btnSetAsThumbnail" runat="server" Style="float: right;"
                    CssClass="anchor">Set as Thumbnail</asp:LinkButton>

                <br />
                <br />
                <asp:LinkButton ID="btnSetAsFirstPage" runat="server" Style="float: right;"
                    CssClass="anchor">Set as First Page</asp:LinkButton>

                <br />
                <br />
                <asp:LinkButton ID="btnBackToViewer" runat="server" ClientIDMode="Static" Style="float: right;" OnClick="btnBackToViewer_Click"
                    CssClass="anchor">Preview in Viewer</asp:LinkButton>

                <br />
              <br />
                <asp:LinkButton ID="btnChange" runat="server" Style="float: right;" OnClick="btnChange_Click"
                    CssClass="anchor">Change Image</asp:LinkButton>

                <br />
                <br />
                <asp:LinkButton ID="btnDelete" runat="server" Style="float: right;" OnClick="btnDelete_Click" OnClientClick="return confirm('Are you sure you want to delete this Page?');"
                    CssClass="anchor">Delete Page</asp:LinkButton>

                <br />
                <br />
                <%--<asp:LinkButton ID="btnPopup" runat="server" Style="float: right;"
                    CssClass="anchor">View Changes</asp:LinkButton>--%>
                <br />
                <br />
                <h3>Page Notes</h3>
                <div class="divide"></div>

                <asp:TextBox ID="txtPageNotes" runat="server" ClientIDMode="Static" TextMode="MultiLine" 
                    CssClass="notestxtbox" Width="170px" Height="100px" MaxLength="250"></asp:TextBox>
                    
                <br /><br />
                    
                <asp:LinkButton ID="btnSaveNotes" runat="server" OnClick="btnSaveNotes_Click"
                    CssClass="buttongrey">Update</asp:LinkButton>
            </div>

            <div style="clear: both;"></div>

            </div>

            <div style="clear: both;"></div>
        </div>
    </div>

</asp:Content>

