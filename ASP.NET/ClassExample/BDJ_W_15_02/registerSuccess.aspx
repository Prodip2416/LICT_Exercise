<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="registerSuccess.aspx.cs" Inherits="BDJ_W_15_02.registerSuccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        You have register successfully. You cant login now, please check your email and follo the instruction to activate your account.</p>
    
    <p>
       <%= MailMessage() %></p>
</asp:Content>
