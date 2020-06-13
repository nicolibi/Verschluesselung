using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verschluesselung
{
    /// <summary>
    /// Übung zu Udemy Kurs "C# Grundlagen üben mit System - Buchstaben verschieben"
    /// Autor des Kurs: Jan Suchotzki
    /// 
    /// code erstellt von Nicole Bieger
    /// </summary>
    class Program
    {
        public static string PlainUserText { get; set; }
        private static string upperCaseString;
        private static string normalizedString;
        private static char[] charArray;
        public static string EncryptedString { get; private set; }
        private const int charShift = 13;
        private static int unicodeOfChar;
        private static int positionCharAfterShift = 0;
        private static int finalUnicodeForChar = 0;

        static void Main(string[] args)
        {
            //int position = 75;

            #region Benutzereingabe abfragen
            //Abfrage des zu verschlüsselnden Textes
            PlainUserText = BenutzerNachEingabeFragen();
            #endregion

            #region Anpassen des Strings
            upperCaseString = PlainUserText.ToUpper();
            normalizedString = NormalisiereString(upperCaseString);
            #endregion

            #region Verschlüsseln und Ausgabe verschlüsselter String
            EncryptedString = VerschluesseleMitROT13(normalizedString);

            Console.WriteLine($"neuer String: {EncryptedString}");
            #endregion

            #region Abschluss
            Console.WriteLine("");
            Console.WriteLine("Zum Beenden bitte ENTER drücken");
            Console.ReadLine();
            #endregion
        }

        public static string BenutzerNachEingabeFragen()
        {
            Console.WriteLine("Bitte gib den zu verschlüsselnden Text ein");
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


        public static string VerschluesseleMitROT13(string originalstring)
        {
            upperCaseString = originalstring.ToUpper();
            charArray = upperCaseString.ToCharArray();
            foreach (char ch in charArray)
            {
                unicodeOfChar = Convert.ToUInt16(ch);
                if (char.IsLetter(ch))
                {
                    positionCharAfterShift = (unicodeOfChar + charShift);
                    int ueberhang = positionCharAfterShift - 90;
                    if (ueberhang > 0)
                    {
                        finalUnicodeForChar = (ueberhang - 1) + 65;
                    }
                    else
                    {
                        finalUnicodeForChar = positionCharAfterShift;
                    }
                    EncryptedString += Convert.ToChar(finalUnicodeForChar);
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

