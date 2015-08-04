<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppViewerSplash.aspx.cs" Inherits="AppViewer.UI.AppViewerSplash" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AppFlow</title>
    <link href="Style/Splash.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="container">
            <h1>AppFlow</h1>
            <h2>Part of the SparkFlow Product Suite</h2>
            <p>Welcome to AppFlow</p>

            <asp:LinkButton ID="btnView" runat="server" OnClick="btnView_Click" CssClass="button">View Showcase Apps</asp:LinkButton>

        </div>
    </div>
    </form>
</body>
</html>
