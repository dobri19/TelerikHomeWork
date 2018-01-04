using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem20Infinite
{
    public class Sum02
    {
        public static double CalculateSum(double start, double step, bool changeSign, double stepIncrement, Func<double, double, double> nextMemeber)
        {
            double oldSum = 0;
            double nextMember = NextMember(start, step);
            double currentSum = start + 1 / nextMember;
            if (changeSign)
            {
                nextMember = -nextMember;
            }
            step += stepIncrement;
            double difference = currentSum - oldSum;

            while (Math.Abs(difference) > 0.00000001)
            {
                oldSum = currentSum;
                nextMember = NextMember(nextMember, step);
                currentSum += 1 / nextMember;
                if (changeSign)
                {
                    nextMember = -nextMember;
                }
                step += stepIncrement;
                difference = currentSum - oldSum;
            }

            return currentSum;
        }

        public static double NextMember(double start, double step)
        {
            return start * step;
        }
    }
}
