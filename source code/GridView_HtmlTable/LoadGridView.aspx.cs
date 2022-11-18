using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GridView_HtmlTable
{
    public partial class LoadGridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gv1.DataSource = helper.lst;
            gv1.DataBind();
        }
    }
}