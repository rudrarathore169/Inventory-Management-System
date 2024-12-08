using System;
using System.Data.SqlClient;

namespace inventory_management
{
    public partial class AddProduct : System.Web.UI.Page
    {
        private string connectionString = "Data Source=LAPTOP-JR9O99HU\\SQLEXPRESS;Initial Catalog=techno;Integrated Security=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            // No special logic for Page_Load
        }

        protected void AddProductButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve input values
                string productName = ProductName.Text.Trim();
                string category = Category.Text.Trim();
                int quantity = int.Parse(Quantity.Text.Trim());
                decimal purchasePrice = decimal.Parse(PurchasePrice.Text.Trim());
                decimal sellingPrice = decimal.Parse(SellingPrice.Text.Trim());

                // Insert into database
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Products (ProductName, Category, Quantity, PurchasePrice, SellingPrice) VALUES (@ProductName, @Category, @Quantity, @PurchasePrice, @SellingPrice)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductName", productName);
                        cmd.Parameters.AddWithValue("@Category", category);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@PurchasePrice", purchasePrice);
                        cmd.Parameters.AddWithValue("@SellingPrice", sellingPrice);

                        cmd.ExecuteNonQuery();
                    }
                }

                // Success Message
                SuccessMessage.Text = "Product added successfully!";
                ClearFields();
            }
            catch (Exception ex)
            {
                // Error Message
                ErrorMessage.Text = "Error adding product: " + ex.Message;
            }
        }

        private void ClearFields()
        {
            ProductName.Text = string.Empty;
            Category.Text = string.Empty;
            Quantity.Text = string.Empty;
            PurchasePrice.Text = string.Empty;
            SellingPrice.Text = string.Empty;
        }
    }
}
