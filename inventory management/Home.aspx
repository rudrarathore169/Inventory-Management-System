

<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Home.aspx.cs" Inherits="inventory_management.Home" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <!-- Welcome Section -->
        <div class="jumbotron text-center bg-light p-4 shadow">
            <h1 class="display-4" style="background-color: #FFFF66">Welcome to Inventory Management System</h1>
            <p class="lead" style="background-color: #FF9966">Effortlessly manage your inventory, customers, and sales with our user-friendly platform.</p>
            <hr class="my-4">
            <p style="background-color: #FFCC99">Get started by navigating to the sections below:</p>
        </div>

        <!-- Quick Navigation Section -->
        <div class="row text-center mt-4">
            <div class="col-md-3">
                <div class="card shadow" style="background-color: #99FF99">
                    <div class="card-body">
                        <h5 class="card-title">Products</h5>
                        <p class="card-text">Add, update, and view all products in your inventory.</p>
                        <a href="Products.aspx" class="btn btn-primary">Manage Products</a>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card shadow" style="background-color: #FF99FF">
                    <div class="card-body">
                        <h5 class="card-title">Orders</h5>
                        <p class="card-text">Track customer orders and sales trends.</p>
                        <a href="Orders.aspx" class="btn btn-primary">View Orders</a>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card shadow" style="background-color: #99FF99">
                    <div class="card-body">
                        <h5 class="card-title">Customers</h5>
                        <p class="card-text">View and manage customer information.</p>
                        <a href="Customers.aspx" class="btn btn-primary">View Customers</a>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card shadow" style="background-color: #FF99FF">
                    <div class="card-body">
                        <h5 class="card-title">Reports</h5>
                        <p class="card-text">Generate detailed reports on inventory and sales.</p>
                        <a href="Reports.aspx" class="btn btn-primary">View Reports</a>
                    </div>
                </div>
            </div>
        </div>

        <!-- Overview Section -->
        <div class="row mt-5">
            <div class="col-md-4 text-center">
                <div class="alert alert-info shadow">
                    <h4>Total Products</h4>
                    <p><strong>120</strong></p>
                </div>
            </div>
            <div class="col-md-4 text-center">
                <div class="alert alert-success shadow">
                    <h4>Total Customers</h4>
                    <p><strong>50</strong></p>
                </div>
            </div>
            <div class="col-md-4 text-center">
                <div class="alert alert-warning shadow">
                    <h4>Total Orders</h4>
                    <p><strong>35</strong></p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

