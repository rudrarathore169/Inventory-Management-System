<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Orders.aspx.cs" Inherits="inventory_management.Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <!-- Page Header -->
        <div class="d-flex justify-content-between align-items-center mb-4">
            <h2>Manage Orders</h2>
            <a href="AddOrder.aspx" class="btn btn-success">Add New Order</a>
        </div>

        <!-- Search Bar -->
        <div class="input-group mb-3">
            <input type="text" class="form-control" placeholder="Search orders..." id="searchBox" />
            <button class="btn btn-primary" type="button" id="searchButton">Search</button>
        </div>

        <!-- Orders Table -->
      <asp:GridView ID="OrdersGrid" runat="server" AutoGenerateColumns="False" DataKeyNames="OrderID" CssClass="table table-bordered table-hover" OnRowDeleting="OrdersGrid_RowDeleting">
    <Columns>
        <asp:BoundField DataField="OrderID" HeaderText="Order ID" />
        <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
        <asp:BoundField DataField="OrderDate" HeaderText="Order Date" DataFormatString="{0:yyyy-MM-dd}" />
        <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" DataFormatString="{0:C}" />
        <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
    </Columns>
</asp:GridView>


    </div>
</asp:Content>
