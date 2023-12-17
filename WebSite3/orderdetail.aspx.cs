
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class orderdetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            // Check if the user is logged in by checking the session variable
            if (Session["UserEmail"] != null)
            {
                // Get the user's email from the session
                string userEmail = Session["UserEmail"].ToString();

                // Retrieve user data based on the email
                string connectionString = "Data Source=DESKTOP-B3AMDGK\\SQLEXPRESS;Initial Catalog=shoesshop;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string selectQuery = "SELECT Name, Contact, Address FROM Users WHERE Email = @Email";
                    SqlCommand cmd = new SqlCommand(selectQuery, connection);
                    cmd.Parameters.AddWithValue("@Email", userEmail);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Display user data on the profile page
                        string name = reader["Name"].ToString();
                        string contact = reader["Contact"].ToString();
                        string address = reader["Address"].ToString();

                        lblName.Text = "Name: " + name;
                        lblEmail.Text = "Email: " + userEmail;
                        lblContact.Text = "Contact: " + contact;
                        lblAddress.Text = "Address: " + address;
                    }
                }
            }
            else
            {
                // User is not logged in, handle accordingly (e.g., redirect to login page)
                Response.Redirect("login.aspx");
            }
            // Check if the user is logged in by verifying the session variable
            if (Session["UserEmail"] != null)
            {
                string userEmail = Session["UserEmail"].ToString();

                // Fetch and display user data based on the email (as shown in previous code)
                // ...

                // Fetch and display order data based on the email
                FetchAndDisplayUserOrders(userEmail);
            }
            else
            {
                // Handle the case where the user is not logged in
                // Redirect to a login page or show an error message
            }
        }
    }

    private void FetchAndDisplayUserOrders(string userEmail)
    {
        string connectionString = "Data Source=DESKTOP-B3AMDGK\\SQLEXPRESS;Initial Catalog=shoesshop;Integrated Security=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Construct your SQL query to retrieve user orders along with product details
            string sqlQuery = "SELECT UO.ProductId, UO.Quantity, UO.Size, UO.OrderDate, PD.ProductName, PD.Price, PD.ProductImage " +
                              "FROM UserOrder AS UO " +
                              "INNER JOIN ProductDetail AS PD ON UO.ProductId = PD.ProductId " +
                              "WHERE UO.Email = @UserEmail";

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.Parameters.AddWithValue("@UserEmail", userEmail);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Display user orders in the GridView
                    GridViewOrders.DataSource = reader;
                    GridViewOrders.DataBind();
                }
            }
        }
    }


    protected void btnLogout_Click(object sender, EventArgs e)
    {
      // Handle the logout request

    // Remove the session variable
    Session.Remove("UserEmail");

    // Optionally, you can also abandon the session to clear all session data
    Session.Abandon();

    // Redirect the user to the shop page or any other desired destination
    Response.Redirect("shop.aspx");
}

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("update.aspx");
    }
}
