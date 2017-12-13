using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01School
{
    public class Discipline : IComment
    {
        private string comment;
        //name, number of lectures and number of exercises.
        private string nameDiscipline;
        private int numLectures;
        private int numExercises;

        public Discipline(string nameDiscipline, int numLectures, int numExercises)
        {
            this.NameDiscipline = nameDiscipline;
            this.NumLectures = numLectures;
            this.NumExercises = numExercises;
        }
        public Discipline(string nameDiscipline, int numLectures, int numExercises, string comment)
            : this(nameDiscipline, numLectures, numExercises)
        {
            this.Comment = comment;
        }

        public string Comment
        {
            get { return this.comment; }
            set { this.comment = value; }
        }
        public string NameDiscipline
        {
            get
            {
                return this.nameDiscipline;
            }
            set
            {
                this.nameDiscipline = value;
            }
        }
        public int NumLectures
        {
            get
            {
                return this.numLectures;
            }
            set
            {
                this.numLectures = value;
            }
        }
        public int NumExercises
        {
            get
            {
                return this.numExercises;
            }
            set
            {
                this.numExercises = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("\nDiscipline \"{0}\":", this.NameDiscipline));
            sb.AppendLine("NumLectures: " + this.NumLectures);
            sb.AppendLine("NumExercises: " + this.NumExercises);
            //if (this.Comment != "" || string.IsNullOrEmpty(this.Comment))
            //{
            //    sb.AppendLine("Comment: " + this.Comment);
            //}

            return sb.ToString();
        }
}
}
