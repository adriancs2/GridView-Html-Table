<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LoadGridView.aspx.cs" Inherits="GridView_HtmlTable.LoadGridView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="false" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="Id" />
            <asp:HyperLinkField HeaderText="Name" DataTextField="Name"
                DataNavigateUrlFields="Id" DataNavigateUrlFormatString="ViewMember.aspx?id={0}" />
            <asp:BoundField HeaderText="Gender" DataField="GenderStr" />
            <asp:BoundField HeaderText="Date Register" DataField="DateRegisterStr" />
        </Columns>
    </asp:GridView>

</asp:Content>
