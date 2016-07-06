using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**Using names.txt (right click and 'Save Link/Target As...'), a 46K text file containing over five
 * -thousand first names, begin by sorting it into alphabetical order. Then working out the 
 * alphabetical value for each name, multiply this value by its alphabetical position in the list
 * to obtain a name score.
 * For example, when the list is sorted into alphabetical order,
 * COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list.
 * So, COLIN would obtain a score of 938 × 53 = 49714.
 * What is the total of all the name scores in the file?
 * ANSWER: 871198282 IS THE TOTAL NAME SCORE FOR ALL NAMES IN THE FILE
 **/
namespace NamesScores
{
    class Program
    {
        private static String[] namesArrayToSort;
        static void Main(string[] args)
        {
            readDataFile();
            Sort.sortDataFile(namesArrayToSort);
        }

        private static void readDataFile()
        {
            try
            {
                //Set up a connection to the text file to be sorted
                StreamReader sr = new StreamReader(@"C:\Users\Joshua\Documents\GitHub\NamesScores\NamesScores\names.txt");
                String names = sr.ReadToEnd();
                namesArrayToSort = names.Split(',');
                for(int i = 0; i < namesArrayToSort.Length; i++)
                {
                    //Loop through the array of names to remove the double quotes and slashes
                    if((namesArrayToSort[i].Contains("\"")) || (namesArrayToSort[i].Contains("\\")))
                    {
                        while (namesArrayToSort[i].Contains("\""))
                        {
                            int indexOfQuote = namesArrayToSort[i].IndexOf("\"");
                            namesArrayToSort[i] = namesArrayToSort[i].Remove(indexOfQuote, 1);
                        }
                        while(namesArrayToSort[i].Contains("\\"))
                        {
                            int indexOfSlash = namesArrayToSort[i].IndexOf("\\");
                            namesArrayToSort[i] = namesArrayToSort[i].Remove(indexOfSlash, 1);
                        }
                        namesArrayToSort[i] = namesArrayToSort[i].Trim();
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("The names.txt file could not be read!");
            }
        }
    }
}
