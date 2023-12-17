using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        // Get the entered username and password
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text;

        // Define your connection string
        string connectionString = "Data Source=DESKTOP-B3AMDGK\\SQLEXPRESS;Initial Catalog=shoesshop;Integrated Security=True";

        // Create a SqlConnection and SqlCommand
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Define your SQL query to check for username and password
            string selectQuery = "SELECT COUNT(*) FROM Admin WHERE Username = @Username AND Password = @Password";
            SqlCommand cmd = new SqlCommand(selectQuery, connection);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);

            int userCount = (int)cmd.ExecuteScalar();

            if (userCount > 0)
            {
                // Successful login
                lblMessage.Text = "Successfully logged in.";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Visible = true;
                Response.Redirect("productupdate.aspx");
            }
            else
            {
                // Incorrect credentials
                lblMessage.Text = "Incorrect username or password. Please try again.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
            }
        }
    }

}