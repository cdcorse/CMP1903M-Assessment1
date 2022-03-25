using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CMP1903M_Assessment_1
{
    class input
    {
        //Handles the text input for Assessment 1
        string text = "nothing";

        //Method: manualTextInput
        //Arguments: none
        //Returns: string
        //Gets text input from the keyboard
        public string manualTextInput()
        {
            Console.WriteLine("Enter the text you want to analyse: ");
            Console.WriteLine("Enter * to end analysis");
            text = Console.ReadLine().ToString();
            return text;
        }

        //Method: fileTextInput
        //Arguments: string (the file path)
        //Returns: string
        //Gets text input from a .txt file
        public string fileTextInput(string fileName)
        {
            text = File.ReadAllText(fileName).ToString();
            return text;
        }


    }
}
