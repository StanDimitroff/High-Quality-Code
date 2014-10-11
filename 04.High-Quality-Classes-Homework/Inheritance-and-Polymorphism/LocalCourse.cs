using System;
using System.Collections.Generic;

public class LocalCourse : Course
{
    private string lab;

    public LocalCourse(string name, string teacherName = null, IList<string> students = null, string lab = null)
        : base(name, teacherName, students)
    {
        this.Lab = lab;
    }

    public string Lab
    {
        get
        {
            return this.lab;
        }

        set
        {
            if (value == string.Empty)
            {
                throw new ArgumentException("Lab can not be empty!", "lab");
            }

            this.lab = value;
        }
    }

    public override string ToString()
    {
        string result = base.ToString();
        if (this.Lab != null)
        {
            result += string.Format("; Lab = {0}", this.Lab);
        }

        return result + " }";
    }
}