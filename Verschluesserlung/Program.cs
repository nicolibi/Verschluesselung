using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verschluesserlung
{
    class Program
    {
        public static string OriginalString = "";
        private static string grossbuchstabenString;
        private static char[] charArray;
        private const int charShift = -4;
        private static int shiftedPosition = 0;
        private static int unicodeOfChar;
        private static int newPosition = 0;

        public static string EncryptedString { get; set; }


        static void Main(string[] args)
        {
            //int position = 75;
            OriginalString = "Asvph";

            Console.WriteLine("neuer String: {0}", Verschluesseln(OriginalString));
            Console.ReadLine();

        }

        public static string Verschluesseln(string originalstring)
        {
            grossbuchstabenString = originalstring.ToUpper();
            charArray = grossbuchstabenString.ToCharArray();
            foreach (char ch in charArray)
            {
                unicodeOfChar = Convert.ToUInt16(ch);
                if (unicodeOfChar >= 65 && unicodeOfChar <= 90)
                {

                    shiftedPosition = (unicodeOfChar + charShift);
                    if (shiftedPosition > 90)
                    {
                        newPosition = ((shiftedPosition - 65) % 26) + 65;
                    }
                    else
                    {
                        newPosition = shiftedPosition;
                    }

                    EncryptedString += Convert.ToChar(newPosition);

                }
                else
                {
                    EncryptedString += ch;
                }
            }

            return EncryptedString;
        }


    }
}
