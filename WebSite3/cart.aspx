 <%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="cart.aspx.cs" Inherits="cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
      <style>
        
        /* Style for the entire GridView */
.gridview {
    width: 100%;
    border-collapse: collapse;
}

/* Style for header row */
.gridview th {
    background-color: #333;
    color: white;
    text-align: center;
    padding: 8px;
}

/* Style for data rows */
.gridview td {
    border: 1px solid #ddd;
    padding: 8px;
    text-align: left;
}

/* Alternate row background color */
.gridview tr:nth-child(even) {
    background-color: #f2f2f2;
}

/* Style for the Delete button */
.gridview .delete-button {
    background-color: red;
    color: white;
    border: none;
    padding: 5px 10px;
    cursor: pointer;
}
.image-size {
    width: 100px; /* Adjust the width as per your requirement */
    height: 100px; /* Automatically adjust the height to maintain aspect ratio */
}
 /*  */
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <div>
    <asp:Label ID="PlaceOrderMessageLabel" runat="server" CssClass="place-order-message" Visible="false"></asp:Label>
 
      <h1>
        <asp:Literal ID="CartEmptyMessage" runat="server"></asp:Literal></h1>
      <h1>  Your Shopping Cart
    </h1>
<asp:GridView ID="CartGridView" runat="server" AutoGenerateColumns="False" 
            CssClass="gridview">
    <Columns>
        <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
        <asp:BoundField DataField="Size" HeaderText="Size" />
        <asp:BoundField DataField="Price" HeaderText="Price" />
        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
        <asp:TemplateField HeaderText="Product Image">
            <ItemTemplate>
                <asp:Image ID="Image1" runat="server" width=100px Height=100px
                    ImageUrl='<%# Eval("ProductImage") %>' />
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("ProductImage") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
          
      
        <asp:TemplateField HeaderText="Total Price">
            <ItemTemplate>
                <%# (Convert.ToDecimal(Eval("Price")) * Convert.ToInt32(Eval("Quantity"))).ToString("C") %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete">
            <ItemTemplate>
                <asp:Button ID="DeleteButton" runat="server" Text="Delete" OnClick="DeleteButton_Click" 
                    CommandArgument='<%# Eval("ProductId") + "," + Eval("Size") + "," + Eval("Quantity") %>' CssClass="delete-button"/>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<hr>
<h2><div runat="server" id="DeliveryMessage" class="delivery-message"></div></h2>

<h2><asp:Label ID="TotalAmountLabel" runat="server" CssClass="total-amount"></asp:Label></h2>
<hr>
 <asp:Button ID="CashOnDeliveryButton" runat="server" Text="Cash on Delivery" OnClick="CashOnDeliveryButton_Click" CssClass="cash-on-delivery-button" Visible="false" />





        </div>
</asp:Content>
