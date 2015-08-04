<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="AppViewerHome.aspx.cs" Inherits="AppViewer.UI.AppViewerHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="Scripts/AppHome.js"></script>
    <meta id="viewport" name="viewport" content="width=device-width, initial-scale=1"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="centercontainer">
        <div class="whiteboxnew">
            <h1>Welcome</h1>
            <div class="dividenew"></div>
            <p>
                Welcome to the AppFlow - Application Demonstration Viewer.
                <br /><br />
                Below is a showcase of our applications.
            </p>
        </div>

        <div id="divApps" runat="server">
            
        </div>
    </div>
</asp:Content>
