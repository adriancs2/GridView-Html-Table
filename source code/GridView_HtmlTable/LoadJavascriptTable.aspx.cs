using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GridView_HtmlTable
{
    public partial class LoadJavascriptTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btSave_Click(object sender, EventArgs e)
        {
            // obtain the removed id
            string removeIDs = Request.Form["hiddenRemoveId"] + "";

            if (removeIDs.Length > 0)
            {
                StringBuilder sb = new StringBuilder();
                string[] removeIdArray = removeIDs.Split(',');
                foreach (var idstr in removeIdArray)
                {
                    int rid = 0;
                    if (int.TryParse(idstr, out rid))
                    {
                        foreach (var m in helper.lst)
                        {
                            if (m.Id == rid)
                            {
                                if (sb.Length > 0)
                                    sb.Append(", ");
                                sb.Append($"(ID: {m.Id}) {m.Name}");
                            }
                        }
                    }
                }

                phMsg.Controls.Add(new LiteralControl($"<div class='divmsg'>Some member(s) were removed: {sb}</div>"));
            }

            int newid = 0;

            foreach (var m in helper.lst)
            {
                if (m.Id > newid)
                    newid = m.Id;
            }

            Dictionary<int, Member> dicMember = new Dictionary<int, Member>();

            foreach (var key in Request.Form.AllKeys)
            {
                if (key.StartsWith("input_"))
                {
                    string[] ka = key.Split('_');

                    int id = Convert.ToInt32(ka[1]);

                    if (dicMember.ContainsKey(id))
                        continue;

                    string name = Request[$"input_{id}_name"];
                    int gender = Convert.ToInt32(Request[$"input_{id}_gender"]);
                    string dateinput = Request[$"input_{id}_date"];
                    DateTime date = helper.ConvertToDate(dateinput);

                    dicMember[id] = new Member(id, name, date, gender);
                }
            }

            List<Member> lst = new List<Member>();

            foreach (var kv in dicMember)
            {
                if (kv.Value.Id < 0)
                {
                    newid++;
                    kv.Value.Id = newid;
                }

                lst.Add(kv.Value);
            }

            helper.lst = lst;
        }
    }
}