<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Products.aspx.cs" Inherits="inventory_management.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <!-- Page Header -->
        <div class="d-flex justify-content-between align-items-center mb-4">
            <h2>Manage Products</h2>
            <a href="AddProduct.aspx" class="btn btn-success">Add Product</a>
        </div>

        <!-- Search Bar -->
        <div class="input-group mb-3">
            <asp:TextBox ID="SearchBox" runat="server" CssClass="form-control" Placeholder="Search for products..." />
            <asp:Button ID="SearchButton" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="SearchButton_Click" />
        </div>

        <!-- Products Table -->
 <asp:GridView ID="ProductsGrid" runat="server" AutoGenerateColumns="False" OnRowDeleting="ProductsGrid_RowDeleting" CssClass="table table-bordered table-hover" DataKeyNames="ProductID">
    <Columns>
        <asp:BoundField DataField="ProductID" HeaderText="Product ID" />
        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
        <asp:BoundField DataField="Category" HeaderText="Category" />
        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
        <asp:BoundField DataField="PurchasePrice" HeaderText="Purchase Price" DataFormatString="{0:C}" />
        <asp:BoundField DataField="SellingPrice" HeaderText="Selling Price" DataFormatString="{0:C}" />
        <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
    </Columns>
</asp:GridView>


        <!-- Error Message -->
        <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>
