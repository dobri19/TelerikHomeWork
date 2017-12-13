using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01School
{
    public class ClassInSchool : IComment
    {
        private string comment;
        private List<Teacher> teachersInClass;
        private List<Student> studentsInClass;
        private string textId;

        public ClassInSchool(string textId)
        {
            this.TeachersInClass = new List<Teacher>();
            this.StudentsInClass = new List<Student>();
            this.TextId = textId;
        }
        public ClassInSchool(string textId, string comment)
            : this(textId)
        {
            this.Comment = comment;
        }

        public string Comment
        {
            get { return this.comment; }
            set { this.comment = value; }
        }
        public string TextId { get; set; }
        public List<Teacher> TeachersInClass { get => teachersInClass; set => teachersInClass = value; }
        public List<Student> StudentsInClass { get => studentsInClass; set => studentsInClass = value; }

        public ClassInSchool AddTeacher(Teacher teacher)
        {
            this.TeachersInClass.Add(teacher);
            return this;
        }

        public ClassInSchool AddStudent(Student student)
        {
            this.StudentsInClass.Add(student);
            return this;
        }

        public ClassInSchool RemoveTeacher(Teacher teacher)
        {
            this.TeachersInClass.Remove(teacher);
            return this;
        }

        public ClassInSchool RemoveStudent(Student student)
        {
            this.StudentsInClass.Remove(student);
            return this;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(this.TextId)+"\n");

            if (this.TeachersInClass.Count > 0)
            {
                
                foreach (var teacher in this.TeachersInClass)
                {
                    sb.Append("Teacher: ");
                    sb.AppendLine(teacher.ToString());
                }
            }

            if (this.StudentsInClass.Count > 0)
            {
                sb.AppendLine("Students: ");

                foreach (var student in this.StudentsInClass)
                {
                    sb.AppendLine(student.ToString());
                }
            }

            return sb.ToString();
        }
    }
}
