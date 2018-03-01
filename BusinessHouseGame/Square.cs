using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHouseGame
{
    public class Square
    {
        private Board board = null;
        private Player player = null;
        private int position;
        private SquareRole squareRole = null;

        public Square(int pos, Board b)
        {
            position = pos;
            board = b;
        }

        public Player getPlayer()
        {
            return player;
        }

        public void setPlayer(Player p)
        {
            player = p;
        }

        public int getPosition()
        {
            return position;
        }

        public void setSquareRole(SquareRole sr)
        {
            squareRole = sr;
        }

        public bool isOccupied()
        {
            return squareRole.isOccupied();
        }

        public bool isLastSquare()
        {
            return squareRole.isLastSquare();
        }

        public Square moveAndLand(int moves)
        {
            return squareRole.moveAndLand(moves);
        }

        public Square landHereOrGoHome()
        {
            return squareRole.landHereOrGoHome();

        }

        public void enter(Player p)
        {
            squareRole.enter(p);
        }

        public void leave(Player p)
        {
            squareRole.leave(p);
        }

        public void calculate(Player p)
        {
            squareRole.UpdateMoney(p);
        }

        public Square findRelativeSquare(int shift)
        {
            return board.FindSquare(position + shift);
        }

        public Square findFirstSquare()
        {
            return board.FirstSquare();
        }

        public Square findLastSquare()
        {
            return board.LastSquare();
        }

    }
}
