using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NamesScores
{
    class Sort
    {
        static int totalNamesScore = 0;

        internal static void sortDataFile(string[] namesArrayToSort)
        {
            int i;
            int X = namesArrayToSort.Length;

            for(i = 0; i < X-1; i++)
            {
                int k = arrayMinValue(namesArrayToSort, i);
                if( i != k)
                { swapPositions(namesArrayToSort, i, k); }
            }

            //Prints the sorted list of names to the console.
            for(int z = 0; z < namesArrayToSort.Length; z++)
            {
                int lettersScore = 0;
                int namesScore = 0;
                Console.WriteLine(namesArrayToSort[z]);

                string name = namesArrayToSort[z];
                foreach(char c in name)
                {
                    //(int)c % 32 returns the int value that represents each letter in the name
                    lettersScore += (int)c % 32;
                    //Console.WriteLine((int)c % 32);
                }
                //After each name, we need to multiply lettersScore by the position in the array +1
                namesScore = lettersScore * (z + 1);
                totalNamesScore += namesScore;
            }
            Console.WriteLine("The total names score for all names in the list is " + totalNamesScore);
            Thread.Sleep(100000);
        }

        private static int arrayMinValue(string[] namesArrayToSort, int start)
        {
            int minPos = start;
            for (int pos = start + 1; pos < namesArrayToSort.Length; pos++)
                if(namesArrayToSort[pos].CompareTo(namesArrayToSort[minPos]) < 1)
                {
                    minPos = pos;
                }
            return minPos;
        }

        private static void swapPositions(string[] dataFile, int m, int n)
        {
            string temp;
            temp = dataFile[m];
            dataFile[m] = dataFile[n];
            dataFile[n] = temp;
        }
    }
}
