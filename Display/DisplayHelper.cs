using System;
using System.Linq;

namespace Display
{
    public class DisplayHelper
    {
        public static void Title()
        {
            int width = Console.WindowWidth;
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < width; i++)
                Console.Write("_");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\t\tW E L C O M E   T O   T H E   B A N K    S I M U L A T O R   A P P L I C A T I O N");
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < width; i++)
                Console.Write("_");
            Console.ResetColor();
        }
        public static void PrintTextAtXY(int x, int y, string msg)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(msg);
        }
        public static void CreateBoxAtXY(int Width, int Height, int x, int y, char HorizontalChar, char VerticalChar)
        {
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < Width; i++)
                Console.Write(HorizontalChar);
            for (int i = 0; i < Height; i++)
            {
                Console.SetCursorPosition(x, y + i + 1);
                Console.WriteLine(VerticalChar);
            }
            for (int i = 0; i < Height; i++)
            {
                Console.SetCursorPosition(x + Width - 1, y + i + 1);
                Console.WriteLine(VerticalChar);
            }
            Console.SetCursorPosition(x + 1, y + Height);
            for (int i = 0; i < Width - 2; i++)
            {
                Console.Write(HorizontalChar);
            }
        }
        public static void Wisher(string msg)
        {
            System.DateTime Moment = DateTime.Now;
            int hour = Moment.Hour;
            string Wish;
            if (hour >= 0 && hour < 12)
                Wish = "GOOD  MORNING";
            else if (hour >= 12 && hour < 18)
                Wish = "GOOD  AFTERNOON";
            else
                Wish = "GOOD  EVENING";
            PrintTextAtXY(0, 4, Wish + "   " + msg);
            PrintTextAtXY(0, 6, "W E   A R E    H A P P Y   T O   H E L P   Y O U");
        }
        public static void CreateMenu(params string[] Menu)
        {
            Title();
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            int TotalInArray = Menu.Count();
            Console.ForegroundColor = ConsoleColor.Cyan;
            CreateBoxAtXY(width, height - 10, 0, 5, '_', '|');
            Console.ResetColor();
            CreateBoxAtXY((int)(width / 4), (TotalInArray * 2 + TotalInArray), (int)(width * 3 / 8), 8, '*', '*');
            int i = 10;
            int j = 1;
            Console.ResetColor();
            foreach (string menu in Menu)
            {
                PrintTextAtXY((int)(width / 4) + 22, i, $"{j}. {menu}");
                i = i + 2;
                j = j + 1;
            }
            PrintTextAtXY((int)(width / 4) + 18 + 18 + 24, i - 3, "ENTER YOUR CHOICE");
            Console.SetCursorPosition((int)(width / 4) + 18 + 18 + 18 + 24, i - 3);
        }
        public static void CreateInputFields(params string[] inputFields)
        {
            Title();
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            int TotalInArray = inputFields.Count();
            Console.ForegroundColor = ConsoleColor.Cyan;
            CreateBoxAtXY(width - 8, (TotalInArray * 2 + TotalInArray), 4, 8, '_', '|');
            int i = 10;
            int j = 1;
            Console.ResetColor();
            foreach (string menu in inputFields)
            {
                PrintTextAtXY(6, i, $"{j}. {menu}");
                i = i + 2;
                j = j + 1;
            }
        }

    }
}

