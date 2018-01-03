<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Income.aspx.cs" Inherits="GridViewExercise.Income" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True">
    <Columns>
        <asp:TemplateField ShowHeader="False">
            <EditItemTemplate>
                <asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
                &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Select" Text="Select" />
                &nbsp;<asp:Button ID="Button3" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="id" InsertVisible="False" SortExpression="id" Visible="False">
            <EditItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("id") %>'></asp:Label>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("id") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="name" SortExpression="name">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("name") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label2" runat="server" Text='<%# Bind("name") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="amount" SortExpression="amount">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("amount") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label3" runat="server" Text='<%# Bind("amount") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="quentity" SortExpression="quentity">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("quentity") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label4" runat="server" Text='<%# Bind("quentity") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:MyCon %>" DeleteCommand="DELETE FROM [Income] WHERE [id] = @original_id AND (([name] = @original_name) OR ([name] IS NULL AND @original_name IS NULL)) AND (([amount] = @original_amount) OR ([amount] IS NULL AND @original_amount IS NULL)) AND (([quentity] = @original_quentity) OR ([quentity] IS NULL AND @original_quentity IS NULL))" InsertCommand="INSERT INTO [Income] ([name], [amount], [quentity]) VALUES (@name, @amount, @quentity)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [id], [name], [amount], [quentity] FROM [Income]" UpdateCommand="UPDATE [Income] SET [name] = @name, [amount] = @amount, [quentity] = @quentity WHERE [id] = @original_id AND (([name] = @original_name) OR ([name] IS NULL AND @original_name IS NULL)) AND (([amount] = @original_amount) OR ([amount] IS NULL AND @original_amount IS NULL)) AND (([quentity] = @original_quentity) OR ([quentity] IS NULL AND @original_quentity IS NULL))">
        <DeleteParameters>
            <asp:Parameter Name="original_id" Type="Int32"/>
            <asp:Parameter Name="original_name" Type="String"/>
            <asp:Parameter Name="original_amount" Type="Double"/>
            <asp:Parameter Name="original_quentity" Type="Double"/>
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="name" Type="String"/>
            <asp:Parameter Name="amount" Type="Double"/>
            <asp:Parameter Name="quentity" Type="Double"/>
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="name" Type="String"/>
            <asp:Parameter Name="amount" Type="Double"/>
            <asp:Parameter Name="quentity" Type="Double"/>
            <asp:Parameter Name="original_id" Type="Int32"/>
            <asp:Parameter Name="original_name" Type="String"/>
            <asp:Parameter Name="original_amount" Type="Double"/>
            <asp:Parameter Name="original_quentity" Type="Double"/>
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/New Income.aspx">New Income</asp:HyperLink>
</asp:Content>
