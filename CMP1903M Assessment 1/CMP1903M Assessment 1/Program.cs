//base code project for CMP1903M Assessment 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace CMP1903M_Assessment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Local list of integers to hold the first five measurements of the text
            List<int> parameters = new List<int>();
            List<int> programValues = new List<int>();
            //Initialise all the values in the list to '0'
            for (int i = 0; i < 5; i++)
            {
                programValues.Add(0);
            }
            //Create 'Input' object
            //Get either manually entered text, or text from a file
            input input = new input();
            analyse analyse = new analyse();
            string inputText = "";
            while (true)
            {
                try
                {
                    Console.WriteLine("1. Do you want to enter text manually via the keyboard?");
                    Console.WriteLine("2. Do you want to read in the text from a file?");
                    Console.WriteLine("What would you like to do? ");
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        //Continues the loop until the user enters '*' as an input
                        while (inputText != "*")
                        {
                            //Checks if the user input is '*' or not
                            if (inputText != "*")
                            {
                                //NOTE: doesn't work because programValues are seemingly reset each sentence
                                inputText = input.manualTextInput();
                                for (int j = 0; j < 5; j++)
                                {
                                    //Assigns the analysis of the text to a list in the main program
                                    programValues[j] = programValues[j] + analyse.analyseText(inputText, choice)[j];
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        //Outputs the analysis of the text
                        Console.WriteLine();
                        Console.WriteLine("Sentences: " + programValues[0].ToString());
                        Console.WriteLine("Vowels: " + programValues[1].ToString());
                        Console.WriteLine("Consonants: " + programValues[2].ToString());
                        Console.WriteLine("Uppercase Characters: " + programValues[3].ToString());
                        Console.WriteLine("Lowercase Characters: " + programValues[4].ToString());
                        break;
                    }
                    else if (choice == "2")
                    {
                        //Finds the path for the textfile
                        var fileLocation = Path.Combine(Directory.GetCurrentDirectory(), "textfile.txt");
                        inputText = input.fileTextInput(fileLocation);
                        for (int j = 0; j < 5; j++)
                        {
                            //Assigns the analysis of the text to a list in the main program
                            programValues[j] = programValues[j] + analyse.analyseText(inputText, choice)[j];
                        }
                        //Outputs the analysis of the text
                        Console.WriteLine();
                        Console.WriteLine(inputText);
                        Console.WriteLine();
                        Console.WriteLine("Sentences: " + programValues[0].ToString());
                        Console.WriteLine("Vowels: " + programValues[1].ToString());
                        Console.WriteLine("Consonants: " + programValues[2].ToString());
                        Console.WriteLine("Uppercase Characters: " + programValues[3].ToString());
                        Console.WriteLine("Lowercase Characters: " + programValues[4].ToString());
                        break;
                    } 
                    else
                    {
                        //If the user enters an incorrect input this error message is shown
                        Console.WriteLine("Invalid Input, please enter either 1 or 2");
                    }
                }
                catch (Exception)
                {       
                }
            }
        }
    }
}
