<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="shop.aspx.cs" Inherits="shop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
   <title></title>
    <style>
    /* Define styles for the classic-gridview */
.classic-gridview {
    width: 100%;
    border-collapse: collapse;
    margin-top: 20px;
    font-family: Arial, sans-serif;
}

/* Define styles for the classic-column */
.classic-column {
    text-align: center;
    padding: 8px;
    border: 1px solid #ddd;
}

/* Define styles for the classic-image */
.classic-image img {
    max-width: 100px;
    max-height: 100px;
    display: block;
    margin: 0 auto;
}

/* Define styles for the classic-dropdown */
.classic-dropdown {
    width: 100px;
}

/* Define styles for the classic-textbox */
.classic-textbox {
    width: 30px;
    text-align: center;
}

/* Define styles for the classic-button */
.classic-button {
    background-color: #007bff;
    color: #fff;
    padding: 5px 10px;
    border: none;
    cursor: pointer;
}

/* Add hover effect for classic-button */
.classic-button:hover {
    background-color: #0056b3;
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
<asp:GridView ID="ProductGridView" runat="server" AutoGenerateColumns="false" CssClass="classic-gridview">
    <Columns>
        <asp:BoundField DataField="ProductId" HeaderText="Product ID" ItemStyle-CssClass="classic-column" />
        <asp:BoundField DataField="ProductName" HeaderText="Product Name" ItemStyle-CssClass="classic-column" />
        <asp:BoundField DataField="Price" HeaderText="Price" ItemStyle-CssClass="classic-column" />
         <asp:TemplateField>
            <ItemTemplate>
                <asp:Image ID="ProductImage" runat="server" CssClass="custom-image" ImageUrl='<%# Eval("ProductImage") %>' AlternateText="Product Image" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Size">
            <ItemTemplate>
                <asp:DropDownList ID="SizeDropDown" runat="server" CssClass="classic-dropdown">
                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quantity">
            <ItemTemplate>
                <asp:TextBox ID="QuantityTextBox" runat="server" CssClass="classic-textbox" Text="1" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Add to Cart">
            <ItemTemplate>
                <asp:Button ID="AddToCartButton" runat="server" Text="Add To Cart" OnClick="AddToCartButton_Click" CommandArgument='<%# Eval("ProductId") %>' CssClass="classic-button" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>



    </div>
</asp:Content>
