using System;

namespace S12URL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] parsedUrl = ParseURL(input);
            Console.WriteLine("[protocol] = {0}", parsedUrl[0]);
            Console.WriteLine("[server] = {0}", parsedUrl[1]);
            Console.WriteLine("[resource] = {0}", parsedUrl[2]);
        }
        private static string[] ParseURL(string input)
        {
            string[] result = new string[3];
            int protocolEndIndex = input.IndexOf(':');
            string protocol = input.Substring(0, protocolEndIndex);
            result[0] = protocol;
            int serverStartIndex = protocol.Length + 3;
            int serverLastIndex = input.IndexOf('/', serverStartIndex);
            string server = input.Substring(serverStartIndex, serverLastIndex - serverStartIndex);
            result[1] = server;
            string resourece = input.Substring(serverLastIndex);
            result[2] = resourece;
            return result;
        }
    }
}
