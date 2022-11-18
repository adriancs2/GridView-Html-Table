using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GridView_HtmlTable
{
public class Member
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateRegister { get; set; }
    public int Gender { get; set; }
    public int Status { get; set; }

    public Member(int id)
    {
        Id = id;
        Status = 1;
    }

    public Member(int id, string name, DateTime dateRegister, int gender)
    {
        Id = id;
        Name = name;
        DateRegister = dateRegister;
        Gender = gender;
        Status = 1;
    }

    public Member(int id, int status)
    {
        Id = id;
        Status = status;
    }

    public string GenderStr
    {
        get
        {
            switch (Gender)
            {
                case 1:
                    return "Male";
                case 2:
                    return "Female";
                default:
                    return "Other";
            }
        }
    }

    public string DateRegisterStr
    {
        get
        {
            if (DateRegister == DateTime.MinValue)
                return "---";
            return DateRegister.ToString("dd MMM yyyy");
        }
    }

    public string DateRegisterData
    {
        get
        {
            if (DateRegister == DateTime.MinValue)
                return "";
            return DateRegister.ToString("yyyy-MM-dd");
        }
    }

    public string SelectGender(int g)
    {
        if (g == Gender)
            return "selected";
        return "";
    }
}
}