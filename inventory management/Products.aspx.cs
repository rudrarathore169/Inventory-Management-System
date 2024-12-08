using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace inventory_management
{
    public partial class Products : System.Web.UI.Page
    {
        private string connectionString = "Data Source=LAPTOP-JR9O99HU\\SQLEXPRESS;Initial Catalog=techno;Integrated Security=True;"; // Replace with your actual connection string

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts();
            }
        }

        // Method to Load Products
        private void LoadProducts()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ProductID, ProductName, Category, Quantity, PurchasePrice, SellingPrice FROM Products";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Bind data to the GridView or HTML Table
                    ProductsGrid.DataSource = dt; // Assuming you're using a GridView with ID ProductsGrid
                    ProductsGrid.DataBind();
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    ErrorMessage.Text = "Error loading products: " + ex.Message; // Assuming you have a Label with ID ErrorMessage
                }
            }
        }

        // Method to Delete Product
        protected void ProductsGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int productId = Convert.ToInt32(ProductsGrid.DataKeys[e.RowIndex].Value);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM Products WHERE ProductID = @ProductID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    cmd.ExecuteNonQuery();

                    // Reload products after deletion
                    LoadProducts();
                }
                catch (Exception ex)
                {
                    ErrorMessage.Text = "Error deleting product: " + ex.Message;
                }
            }
        }

        // Method for Search Functionality
        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string searchText = SearchBox.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ProductID, ProductName, Category, Quantity, PurchasePrice, SellingPrice " +
                                   "FROM Products WHERE ProductName LIKE @SearchText OR Category LIKE @SearchText";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Bind search results
                    ProductsGrid.DataSource = dt;
                    ProductsGrid.DataBind();
                }
                catch (Exception ex)
                {
                    ErrorMessage.Text = "Error searching products: " + ex.Message;
                }
            }
        }
    }
}
