<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="AddProduct.aspx.cs" Inherits="inventory_management.AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2>Add New Product</h2>
        <asp:Label ID="SuccessMessage" runat="server" ForeColor="Green"></asp:Label>
        <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red"></asp:Label>
        <form>
            <div class="mb-3">
                <label for="ProductName" class="form-label">Product Name</label>
                <asp:TextBox ID="ProductName" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="Category" class="form-label">Category</label>
                <asp:TextBox ID="Category" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="Quantity" class="form-label">Quantity</label>
                <asp:TextBox ID="Quantity" runat="server" CssClass="form-control" TextMode="Number" />
            </div>
            <div class="mb-3">
                <label for="PurchasePrice" class="form-label">Purchase Price</label>
                <asp:TextBox ID="PurchasePrice" runat="server" CssClass="form-control" TextMode="Number" />
            </div>
            <div class="mb-3">
                <label for="SellingPrice" class="form-label">Selling Price</label>
                <asp:TextBox ID="SellingPrice" runat="server" CssClass="form-control" TextMode="Number" />
            </div>
            <asp:Button ID="AddProductButton" runat="server" CssClass="btn btn-primary" Text="Add Product" OnClick="AddProductButton_Click" />
        </form>
    </div>
</asp:Content>

