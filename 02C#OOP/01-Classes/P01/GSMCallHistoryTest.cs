using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01
{
    class GSMCallHistoryTest
    {
        public static void TestCallHistory()
        {
            GSM mobile01 = new GSM("Galaxy", "Nokia", 33.5m, "Spiro", new Battery("ABV", 4, 567, BatteryType.LiIon), new Display(6.3, 1024));

            Calls callOne = new Calls(DateTime.Now, new DateTime(1252,12,25), "4564564646", new TimeSpan(1, 23, 35));
            Calls callTwo = new Calls(DateTime.Now, new DateTime(2222, 02, 25), "37357373", new TimeSpan(0, 19, 25));
            Calls callThree = new Calls(DateTime.Now, new DateTime(1622, 12, 25), "37537357357", new TimeSpan(2, 29, 18));

            mobile01.CallHistory.Add(callOne);
            mobile01.CallHistory.Add(callTwo);
            mobile01.CallHistory.Add(callThree);

            mobile01.PrintCallHistory();

            mobile01.RemoveLongestCall();
            mobile01.PrintCallHistory();
            //Console.WriteLine(mobile01.CalculateCallsPrice());
        }
    }
}
