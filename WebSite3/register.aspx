<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>User Registration</title>
   <style>
    /* Center-align container */
    .registration-container {
        text-align: center;
        margin: 0 auto;
        max-width: 400px; /* Adjust the max-width as needed */
    }

    /* Style for the container box */
    .container-box {
        background-color: #f3f3f3; /* Light gray background color */
        border: 1px solid #ccc;
        padding: 20px;
        box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.2); /* Apply box shadow for shading */
    }

    /* Style for the registration button */
    .registration-button {
        font-family: Arial, sans-serif;
        background-color: #007bff; /* Blue color, adjust as needed */
        color: #fff; /* White text color */
        padding: 10px 20px;
        border: none;
        cursor: pointer;
        font-size: 16px;
    }

    /* Apply hover effect to the button */
    .registration-button:hover {
        background-color: #0056b3; /* Darker blue on hover */
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
</style>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="registration-container">
    <div class="container-box">
        <h2>User Registration</h2>
        <hr />
        <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        <table>
            <tr>
                <td>Name:</td>
                <td><asp:TextBox ID="txtName" runat="server" required="true" CssClass="input-box" /></td>
            </tr>
            <tr>
                <td>Email:</td>
                <td><asp:TextBox ID="txtEmail" runat="server" required="true" TextMode="Email" CssClass="input-box" /></td>
            </tr>
            <tr>
                <td>Contact:</td>
                <td><asp:TextBox ID="txtContact" runat="server" required="true" onkeypress="return isNumeric(event);" MaxLength="10" TextMode="Number" CssClass="input-box" /></td>
            </tr>
            <tr>
                <td>Password:</td>
                <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" required="true" CssClass="input-box" /></td>
            </tr>
            <tr>
                <td>Address:</td>
                <td><asp:TextBox ID="txtAddress" runat="server" required="true" TextMode="MultiLine" CssClass="input-box" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" CssClass="registration-button" />
                </td>
            </tr>
        </table>
    </div>
</div>


</asp:Content>
