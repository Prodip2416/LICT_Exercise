<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ConfirmButtonExtenderDemo.aspx.cs" Inherits="AJAXToolkitExercise.ConfirmButtonExtenderDemo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    <br/>
    <br/>
    <asp:Button ID="btnDisplay" runat="server" Text="Display Message" OnClick="btnDisplay_Click"/>
    <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Are U Sure, View This Message???" TargetControlID="btnDisplay" />
</asp:Content>
