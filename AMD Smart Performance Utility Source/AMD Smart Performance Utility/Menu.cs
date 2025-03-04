﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMD_Smart_Performance_Utility
{
    class Menu
    {
        private int SelectedIndex;
        private string[] Options;
        private string Prompt;

        public Menu(string prompt, string[] options)
        {
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
        }

        private void DisplayOptions()
        {
            switch (Prompt)
            {
                case @"
  █████╗ ███████╗██████╗ ██╗   ██╗
 ██╔══██╗██╔════╝██╔══██╗██║   ██║
 ███████║███████╗██████╔╝██║   ██║
 ██╔══██║╚════██║██╔═══╝ ██║   ██║
 ██║  ██║███████║██║     ╚██████╔╝
 ╚═╝  ╚═╝╚══════╝╚═╝      ╚═════╝":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
            }
            Console.WriteLine(Prompt);
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefix;
                switch (SelectedIndex)
                {
                    case var abc when i == SelectedIndex:
                        switch (currentOption)
                        {
                            case "Back\t Temp Limits\n":
                                prefix = "<";
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write($" {prefix} ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(currentOption);
                                break;

                            case "Back\n\n":
                                prefix = "<";
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write($" {prefix} ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(currentOption);
                                break;

                            default:
                                prefix = ">";
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write($"  {prefix} ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(currentOption);
                                break;

                        }
                        break;
                    default:
                        {
                            prefix = ">";
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine($" {prefix} {currentOption}");
                        }
                        break;
                }
            }
            Console.ResetColor();
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;
                switch (keyPressed)
                {
                    case ConsoleKey.UpArrow:
                        SelectedIndex--;
                        if (SelectedIndex == -1)
                        {
                            SelectedIndex = Options.Length - 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        SelectedIndex++;
                        if (SelectedIndex == Options.Length)
                        {
                            SelectedIndex = 0;
                        }
                        break;
                }
            } while (keyPressed != ConsoleKey.Enter);
            return SelectedIndex;
        }
    }
}
