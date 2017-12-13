using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem02Workers
{
    public class Worker : Human
    {
        private decimal weekSalary;
        private int workDaysPerWeek;

        public Worker(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }

        public Worker(string firstName, string lastName, decimal weekSalary, int workHoursPerDay = 10, int workDaysPerWeek = 7)
            : base(firstName, lastName)
        {
            this.WorkHoursPerDay = workHoursPerDay;
            this.WorkDaysPerWeek = workDaysPerWeek;
            this.WeekSalary = weekSalary;
        }

        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The salary must be positive number");
                }
                this.weekSalary = value;
            }
        }

        public int WorkDaysPerWeek
        {
            get { return this.workDaysPerWeek; }
            private set
            {
                if (value < 0 || value > 7)
                {
                    throw new ArgumentOutOfRangeException("The workdays per week must be in the range [0,7]");
                }
                this.workDaysPerWeek = value;
            }
        }

        public int WorkHoursPerDay { get; private set; }

        public decimal CalculateMoneyPerHour()
        {
            decimal moneyPerHour = this.WeekSalary / this.WorkDaysPerWeek / this.WorkHoursPerDay;
            return Math.Round(moneyPerHour, 2);
        }
    }
}
