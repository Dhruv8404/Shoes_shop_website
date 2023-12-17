using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        // Retrieve user input
        string name = txtName.Text.Trim();
        string email = txtEmail.Text.Trim();
        string contact = txtContact.Text.Trim();
        string password = txtPassword.Text;
        string address = txtAddress.Text.Trim();

        // Validate user input (You should implement proper validation here)

        // Check if the email address already exists in the database
        string connectionString = "Data Source=DESKTOP-B3AMDGK\\SQLEXPRESS;Initial Catalog=shoesshop;Integrated Security=True";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string checkQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
            SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
            checkCmd.Parameters.AddWithValue("@Email", email);
            int emailCount = (int)checkCmd.ExecuteScalar();

            if (emailCount > 0)
            {
                // Email address already exists in the database
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "This email address is already registered.";
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                // Email address is not in the database, proceed with registration
                string insertQuery = "INSERT INTO Users (Name, Email, Contact, Password, Address) VALUES (@Name, @Email, @Contact, @Password, @Address)";
                SqlCommand cmd = new SqlCommand(insertQuery, connection);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Contact", contact);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Address", address);

                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Registration successful
                        lblErrorMessage.Visible = true;
                        lblErrorMessage.Text = "Registration successful!";
                        lblErrorMessage.ForeColor = System.Drawing.Color.Green;
                        Session["UserEmail"] = email; // Storing the user's email in a session variable

                        // Redirect to the profile page
                        Response.Redirect("home.aspx");
                    }
                    else
                    {
                        // Registration failed
                        lblErrorMessage.Visible = true;
                        lblErrorMessage.Text = "Registration failed. Please try again later.";
                        lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    lblErrorMessage.Visible = true;
                    lblErrorMessage.Text = "Error: " + ex.Message;
                    lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}
