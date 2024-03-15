<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FipsUnlockReport.aspx.cs" MasterPageFile="~/Site.Master" Inherits="UserManagement.Pages.Reports.FipsUnlockReport" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    <style type="text/css">
        .fipscontainer{
            margin-bottom:10px;
        }
        .GridViewHeaderStyle th {
    padding: 10px;
    border: 1px solid #F7F7F7;
    position: sticky;
    top: 0;
   
}

.GridViewRowStyle td {
    padding: 10px;
    border: 1px solid #D6D6D6;
    
}
    </style>
   <main style="width: 100%; auto;  padding: 10px;"">
   <div style="margin-left: 15%">
       <div id="fipscontainer" class="fipscontainer">
        <!-- Initial textboxes and buttons will be added here -->
        <br />
        Change the Fips Unlock Status
    </div>

    <%--<button OnClientClick="return addTextBox()">Add Case Number</button>--%>
    <asp:Button ID="btnAddCase" runat="server" CssClass="btn btn-primary" Text="Add Case Number" OnClientClick="return addTextBox()" />
    <asp:Button ID="btnFipsUnlock" runat="server" CssClass="btn btn-primary" Text="Fips Unlock" OnClientClick="return fipsUnlock()" OnClick="btnFipsUnlock_Click" />  
    <asp:HiddenField ID="hdnFips" runat="server" />
  
     <div style="width:500px;  min-height: 200px; height: 400px; ">
         <br />
         <br />
        
         <asp:PlaceHolder ID="fipsUnlockHeader" runat="server"></asp:PlaceHolder>
        <asp:GridView ID="grdUnlockList" Width="87%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="144px"
        >
            <HeaderStyle Height="30px" />
            <rowstyle Height="20px" />
        <alternatingrowstyle  Height="20px"/>
         <AlternatingRowStyle BackColor="White" />
         <EditRowStyle BackColor="#2461BF" />
         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <HeaderStyle CssClass="GridViewHeaderStyle" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle CssClass="GridViewRowStyle" BackColor="#EFF3FB" />
        
         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
         <SortedAscendingCellStyle BackColor="#F5F7FB" />
         <SortedAscendingHeaderStyle BackColor="#6D95E1" />
         <SortedDescendingCellStyle BackColor="#E9EBEF" />
         <SortedDescendingHeaderStyle BackColor="#4870BE" />
       
     </asp:GridView>
                <br />
<asp:Button ID="btnClear" runat="server" CssClass="btn btn-primary" Text="Clear" OnClick="btnFipsUnlockGridClear_Click" Visible="False" />  

 </div>
      
       </div>
       </main>
</asp:Content>
