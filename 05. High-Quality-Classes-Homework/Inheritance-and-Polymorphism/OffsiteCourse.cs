using System;
using System.Collections.Generic;

public class OffsiteCourse : Course
{
    private string town;

    public OffsiteCourse(string name, string teacherName = null, IList<string> students = null, string town = null)
        : base(name, teacherName, students)
    {
        this.Town = town;
    }

    public string Town
    {
        get
        {
            return this.town;
        }

        set
        {
            if (value == string.Empty)
            {
                throw new ArgumentException("Town can not be empty!", "town");
            }

            this.town = value;
        }
    }

    public override string ToString()
    {
        string result = base.ToString();
        if (this.Town != null)
        {
            result += string.Format("; Town = {0} ", this.Town);
        }

        return result + " }";
    }
}