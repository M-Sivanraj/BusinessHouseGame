using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHouseGame
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] playerNames = { "Sivan", "Raj" };
            int playerAmount = 500;
            int numSquares = 40;
            int numofRounds = 10;
            // for the user first square is at position 1 but
            // internally is at 0
            int[] hotels = { 2, 9, 19, 31 };
            int[] treasures = { 3, 12, 22, 32 };
            int[] jails = { 6, 17, 26, 34 };

            Game game = new Game(playerNames, numSquares, hotels, treasures, jails, playerAmount);
            game.Play(numofRounds);

        }
    }
}
