using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verschluesserlung
{
    class Program
    {
        public static string ZuVerschluesselnderText = "";
        private static string grossbuchstabenString;
        private static char[] charArray;
        private const int charShift = 13;
        private static int shiftedPosition = 0;
        private static int unicodeOfChar;
        private static int newPosition = 0;

        public static string EncryptedString { get; set; }


        static void Main(string[] args)
        {
            //int position = 75;

            #region Benutzereingabe abfragen
            //Abfrage des zu verschlüsselnden Textes
            ZuVerschluesselnderText = BenutzerNachEingabeFragen();
            #endregion

            #region Verschlüsseln und Ausgabe verschlüsselter String
            EncryptedString = VerschluesselnMitRot13(ZuVerschluesselnderText);

            Console.WriteLine("neuer String: {0}", EncryptedString);
            #endregion

            #region Abschluss
            Console.WriteLine("");
            Console.WriteLine("Zum Beenden bitte ENTER drücken");
            Console.ReadLine();
            #endregion

        }

        public static string BenutzerNachEingabeFragen()
        {
            Console.WriteLine("Bitte gib zu den verschlüsselnden Text ein");
            return Console.ReadLine();
        }

        private static string NormalisiereString(string unverschluesselterString)
        {
            string normalisierterString = unverschluesselterString;
            normalisierterString = normalisierterString.Replace("Ä", "AE");
            normalisierterString = normalisierterString.Replace("Ö", "OE");
            normalisierterString = normalisierterString.Replace("Ü", "UE");
            normalisierterString = normalisierterString.Replace("ß", "SS");

            return normalisierterString;
        }



        public static string VerschluesselnMitRot13(string originalstring)
        {
            grossbuchstabenString = originalstring.ToUpper();
            charArray = grossbuchstabenString.ToCharArray();
            foreach (char ch in charArray)
            {
                unicodeOfChar = Convert.ToUInt16(ch);
                if (char.IsLetter(ch))
                {
                    shiftedPosition = (unicodeOfChar + charShift);
                    int ueberhang = shiftedPosition - 90;
                    if (ueberhang > 0)
                    {
                        newPosition = (ueberhang - 1) + 65;
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

