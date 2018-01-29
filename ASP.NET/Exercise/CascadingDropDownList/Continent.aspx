<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Continent.aspx.cs" Inherits="CascadingDropDownList.Continent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <br/>
    <br/>

    <div class="text-primary">
        <h2>Cascading DropDownList Example</h2>
    </div>
    <br/>
    <div class="">
        <P class="text-info">Continent Name:</P>
        <asp:DropDownList ID="ddlContinent" Width="200px" AutoPostBack="True" runat="server" OnSelectedIndexChanged="ddlContinent_SelectedIndexChanged"></asp:DropDownList>
        <br/><br/>
          <P class="text-info">Country Name:</P>
        <asp:DropDownList ID="ddlCountry" AutoPostBack="True" Width="200px" runat="server" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList>
        <br/><br/>
          <P class="text-info">City Name:</P>
        <asp:DropDownList ID="ddlCity" Width="200px" runat="server"></asp:DropDownList>
    </div>
    </asp:Content>
