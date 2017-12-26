<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductImageNew.aspx.cs" Inherits="BDJ_W_15_02.ProductImageNew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSource1" DefaultMode="Insert" ForeColor="Black" GridLines="Horizontal" Height="50px" Width="525px" OnItemInserted="DetailsView1_ItemInserted" OnItemInserting="DetailsView1_ItemInserting">
        <EditRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <Fields>
            <asp:TemplateField HeaderText="id" InsertVisible="False" SortExpression="id">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="productId" SortExpression="productId">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("productId") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DropDownList ID="ddlProduct" runat="server" SelectedValue='<%# Bind("productId") %>' DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="Id">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MyCon %>" SelectCommand="SELECT [Id], [Name] FROM [Product]"></asp:SqlDataSource>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("productId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="title" SortExpression="title">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("title") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("title") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("title") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="fileName" SortExpression="fileName">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("fileName") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:FileUpload ID="fleImage" runat="server" />
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("fileName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <InsertItemTemplate>
                    <asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                    &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="New" Text="New" />
                </ItemTemplate>
            </asp:TemplateField>
        </Fields>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
    </asp:DetailsView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:MyCon %>" DeleteCommand="DELETE FROM [productImage] WHERE [id] = @original_id AND [productId] = @original_productId AND (([title] = @original_title) OR ([title] IS NULL AND @original_title IS NULL)) AND (([datetime] = @original_datetime) OR ([datetime] IS NULL AND @original_datetime IS NULL)) AND (([fileName] = @original_fileName) OR ([fileName] IS NULL AND @original_fileName IS NULL))" InsertCommand="INSERT INTO [productImage] ([productId], [title], [datetime], [fileName]) VALUES (@productId, @title, @datetime, @fileName)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [productImage]" UpdateCommand="UPDATE [productImage] SET [productId] = @productId, [title] = @title, [datetime] = @datetime, [image] = @image, [fileName] = @fileName WHERE [id] = @original_id AND [productId] = @original_productId AND (([title] = @original_title) OR ([title] IS NULL AND @original_title IS NULL)) AND (([datetime] = @original_datetime) OR ([datetime] IS NULL AND @original_datetime IS NULL)) AND (([image] = @original_image) OR ([image] IS NULL AND @original_image IS NULL)) AND (([fileName] = @original_fileName) OR ([fileName] IS NULL AND @original_fileName IS NULL))">
        <DeleteParameters>
            <asp:Parameter Name="original_id" Type="Int32" />
            <asp:Parameter Name="original_productId" Type="Int32" />
            <asp:Parameter Name="original_title" Type="String" />
            <asp:Parameter Name="original_datetime" Type="DateTime" />
            <asp:Parameter Name="original_fileName" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="productId" Type="Int32" />
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="datetime" Type="DateTime" />
            <asp:Parameter Name="fileName" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="productId" Type="Int32" />
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="datetime" Type="DateTime" />
            <asp:Parameter Name="image" Type="Object" />
            <asp:Parameter Name="fileName" Type="String" />
            <asp:Parameter Name="original_id" Type="Int32" />
            <asp:Parameter Name="original_productId" Type="Int32" />
            <asp:Parameter Name="original_title" Type="String" />
            <asp:Parameter Name="original_datetime" Type="DateTime" />
            <asp:Parameter Name="original_image" Type="Object" />
            <asp:Parameter Name="original_fileName" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
