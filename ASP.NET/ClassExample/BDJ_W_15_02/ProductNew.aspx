<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductNew.aspx.cs" Inherits="BDJ_W_15_02.ProductNew" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" DefaultMode="Insert" Height="50px" Width="125px">
        <Fields>
            <asp:TemplateField HeaderText="Id" InsertVisible="False" SortExpression="Id">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name" SortExpression="Name">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description" SortExpression="Description">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tag" SortExpression="Tag">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Tag") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Tag") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Tag") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Code" SortExpression="Code">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Code") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Code") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Code") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Type" SortExpression="Type">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Type") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("Type") %>'>
                        <asp:ListItem>Finished Goods</asp:ListItem>
                        <asp:ListItem>RAW Materil</asp:ListItem>
                    </asp:DropDownList>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("Type") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="categoryId" SortExpression="categoryId">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("categoryId") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DropDownList ID="ddlCategory" runat="server" SelectedValue='<%# Bind("categoryId") %>' DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="Id">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MyCon %>" SelectCommand="SELECT * FROM [Category]"></asp:SqlDataSource>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlCategory" ErrorMessage="Required" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("categoryId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="brandId" SortExpression="brandId">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("brandId") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DropDownList ID="ddlBrand" runat="server" SelectedValue='<%# Bind("brandId") %>' DataSourceID="SqlDataSource3" DataTextField="Name" DataValueField="Id">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:MyCon %>" SelectCommand="SELECT * FROM [Brand]"></asp:SqlDataSource>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("brandId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Offers" SortExpression="Offers">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Offers") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Offers") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("Offers") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Discount" SortExpression="Discount">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("Discount") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("Discount") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label10" runat="server" Text='<%# Bind("Discount") %>'></asp:Label>
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
    </asp:DetailsView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:MyCon %>" DeleteCommand="DELETE FROM [Product] WHERE [Id] = @original_Id AND (([Name] = @original_Name) OR ([Name] IS NULL AND @original_Name IS NULL)) AND (([Description] = @original_Description) OR ([Description] IS NULL AND @original_Description IS NULL)) AND (([Tag] = @original_Tag) OR ([Tag] IS NULL AND @original_Tag IS NULL)) AND (([Code] = @original_Code) OR ([Code] IS NULL AND @original_Code IS NULL)) AND (([Type] = @original_Type) OR ([Type] IS NULL AND @original_Type IS NULL)) AND [categoryId] = @original_categoryId AND [brandId] = @original_brandId AND (([Offers] = @original_Offers) OR ([Offers] IS NULL AND @original_Offers IS NULL)) AND (([Discount] = @original_Discount) OR ([Discount] IS NULL AND @original_Discount IS NULL))" InsertCommand="INSERT INTO [Product] ([Name], [Description], [Tag], [Code], [Type], [categoryId], [brandId], [Offers], [Discount]) VALUES (@Name, @Description, @Tag, @Code, @Type, @categoryId, @brandId, @Offers, @Discount)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Product]" UpdateCommand="UPDATE [Product] SET [Name] = @Name, [Description] = @Description, [Tag] = @Tag, [Code] = @Code, [Type] = @Type, [categoryId] = @categoryId, [brandId] = @brandId, [Offers] = @Offers, [Discount] = @Discount WHERE [Id] = @original_Id AND (([Name] = @original_Name) OR ([Name] IS NULL AND @original_Name IS NULL)) AND (([Description] = @original_Description) OR ([Description] IS NULL AND @original_Description IS NULL)) AND (([Tag] = @original_Tag) OR ([Tag] IS NULL AND @original_Tag IS NULL)) AND (([Code] = @original_Code) OR ([Code] IS NULL AND @original_Code IS NULL)) AND (([Type] = @original_Type) OR ([Type] IS NULL AND @original_Type IS NULL)) AND [categoryId] = @original_categoryId AND [brandId] = @original_brandId AND (([Offers] = @original_Offers) OR ([Offers] IS NULL AND @original_Offers IS NULL)) AND (([Discount] = @original_Discount) OR ([Discount] IS NULL AND @original_Discount IS NULL))">
        <DeleteParameters>
            <asp:Parameter Name="original_Id" Type="Int32" />
            <asp:Parameter Name="original_Name" Type="String" />
            <asp:Parameter Name="original_Description" Type="String" />
            <asp:Parameter Name="original_Tag" Type="String" />
            <asp:Parameter Name="original_Code" Type="String" />
            <asp:Parameter Name="original_Type" Type="String" />
            <asp:Parameter Name="original_categoryId" Type="Int32" />
            <asp:Parameter Name="original_brandId" Type="Int32" />
            <asp:Parameter Name="original_Offers" Type="String" />
            <asp:Parameter Name="original_Discount" Type="Double" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="Tag" Type="String" />
            <asp:Parameter Name="Code" Type="String" />
            <asp:Parameter Name="Type" Type="String" />
            <asp:Parameter Name="categoryId" Type="Int32" />
            <asp:Parameter Name="brandId" Type="Int32" />
            <asp:Parameter Name="Offers" Type="String" />
            <asp:Parameter Name="Discount" Type="Double" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="Tag" Type="String" />
            <asp:Parameter Name="Code" Type="String" />
            <asp:Parameter Name="Type" Type="String" />
            <asp:Parameter Name="categoryId" Type="Int32" />
            <asp:Parameter Name="brandId" Type="Int32" />
            <asp:Parameter Name="Offers" Type="String" />
            <asp:Parameter Name="Discount" Type="Double" />
            <asp:Parameter Name="original_Id" Type="Int32" />
            <asp:Parameter Name="original_Name" Type="String" />
            <asp:Parameter Name="original_Description" Type="String" />
            <asp:Parameter Name="original_Tag" Type="String" />
            <asp:Parameter Name="original_Code" Type="String" />
            <asp:Parameter Name="original_Type" Type="String" />
            <asp:Parameter Name="original_categoryId" Type="Int32" />
            <asp:Parameter Name="original_brandId" Type="Int32" />
            <asp:Parameter Name="original_Offers" Type="String" />
            <asp:Parameter Name="original_Discount" Type="Double" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
