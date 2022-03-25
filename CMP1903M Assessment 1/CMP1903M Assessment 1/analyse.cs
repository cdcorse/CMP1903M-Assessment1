using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CMP1903M_Assessment_1
{
    class analyse
    {
        //Handles the analysis of text

        //Method: analyseText
        //Arguments: string
        //Returns: list of integers
        //Calculates and returns an analysis of the text
        public List<int> analyseText(string inputText, string choice)
        {
            //List of integers to hold the first five measurements:
            //1. Number of sentences
            //2. Number of vowels
            //3. Number of consonants
            //4. Number of upper case letters
            //5. Number of lower case letters
            List<int> values = new List<int>();
            //Initialise all the values in the list to '0'
            for (int i = 0; i < 5; i++)
            {
                values.Add(0);
            }
            Program program = new Program();
            int count = 0;
            string longWord = "";
            var fileLocation = Path.Combine(Directory.GetCurrentDirectory(), "longwords.txt");
            if (File.Exists("longwords.txt"))
            {
                File.Delete(fileLocation);
            }
            foreach (char v in inputText)
            {
                count += 1;
                //compares the current character with punctuation to see if it is punctuation
                if (v.ToString() == "." ^ v.ToString() == "?" ^ v.ToString() == "!")
                {
                    //If the character is a full stop, question mark or a exclamation mark then the number representing sentences in values is raised by 1
                    values[0] += 1;
                }
                //If the current character is not punctuation then it is a letter
                else if (v.ToString() == "*")
                {
                }
                else
                {
                    if (Char.IsLetter(v))
                    {
                        if (choice == "2")
                        {
                            longWord += v.ToString();
                        }
                        //Compares the current letter with all vowels
                        if (v.ToString().ToLower() == "a" ^ v.ToString().ToLower() == "e" ^ v.ToString().ToLower() == "i" ^ v.ToString().ToLower() == "o" ^ v.ToString().ToLower() == "u")
                        {
                            //If the letter is a vowel then the number representing vowels in values is raised by 1
                            values[1] += 1;
                            //Compares the current letter to a uppercase verion of itself to see if it is uppercase
                            if (v.ToString() == v.ToString().ToUpper())
                            {
                                //If the current letter is uppercase then the number representing uppercase letters in values is increased by 1
                                values[3] += 1;
                            }
                            //Compares the current letter to an lowercase version of itself to see if it is lowercase
                            else if (v.ToString() == v.ToString().ToLower())
                            {
                                //If the current letter is lowercase then the number representing lowercase letters in values is increased by 1
                                values[4] += 1;
                            }
                        }
                        //If the current letter is not a vowel then it is checked to see if it is a consonant
                        else if (v.ToString().ToLower() == "b" ^ v.ToString().ToLower() == "c" ^ v.ToString().ToLower() == "d" ^ v.ToString().ToLower() == "f" ^ v.ToString().ToLower() == "g" ^ v.ToString().ToLower() == "h" ^ v.ToString().ToLower() == "j" ^ v.ToString().ToLower() == "k" ^ v.ToString().ToLower() == "l" ^ v.ToString().ToLower() == "m" ^ v.ToString().ToLower() == "n" ^ v.ToString().ToLower() == "p" ^ v.ToString().ToLower() == "q" ^ v.ToString().ToLower() == "r" ^ v.ToString().ToLower() == "s" ^ v.ToString().ToLower() == "t" ^ v.ToString().ToLower() == "v" ^ v.ToString().ToLower() == "w" ^ v.ToString().ToLower() == "x" ^ v.ToString().ToLower() == "y" ^ v.ToString().ToLower() == "z")
                        {
                            //If the letter is a consonant then the number representing consonants  in values is raised by 1
                            values[2] += 1;
                            //Compares the current letter to a uppercase verion of itself to see if it is uppercase
                            if (v.ToString() == v.ToString().ToUpper())
                            {
                                //If the current letter is uppercase then the number representing uppercase letters in values is increased by 1
                                values[3] += 1;
                            }
                            //Compares the current letter to an lowercase version of itself to see if it is lowercase
                            else if (v.ToString() == v.ToString().ToLower())
                            {
                                //If the current letter is lowercase then the number representing lowercase letters in values is increased by 1
                                values[4] += 1;
                            }
                        }
                        //If the character isn't a vowel or a consonant it is ignored
                    }
                    else
                    {
                        if (choice == "2")
                        { 
                        //If the file for longwords does not exist then the file is created
                        if (File.Exists("longwords.txt") == false)
                        {
                            using FileStream fs = File.Create(fileLocation);
                        }
                        //If the length of the current word is greater than 7 characters it is added to the file
                        if (longWord.Length > 7)
                        {
                            using (StreamWriter outputFile = new StreamWriter(fileLocation, true))
                            {
                                outputFile.WriteLine(longWord);
                            }
                        }
                        longWord = "";
                        }
                    }
                }
                if (count == inputText.Length)
                {
                    //Used to make sure sentence count is accurate if user forgets to add full stop at end of text
                    if (v.ToString() == "*" ^ v.ToString() == ".")
                    {
                    }
                    else
                    {
                        values[0] += 1;
                    }
                }
            }
            return values;
        }


    }
}
