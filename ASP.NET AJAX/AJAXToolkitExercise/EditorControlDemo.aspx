<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditorControlDemo.aspx.cs" Inherits="AJAXToolkitExercise.EditorControlDemo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br/>
    <br/>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
     <ajaxToolkit:HtmlEditorExtender ID="TextBox1_HtmlEditorExtender" runat="server" BehaviorID="TextBox1_HtmlEditorExtender" TargetControlID="TextBox1">
    </ajaxToolkit:HtmlEditorExtender>
     <asp:Button ID="Button1" runat="server" Text="Editor" OnClick="Button1_Click"/>
    <br/>
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
</asp:Content>
