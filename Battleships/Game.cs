using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    // Imagine a game of battleships.
    //   The player has to guess the location of the opponent's 'ships' on a 10x10 grid
    //   Ships are one unit wide and 2-4 units long, they may be placed vertically or horizontally
    //   The player asks if a given co-ordinate is a hit or a miss
    //   Once all cells representing a ship are hit - that ship is sunk.
    public class Game
    {
        // ships: each string represents a ship in the form first co-ordinate, last co-ordinate
        //   e.g. "3:2,3:5" is a 4 cell ship horizontally across the 4th row from the 3rd to the 6th column
        // guesses: each string represents the co-ordinate of a guess
        //   e.g. "7:0" - misses the ship above, "3:3" hits it.
        // returns: the number of ships sunk by the set of guesses
        public static int Play(string[] ships, string[] guesses)
        {
            int gridRow = 10;
            int gridColumn = 10;
            string[,] grid = new String[gridRow, gridColumn];

            int sunkShipsCount = 0;

            foreach (var guess in guesses)
            {
                var guessRC = guess.Split(':');
                int row = Int32.Parse(guessRC[0]);
                int col = Int32.Parse(guessRC[1]);
                grid[row, col] = "X";
            }

            foreach (String ship in ships)
            {
                // 3:2,3:5
                // extract these to 
                String[] shipRC = ship.Split(":,".ToCharArray());
                Boolean ok = true;

                int row1 = Int32.Parse(shipRC[0]);
                int col1 = Int32.Parse(shipRC[1]);
                int row2 = Int32.Parse(shipRC[2]);
                int col2 = Int32.Parse(shipRC[3]);
                
                for (int row = row1; row <= row2; ++row)
                {
                    for (int col = col1; col <= col2; ++col)
                    {
                        if (grid[row, col] != "X")
                        {
                            ok = false;
                            break;
                        }
                    }
                }

                if (ok)
                {
                    ++sunkShipsCount;
                }
            }
            return sunkShipsCount;
        }
    }
}
