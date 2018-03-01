using BusinessHouseGame.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHouseGame
{
    public class Game
    {
        private LinkedList<Player> players = new LinkedList<Player>();
        private Board board = null;

        private sealed class Die
        {
            private const int MINVALUE = 2;
            private const int MAXVALUE = 12;

            public int Roll()
            {
                return Random(MINVALUE, MAXVALUE);
            }

            private int Random(int min, int max)
            {
                return (int)(min + Math.Round((max - min) * GlobalRandom.NextDouble));
            }
        }

        private void MovePlayer(int roll)
        {
            Player currentPlayer = players.First.Value;
            players.RemoveFirst();
            currentPlayer.MoveForward(roll);
            players.AddLast(currentPlayer); // to the tail
        }

        public Game(string[] playerNames, int numSquares, int[] hotels, int[] treasure, int[] jail, int startAmount)
        {
            MakeBoard(numSquares, hotels, treasure, jail);
            MakePlayers(playerNames, startAmount);
        }

        private void MakeBoard(int numSquares, int[] hotels, int[] treasure, int[] jail)
        {
            board = new Board(numSquares, hotels, treasure, jail);
        }

        private void MakePlayers(string[] playerNames, int startAmount)
        {
            int i = 1;
            foreach (string str in playerNames)
            {
                Player player = new Player(str, startAmount);
                players.AddLast(player);
                Console.WriteLine(i + ". " + str);
                i++;
            }
        }

        public virtual void Play(int rounds)
        {
            Die die = new Die();
            StartGame();
            int diceRound = 0;

            Console.WriteLine(" Initial state : \n" + this);
            while (diceRound < rounds)
            {
                int roll = die.Roll();
                Console.WriteLine(" Current player is " + CurrentPlayer() + " and rolls " + roll);
                MovePlayer(roll);
                Console.WriteLine(" \n");
                diceRound++;
            }
            AnnonceWinner();
        }

        private void StartGame()
        {
            PlacePlayersAtFirstSquare();
        }

        private void PlacePlayersAtFirstSquare()
        {
            foreach (Player player in players)
            {
                board.FirstSquare().enter(player);
            }
        }

        public override string ToString()
        {
            string str = "";
            foreach (Player player in players)
            {
                str += player.GetName() + " is at square "
                + (player.Position() + 1) + "\n";
            }
            return str;
        }


        internal virtual Player CurrentPlayer()
        {
            return players.First.Value;
        }

        private void AnnonceWinner()
        {
            var winner = players.Aggregate((i1, i2) => i1.GetAmount() > i2.GetAmount() ? i1 : i2);
            Console.WriteLine(winner.GetName() + " Win the Match, Totally " + winner.GetAmount() + " rupees in his hand and he owned " + winner.GetAssetCount() + " Hotel(s)..!");
            Console.Read();
        }
    }
}
