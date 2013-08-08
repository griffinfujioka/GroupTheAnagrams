using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupTheAnagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Group The Anagram!\n");
            Console.WriteLine("\t -- Griffin Fujoka\n");
            Console.WriteLine("Your anagrams: \n\trat, \n\tatr, \n\tdog, \n\ttra\n"); 

            var input = new string[] { "rat", "atr", "dog", "tra" };

            bool alreadyAddedAnagram = false;       // If we've already added the anagram to a dictionary's list of values

            // A buffer list for holding groups of anagrams
            var groupedAnagrams = new Dictionary<string, List<string>>();

            // The final answer which will be appended to on each iteration 
            var finalAnswer = new List<Dictionary<string, List<string>>>(); 

            foreach (var ana in input)
            {
                alreadyAddedAnagram = false; 

                // If there's no dictionaries in the finalAnswer, create and add a new dictionary 
                if (finalAnswer.Count == 0)
                {
                    var dictionary = new Dictionary<string, List<string>>();
                    dictionary.Add(ana, new List<string>() { ana });
                    finalAnswer.Add(dictionary); 
                }
                else
                {
                    // Iterate through all of the keys in the dictionary
                    // and if CompareLetters(key, ana) == true, add ana to the list of values for that key
                    foreach (var dictionary in finalAnswer.ToList())
                    {
                        foreach (var key in dictionary.Keys.ToList<string>())
                        {
                           
                                // If there is already a bucket for this anagram (i.e., tra would have a bucket if rat was a key)
                                if (CompareLetters(key, ana))
                                {

                                    // If the anagram isn't already in the list of values 
                                    if (!dictionary[key].Contains(ana))
                                    {
                                        // Add the anagram to the list of values 
                                        dictionary[key].Add(ana);
                                        Console.WriteLine("Found set of anagrams! Added: \t" + ana + "\t to \t" + key);
                                        alreadyAddedAnagram = true;
                                    }
                                }
                                else
                                {
                                    if (alreadyAddedAnagram)
                                        break;      // We've already added the anagram to it's appropriate dictionary

                                    // Create a new dictionary for the anagram
                                    var dict = new Dictionary<string, List<string>>();
                                    dict.Add(ana, new List<string>() { ana });
                                    finalAnswer.Add(dict);
                                }

                            
                            
                         

                        }
                    }

                }
            }


            // Print the final answer 
            foreach (var dictionary in finalAnswer)
            {
                foreach (var key in dictionary.Keys)
                {
                    Console.WriteLine(key + ":");
                    foreach (var value in dictionary[key].ToList<string>())
                    {
                        Console.WriteLine("\t" + value);
                    }
                }
            }

            Console.Write("Press any key to exit..."); 
            Console.ReadKey(); 
        }

        /// <summary>
        ///  Returns true if the two input strings contain exactly the same letters. 
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="a2"></param>
        /// <returns></returns>
        public static bool CompareLetters(string a1, string a2)
        {
            if (a1.Length != a2.Length)
                return false;           // They can't be exactly the same letters 

            if (a1.Length == 0)     // Only need to check one of them since we know they're the same length
                return true; 

            int i = 0;


            foreach (var c in a1)
            {
                if (a2.Contains(c))
                {
                    var a1Substring = a1.Remove(i, 1);      // Remove one character at the ith index 
                    var j = a2.IndexOf(c);          // Get the index of the occurence of the letter in a2 

                    var a2Substring = a2.Remove(j, 1);      // and remove it 
                    i++;    // Iterate through all the letters in the string 
                    // Recursive call 
                    if (CompareLetters(a1Substring, a2Substring))
                        return true;
                    else
                        return false;
                    


                }
                else
                    return false;



            }


            return false;
        }
        
    }

        
}
