<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Viewer.aspx.cs" Inherits="AppViewer.UI.Viewer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-touch-fullscreen" content="yes" />
    <script type="text/javascript">
        var arrPageNotes = <%=GetPageNotes() %>;
        var _app = <%=GetApp() %>;
    </script>
    <%--<script src='<%= ResolveUrl("~/Scripts/hammer.min.js")%>'></script>--%>
    <script src='<%=ResolveUrl("~/Scripts/Viewer.js")%>'></script>
    <style type="text/css">
        @media screen and (max-width: <%=app.FullscreenSize%>px) {
            .header {
                display: none;
            }
            .buttonlogin, .viewerSettings, .viewerPageNotes {
                display: none;
            }

            .viewerIphone {
                margin: 0!important; 
                width: <%=app.ImgWidth%>px!important; 
                height: <%=app.ImgHeight%>px!important; 
                margin-top: 0!important; 
                padding: 0!important; 
                background-repeat: no-repeat!important; 
                background-image: none!important;
                border: 0!important;
            }
        }
     </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="viewerSettings">
        <table>
            <tr>
                <td id="tdBack" runat="server" style="padding: 10px;">
                    <asp:LinkButton ID="lnkBack" runat="server" CssClass="anchor" OnClick="lnkBack_Click">Back to App Selection Screen</asp:LinkButton>
                </td>
                <td id="tdShowLinks" runat="server" style="padding: 10px; border-left: 1px solid #AAAAAA;">
                    <asp:Label ID="lblShowLinks" runat="server" Style="margin-right: 4px;">Show Links:</asp:Label>
                    <asp:CheckBox ID="chkShowLinks" runat="server" ClientIDMode="Static" />
                </td>
                <td id="tdManApp" runat="server" style="padding: 10px; border-left: 1px solid #AAAAAA;">
                    <asp:LinkButton ID="lnkManageApp" runat="server" CssClass="anchor" OnClick="lnkManageApp_Click">Manage App</asp:LinkButton>
                </td>
                <td id="tdManPage" runat="server" style="padding: 10px; border-left: 1px solid #AAAAAA;">
                    <asp:LinkButton ID="lnkManagePage" runat="server" CssClass="anchor" OnClick="lnkManagePage_Click">Manage Page</asp:LinkButton>
                </td>
                <td id="tdImgSize" runat="server" style="padding: 10px; border-left: 1px solid #AAAAAA;">
                    <asp:Label ID="appImageSize" runat="server">Image Size</asp:Label>
                </td>
            </tr>
        </table>
    </div>




    <div class="viewerPageNotes" style="display: none;">
        <asp:TextBox ID="txtPageNotes" runat="server" ClientIDMode="Static" CssClass="stickynotetxtbox" TextMode="MultiLine" Width="199px" ReadOnly="True"></asp:TextBox>
    </div>




    <div id="imgIphone" runat="server" class="viewerIphone">
        <div id="imgViewer" runat="server">
            <div id="imgContainer" runat="server">
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdnPageID" runat="server" ClientIDMode="Static" />
   <%-- <video controls>
        <source src="Video/OfficeVideo.mp4" type="video/mp4" />
          Your browser does not support the video tag.
    </video>--%>
</asp:Content>

