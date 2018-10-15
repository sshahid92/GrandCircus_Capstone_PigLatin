using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandCircusCapstonePigLatin
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Pig Latin Translator!");
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Enter a line to be translated: ");
                string convertedSentence = ConvertToPigLatin(Console.ReadLine().ToLower());
                Console.WriteLine(convertedSentence);
                Console.WriteLine("Translate another word? (y/n):");
                bool retryLoop = true;
                while (retryLoop)
                {
                    var answer = Console.ReadLine().ToLower();
                    if (answer == "y" || answer == "yes")
                    {
                        retryLoop = false;
                        break;
                    }
                    else if (answer == "n" || answer == "no")
                    {
                        loop = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid response. Please enter 'y' or 'n'.");
                    }
                }
            }
        }

        private static string FixPunctuation(string input)
        {
            string punctuation = ",;:!?";
            string correctedWord = input;

            for (int i = 0; i < input.Trim().Length; i++)
            {
                if (punctuation.Contains(input.Trim()[i]))
                {
                    correctedWord = input.Trim().Remove(i, 1) + input.Trim().Substring(i, 1) + " ";
                    break;
                }
                else
                {
                    continue;
                }
            }
            return correctedWord;
        }

        private static string ConvertToPigLatin(string input)
        {
            StringBuilder pigLatinString = new StringBuilder();
            string[] separators = {" "};
            
            string[] SplitWordsToArray = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in SplitWordsToArray)
            {
                
                string firstLetter = word.Substring(0, 1);
                bool isVowel = "aeiou".IndexOf(firstLetter) >= 0;
                var vowels = "aeiou";
                string specialChar = "0123456789~@#^*";
                bool specialCharFlag = false;

                for (int x = 0; x < word.Length; x++)
                {
                    if (specialChar.Contains(word[x]))
                    {
                        pigLatinString.Append(word + " ");
                        specialCharFlag = true;
                        break;
                    }
                    
                }

                if (isVowel && specialCharFlag == false)
                {

                    string convertWord = word + "way ";
                    string finalWord = FixPunctuation(convertWord);
                    pigLatinString.Append(finalWord);

                }
                else if (!isVowel && specialCharFlag == false)
                {
                    int vowelIndex = 0;
                    
                    for (int x = 1; x < word.Length; x++)
                    {
                        if (vowels.Contains(word[x]))
                        {
                            vowelIndex = x;
                            break;
                        }
                    }
                    string convertedWord = word.Remove(0, vowelIndex) + word.Substring(0, vowelIndex) + "ay ";
                    string finalWord = FixPunctuation(convertedWord);
                    pigLatinString.Append(finalWord);
                }
            }
    
            return pigLatinString.ToString();
        }
       
    }
}
