using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Load the first 6 products from the database and bind them to the GridView
            BindProductGridView();
        }
    }

    private void BindProductGridView()
    {
        string connectionString = "Data Source=DESKTOP-B3AMDGK\\SQLEXPRESS;Initial Catalog=shoesshop;Integrated Security=True";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT TOP 6 ProductId, ProductName, Price, ProductImage FROM ProductDetail", con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                ProductGridView.DataSource = reader;
                ProductGridView.DataBind();
                con.Close();
            }
        }
    }
    protected void AddToCartButton_Click(object sender, EventArgs e)
    {
        // Get the ProductId from the CommandArgument of the button
        Button addToCartButton = (Button)sender;
        int productId = Convert.ToInt32(addToCartButton.CommandArgument);

        // Use the userEmail variable to associate the product with the user
        string userEmail = Session["UserEmail"] as string;

        if (!string.IsNullOrEmpty(userEmail))
        {
            // Find the QuantityTextBox and SizeDropDown in the GridView row that corresponds to the clicked button
            GridViewRow row = (GridViewRow)addToCartButton.NamingContainer;
            TextBox quantityTextBox = (TextBox)row.FindControl("QuantityTextBox");
            DropDownList sizeDropDown = (DropDownList)row.FindControl("SizeDropDown");

            if (quantityTextBox != null && sizeDropDown != null)
            {
                int quantity = Convert.ToInt32(quantityTextBox.Text);
                string size = sizeDropDown.SelectedValue; // Get the selected size as a string

                string connectionString = "Data Source=DESKTOP-B3AMDGK\\SQLEXPRESS;Initial Catalog=shoesshop;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Check if the CartItem already exists for the user, product, and size
                    using (SqlCommand checkCmd = new SqlCommand("SELECT Quantity FROM CartItem4 WHERE Email = @Email AND ProductId = @ProductId AND Size = @Size", con))
                    {
                        checkCmd.Parameters.AddWithValue("@Email", userEmail);
                        checkCmd.Parameters.AddWithValue("@ProductId", productId);
                        checkCmd.Parameters.AddWithValue("@Size", size); // Make sure the parameter name matches the table schema

                        // Execute the query and store the result in existingQuantityObj
                        object existingQuantityObj = checkCmd.ExecuteScalar();

                        // Check if a result was returned
                        if (existingQuantityObj != null)
                        {
                            int existingQuantity = Convert.ToInt32(existingQuantityObj);

                            // If the new quantity is greater, update the existing record
                            if (quantity > existingQuantity)
                            {
                                using (SqlCommand updateCmd = new SqlCommand("UPDATE CartItem4 SET Quantity = @Quantity WHERE Email = @Email AND ProductId = @ProductId AND Size = @Size", con))
                                {
                                    updateCmd.Parameters.AddWithValue("@Email", userEmail);
                                    updateCmd.Parameters.AddWithValue("@ProductId", productId);
                                    updateCmd.Parameters.AddWithValue("@Quantity", quantity);
                                    updateCmd.Parameters.AddWithValue("@Size", size);

                                    // Execute the update query
                                    updateCmd.ExecuteNonQuery();
                                }
                            }
                            // If the new quantity is not greater, you can handle it as needed (e.g., show a message).
                        }
                        else
                        {
                            // If the CartItem doesn't exist, insert a new record
                            using (SqlCommand insertCmd = new SqlCommand("INSERT INTO CartItem4 (Email, ProductId, Quantity, Size) VALUES (@Email, @ProductId, @Quantity, @Size)", con))
                            {
                                insertCmd.Parameters.AddWithValue("@Email", userEmail);
                                insertCmd.Parameters.AddWithValue("@ProductId", productId);
                                insertCmd.Parameters.AddWithValue("@Quantity", quantity);
                                insertCmd.Parameters.AddWithValue("@Size", size);

                                // Execute the insert query
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    con.Close();
                }
            }
        }
        else
        {
            // Handle the case where the user is not logged in or the session variable is not set.
            // You can redirect the user to the login page or display a message.
        }
    }

}