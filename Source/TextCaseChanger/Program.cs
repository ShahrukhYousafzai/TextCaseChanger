using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TextCaseChanger
{
    class Program
    {
        public delegate string FormatString(string rawString);

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Text Case Changer by Shahrukh Yousafzai");

            Console.ForegroundColor = ConsoleColor.White;

            string FilePath = "";
            string[] lines = {""};
           
          
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;

                try
                {
                    Console.Write("Enter text file path: ");

                    FilePath = Console.ReadLine();

                    lines = File.ReadAllLines(FilePath);

                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write("Error, No readable file found");

                    return;
                }

                Console.ForegroundColor = ConsoleColor.Red;

                Console.Write("Select an option: \n");
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("0) Change to sentence case\n");
                Console.Write("1) change to lower case\n");
                Console.Write("2) CHANGE TO UPPER CASE\n");
                Console.Write("3) Change To Capitalized Case\n");
                Console.Write("4) Change to Title Case\n");

                int Option;
                Console.Write("Your Option: ");
                Option = int.Parse(Console.ReadLine());

                if (Option == 0)
                {
                    for (int i = 0; i < lines.Length; i++)
                    {
                        lines[i] = ConvertToSentenceCase(lines[i]);
                    }

                    string SavePath = AppDomain.CurrentDomain.BaseDirectory  + Path.GetFileNameWithoutExtension(FilePath) + "_sentencecased" + Path.GetExtension(FilePath);

                    File.WriteAllLines(SavePath, lines);
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("Case converted file have been saved to " + SavePath);
                }
                else if (Option == 1)
                {
                    for (int i = 0; i < lines.Length; i++)
                    {
                        lines[i] = ConvertToLowerCase(lines[i]);
                    }
                    string SavePath = AppDomain.CurrentDomain.BaseDirectory +  Path.GetFileNameWithoutExtension(FilePath) + "_lowercased" + Path.GetExtension(FilePath);

                    File.WriteAllLines(SavePath, lines);
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("Case converted file have been saved to " + SavePath);

                }
                else if (Option == 2)
                {
                    for (int i = 0; i < lines.Length; i++)
                    {
                        lines[i] = ConvertToUpperCase(lines[i]);
                    }
                    string SavePath = AppDomain.CurrentDomain.BaseDirectory +  Path.GetFileNameWithoutExtension(FilePath) + "_uppercased" + Path.GetExtension(FilePath);

                    File.WriteAllLines(SavePath, lines);
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("Case converted file have been saved to " + SavePath);

                }
                else if (Option == 3)
                {
                    for (int i = 0; i < lines.Length; i++)
                    {
                        lines[i] = ConvertToCapitalizedCase(lines[i]);
                    }
                    string SavePath = AppDomain.CurrentDomain.BaseDirectory +  Path.GetFileNameWithoutExtension(FilePath) + "_capitalizedcased" + Path.GetExtension(FilePath);

                    File.WriteAllLines(SavePath, lines);
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("Case converted file have been saved to " + SavePath);


                }
                else if (Option == 4)
                {
                    for (int i = 0; i < lines.Length; i++)
                    {
                        lines[i] = ConvertToTitleCase(lines[i]);
                    }
                    string SavePath = AppDomain.CurrentDomain.BaseDirectory + Path.GetFileNameWithoutExtension(FilePath) + "_titlecased" + Path.GetExtension(FilePath);

                    File.WriteAllLines(SavePath, lines);
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("Case converted file have been saved to " + SavePath);

                }

            }



        }


        static string ConvertToSentenceCase(string strParagraph)
        {
            FormatString format = RemoveSpace;
            string formatted = RemoveSpace(strParagraph);
            FormatString split = Split;
            var finalString = Split(formatted);

            return finalString;
        }

        static string ConvertToUpperCase(string Text)
        {
            
            var ConvertedString = Text.ToUpper();

            return ConvertedString;
        }

        static string ConvertToTitleCase(string Text)
        {
            var ConvertedString = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Text);

            return ConvertedString;
        }

        static string ConvertToLowerCase(string Text)
        {
            var ConvertedString = Text.ToLower();

            return ConvertedString;
        }

        static string ConvertToCapitalizedCase(string Text)
        {
            var ConvertedString = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(Text.ToLower());

            return ConvertedString;
        }

        public static string RemoveSpace(string fullString)
        {
            return fullString.Trim();

        }

        public static string Split(string fullString)
        {
            var strArr = fullString.Split(new char[] { '.' });
            var newStrArr = strArr;
            foreach (var item in strArr)
                for (int iCount = 0; iCount < strArr.Count(); iCount++)
                {
                    strArr[iCount] = strArr[iCount].Insert(0, strArr[iCount][0].ToString().ToUpper());
                    strArr[iCount] = strArr[iCount].Remove(1, 1);
                }
            return string.Join(".", strArr);
        }
    }
}
