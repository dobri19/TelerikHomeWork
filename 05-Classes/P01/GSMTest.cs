using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01
{
    class GSMTest
    {
        public static List<GSM> CreatePhoneList()
        {
            List<GSM> phoneList = new List<GSM>();

            GSM mobile01 = new GSM("Galaxy", "Nokia", 33.5m, "Zdravko", new Battery("ABV", 3, 56, BatteryType.NiCd), new Display(6.3, 1024));
            GSM mobile02 = new GSM("Esperia", "NokiaViber", 43.6m, "Ganio", new Battery("Novata", 4, 4, BatteryType.LiIon), new Display(5.3, 2024));
            GSM mobile03 = new GSM("Hosterka", "Alkatel", null, "Spiro", new Battery("Starata", 5, 4, BatteryType.None), new Display(4, 50));
            GSM mobile04 = new GSM("Note", "Samsung");

            phoneList.Add(mobile01);
            phoneList.Add(mobile02);
            phoneList.Add(mobile03);
            phoneList.Add(mobile04);

            return phoneList;
        }

        public static void DisplayInfoAboutPhones()
        {
            List<GSM> phones = CreatePhoneList();

            foreach (var phone in phones)
            {
                Console.WriteLine(phone.ToString());
                Console.WriteLine();
            }
        }

        public static void DisplayInfoAboutIphone4S()
        {
            Console.WriteLine(GSM.IPhone4S);
        }
    }
}
