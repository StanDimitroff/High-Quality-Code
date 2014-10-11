using System;
using System.Collections.Generic;
using System.Text;

public abstract class Course
{
    private string name;
    private string teacherName;
    private IList<string> students;

    public Course(string name, string teacherName = null, IList<string> students = null)
    {
        this.Name = name;
        this.TeacherName = teacherName;
        this.Students = students;
    }

    public string Name
    {
        get
        {
            return this.name;
        }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("name", "Name can not be null or empty!");
            }

            this.name = value;
        }
    }

    public string TeacherName
    {
        get
        {
            return this.teacherName;
        }

        set
        {
            if (value == string.Empty)
            {
                throw new ArgumentException(
                    "Teacher Name can not be empty!", "teacherName");
            }

            this.teacherName = value;
        }
    }

    public IList<string> Students
    {
        get { return this.students; }
        set { this.students = value; }
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.Append(this.GetType() + "{ Name = ");
        result.Append(this.Name);
        if (this.TeacherName != null)
        {
            result.Append("; Teacher = ");
            result.Append(this.TeacherName);
        }

        result.Append("; Students = ");
        result.Append(this.GetStudentsAsString());

        return result.ToString();
    }

    protected string GetStudentsAsString()
    {
        if (this.Students == null || this.Students.Count == 0)
        {
            return "{ }";
        }
        else
        {
            return "{ " + string.Join(", ", this.Students) + " }";
        }
    }
}