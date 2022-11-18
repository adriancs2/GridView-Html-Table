using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GridView_HtmlTable
{
    public partial class LoadHtmlTableStyleEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                LoadTable(helper.lst);
            }
        }

        void LoadTable(List<Member> lst)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"
<table>
<tr>
<th>ID</th>
<th>Name</th>
<th>Gender</th>
<th>Date Register</th>
<th>Remove</th>
</tr>
");

            foreach (var m in lst)
            {
                string name = Server.HtmlEncode(m.Name);

                sb.Append($@"
<tr>
<td>{m.Id}</td>
<td><input name='input_{m.Id}_name' type='text' value='{name}' /></td>
<td>
<select name='input_{m.Id}_gender'>
<option value='1' {m.SelectGender(1)}>Male</option>
<option value='2' {m.SelectGender(2)}>Female</option>
<option value='0' {m.SelectGender(0)}>Other</option>
</select>
<td><input name='input_{m.Id}_date' type='date' value='{m.DateRegisterData}' /></td>
<td><input name='input_{m.Id}_remove' type='checkbox' /></td>
</tr>
");
            }

            sb.Append("</table>");

            ph1.Controls.Add(new LiteralControl(sb.ToString()));
        }

        List<Member> Save()
        {
            // declare a dictionary to store the data
            Dictionary<int, Member> dicMember = new Dictionary<int, Member>();

            foreach (var key in Request.Form.AllKeys)
            {
                if (key.StartsWith("input_"))
                {
                    string[] ka = key.Split('_');

                    int id = Convert.ToInt32(ka[1]);

                    if (dicMember.ContainsKey(id))
                        continue;

                    if (Request[$"input_{id}_remove"] != null)
                    {
                        // remove
                        dicMember[id] = new Member(id, 0);
                    }
                    else
                    {
                        string name = Request[$"input_{id}_name"];
                        int gender = Convert.ToInt32(Request[$"input_{id}_gender"]);
                        string dateinput = Request[$"input_{id}_date"];
                        DateTime date = helper.ConvertToDate(dateinput);

                        dicMember[id] = new Member(id, name, date, gender);
                    }
                }
            }


            List<Member> lst = new List<Member>();

            foreach (var kv in dicMember)
            {
                if (kv.Value.Status == 1)
                    lst.Add(kv.Value);
            }

            return lst;
        }

        protected void btSave_Click(object sender, EventArgs e)
        {
            helper.lst = Save();
            LoadTable(helper.lst);
        }

        protected void btRefresh_Click(object sender, EventArgs e)
        {
            
            LoadTable(helper.lst);
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            var lst = Save();

            int newId = 0;

            foreach (var m in lst)
            {
                if (m.Id > newId)
                    newId = m.Id;
            }

            newId++;

            lst.Add(new Member(newId, "", DateTime.MinValue, 0));
            LoadTable(lst);
        }
    }
}