<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LoadHtmlTable.aspx.cs" Inherits="GridView_HtmlTable.LoadHtmlTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .tb1 table {
            border-collapse: collapse;
        }

        .tb1 th {
            border: 1px solid black;
        }

        .tb1 td {
            border: 1px solid black;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="tb1">
        <asp:PlaceHolder ID="ph1" runat="server"></asp:PlaceHolder>
    </div>

</asp:Content>
