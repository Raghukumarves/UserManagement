<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ManageUsers.aspx.cs" Inherits="UserManagement.Pages.ManageUsers" %>

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
    </style>


    <main>
        <div class="container">
            <div style="width: 45%; margin: 4% auto; border: 1px solid #D6D6D6; padding: 10px;">
                <div class="row">
                    <div style="width: 99.50%; margin: 2px; padding-bottom: 5px; border-bottom: 1px solid #D6D6D6">
                        Search by Username
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
                        Enter Username
                    </div>
                    <div class="col-md-6 cellspace">
                        <asp:TextBox ID="txtUserName" Width="200px" runat="server" ValidationExpression="^[a-zA-Z]+\s+[0-9]+$"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 cellspace">
                    </div>
                    <div class="col-md-6 cellspace">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                    </div>
                </div>

            </div>
        </div>
        <div class="container" id="dvUsersList" runat="server" style="padding: 10px;" visible="false">
            <div style="padding: 10px; background-color: #414042; color: #ffffff; font-weight: bold;">
                <asp:Label ID="lblSearchText" runat="server"></asp:Label>
            </div>
            <div style="width: 100%; min-height: 200px; height: 400px; overflow-x: scroll; overflow-y: scroll">
                <asp:GridView ID="grdUsersList" Width="90%" runat="server" AutoGenerateColumns="true"
                    OnRowDeleting="GrdUsersList_RowDeleting"
                    OnRowDataBound="GrdUsersList_RowDataBound">
                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                    <RowStyle CssClass="GridViewRowStyle" />
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ButtonType="Button" DeleteText="InActive" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>


    </main>
    <!-- Button to trigger modal -->
    <div class="container" id="dvNewUser" runat="server" style="padding: 10px;" visible="false">
        The Username '<asp:Label ID="lblLoginId" runat="server"></asp:Label>'
        is available.
        <asp:LinkButton ID="lnkBtnAddUser" runat="server" OnClick="lnkBtnAddUser_Click">Click here</asp:LinkButton>
        to add the user.
    </div>

    <!-- The Modal -->
    <div id="modalDialog" class="modal" runat="server">
        <div class="modal-content animate-top">
            <div class="modal-header" style="background-color: #D4D4D4; padding: 10px;">
                <h5 class="modal-title">New User Creation</h5>
                <asp:Button type="button" ID="btnCloseModal" runat="server" CssClass="close" Text="X" OnClick="btnCloseModal_Click">
                </asp:Button>
            </div>
            <div class="modal-body" style="height: 240px; overflow-y: scroll">
                <div class="row">
                    <div class="col-md-10 cellspace text-md-end" style="text-align: left !important;">
                        <asp:Label ID="lblAddUserMsg" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 cellspace text-md-end">
                        Username
                    </div>
                    <div class="col-md-6 cellspace">
                        <asp:TextBox ID="txtLoginId" Width="200px" runat="server" ReadOnly="true" MaxLength="15"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 cellspace text-md-end">
                        Employee ID
                    </div>
                    <div class="col-md-6 cellspace">
                        <asp:TextBox ID="txtEmpId" Width="200px" runat="server" TextMode="Number" MaxLength="10"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 cellspace text-md-end">
                        Last Name
                    </div>
                    <div class="col-md-6 cellspace">
                        <asp:TextBox ID="txtLastName" Width="200px" runat="server" MaxLength="50"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 cellspace text-md-end">
                        First Name
                    </div>
                    <div class="col-md-6 cellspace">
                        <asp:TextBox ID="txtFirstName" Width="200px" runat="server" MaxLength="50"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 cellspace text-md-end">
                        Role
                    </div>
                    <div class="col-md-6 cellspace">
                        <asp:DropDownList ID="ddlRole" runat="server" Width="200px" Height="30px">
                            <asp:ListItem Value="-1">Select</asp:ListItem>
                            <asp:ListItem Value="MedRec">MedRec</asp:ListItem>
                            <asp:ListItem Value="Call Center">Call Center</asp:ListItem>
                            <asp:ListItem Value="Case Builder">Case Builder</asp:ListItem>
                            <asp:ListItem Value="Clarification">Clarification</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <hr />
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnClose" runat="server" CssClass="btn btn-secondary close" Text="Cancel" OnClick="btnCancel_Click" />
                <asp:Button ID="btnAddUser" runat="server" CssClass="btn btn-primary" Text="Add User" OnClientClick="return ValidateAddUserInput()" OnClick="btnAddUser_Click" />
            </div>
        </div>
    </div>
</asp:Content>
