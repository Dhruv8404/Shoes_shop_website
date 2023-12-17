<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Home Page</title>
    <style>
        /* Style for the entire GridView */
        .custom-gridview {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        /* Style for the header row */
        .custom-gridview th {
            background-color: #663399; /* A classic purple color */
            color: white;
            padding: 10px;
            text-align: left;
            border-bottom: 2px solid #ddd; /* A subtle gray border */
        }

        /* Style for the data rows */
        .custom-gridview tr:nth-child(even) {
            background-color: #f0e0ff; /* A fantasy-like lavender color */
        }

        .custom-gridview tr:nth-child(odd) {
            background-color: #f9d9ff; /* A fantasy-like pink color */
        }

        /* Style for the cells in the data rows */
        .custom-gridview td {
            padding: 10px;
            border-bottom: 1px solid #ddd;
        }

        /* Style for the Add to Cart button */
        .custom-add-button {
            background-color: #663399;
            color: white;
            border: none;
            padding: 8px 16px;
            cursor: pointer;
            font-weight: bold;
            border-radius: 5px; /* Rounded button corners */
        }

        .custom-add-button:hover {
            background-color: #491e66; /* Darker purple on hover */
        }

        /* Style for the container */
        .container {
            position: relative;
            text-align: center;
        }

        /* Style for the background image */
        .bg-image {
            width: 100%;
            height: auto;
            display: block;
            margin-top: 20px; /* Adjust the margin as needed */
            object-fit: cover; /* Ensures the image covers the container */
        }

        /* Style for the centered button */
        .centered-button {
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            background-color: #663399;
            color: white;
            padding: 10px 20px;
            text-decoration: none;
            border-radius: 5px; /* Rounded button corners */
            font-weight: bold;
        }
        
         .custom-image {
        max-width: 100px; /* Adjust the maximum width as needed */
        max-height: 100px; /* Adjust the maximum height as needed */
        display: block;
        margin: 0 auto; /* Center the images horizontally */
        border: 1px solid #ccc; /* Add a border for styling */
        border-radius: 5px; /* Add rounded corners */
    }
    </style>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div>
            <div class="container">
                <h1>Welcome to Our Online Store</h1> 
                <img src="https://media.istockphoto.com/id/1279108197/photo/variety-of-womens-fashion-comfortable-shoes-of-all-seasons-on-a-light-background-top-view.jpg?s=612x612&w=is&k=20&c=qxCXUXW9SA8On2Kij0gubrVe97DS-mcTxoz-QfkeBto=" alt="Background Image" class="bg-image" />
                <a href="shop.aspx" class="centered-button">Shop Now</a>
            </div>
        </div>
        <div class="product-container">
            <asp:GridView ID="ProductGridView" runat="server" CssClass="custom-gridview" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                   <asp:TemplateField>
            <ItemTemplate>
                <asp:Image ID="ProductImage" runat="server" CssClass="custom-image" ImageUrl='<%# Eval("ProductImage") %>' AlternateText="Product Image" />
            </ItemTemplate>
        </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:TextBox ID="QuantityTextBox" runat="server" Text="1" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:DropDownList ID="SizeDropDown" runat="server">
                                <asp:ListItem Value="Small">Small</asp:ListItem>
                                <asp:ListItem Value="Medium">Medium</asp:ListItem>
                                <asp:ListItem Value="Large">Large</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="AddToCartButton" runat="server" CssClass="custom-add-button" Text="Add to Cart" OnClick="AddToCartButton_Click" CommandArgument='<%# Eval("ProductId") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
</asp:Content>   
   