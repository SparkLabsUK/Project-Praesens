<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="ManageDemo.aspx.cs" Inherits="AppViewer.UI.Account.ManageDemo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        &nbsp;
    </p>
    <div class="centercontainer">
        <div class="whitebox">
            <asp:LinkButton ID="btnBacktoManageApp" runat="server" Style="float: right; margin-top: 5px;"
                CssClass="anchor" OnClientClick="" OnClick="btnBacktoManageApp_Click">Back to Manage App</asp:LinkButton>
            <h1>Create Demo</h1>
            <div class="divide"></div>

            <p>
                Create an automated demo for an app
            </p>
            <br />


            <div style="width: 283px; height: 497px; overflow: hidden; border: 1px solid #aaaaaa;">
                <div id="imgOuterContainerDemo" style="width: 849px; height: 1491px; position: absolute; overflow: hidden; margin: -497px 0 0 -283px;">
                    <div id="imgContainerDemo" runat="server">
                    </div>
                </div>
            </div>
                <asp:ListBox ID="lstDemoLinks" runat="server" ClientIDMode="Static" Height="150px" Style="float:left; margin: -499.5px 0px 0px 400px; width: 200px;"></asp:ListBox>
            </div>
    </div>
</asp:Content>
