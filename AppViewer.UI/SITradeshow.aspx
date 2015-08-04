<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SI.Master" AutoEventWireup="true" CodeBehind="SITradeshow.aspx.cs" Inherits="AppViewer.UI.SITradeshow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="Scripts/AppHome.js"></script>
    <meta id="viewport" name="viewport" content="width=device-width, initial-scale=1"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="centercontainer">
        <div class="whiteboxnew">
            <h1>SI Tradeshow</h1>
            <div class="dividenew"></div>
            <p>
                Welcome to the SI Tradeshow.
                <br /><br />
                Below is a showcase of the presentations of the day.
            </p>
        </div>

        <div id="divApps" runat="server" style="padding-left:35px;">
            
        </div>
    </div>
</asp:Content>
