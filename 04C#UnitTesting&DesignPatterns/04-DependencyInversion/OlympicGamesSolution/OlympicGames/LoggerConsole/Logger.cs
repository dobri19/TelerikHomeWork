using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGames.LoggerConsole
{
    public class Logger : ILogger
    {
        //public Iwriter writer;
        //public IReader reader;

        public string Read()
        {
            return Console.ReadLine();
        }

        public void Write(string text)
        {
            Console.WriteLine(text);
        }

        public void WriteFormat(string text, string ex)
        {
            Console.WriteLine("ERROR: {0}", ex);
        }
    }
}
