<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="orderdetail.aspx.cs" Inherits="orderdetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Order Detail</title>
    <style>
        /* Reset some default styles */
        body, div, h2, hr {
            margin: 0;
            padding: 0;
        }
        
        /* Apply a background color */
        body {
            background-color: #f5f5f5;
            font-family: Arial, sans-serif;
        }

        /* Style the profile container */
        .profile-container {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        /* Style the profile box */
        .profile-box {
            background-color: #fff;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.2);
            padding: 20px;
            width: 97%;
            max-width: 600px;
            text-align: center;
         margin-top:auto;
         margin-bottom:auto;
            height: 843px;
        }

        /* Style the profile labels */
        .profile-label {
            font-weight: bold;
            display: block;
            margin-bottom: 10px;
            font-family:Arial;
            text-align:justify;
        }

        /* Style the GridView */
        .order-gridview {
            margin-top: 20px;
            border-collapse: collapse;
            width: 100%;
        }

        .order-gridview th, .order-gridview td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }



        .order-gridview tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        /* Style the Product Image */
        .product-image {
            max-width: 100px;
            max-height: 100px;
        }
      .registration-button {
            font-family: Arial, sans-serif;
            background-color: #007bff; /* Blue color, adjust as needed */
            color: #fff; /* White text color */
            padding: 10px 20px;
            border: none;
            cursor: pointer;
            font-size: 16px;
            width:auto;
        }
        /* Apply hover effect to the Save button */
        .registration-button:hover {
            background-color: #0056b3; /* Darker blue on hover */
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="profile-container">
            <div class="profile-box">
                <h2>User Profile</h2>
                <br>
                <hr />
                <br />
               <table style="margin: 0 auto; width: 746px;">
    <tr>
        <td>
            <div class="profile-info">
                <asp:Label ID="lblName" runat="server" CssClass="profile-label"></asp:Label>
                <asp:Label ID="lblEmail" runat="server" CssClass="profile-label"></asp:Label>
                <asp:Label ID="lblContact" runat="server" CssClass="profile-label"></asp:Label>
                <asp:Label ID="lblAddress" runat="server" CssClass="profile-label"></asp:Label>
                <hr width=600px>
            </div>

     <br />
      
           <asp:Button ID="Button1" runat="server" CssClass="registration-button" 
                Text="Update Data" onclick="Button1_Click" />
       &nbsp &nbsp
        <asp:Button ID="btnLogout" runat="server" CssClass="registration-button" Text="Logout" OnClick="btnLogout_Click" /></td>
    </tr>
</table>

                <asp:GridView ID="GridViewOrders" runat="server" AutoGenerateColumns="False" CssClass="order-gridview">
                    <Columns>
                        <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                        <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                        <asp:BoundField DataField="Size" HeaderText="Size" />
                        <asp:BoundField DataField="OrderDate" HeaderText="Order Date" DataFormatString="{0:MM/dd/yyyy}" />
                        <asp:ImageField DataImageUrlField="ProductImage" HeaderText="Product Image" ControlStyle-Height="100px" ControlStyle-Width="100px" ItemStyle-CssClass="product-image" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        
</asp:Content>