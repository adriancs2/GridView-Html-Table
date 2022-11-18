using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GridView_HtmlTable
{
    public partial class LoadGridViewStyleEdit : System.Web.UI.Page
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
            gv3.DataSource = lst;
            gv3.DataBind();

            for (int i = 0; i < lst.Count; i++)
            {
                GridViewRow gr = gv3.Rows[i];

                var txtName = (TextBox)gr.FindControl("txtName");
                var dropGender = (DropDownList)gr.FindControl("dropGender");
                var txtDateRegister = (TextBox)gr.FindControl("txtDateRegister");

                var m = lst[i];

                txtName.Text = m.Name;
                dropGender.SelectedValue = m.Gender.ToString();
                txtDateRegister.Text = m.DateRegisterData;
            }
        }

        List<Member> Save()
        {
            // declare a list to store data
            List<Member> lst = new List<Member>();

            for (int i = 0; i < gv3.Rows.Count; i++)
            {
                GridViewRow gr = gv3.Rows[i];

                var cbRemove = (CheckBox)gr.FindControl("cbRemove");

                if (cbRemove.Checked)
                {
                    // remove
                    continue;
                }

                int id = Convert.ToInt32(gr.Cells[0].Text);

                var txtName = (TextBox)gr.FindControl("txtName");
                var dropGender = (DropDownList)gr.FindControl("dropGender");
                var txtDateRegister = (TextBox)gr.FindControl("txtDateRegister");

                var date = helper.ConvertToDate(txtDateRegister.Text);
                int gender = Convert.ToInt32(dropGender.SelectedValue);

                lst.Add(new Member(id, txtName.Text, date, gender));
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