<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CalendarExtenderDemo.aspx.cs" Inherits="AJAXToolkitExercise.CalendarExtenderDemo" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br/>
    <br/>
    <br/>
    <asp:Label ID="Label1" runat="server" Text="Date : "></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <ajaxToolkit:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" BehaviorID="TextBox1_CalendarExtender" Format="dd/MM/yyyy" TargetControlID="TextBox1">
    </ajaxToolkit:CalendarExtender>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
</asp:Content>
