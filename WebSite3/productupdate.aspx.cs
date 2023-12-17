using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;

public partial class productupdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Bind data to the GridView
            BindGridView();
        }
    }

    protected void BindGridView()
    {
        string connectionString = "Data Source=DESKTOP-B3AMDGK\\SQLEXPRESS;Initial Catalog=shoesshop;Integrated Security=True"; // Replace with your database connection string
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ProductDetail", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile && !string.IsNullOrWhiteSpace(TextBox1.Text) && !string.IsNullOrWhiteSpace(TextBox2.Text) && !string.IsNullOrWhiteSpace(TextBox3.Text))
        {
            try
            {
                // Get the file name

                // Get the file name
                string fileName = Path.GetFileName(FileUpload1.FileName);

                // Specify the path to save the uploaded image
                string imagePath = Server.MapPath("~/image/" + fileName);

                // Save the image to the specified path
                FileUpload1.SaveAs(imagePath);


                // Update data in the database
                string connectionString = "Data Source=DESKTOP-B3AMDGK\\SQLEXPRESS;Initial Catalog=shoesshop;Integrated Security=True"; // Replace with your database connection string
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE ProductDetail SET ProductName = @ProductName, Price = @Price, ProductImage = @ProductImage WHERE ProductID = @ProductID", con);
                    cmd.Parameters.AddWithValue("@ProductID", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@ProductName", TextBox2.Text);
                    cmd.Parameters.AddWithValue("@Price", TextBox3.Text);

                    cmd.Parameters.AddWithValue("@ProductImage", "~/image/" + fileName); // Store the updated image path in the database

                    cmd.ExecuteNonQuery();
                }

                Label5.Text = "Data updated successfully!";
            }
            catch (Exception ex)
            {
                Label5.Text = "Error: " + ex.Message;
            }
        }
        else
        {
            Label5.Text = "Please fill out all fields and select an image to update.";
        }

        // Refresh the GridView
        BindGridView();
    }

    protected void InsertButton_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(TextBox1.Text) && !string.IsNullOrWhiteSpace(TextBox2.Text) && !string.IsNullOrWhiteSpace(TextBox3.Text))
        {
            try
            {
                // Insert data into the database
                string connectionString = "Data Source=DESKTOP-B3AMDGK\\SQLEXPRESS;Initial Catalog=shoesshop;Integrated Security=True"; // Replace with your database connection string
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO ProductDetail (ProductId, ProductName, Price, ProductImage) VALUES (@ProductId, @ProductName, @Price, @ProductImage)", con);
                    cmd.Parameters.AddWithValue("@ProductId", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@ProductName", TextBox2.Text);
                    cmd.Parameters.AddWithValue("@Price", TextBox3.Text);
                    cmd.Parameters.AddWithValue("@ProductImage", "~/image/default.jpg"); // Provide a default image path or leave it blank
                    cmd.ExecuteNonQuery();
                }

                Label5.Text = "Data inserted successfully!";
            }
            catch (Exception ex)
            {
                Label5.Text = "Error: " + ex.Message;
            }
        }
        else
        {
            Label5.Text = "Please fill out all fields to insert data.";
        }

        // Refresh the GridView
        BindGridView();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
        if (e.CommandName == "EditRecord")
        {
            // Handle edit operation
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            string productId = GridView1.DataKeys[rowIndex]["ProductID"].ToString();

            // Retrieve the record to edit (similar to your existing code)
            // Populate the form fields with the data
            // ...

            // You can implement an update operation based on user input here
            // ...
        }
    }
    protected void GetDataButton_Click(object sender, EventArgs e)
    {
        // Call a method to retrieve and display all products
        DisplayAllProducts();
    }

  

    private void DisplayAllProducts()
    {
        // Implement code to retrieve all products from the database and display them
        string connectionString = "Data Source=DESKTOP-B3AMDGK\\SQLEXPRESS;Initial Catalog=shoesshop;Integrated Security=True"; // Replace with your database connection string
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ProductDetail", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }

  

    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        // Implement the database delete operation using productId
        string connectionString = "Data Source=DESKTOP-B3AMDGK\\SQLEXPRESS;Initial Catalog=shoesshop;Integrated Security=True"; // Replace with your database connection string
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM ProductDetail WHERE ProductID = @ProductID", con);
            cmd.Parameters.AddWithValue("@ProductID", TextBox1.Text);
            cmd.ExecuteNonQuery();
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
