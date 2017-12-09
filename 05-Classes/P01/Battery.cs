using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01
{
    class Battery
    {
        private string model;
        private double? hoursIdle;
        private double? hoursTalk;
        private BatteryType? batteryType;

        public Battery()
        {
        }

        public Battery(string model)
        {
            this.Model = model;
        }

        public Battery(string model, double? hoursIdle, double? hoursTalk, BatteryType batteryType)
            : this(model)
        {
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.BatteryType = batteryType;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                this.model = value;
            }
        }

        public double? HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            private set
            {
                if (value.GetValueOrDefault() < 0)
                {
                    throw new ArgumentOutOfRangeException("The hoursIdle should be bigger than 0!");
                }
                this.hoursIdle = value;
            }
        }

        public double? HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            private set
            {
                if (value.GetValueOrDefault() < 0)
                {
                    throw new ArgumentOutOfRangeException("The hoursIdle should be bigger than 0!");
                }
                this.hoursTalk = value;
            }
        }

        public BatteryType? BatteryType
        {
            get
            {
                return this.batteryType;
            }
            private set
            {
                this.batteryType = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("---> BATTERY <---");
            if (!string.IsNullOrEmpty(this.model))
            {
                sb.Append("\r\n").Append("Battery Model: ").Append(this.model);
            }
            //sb.Append("Battery Model: ").Append(this.model).Append("\r\n");
            if (this.hoursIdle.HasValue) sb.Append("\r\n").Append("Battery Hours Idle: ").Append(this.hoursIdle);
            //sb.Append("Battery Hours Idle: ").Append(this.hoursIdle).Append("\r\n");
            if (this.hoursTalk.HasValue) sb.Append("\r\n").Append("Battery Hours Talk: ").Append(this.hoursTalk);
            //sb.Append("Battery Hours Talk: ").Append(this.hoursTalk).Append("\r\n");
            if (this.batteryType.HasValue) sb.Append("\r\n").Append("Battery Type: ").Append(this.batteryType); ;
            //sb.Append("Battery Type: ").Append(this.batteryType);
            return sb.ToString();
        }
    }
}
