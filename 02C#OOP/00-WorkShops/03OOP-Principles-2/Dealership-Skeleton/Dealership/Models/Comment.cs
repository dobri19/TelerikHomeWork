using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Comment : IComment
    {
        private string content;
        private string author;

        public Comment(string content)
        {
            this.Content = content;
            this.Author = author;
        }

        public string Content
        {
            get { return this.content; }
            set
            {
                if (value.Length < 3 || value.Length > 200)
                {
                    throw new ArgumentException("Content must be between 3 and 200 characters long!");
                }
                Guard.WhenArgument(value, "Not correct lenght!").IsNull().Throw();
                this.content = value;
            }
        }

        public string Author
        {
            get
            {
                return this.author;
            }
            set
            {
                this.author = value;
            }
        }
    }
}
