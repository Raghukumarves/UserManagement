<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MileageReport.aspx.cs" MasterPageFile="~/Site.Master" Inherits="UserManagement.Pages.Reports.MileageReport" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">  
    <style type="text/css">
    .GridViewHeaderStyle th {
        padding: 10px;
        border: 1px solid #F7F7F7;
        position: sticky;
        top: 0;
        background-color: #D4D4D4;
    }

    .GridViewRowStyle td {
        padding: 10px;
        border: 1px solid #D6D6D6;
    }

    .popup-overlay {
        visibility: hidden;
    }

    .popup-content {
        visibility: hidden;
    }
    .GridViewEmptyRow{
        display:block;
        padding:10px;
    }
</style>
    <div>
        <h4>
            Mileage Report
        </h4>
    </div>
    <div style="width: 100%; min-height: 200px; height: 400px; overflow-y: scroll">
        <div style="width:90%; text-align:right;margin-bottom:10px;">
             <asp:Button ID="btnExport" runat="server" Visible="false" Text="Export to Excel" OnClick="btnExport_Click" />
        </div>
       
        <asp:GridView ID="grdUsersList" Width="90%" runat="server" AutoGenerateColumns="true">
            <HeaderStyle CssClass="GridViewHeaderStyle" />
            <RowStyle CssClass="GridViewRowStyle" />  
            <EmptyDataRowStyle CssClass="GridViewEmptyRow" BorderStyle="None" BorderWidth="0" />
        </asp:GridView>
    </div>

</asp:Content>

