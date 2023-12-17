<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage1.master" CodeFile="productupdate.aspx.cs" Inherits="productupdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Product Update</title>
    <style>
        body
        {
            font-family:arial;
            font-size:20px;
            }
        /* Center-align container */
        .login-container {
            text-align: center;
            margin: 0 auto;
            max-width: 400px; /* Adjust the max-width as needed */
            background-color: #f3f3f3; /* Light gray background color */
            border: 1px solid #ccc;
            padding: 20px;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.2); /* Apply box shadow for shading */
        }

        /* Style for input boxes */
        .input-box {
            width: 90%; /* Full width input boxes */
            padding: 10px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            font-size: 14px;
        }

        /* Style for the Save button */
       
        /* Define a CSS class for the GridView */
.gridview {
    font-family: Arial, sans-serif;
    border-collapse: collapse;
    width: 100%;
}

.gridview th, .gridview td {
    border: 1px solid #dddddd;
    text-align: left;
    padding: 8px;
}

.gridview tr:nth-child(even) {
    background-color: #f2f2f2;
}

.gridview tr:hover {
    background-color: #ddd;
}
 .registration-button {
            font-family: Arial, sans-serif;
            background-color: #007bff; /* Blue color, adjust as needed */
            color: #fff; /* White text color */
            padding: 10px 20px;
            border: none;
            cursor: pointer;
            font-size: 16px;
            width:100px;
        }
        /* Apply hover effect to the Save button */
        .registration-button:hover {
            background-color: #0056b3; /* Darker blue on hover */
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="login-container">
     <h1>Update product</h1>
     <hr>
        <asp:Label ID="Label1" runat="server" Text="Product ID"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="input-box"></asp:TextBox>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Product Name"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" CssClass="input-box"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Price"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" CssClass="input-box"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="Product Image:"></asp:Label>
            <asp:FileUpload ID="FileUpload1" runat="server"  />
        </p>
        <table>
        <tr>
     <td>  <asp:Button ID="Button1" runat="server" Text="Update" CssClass="registration-button" OnClick="Button1_Click" /></td>
       <td>    <asp:Button ID="InsertButton" runat="server" Text="Insert" CssClass="registration-button" OnClick="InsertButton_Click" /></td>
       <td>     <asp:Button ID="DeleteButton" Text="Delete" runat="server" CssClass="registration-button"  OnClick="DeleteButton_Click" /></td>
    </tr>
    <tr>
   <td>   <asp:Button ID="GetDataButton" runat="server" Text="Get Data" CssClass="registration-button" OnClick="GetDataButton_Click" /></td>
        
</tr>
</table>

        <p>
            <asp:Label ID="Label5" runat="server"></asp:Label>
        </p>
     </div>


     <h1> Product Data</h1>
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" 
         CssClass="gridview" onselectedindexchanged="GridView1_SelectedIndexChanged">
    <Columns>
        <asp:BoundField DataField="ProductID" HeaderText="Product ID" />
        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
        <asp:BoundField DataField="Price" HeaderText="Price" />
        <asp:TemplateField HeaderText="Product Image">
            <ItemTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("ProductImage") %>' Height="50" Width="50" />
            </ItemTemplate>
        </asp:TemplateField>

      
    </Columns>
</asp:GridView>

 </asp:Content>   
   
