<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LoadGridViewStyleEdit.aspx.cs" Inherits="GridView_HtmlTable.LoadGridViewStyleEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Button ID="btRefresh" runat="server" Text="Rebuild" OnClick="btRefresh_Click" />
    <asp:Button ID="btSave" runat="server" Text="Save" OnClick="btSave_Click" />
    <asp:Button ID="btAdd" runat="server" Text="Add" OnClick="btAdd_Click" />

    <br /><br />

<asp:GridView ID="gv3" runat="server" AutoGenerateColumns="False" CellPadding="10" ForeColor="#333333" GridLines="None">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField HeaderText="ID" DataField="Id" />
        <asp:TemplateField HeaderText="Name">
            <ItemTemplate>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Gender">
            <ItemTemplate>
                <asp:DropDownList ID="dropGender" runat="server">
                    <asp:ListItem Value="1" Text="Male"></asp:ListItem>
                    <asp:ListItem Value="2" Text="Female"></asp:ListItem>
                    <asp:ListItem Value="0" Text="Other"></asp:ListItem>
                </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date Register">
            <ItemTemplate>
                <asp:TextBox ID="txtDateRegister" runat="server" TextMode="Date"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Remove">
            <ItemTemplate>
                <asp:CheckBox ID="cbRemove" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <EditRowStyle BackColor="#7C6F57" />
    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#E3EAEB" />
    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#F8FAFA" />
    <SortedAscendingHeaderStyle BackColor="#246B61" />
    <SortedDescendingCellStyle BackColor="#D4DFE1" />
    <SortedDescendingHeaderStyle BackColor="#15524A" />
</asp:GridView>

</asp:Content>
