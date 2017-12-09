using System;

namespace P01
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            GSMTest.DisplayInfoAboutPhones();
            GSMTest.DisplayInfoAboutIphone4S();

            GSMCallHistoryTest.TestCallHistory();

            //GSM mobile01 = new GSM("Galaxy", "Nokia", 33.5m, "Spiro", new Battery("ABV", 4, 567, BatteryType.LiIon), new Display(6.3, 1024));
            //GSM mobile02 = new GSM("Note", "Samsung");
            //Console.WriteLine(mobile01.Manufacturer);
            //Console.WriteLine(mobile01.ToString());
            //GSM mobile02 = new GSM("Galaxy", "Nokia", null, "", new Battery("ABV", 4, 567, BatteryType.LiIon), new Display(6.3, 1024));
            //Console.WriteLine(mobile02.ToString());
            //GSM mobile02 = new GSM(null, null);
            //Console.WriteLine(mobile02.ToString());
            //GSM.IPhone4S.ToString();

            //Battery bat1 = new Battery("Nokia", 1.2, 3, BatteryType.LiIon);
            //Console.WriteLine(bat1.ToString());
            //Battery bat2 = new Battery();
            //Console.WriteLine(bat2.ToString());

            //Display dis1 = new Display(2.5, 126);
            //Console.WriteLine(dis1.ToString());
            //Display dis2 = new Display(1.5);
            //Console.WriteLine(dis2.ToString());
        }
    }

}
