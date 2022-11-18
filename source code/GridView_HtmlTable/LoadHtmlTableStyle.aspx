<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LoadHtmlTableStyle.aspx.cs" Inherits="GridView_HtmlTable.LoadHtmlTableStyle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .tb1 table {
            border-collapse: collapse;
        }

        .tb1 th {
            border: 1px solid black;
            background: #1C5E55;
            color: white;
            padding: 10px;
            border: none;
        }

        .tb1 td {
            border: 1px solid black;
            color: #333333;
            padding: 10px;
            border: none;
        }

        .tb1 tr:nth-child(even) {
            background: #E3EAEB;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="tb1">
        <asp:PlaceHolder ID="ph1" runat="server"></asp:PlaceHolder>
    </div>

</asp:Content>
