<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="AuditsHome.aspx.cs" Inherits="AppViewer.UI.Account.AuditsHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <script type="text/javascript" src="../Scripts/gauges.min.js"></script>
    <script type="text/javascript" src="../Scripts/Audits.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        &nbsp;
    </p>
     <div class="centercontainer">

        <div class="whiteboxnew">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btnBack_Click" style="float:right; margin-top: 5px;" 
                CssClass="anchor"  >Back to AppFlow</asp:LinkButton>
            <h1>Audits Dashboard</h1>
            <div class="dividenew"></div>


            <!--<div style="float: left; padding-right: 10px;">-->
                 
                    <!--<div id="gauges" style="margin:auto; width:900px;">-->
                        
                        
                     
                       
                       <table style="text-align:center; color:#0066A1; margin:auto;">
                           <tr>
                               <td><canvas width="220" height="70" id="Apps"></canvas></td>
                               <td><canvas width="220" height="70" id="Pages"></canvas></td>
                               <td>   <canvas width="220" height="70" id="Users"></canvas></td>
                               <td> <canvas width="220" height="70" id="ActiveUsers"></canvas></td>
                           </tr>
				<tr>
					<td width="220">
						Apps:
					</td>
					<td width="220">
						Pages:
					</td>
			        <td width="220">
			Users:
		</td>
        <td width="220">
			Links:
		</td>
	</tr>
	<tr>
		<td>
            <asp:Label ID="lblAppCount" runat="server" Text="13"></asp:Label>
		</td>
		<td>
			<asp:Label ID="lblPageCount" runat="server" Text="265"></asp:Label>
		</td>
        <td>
			<asp:Label ID="lblUserCount" runat="server" Text="1154"></asp:Label>
		</td>
        <td>
			<asp:Label ID="lblLinkCount" runat="server" Text="68"></asp:Label>
		</td>
	</tr>
                           <tr>
                               <td>
<br />
                               </td>
                               <td>

                               </td>
                               <td>

                               </td>
                               <td>

                               </td>
                           </tr>
                           <tr>
                               <td>
                                   <asp:LinkButton ID="btnApp" runat="server" CssClass="buttongreysmallaudit" ClientIDMode="Static" OnClick="btnApp_Click">
                            App Audits
                        </asp:LinkButton>
                               </td>
                               <td>
                                   <asp:LinkButton ID="btnPage" runat="server" CssClass="buttongreysmallaudit" ClientIDMode="Static" OnClick="btnPage_Click">
                            Page Audits
                        </asp:LinkButton>
                               </td>
                               <td>
                                    <asp:LinkButton ID="btnUser" runat="server" CssClass="buttongreysmallaudit" ClientIDMode="Static" OnClick="btnUser_Click">
                            User Audits
                        </asp:LinkButton>
                               </td>
                               <td>
                                    <asp:LinkButton ID="btnSystem" runat="server" CssClass="buttongreysmallaudit" ClientIDMode="Static" OnClick="btnSystem_Click" >
                            System Audits
                        </asp:LinkButton>
            
                               </td>
                           </tr>
</table>


         
                   
                   
                         
                        
                        
                       
                       
            
          
           

            
            <div style="clear: both;"></div>
        </div>

        </div>

    <div class="centercontainer">

        <div class="whiteboxnew">
            <asp:LinkButton ID="btnRefreshRecent" runat="server" OnClick="btnRefreshRecent_Click" style="float:right; margin-top: 5px;" 
                CssClass="anchor"  >
                Refresh</asp:LinkButton>
            <h1>Recent Audits</h1>
            <div class="dividenew"></div>

            <p>
                View the most recent audits for the system here...
                <br />
                
            </p>
            <br />
            
            <div style="float: left; padding-right: 10px;">
                <asp:GridView ID="AuditGrid" runat="server" HorizontalAlign="Center" AlternatingRowStyle-BackColor="#EFEFEF" 
                SelectedRowStyle-BackColor="#0066CC" AllowPaging="False" PageSize="10" 
               SelectedRowStyle-ForeColor="White" Width="960px" AutoGenerateColumns="false" DataKeyNames="AuditID">
                <RowStyle  CssClass="GridRow"/>
                <HeaderStyle  CssClass="GridHeadernew"/>
                <Columns >
                   
                    <asp:TemplateField HeaderStyle-CssClass="hiddenCol" ItemStyle-CssClass="hiddenCol">
                        <ItemTemplate>
                        <asp:HiddenField ID="AuditID" runat="server" 
                         Value='<%# Eval("AuditID") %>'></asp:HiddenField>
                            </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="AuditDate" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}"/>
                    <asp:BoundField DataField="AuditDate"  HeaderText="Time" DataFormatString="{0:hh:mm:ss}"/>
                    <asp:BoundField DataField="AuditTypeID"  HeaderText="Audit Type"/>
                    <asp:BoundField DataField="Username" HeaderText="Username"/>
                    <asp:BoundField DataField="Name" HeaderText="App Name"/>
                    <asp:BoundField DataField="PageName" HeaderText="Page Name"/>
                    <asp:BoundField DataField="Description"  HeaderText="Description"/>
                    


                </Columns>
            </asp:GridView>
                
            <br />

            </div>
           

            <div style="clear: both;"></div>
        </div>

        </div>
    <br />
    

</asp:Content>
