<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login user</title>
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
        width: 60%;
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

    /* Style for the registration link */
    .registration-link {
        font-size: 16px;
        text-decoration: none;
        color: #007bff; /* Blue color, adjust as needed */
    }

    /* Apply hover effect to the registration link */
    .registration-link:hover {
        text-decoration: underline; /* Underline on hover */
    }
</style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <br>
   <br>
     <div class="login-container">
    <div>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
    </div>
    <h2>Login User</h2>
    <hr>
    <br>
    <div>
        <label for="txtEmail">Email:<br />
        </label>
&nbsp;<asp:TextBox ID="txtEmail" runat="server" CssClass="input-box" />
    </div>
    <div>
        <label for="txtPassword">Password:<br />
        </label>
        &nbsp;<asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="input-box" />
    </div>
    <div>
        <asp:Button ID="btnLogin" Text="Login" OnClick="btnLogin_Click" runat="server" CssClass="registration-button" />
    </div>
    <div>
        <asp:HyperLink ID="lnkRegister" Text=" for Registration" NavigateUrl="Register.aspx" runat="server" CssClass="registration-link" />
    </div>
</div>
<br>
<br>
</asp:Content>   