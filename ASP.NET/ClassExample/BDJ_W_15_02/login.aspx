<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="BDJ_W_15_02.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblMessage" runat="server" Font-Bold="True"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Email / Contact"></asp:Label>
    <br />
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Password"></asp:Label>
    <br />
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <br />
    <asp:CheckBox ID="chkRemember" runat="server" Text="Remember Me" />
    <br />
    <br />
    <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" />
    <br />
    <br />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="forgot.aspx">Forgot Password</asp:HyperLink>
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="register.aspx">Register</asp:HyperLink>
</asp:Content>
