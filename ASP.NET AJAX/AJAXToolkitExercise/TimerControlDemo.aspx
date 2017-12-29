<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TimerControlDemo.aspx.cs" Inherits="AJAXToolkitExercise.TimerControlDemo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br/>
    <br/>
    <h2>Timer Demo</h2>
    <br/>
    <br/>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Timer ID="Timer1" runat="server" Interval="1000"></asp:Timer>
    <asp:Label ID="Label1" runat="server" Text="Time : "></asp:Label>
</asp:Content>
