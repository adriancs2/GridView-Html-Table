using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.Json;

namespace GridView_HtmlTable
{
public partial class apiGetMemberList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string json = JsonSerializer.Serialize(helper.lst);
        Response.Write(json);
    }
}
}