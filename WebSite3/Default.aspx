<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductId" OnRowCommand="GridView1_RowCommand">

    <Columns>
        <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
        <asp:BoundField DataField="Price" HeaderText="Price" />
        <asp:TemplateField HeaderText="Quantity">
            <ItemTemplate>
                <asp:DropDownList ID="QuantityDropDown" runat="server">
                    <asp:ListItem Text="1" Value="1" />
                    <asp:ListItem Text="2" Value="2" />
                    <asp:ListItem Text="3" Value="3" />
                    <asp:ListItem Text="4" Value="4" />
                </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Product Image">
            <ItemTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("ProductImage") %>' style="width: 100px; height: 100px;" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
    <ItemTemplate>
        <asp:CheckBox ID="CheckBox1" runat="server" />
    </ItemTemplate>
</asp:TemplateField>


    </Columns>
</asp:GridView>

        <asp:Button ID="AddToCartButton" runat="server" Text="Add to Cart" OnClick="AddToDatabaseButton_Click" />
  
    </form>
</body>
</html>