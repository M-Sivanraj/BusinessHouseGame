using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHouseGame
{
    public class Board
    {
        private List<Square> squares = new List<Square>();
        private static int MINNUMSQUARES = 35;

        public Board(int numSquares, int[] hotel, int[] treasure, int[] jail)
        {

            if (numSquares < MINNUMSQUARES)
                throw new Exception(" There must be at least " + MINNUMSQUARES + " squares ");

            MakeSquares(numSquares);
            MakeHotels(hotel);
            MakeTreasures(treasure);
            MakeJails(jail);
        }

        private void MakeSquares(int numSquares)
        {
            for (int position = 0; position < numSquares; position++)
            {
                Square square = new Square(position, this);
                squares.Add(square);
                square.setSquareRole(new RegularSquareRole(square));
            }
            FirstSquare().setSquareRole(new FirstSquareRole(FirstSquare()));
            LastSquare().setSquareRole(new LastSquareRole(LastSquare()));
        }

        public Square FirstSquare()
        {
            return squares[0];
        }

        public Square LastSquare()
        {
            return squares[squares.Count - 1];
        }

        public Square FindSquare(int position)
        {
            return squares[position];
        }

        private int NumberOfSquares()
        {
            return squares.Count;
        }

        private void MakeTreasures(int[] treasures)
        {
            for (int index = 0; index < treasures.Length; index++)
            {
                int position = treasures[index];
                Square treasureSquare = squares[position];
                treasureSquare.setSquareRole(new TreasureRole(treasureSquare));
            }
        }

        private void MakeHotels(int[] hotels)
        {
            for (int index = 0; index < hotels.Length; index++)
            {
                int position = hotels[index];
                Square hotelSquare = squares[position];
                hotelSquare.setSquareRole(new HotelRole(hotelSquare));
            }
        }

        private void MakeJails(int[] jails)
        {
            for (int index = 0; index < jails.Length; index++)
            {
                int position = jails[index];
                Square jailSquare = squares[position];
                jailSquare.setSquareRole(new JailRole(jailSquare));
            }
        }
    }
}
