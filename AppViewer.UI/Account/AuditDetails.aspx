<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="AuditDetails.aspx.cs" Inherits="AppViewer.UI.Account.AuditsDetails" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        &nbsp;
    </p>
     <div class="centercontainer">

        <div class="whitebox">
            <asp:LinkButton ID="LinkButton1" runat="server" ClientIDMode="Static" OnClick="btnBack_Click" style="float:right; margin-top: 5px;" 
                CssClass="anchor"  >Back to Overview</asp:LinkButton>
            <!--<h1>Audits Dashboard</h1>-->
            <asp:Label ID="lblTitle" runat="server" Text="<h1>Audits Details </h1>" CssClass="h1"></asp:Label>
            <div class="divide"></div>
            <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
                <asp:TableRow>
                 <asp:TableCell>
                       <strong>Audit ID: </strong>
                  </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="AuditID" runat="server" Text="AUDIT ID"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <strong> Username: </strong>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="Username" runat="server" Text="USERNAME"></asp:Label>
                   </asp:TableCell>
               </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                         <strong>App Name: </strong>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="AppName" runat="server" Text="APP NAME"></asp:Label>
                   </asp:TableCell>
               </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                         <strong>Page ID: </strong>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="PageID" runat="server" Text="PAGE ID"></asp:Label>
                   </asp:TableCell>
               </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                         <strong>Page Name: </strong>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="PageName" runat="server" Text="PAGE NAME"></asp:Label>
                   </asp:TableCell>
               </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                         <strong>Audit Type: </strong>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="AuditType" runat="server" Text="AUDIT TYPE"></asp:Label>
                   </asp:TableCell>
               </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                         <strong>Description: </strong>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="Description" runat="server" Text="DESCRIPTION"></asp:Label>
                   </asp:TableCell>
               </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <strong>Occured:</strong>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="DateTime" runat="server" Text="DATE/TIME"></asp:Label>
                   </asp:TableCell>
               </asp:TableRow>
            </asp:Table>

               
                   
                         
                       
            
            
          
           

            
            <div style="clear: both;"></div>
        </div>

        </div>
    
   
            
            
       

        
</asp:Content>
