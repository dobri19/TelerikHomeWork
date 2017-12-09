using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01
{
    class GSM
    {
        private static GSM iPhone4S = new GSM("IPhone4S", "Apple", 111.45m, "Traicho",
                    new Battery("Green", 50, 550, BatteryType.NiMH), new Display(4.5, 1000000));
        private string model;
        private string manufacturer;
        private decimal? price;
        private string owner;
        private Battery battery;
        private Display display;
        private List<Calls> callHistory;

        //public GSM()
        //{
        //}

        public GSM(string model, string manufacturer)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.CallHistory = new List<Calls>();
        }

        public GSM(string model, string manufacturer, decimal? price, string owner, Battery battery, Display display)
            : this(model, manufacturer)
        {
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery ?? new Battery();
            this.Display = display ?? new Display();
        }

        public static GSM IPhone4S
        {
            get
            {
                return GSM.iPhone4S;
            }
            private set
            {
                GSM.iPhone4S = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Enter model!");
                }
                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Enter manifacturer!");
                }
                this.manufacturer = value;
            }
        }

        public decimal? Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value.HasValue && (value < 0))
                    throw new ArgumentOutOfRangeException("Price value cannot be less than zero!");
                this.price = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Enter owner!");
                }
                if (value.Length < 3)
                {
                    throw new ArgumentException("The name should be longer than 2 characters!");
                }
                this.owner = value;
            }
        }

        public Battery Battery
        {
            get
            {
                return this.battery;
            }
            set
            {
                this.battery = value;
            }
        }

        public Display Display
        {
            get
            {
                return this.display;
            }
            set
            {
                this.display = value;
            }
        }

        public List<Calls> CallHistory
        {
            get
            {
                return this.callHistory;
            }

            private set
            {
                this.callHistory = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("-------> GSM <-------");
            sb.Append("\r\n").Append("GSM Model: ").Append(this.model);
            sb.Append("\r\n").Append("GSM Manifacturer: ").Append(this.manufacturer);
            if (this.price.HasValue) sb.Append("\r\n").Append("GSM Price: ").Append(this.price).Append(" $");
            if (!string.IsNullOrEmpty(this.owner)) sb.Append("\r\n").Append("GSM Owner: ").Append(this.owner);
            if (this.battery != null) sb.Append("\r\n").Append(this.battery.ToString());
            if (this.display != null && this.display.Size.HasValue && this.display.NumColors.HasValue) sb.Append("\r\n").Append(this.display.ToString());
            return sb.ToString();
        }

        public void AddCall(Calls call)
        {
            this.CallHistory.Add(call);
        }

        public void RemoveCall(Calls call)
        {
            this.CallHistory.Remove(call);
        }

        public void ClearAllCalls()
        {
            this.CallHistory.Clear();
        }

        public long GetTotalMinutes()
        {
            return (long)callHistory.Sum(call => Math.Ceiling(call.Duration.TotalMinutes));
        }

        public decimal CalculateCallsPrice()
        {         
            return GetTotalMinutes() * Calls.PriceCall;
        }

        public void PrintCallHistory()
        {
            foreach (var item in this.CallHistory)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Total price of the calls is " + this.CalculateCallsPrice() + "$");
        }

        public Calls GetLongestCall()
        {
            return this.CallHistory.Max();
        }

        public void RemoveLongestCall()
        {
            //TimeSpan? longestCall = this.CallHistory.Count > 0 ? this.GetLongestCall().Duration : TimeSpan.Zero;
            //TimeSpan? longestCall = this.GetLongestCall();
            this.CallHistory.Remove(this.GetLongestCall());
        }
    }
}
