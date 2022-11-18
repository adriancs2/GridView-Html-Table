using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GridView_HtmlTable
{
    public partial class LoadHtmlTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


StringBuilder sb = new StringBuilder();

sb.Append(@"
<table>
<tr>
<th>ID</th>
<th>Name</th>
<th>Gender</th>
<th>Date Register</th>
</tr>
");

foreach (var m in helper.lst)
{
    sb.Append($@"
<tr>
<td>{m.Id}</td>
<td><a href='ViewMember.aspx?id={m.Id}'>{m.Name}</a></td>
<td>{m.GenderStr}</td>
<td>{m.DateRegisterStr}</td>
</tr>
");
}

sb.Append("</table>");

ph1.Controls.Add(new LiteralControl(sb.ToString()));

        }
    }
}