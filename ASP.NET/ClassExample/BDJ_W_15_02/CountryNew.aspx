<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CountryNew.aspx.cs" Inherits="BDJ_W_15_02.CountryNew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
<img alt="" src="images/special.gif" style="width: 280px; height: 13px" />
        </ProgressTemplate>
    </asp:UpdateProgress>
&nbsp;<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblMessage" runat="server" Font-Bold="True"></asp:Label>
<br />
<br />
            <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
<br />
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <asp:Label ID="lblEName" runat="server" ForeColor="Red"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="Required JS" ForeColor="Red"></asp:RequiredFieldValidator>
<br />
<br />
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" />
            &nbsp;<asp:Button ID="btnReset" runat="server" CausesValidation="False" OnClick="btnReset_Click" Text="Reset" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
</asp:Content>
