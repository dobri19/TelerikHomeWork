using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01
{
    class Calls: IComparable<Calls>
    {
        private const decimal CallPricePerMinute = 0.37M;
        private DateTime date;
        private DateTime time;
        private string dialledNumber;
        private TimeSpan duration = TimeSpan.Zero;

        public Calls(DateTime date, DateTime time, string dialledNumber, TimeSpan duration)
        {
            this.Date = date;
            this.Time = time;
            this.DialledNumber = dialledNumber;
            this.Duration = duration;
        }

        public static decimal PriceCall
        {
            get { return CallPricePerMinute; }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Datetime cannot be null!");
                }
                this.date = value;
            }
        }

        public DateTime Time
        {
            get
            {
                return this.time;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Time cannot be null!");
                }
                this.time = value;
            }
        }

        public string DialledNumber
        {
            get
            {
                return this.dialledNumber;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Dialed number cannot be null!");
                }
                this.dialledNumber = value;
            }
        }

        public TimeSpan Duration
        {
            get
            {
                return this.duration;
            }
            set
            {
                if (value == TimeSpan.Zero)
                {
                    throw new ArgumentNullException("Duration time cannot be null!");
                }
                this.duration = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Date: ").Append(this.Date).Append("\r\n");
            sb.Append("Time: ").Append(this.Time).Append("\r\n");
            sb.Append("Dialled Phone Number: ").Append(this.DialledNumber).Append("\r\n");
            sb.Append("Duration: ").Append(this.Duration).Append("\r\n");

            return sb.ToString();
        }

        public int CompareTo(Calls other)
        {
            return (int)(this.Duration - other.Duration).TotalSeconds;
        }
    }
}
