using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01School
{
    public class Teacher : Person, IComment
    {
        public List<Discipline> DisciplineEnseigne { get; private set; }
        //private string comment;

        public Teacher(string firstName, string lastName) : base(firstName, lastName)
        {
            this.DisciplineEnseigne = new List<Discipline>();
        }
        public Teacher(string firstName, string lastName, string comment)
            : this(firstName, lastName)
        {
            this.Comment = comment;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (this.DisciplineEnseigne != null && this.DisciplineEnseigne.Count > 0)
            {
                sb.Append(this.FirstName + " " + this.LastName);
                //sb.Append("Disciplines : ");
                foreach (var item in this.DisciplineEnseigne)
                {
                    sb.Append(item.ToString());
                }
            }
            else
            {
                sb.Append("Teacher: " + this.FirstName + " " + this.LastName);
            }

            return sb.ToString();
        }
    }
}
