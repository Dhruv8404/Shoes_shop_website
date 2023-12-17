<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="ordercome.aspx.cs" Inherits="ordercome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>ordercome</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
 <asp:GridView ID="GridViewOrders" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="Email" HeaderText="Email" />
        <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
        <asp:BoundField DataField="Size" HeaderText="Size" />
        <asp:BoundField DataField="OrderDate" HeaderText="Order Date" />
        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
        <asp:BoundField DataField="Price" HeaderText="Price" />
        <asp:TemplateField HeaderText="Product Image">
            <ItemTemplate>
                <asp:Image ID="ProductImage" runat="server" ImageUrl='<%# Eval("ProductImage") %>' Width="100" Height="100" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>


    </div>
 </asp:Content>   
   