using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01
{
    class Display
    {
        private double? size;
        private int? numColors;

        public Display()
        {
        }

        public Display(double? size)
        {
            this.Size = size;
        }

        public Display(double? size, int? numColors)
            : this(size)
        {
            this.NumColors = numColors;
        }

        public double? Size
        {
            get
            {
                return this.size;
            }
            private set
            {
                if (value <= 1)
                {
                    throw new ArgumentNullException("The size of the display should be bigger than 1!");
                }
                if (value == null)
                {
                    throw new ArgumentNullException("Enter model!");
                }
                this.size = value;
            }
        }

        public int? NumColors
        {
            get
            {
                return this.numColors;
            }
            private set
            {
                if (value <= 10)
                {
                    throw new ArgumentNullException("The number of colors should be bigger than 10!");
                }
                if (value == null)
                {
                    throw new ArgumentNullException("Enter model!");
                }
                this.numColors = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append("---> DISPLAY <---");
            if (this.size.HasValue) sb.Append("---> DISPLAY <---").Append("\r\n").Append("Display Size: ").Append(this.size).Append("\"");
            //sb.Append("Display Size: ").Append(this.size);
            if (this.numColors.HasValue) sb.Append("\r\n").Append("Display Colors: ").Append(this.numColors);
            //sb.Append("Display Colors: ").Append(this.numColors);
            return sb.ToString();
        }
    }
}
