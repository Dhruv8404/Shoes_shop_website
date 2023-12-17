using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Database connection string
            string connectionString = @"Data Source=DESKTOP-B3AMDGK\SQLEXPRESS;Initial Catalog=shoesshop;Integrated Security=True";

            // SQL query to retrieve data from ProductDetail
            string query = "SELECT ProductId, ProductName, Price, ProductImage FROM ProductDetail";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                GridView1.DataSource = reader;
                GridView1.DataBind();
                reader.Close();
            }
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "AddToCart")
        {
            int rowIndex=0;
            rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[rowIndex];

            CheckBox checkBox = row.FindControl("CheckBox1") as CheckBox;

            if (checkBox != null && checkBox.Checked)
            {
                int productId = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);
                int quantity = Convert.ToInt32((row.FindControl("QuantityDropDown") as DropDownList).SelectedValue);

                string connectionString = @"Data Source=DESKTOP-B3AMDGK\SQLEXPRESS;Initial Catalog=shoesshop;Integrated Security=True";
                string query = "INSERT INTO Buy (ProductId, Quantity) VALUES (@ProductId, @Quantity)";
                 

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ProductId", productId);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        
                        cmd.ExecuteNonQuery();
                    
                    
                    
                    }

                }
            }
            }
        }
    protected void AddToDatabaseButton_Click(object sender, EventArgs e)
    {
        string connectionString = @"Data Source=DESKTOP-B3AMDGK\SQLEXPRESS;Initial Catalog=shoesshop;Integrated Security=True";

        // Retrieve the user's email address from the session variable
        string userEmail = Session["UserEmail"] as string;

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox checkBox = row.FindControl("CheckBox1") as CheckBox;

                    if (checkBox != null && checkBox.Checked)
                    {
                        int productId = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);
                        int quantity = Convert.ToInt32((row.FindControl("QuantityDropDown") as DropDownList).SelectedValue);

                        string query = "INSERT INTO Buy (Email, ProductId, Quantity) VALUES (@Email, @ProductId, @Quantity)";

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            // Add user's email address as a parameter
                            cmd.Parameters.AddWithValue("@Email", userEmail);
                            cmd.Parameters.AddWithValue("@ProductId", productId);
                            cmd.Parameters.AddWithValue("@Quantity", quantity);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }

            // Optionally, you can perform any additional logic or redirection after adding data to the "Buy" table.
        }
        catch (Exception ex)
        {
            // Handle any exceptions here or log them for debugging.
            Response.Write("An error occurred: " + ex.Message);
        }
    }


}



    



   