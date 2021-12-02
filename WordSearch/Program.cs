using System;
using System.Data;

namespace WordSearch
{
    class Program
    {
        static char[,] Grid = new char[,] {
            {'C', 'P', 'K', 'X', 'O', 'I', 'G', 'H', 'S', 'F', 'C', 'H'},
            {'Y', 'G', 'W', 'R', 'I', 'A', 'H', 'C', 'Q', 'R', 'X', 'K'},
            {'M', 'A', 'X', 'I', 'M', 'I', 'Z', 'A', 'T', 'I', 'O', 'N'},
            {'E', 'T', 'W', 'Z', 'N', 'L', 'W', 'G', 'E', 'D', 'Y', 'W'},
            {'M', 'C', 'L', 'E', 'L', 'D', 'N', 'V', 'L', 'G', 'P', 'T'},
            {'O', 'J', 'A', 'A', 'V', 'I', 'O', 'T', 'E', 'E', 'P', 'X'},
            {'C', 'D', 'B', 'P', 'H', 'I', 'A', 'W', 'V', 'X', 'U', 'I'},
            {'L', 'G', 'O', 'S', 'S', 'B', 'R', 'Q', 'I', 'A', 'P', 'K'},
            {'E', 'O', 'I', 'G', 'L', 'P', 'S', 'D', 'S', 'F', 'W', 'P'},
            {'W', 'F', 'K', 'E', 'G', 'O', 'L', 'F', 'I', 'F', 'R', 'S'},
            {'O', 'T', 'R', 'U', 'O', 'C', 'D', 'O', 'O', 'F', 'T', 'P'},
            {'C', 'A', 'R', 'P', 'E', 'T', 'R', 'W', 'N', 'G', 'V', 'Z'}
        };

        static string[] Words = new string[] 
        {
            "CARPET",
            "CHAIR",
            "DOG",
            "BALL",
            "DRIVEWAY",
            "FISHING",
            "FOODCOURT",
            "FRIDGE",
            "GOLF",
            "MAXIMIZATION",
            "PUPPY",
            "SPACE",
            "TABLE",
            "TELEVISION",
            "WELCOME",
            "WINDOW"
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Word Search");

            for (int y = 0; y < 12; y++)
            {
                for (int x = 0; x < 12; x++)
                {
                    Console.Write(Grid[y, x]);
                    Console.Write(' ');
                }
                Console.WriteLine("");

            }

            Console.WriteLine("");
            Console.WriteLine("Found Words");
            Console.WriteLine("------------------------------");

            FindWords();

            Console.WriteLine("------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Press any key to end");
            Console.ReadKey();
        }

        private static void FindWords()
        {
            //Find each of the words in the grid, outputting the start and end location of
            //each word, e.g.
            //PUPPY found at (10,7) to (10, 3) 
           
            foreach(string word in Words)
            {                
                findWordsinGrid(word);
            }
        }

        // Searches given word in a given
        // matrix in all 8 directions
        static void findWordsinGrid(string word)
        {
            // Consider every point as starting
            // point and search given word
            for (int row = 0; row < 12; row++)
            {
                for (int col = 0; col < 12; col++)
                {
                    //search for the word
                    if (searchWord(row, col, word,out string endpoint))
                    {
                        //Word found so print to console
                        //Based on the example (PUPPY) we are writing locations as (col,row)
                        Console.WriteLine(word + " found at (" + col + "," + row + ") to (" + endpoint +")");
                        
                    }                    
                }
            }
        }

        // This function searches in all 8-direction
        // from point (row, col) in grid[, ]
        static bool searchWord(int row, int col, string word,out string endpoint)
        {
            // For searching in all 8 direction
            int[] x = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] y = { -1, 0, 1, -1, 1, -1, 0, 1 };

            //default the output variable
            endpoint = "";

            // If first character of word doesn't match
            // with given starting point in grid.
            if (Grid[row, col] != word[0])
            {
                return false;
            }
            
            //get the word length
            int len = word.Length;

            // Search word in all 8 directions
            // starting from (row, col)
            for (int dir = 0; dir < 8; dir++)
            {
                // Initialize starting point
                // for current direction
                int k, rd = row + x[dir], cd = col + y[dir];

                // First character is already checked,
                // match remaining characters
                for (k = 1; k < len; k++)
                {
                    // If out of bound break
                    if (rd >= 12 || rd < 0 || cd >= 12 || cd < 0)
                    {
                        break;
                    }

                    // If not matched, break
                    if (Grid[rd, cd] != word[k])
                    {
                        break;
                    }

                    // Moving in particular direction
                    rd += x[dir];
                    cd += y[dir];
                }

                // If all character matched, then value of k
                // must be equal to length of word
                if (k == len)
                {
                    //get the true row ending coordinates
                    if (x[dir] == -1)
                    {
                        rd = rd + 1;
                    }
                    else if (x[dir] == 1)
                    {
                        rd = rd - 1;
                    }

                    //get the true column ending coordinates
                    if(y[dir] == -1)
                    {
                        cd = cd + 1;
                    }
                    else if (y[dir] == 1)
                    {
                        cd = cd - 1;
                    }

                    //set the word end coordinates in the out variable
                    endpoint = cd + "," + rd;
                    return true;
                }
            }
            return false;
        }
    }
}
