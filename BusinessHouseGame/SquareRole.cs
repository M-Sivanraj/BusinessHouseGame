using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHouseGame
{
    public abstract class SquareRole
    {
        protected internal Square square = null;
        public SquareRole(Square s)
        {
            square = s;
        }

        public virtual bool isOccupied()
        {
            return square.getPlayer() != null;
        }

        public virtual bool isFirstSquare()
        {
            return false;
        }

        public virtual bool isLastSquare()
        {
            return false;
        }

        public virtual Square moveAndLand(int moves)
        {
            int lastPosition = square.findLastSquare().getPosition();
            int presentPosition = square.getPosition();
            if (presentPosition + moves > lastPosition)
            {
                Console.WriteLine(" Should go to " + (presentPosition + moves + 1) + " beyond last square " + (lastPosition + 1) + " so don 't move ");
                return square;
            }
            else
            {
                Console.WriteLine(" move from " + (square.getPosition() + 1) + " to " + (square.findRelativeSquare(moves).getPosition() + 1));
                return square.findRelativeSquare(moves).landHereOrGoHome();
            }
        }

        public virtual Square landHereOrGoHome()
        {
            if (square.isOccupied())
            {
                Console.WriteLine(" square " + (square.getPosition() + 1) + " is occupied ");
            }
            else
            {
                Console.WriteLine(" land at " + (square.getPosition() + 1));
            }
            return square.isOccupied() ? square.findFirstSquare() : square;
        }

        public virtual void UpdateMoney(Player player)
        {
            player.GetAmount();
        }

        public virtual void enter(Player player)
        {
            square.setPlayer(player);
            player.SetSquare(square);
        }

        public virtual void leave(Player player)
        {
            square.setPlayer(null);
        }
    }
}
