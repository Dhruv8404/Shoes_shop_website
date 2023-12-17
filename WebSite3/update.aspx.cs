using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class update : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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

}