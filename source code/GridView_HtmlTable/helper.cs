using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GridView_HtmlTable
{
public class helper
{
    static List<Member> _lst = null;

    public static List<Member> lst
    {
        get
        {
            if (_lst == null)
            {
                _lst = new List<Member>();
                _lst.Add(new Member(1, "James", new DateTime(2022, 11, 11), 1));
                _lst.Add(new Member(2, "Amy", new DateTime(2022, 11, 10), 2));
                _lst.Add(new Member(3, "Smith", new DateTime(2022, 10, 8), 1));
                _lst.Add(new Member(4, "Cait", new DateTime(2022, 9, 7), 2));
            }

            return _lst;
        }
        set
        {
            _lst = value;
        }
    }

    public static DateTime ConvertToDate(string input)
    {
        DateTime date = DateTime.MinValue;

        try
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                string[] da = input.Split('-');
                int year = Convert.ToInt32(da[0]);
                int month = Convert.ToInt32(da[1]);
                int day = Convert.ToInt32(da[2]);

                date = new DateTime(year, month, day);
            }
        }
        catch { }

        return date;
    }
}
}