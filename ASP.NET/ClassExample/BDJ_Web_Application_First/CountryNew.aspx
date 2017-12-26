<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CountryNew.aspx.cs" Inherits="BDJ_Web_Application_First.CountryNew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
    <br />
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
&nbsp;<asp:Label ID="lblEMessage" runat="server" ForeColor="Red"></asp:Label>
    <br />
    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" />
&nbsp;
    <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="Reset" />
</asp:Content>
