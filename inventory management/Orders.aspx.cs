using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace inventory_management
{
    public partial class Orders : System.Web.UI.Page
    {
        private string connectionString = "Data Source=LAPTOP-JR9O99HU\\SQLEXPRESS;Initial Catalog=InventoryDB;Integrated Security=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOrders();
            }
        }

        // Method to Load Orders
        private void LoadOrders()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT o.OrderID, c.CustomerName, o.OrderDate, o.TotalAmount FROM Orders o INNER JOIN Customers c ON o.CustomerID = c.CustomerID";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    OrdersGrid.DataSource = dt;
                    OrdersGrid.DataBind();
                }
                catch (Exception ex)
                {
                    ErrorMessage.Text = "Error loading orders: " + ex.Message;
                }
            }
        }

        // Method to Search Orders
        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string searchText = SearchBox.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT o.OrderID, c.CustomerName, o.OrderDate, o.TotalAmount 
                        FROM Orders o 
                        INNER JOIN Customers c ON o.CustomerID = c.CustomerID
                        WHERE c.CustomerName LIKE @SearchText OR o.OrderID LIKE @SearchText";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    OrdersGrid.DataSource = dt;
                    OrdersGrid.DataBind();
                }
                catch (Exception ex)
                {
                    ErrorMessage.Text = "Error searching orders: " + ex.Message;
                }
            }
        }

        // Method to Cancel Order
        protected void OrdersGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int orderId = Convert.ToInt32(OrdersGrid.DataKeys[e.RowIndex].Value);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM Orders WHERE OrderID = @OrderID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    cmd.ExecuteNonQuery();

                    // Reload orders after deletion
                    LoadOrders();
                }
                catch (Exception ex)
                {
                    ErrorMessage.Text = "Error cancelling order: " + ex.Message;
                }
            }
        }
    }
}
