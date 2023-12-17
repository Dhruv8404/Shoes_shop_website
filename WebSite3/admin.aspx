<%@ Page Language="C#"  MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Admin Login</title>
    <style>
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
        width: 80%;
        padding: 10px;
        margin-bottom: 10px;
        border: 1px solid #ccc;
        border-radius: 5px;
        font-size: 14px;
    }

    /* Style for the login button */
    .registration-button {
        font-family: Arial, sans-serif;
        background-color: #007bff; /* Blue color, adjust as needed */
        color: #fff; /* White text color */
        padding: 10px 20px;
        border: none;
        cursor: pointer;
        font-size: 16px;
    }

    /* Apply hover effect to the login button */
    .registration-button:hover {
        background-color: #0056b3; /* Darker blue on hover */
    }
</style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul>
    <li>
        <br>
        <br></li>
</ul>
        <div class="login-container">
        <div>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
    </div>
    <h2 style="font-family: Arial">Admin Login</h2>
    <hr>
    <div>
        <label for="txtUsername" style="font-family: Arial">Username:</label>
        <asp:TextBox ID="txtUsername" runat="server" CssClass="input-box" />
    </div>
    <div>
        <label for="txtPassword" style="font-family: Arial">Password:</label>
        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="input-box" />
    </div>
    <div>
        <asp:Button ID="btnLogin" Text="Login" OnClick="btnLogin_Click" runat="server" CssClass="registration-button" />
    </div>
    
</div>
<br>
<br>
 </asp:Content>
