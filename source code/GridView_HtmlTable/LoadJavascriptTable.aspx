<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LoadJavascriptTable.aspx.cs" Inherits="GridView_HtmlTable.LoadJavascriptTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .div1 table {
            border-collapse: collapse;
        }

        .div1 th {
            border: 1px solid black;
            background: #1C5E55;
            color: white;
            padding: 10px;
            border: none;
        }

        .div1 td {
            border: 1px solid black;
            color: #333333;
            padding: 10px;
            border: none;
        }

        .div1 tr:nth-child(even) {
            background: #E3EAEB;
        }

        .divbuttons {
            margin-bottom: 10px;
        }

            .divbuttons input[type=submit], .divbuttons a {
                border-radius: 15px;
                border: 1px solid #234db1;
                padding: 8px 12px;
                display: inline-block;
                text-decoration: none;
                background: #4266bd;
                color: white;
                font-size: 10pt;
                cursor: pointer;
            }

                .divbuttons input[type=submit]:hover, .divbuttons a:hover {
                    text-decoration: none;
                    background: #234db1;
                }

        .divmsg {
            border: 1px solid #218529;
            color: #218529;
            padding: 10px;
            margin-bottom: 10px;
        }
    </style>

    <script type="text/javascript">

        function loadDoc() {
            const xhttp = new XMLHttpRequest();
            xhttp.onload = function () {

                // this is the downloaded json
                let text = this.responseText;
                let lst = JSON.parse(text);
                loadMember(lst);
            }
            xhttp.open("GET", "apiGetMemberList.aspx", true);
            xhttp.send();
        }

        function loadMember(lst) {
            let tb1 = document.getElementById("tb1");

            for (let i = 0; i < lst.length; i++) {

                // the member object
                let m = lst[i];

                // generate the row id
                let rowid = `tr_${m.Id}`;

                let row = tb1.insertRow(-1);

                row.id = rowid;

                let td1 = row.insertCell(-1);
                let td2 = row.insertCell(-1);
                let td3 = row.insertCell(-1);
                let td4 = row.insertCell(-1);
                let td5 = row.insertCell(-1);

                let selectMale = "";
                let selectFemale = "";
                let selectOther = "";

                if (m.Gender == 1)
                    selectMale = "selected";
                else if (m.Gender == 2)
                    selectFemale = "selected";
                else
                    selectOther = "selected";

                if (m.Id < 0)
                    td1.innerHTML = "[new]";
                else
                    td1.innerHTML = m.Id;

                td2.innerHTML = `<input name='input_${m.Id}_name' type='text' value='${m.Name}' />`;
                td3.innerHTML = `
<select name='input_${m.Id}_gender'>
<option value='1' ${selectMale}>Male</option>
<option value='2' ${selectFemale}>Female</option>
<option value='0' ${selectOther}>Other</option>
</select>`;
                td4.innerHTML = `<input name='input_${m.Id}_date' type='date' value='${m.DateRegisterData}' />`;
                td5.innerHTML = `<a href='#' onclick='removeRow(${m.Id}); return false;'>Remove</a>`;
            }
        }

        function removeRow(rid) {
            if (rid > 0) {
                let hiddenRemoveId = document.getElementById("hiddenRemoveId");
                hiddenRemoveId.value = hiddenRemoveId.value + rid + ",";
            }
            document.getElementById(`tr_${rid}`).remove();
        }

        var newid = 0;

        function addRow() {
            let newid = getNewId();
            let j = `[{"Id":${newid},"Name":"","DateRegister":"","Gender":0,"DateRegisterData":""}]`;
            let lst = JSON.parse(j);
            loadMember(lst);
        }

        function getNewId() {
            newid--;
            return newid;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <input type="hidden" name="hiddenRemoveId" id="hiddenRemoveId" />

    <asp:PlaceHolder ID="phMsg" runat="server"></asp:PlaceHolder>

    <div class="divbuttons">
        <asp:Button ID="btSave" runat="server" Text="Save" OnClick="btSave_Click" />
        <a href="LoadJavascriptTable.aspx">Refresh Data</a>
        <a href="#" onclick="addRow(); return false;">Add Row</a>
    </div>

    <div class="div1">
        <table id="tb1">
            <tr>
                <th>ID</th>
                <th>Name</th>
                <th>Gender</th>
                <th>Date Register</th>
                <th>Remove</th>
            </tr>
        </table>
    </div>

    <script type="text/javascript">
        window.onload = loadDoc();
    </script>

</asp:Content>
