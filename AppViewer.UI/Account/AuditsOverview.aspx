<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="AuditsOverview.aspx.cs" Inherits="AppViewer.UI.Account.AuditsOverview" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script src='<%= ResolveUrl("~/Scripts/AddApp.js")%>'></script>
    <script src='<%= ResolveUrl("~/jscolor/jscolor.js")%>'></script>
    <link rel="stylesheet" href="/../code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
<script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
<link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
    rel="stylesheet" type="text/css" />
    <p>
        &nbsp;
    </p>
     <div class="centercontainer">
          <script>
              function DialogBox() {
                  $("#dialog").dialog({
                      title: "Audit Details",
                      width: "1050px",
                      modal: true,
                      dialogClass: 'myDialogClass'
                  });
                 
                  return false;
              };
    </script>

         <div id="dialog"  style="display: none; width:900px;" >
  <p>Details for the audit you have selected will be displayed below...</p>
             <br />
             <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
               
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
                 <asp:TableRow>
                     <asp:TableCell>
                     <br />
                         </asp:TableCell>
                 </asp:TableRow>
                 <asp:TableRow>
                     <asp:TableCell>
                         
                     </asp:TableCell>
                 </asp:TableRow>
            </asp:Table>
             <asp:LinkButton ID="btnClose" runat="server" CssClass="buttonpopup" style="float:right;" ClientIDMode="Static">
                            Done
                        </asp:LinkButton>
            <br />

      

</div>
        <div class="whiteboxnew">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btnBack_Click" style="float:right; margin-top: 5px;" 
                CssClass="anchor"  >Back to Dashboard</asp:LinkButton>
            <!--<h1>Audits Dashboard</h1>-->
            <asp:Label ID="lblTitle" runat="server" Text="<h1>Audits Overview - </h1>" CssClass="h1"></asp:Label>
            <div class="dividenew"></div>
             <!--<asp:BoundField DataField="AuditID"  ItemStyle-CssClass="hiddenCol" HeaderStyle-CssClass="hiddenCol" />-->
            <asp:GridView ID="AuditGrid" runat="server" HorizontalAlign="Center" AlternatingRowStyle-BackColor="#EFEFEF" 
                SelectedRowStyle-BackColor="#0066CC" AllowPaging="False" PageSize="10" OnRowCreated="AuditGrid_RowCreated" 
                OnSelectedIndexChanged="AuditGrid_SelectedIndexChanged" SelectedRowStyle-ForeColor="White" Width="958px" AutoGenerateColumns="false" DataKeyNames="AuditID">
                <RowStyle  CssClass="GridRow"/>
                <HeaderStyle  CssClass="GridHeadernew"/>
                <Columns >
                   
                    <asp:TemplateField HeaderStyle-CssClass="hiddenCol" ItemStyle-CssClass="hiddenCol">
                        <ItemTemplate>
                        <asp:HiddenField ID="AuditID" runat="server" 
                         Value='<%# Eval("AuditID") %>'></asp:HiddenField>
                            </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Username" HeaderText="Username"/>
                    <asp:BoundField DataField="AppName" HeaderText="App Name"/>
                    <asp:BoundField DataField="PageName" HeaderText="Page Name"/>
                    <asp:BoundField DataField="AuditTypeID"  HeaderText="Audit Type"/>
                    <asp:BoundField DataField="Description"  HeaderText="Description"/>
                    <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}"/>
                    <asp:BoundField DataField="Date"  HeaderText="Time" DataFormatString="{0:hh:mm:ss}"/>


                </Columns>
            </asp:GridView>
            
            <div style="clear: both;"></div>
                  
                <div style="clear: both;"></div>
            </div>

        </div>
    
   <br />
    <br />
            
            
       

        
</asp:Content>
