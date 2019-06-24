using System;
using System.Collections.Generic;
/// <summary>
/// Arvid Ståhl Strömberg
/// </summary>
namespace Checkpoint_1
{
    class Program
    {
        static List<string> produkter;
        //Only called once
        static void Main(string[] args)
        {
            Start(true);
        }
        static void Start(bool reset)
        {
            //If reset is true create a new list
            if(reset == true)
            {
                produkter = new List<string>();
                PrintColoredText("Skriv in produkter avsluta med att skriva 'exit':", ConsoleColor.Yellow);
                Console.WriteLine("\n-----------------------------\n");
            }
            //Just keep looping and execute code in the Loop method
            while (Loop())
            {
                //Warning of infinite loops
            }

            //If the user has decided ist done adding products sort the list and show display it to the user
            produkter.Sort();
            Console.WriteLine("\n-----------------------------\n");
            PrintColoredText("Du angav följande produkter:", ConsoleColor.Yellow);
            Console.WriteLine("\n-----------------------------\n");
            foreach (string item in produkter)
            {
                Console.WriteLine($"* {item}");
            }
            Console.WriteLine("\n-----------------------------\n");
            //Restart the program instead of exiting
            Console.ReadLine();
            Start(true);
        }
        static bool Loop()
        {
            string input = Console.ReadLine();

            //check to see if the user has entered the string 'exit'
            if(IsExit(input))
            {
                //Do something
                return false;   
            }
            //check that the string input is correct format
            if(IsCorrectFormat(input) == false)
            {
                //Do something
                Start(false);
            }
            //If the string is not 'exit' and is the correct format add it to the list
            produkter.Add(input);
            return true;
        }
        //Check that the parameter string is the correct format
        //display a corresponding error message if its wrong
        static bool IsCorrectFormat(string input)
        {
            string[] stringArray = input.Split("-");
            bool value = true;
            if(input == "")
            {
                PrintColoredText("Error: Du får inte ange ett tomt värde", ConsoleColor.Red);
                value = false;
            }
            if (stringArray.Length != 2)
            {
                PrintColoredText($"Error: '{input}' should be a string in the format AAA - 000", ConsoleColor.Red);
                value = false;
            }
            if (stringArray[0] == "" || IsAnyCharANumber(stringArray[0]) == true)
            {
                PrintColoredText("Error: Felaktivt värde på vänstra delen av produktnummret", ConsoleColor.Red);
                value = false;
            }
            if (stringArray[1] == "" || int.TryParse(stringArray[1], out int result) == false || 
                int.Parse(stringArray[1]) < 200 || int.Parse(stringArray[1]) > 500)
            {
                PrintColoredText("Error: Felaktivt värde på högra delen av produktnummret, " +
                    "värdet bör vara ett heltal mellan 200 till 500", ConsoleColor.Red);
                value = false;
            }
            return value;
        }
        //check to see if any char in the parameter string can be converted to a number
        static bool IsAnyCharANumber(string input)
        {
            foreach (char c in input)
            {
                if (double.TryParse(c.ToString(), out double result) == true)
                    return true;
            }
            return false;
        }
        //check to see if the parameter string is equal to 'exit'
        static bool IsExit(string input)
        {
            input = input.Trim().ToLower();

            if (input == "exit")
                return true;

            return false;
        }
        //display a parameter string with parameter color
        static void PrintColoredText(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
