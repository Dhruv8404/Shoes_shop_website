using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class ordercome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Retrieve and display data from the "UserOrder" table along with product details, ordered by date
            BindGridView();
        }
    }

    private void BindGridView()
    {
        // Define your connection string
        string connectionString = "Data Source=DESKTOP-B3AMDGK\\SQLEXPRESS;Initial Catalog=shoesshop;Integrated Security=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT U.Email, U.ProductId, U.Quantity, U.Size, U.OrderDate, P.ProductName, P.Price, P.ProductImage " +
                           "FROM UserOrder U " +
                           "INNER JOIN ProductDetail P ON U.ProductId = P.ProductId " +
                           "ORDER BY U.OrderDate DESC"; // Change to ASC for ascending order

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                GridViewOrders.DataSource = dataTable;
                GridViewOrders.DataBind();
            }
        }
    }
}