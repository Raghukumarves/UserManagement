<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReplayEvent.aspx.cs" MasterPageFile="~/Site.Master" Inherits="UserManagement.Pages.Reports.ReplayEvent" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .casecontainer {
            margin-bottom: 10px;
        }

        .GridViewHeaderStyle th {
            padding: 10px;
            border: 1px solid #F7F7F7;
            position: sticky;
            top: 0;
        }

        .gridview-wrapper {
            max-height: 300px;
            overflow-y: auto;
            min-height:300px;
        }

        .GridViewRowStyle td {
            padding: 10px;
            border: 1px solid #D6D6D6;
        }
    </style>
    <script>
        function showConfirmation() {
            // Display a confirmation box
            var result = confirm("Are you sure you want to replay the event?");

            return result;
        }
    </script>
    <main style="width: 100%; auto; padding: 10px;">
        <div class="container">
            <div style="width: 70%; margin: 4% auto; border: 1px solid #D6D6D6; padding: 10px;">
                <div class="row">
                    <div style="width: 99.50%; margin: 2px; padding-bottom: 5px; border-bottom: 1px solid #D6D6D6">
                        Get All Case Events by ESRID
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                </div>
                <div class="clearfix"></div>
                <div class="row">
                    <div class="col-md-4 cellspace text-md-end">
                        Enter ESR Id
                    </div>
                    <div class="col-md-6 cellspace">
                        <asp:TextBox ID="ESRId" Width="424px" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 cellspace">
                    </div>
                    <div class="col-md-6 cellspace">
                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Get Events" OnClick="GetAllEvents_Click" />
                    </div>
                </div>

            </div>
        </div>
        <div style="margin-left: 14%">

            <div style="width: 100%; min-height: 200px; height: 400px;">
                <br />
                <br />

                <asp:PlaceHolder ID="replayPastEventsHeader" runat="server"></asp:PlaceHolder>
                <div class="gridview-wrapper">
                    <asp:GridView ID="grdpastEventList" Width="100%" AutoGenerateColumns="false" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="144px"
                        OnRowCommand="grdpastEventList_RowCommand">
                        <HeaderStyle Height="30px" />
                        <RowStyle Height="20px" />
                        <AlternatingRowStyle Height="20px" />
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
                        <Columns>

                            <asp:BoundField DataField="eventId" HeaderText="Event Id" />
                            <asp:BoundField DataField="previousEventId" HeaderText="Previous Event Id" />
                            <asp:BoundField DataField="modelVersion" HeaderText="Model Version" />
                            <asp:BoundField DataField="eventTypeId" HeaderText="Event Type Id" />
                            <asp:BoundField DataField="createdDate" HeaderText="Created Date" />


                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button OnClientClick="return showConfirmation();" CommandName="ReplayData" CommandArgument='<%# Eval("eventId") %>' runat="server" Text="Replay" Visible='<%# DispalyReplay(Eval("eventTypeId")) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                    </asp:GridView>
                </div>
                <br />
                <br />
                <asp:PlaceHolder ID="replayPendingEventsHeader" runat="server"></asp:PlaceHolder>
                <div class="gridview-wrapper">
                    <asp:GridView ID="grdpendingEventList" Width="100%" AutoGenerateColumns="false" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="144px">
                        <HeaderStyle Height="30px" />
                        <RowStyle Height="20px" />
                        <AlternatingRowStyle Height="20px" />
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
                        <Columns>

                            <asp:BoundField DataField="eventId" HeaderText="Event Id" />
                            <asp:BoundField DataField="previousEventId" HeaderText="Previous Event Id" />
                            <asp:BoundField DataField="modelVersion" HeaderText="Model Version" />
                            <asp:BoundField DataField="eventTypeId" HeaderText="Event Type Id" />
                            <asp:BoundField DataField="createdDate" HeaderText="Created Date" />

                        </Columns>

                    </asp:GridView>
                </div>

            </div>
        </div>
    </main>
</asp:Content>
