using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string email = txtEmail.Text.Trim();
        string password = txtPassword.Text;

        // Validate user input (You should implement proper validation here)

        // Check if the provided email exists in the database
        string connectionString = "Data Source=DESKTOP-B3AMDGK\\SQLEXPRESS;Initial Catalog=shoesshop;Integrated Security=True";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string selectQuery = "SELECT Password FROM Users WHERE Email = @Email";
            SqlCommand cmd = new SqlCommand(selectQuery, connection);
            cmd.Parameters.AddWithValue("@Email", email);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string storedPassword = reader["Password"].ToString();
                if (password == storedPassword)
                {
                    // Successful login
                    lblMessage.Visible = true;
                    lblMessage.Text = "Welcome to Shoes Shop!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    Session["UserEmail"] = email; // Storing the user's email in a session variable

                    // Redirect to the profile page
                    Response.Redirect("home.aspx");
                }
                else
                {
                    // Incorrect password
                    lblMessage.Visible = true;
                    lblMessage.Text = "Incorrect password. Please try again.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                // Incorrect email
                lblMessage.Visible = true;
                lblMessage.Text = "Incorrect email. Please try again.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
