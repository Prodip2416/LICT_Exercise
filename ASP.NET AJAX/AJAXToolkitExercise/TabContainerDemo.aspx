<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TabContainerDemo.aspx.cs" Inherits="AJAXToolkitExercise.TabContainerDemo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        h1 {
            color: #000080;
        }


    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br/>
    <h1>Tab Container Panel Demo</h1>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" style="margin-right: 25px">
        <ajaxToolkit:TabPanel runat="server" HeaderText="Home" ID="TabPanel1">
           <ContentTemplate> <h2>Welcome To Aushomapto World!!!!!!!</h2></ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Service">
            <ContentTemplate>
                <h2> Our Service.........</h2>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="About">
            <ContentTemplate>
                <h2>It is a IT solution company!</h2>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel4" runat="server" HeaderText="Contact">
            <ContentTemplate><h2>prodip2416@gmail.com</h2></ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
</asp:Content>
