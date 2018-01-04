using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem03RangeExceptions
{
    public class InvalidRangeException<T> : ApplicationException
    {
        public InvalidRangeException(T start, T end, T number)
            : base("is outside of boundaries!")
        {
            this.Start = start;
            this.End = end;
            this.Number = number;
        }

        public T Start { get; private set; }
        public T End { get; private set; }
        public T Number { get; private set; }
    }
}
