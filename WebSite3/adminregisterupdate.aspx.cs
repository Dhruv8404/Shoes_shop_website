using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class adminregisterupdate : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Load user data into the GridView when the page first loads
            LoadUserData();
        }
    }
    protected void gvUserData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteUser")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            if (rowIndex >= 0 && rowIndex < gvUserData.Rows.Count)
            {
                string email = gvUserData.DataKeys[rowIndex]["Email"].ToString(); // Assuming Email is a unique identifier

                // Implement the delete operation here
                DeleteUserByEmail(email);

                // Reload user data after deletion
                LoadUserData();
            }
        }
    }


    protected void DeleteUserByEmail(string email)
    {
        // Check if the email address already exists in the database
        string connectionString = "Data Source=DESKTOP-B3AMDGK\\SQLEXPRESS;Initial Catalog=shoesshop;Integrated Security=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string deleteQuery = "DELETE FROM Users WHERE Email = @Email";
            SqlCommand deleteCmd = new SqlCommand(deleteQuery, connection);
            deleteCmd.Parameters.AddWithValue("@Email", email);

            int rowsAffected = deleteCmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "User data deleted successfully!";
                lblErrorMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "User data deletion failed.";
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }

    protected void LoadUserData()
    {
        string connectionString = "Data Source=DESKTOP-B3AMDGK\\SQLEXPRESS;Initial Catalog=shoesshop;Integrated Security=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string selectQuery = "SELECT * FROM Users"; // Select all columns
            SqlCommand selectCmd = new SqlCommand(selectQuery, connection);

            SqlDataAdapter adapter = new SqlDataAdapter(selectCmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                // Bind the data to the GridView control
                gvUserData.DataSource = dataTable;
                gvUserData.DataBind();
            }
            else
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "No users found.";
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }

    protected void btnGetUserData_Click(object sender, EventArgs e)
    {
        // Reload user data when the "Get User Data" button is clicked
        LoadUserData();
    }
    protected void btnUpdateUser_Click(object sender, EventArgs e)
    {
        string email = txtEmail.Text.Trim();
        string name = txtName.Text.Trim();
        string contact = txtContact.Text.Trim();
        string password = txtPassword.Text;
        string address = txtAddress.Text.Trim();

        string connectionString = "Data Source=DESKTOP-B3AMDGK\\SQLEXPRESS;Initial Catalog=shoesshop;Integrated Security=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string updateQuery = "UPDATE Users SET Name = @Name, Contact = @Contact, Password = @Password, Address = @Address WHERE Email = @Email";
            SqlCommand updateCmd = new SqlCommand(updateQuery, connection);
            updateCmd.Parameters.AddWithValue("@Name", name);
            updateCmd.Parameters.AddWithValue("@Contact", contact);
            updateCmd.Parameters.AddWithValue("@Password", password);
            updateCmd.Parameters.AddWithValue("@Address", address);
            updateCmd.Parameters.AddWithValue("@Email", email);

            int rowsAffected = updateCmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "User data updated successfully!";
                lblErrorMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "User data update failed.";
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
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
                        Session["UserEmail"] = email;

                       
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
