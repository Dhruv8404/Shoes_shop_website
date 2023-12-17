<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="update.aspx.cs" Inherits="update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title> Admin Update</title>
    <style>
    /* Center-align container */
    .update-container {
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
        width: 100%;
        padding: 10px;
        margin-bottom: 10px;
        border: 1px solid #ccc;
        border-radius: 5px;
        font-size: 14px;
    }

    /* Style for the registration button and Get User Data button */
    .registration-button {
        font-family: Arial, sans-serif;
        background-color: #007bff; /* Blue color, adjust as needed */
        color: #fff; /* White text color */
        padding: 10px 20px;
        border: none;
        cursor: pointer;
        font-size: 16px;
    }

    /* Apply hover effect to the buttons */
    .registration-button:hover {
        background-color: #0056b3; /* Darker blue on hover */
    }
    td ,h2
    {
        font-family:Arial;
        }
        .style1
        {
            height: 48px;
        }
        .style2
        {
            width: 365px;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="update-container">
    <h2>&nbsp;Update</h2>
    <hr>
    <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
    <table>
        <tr>
            <td>Email:</td>
            <td class="style2"><asp:TextBox ID="txtEmail" runat="server" required="true" type="email" TextMode="Email" CssClass="input-box" Width="100%"></asp:TextBox></td>
            
        </tr>
        <tr>
            <td>Name:</td>
            <td class="style2"><asp:TextBox ID="txtName" runat="server" required="true" CssClass="input-box"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Contact:</td>
            <td class="style2"><asp:TextBox ID="txtContact" runat="server" required="true" onkeypress="return isNumeric(event);" MaxLength="10" CssClass="input-box"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Password:</td>
            <td class="style2"><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" required="true" CssClass="input-box"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Address:</td>
            <td class="style2"><asp:TextBox ID="txtAddress" runat="server" required="true" TextMode="MultiLine" CssClass="input-box"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" class="style1">
              
                <asp:Button ID="btnUpdateUser" runat="server" Text="Update" OnClick="btnUpdateUser_Click" CssClass="registration-button" />
            </td>
           
        </tr>
    </table>
</div>
</asp:Content>