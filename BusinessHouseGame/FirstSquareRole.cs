using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHouseGame
{
    public class FirstSquareRole : SquareRole
    {
        private List<Player> players = new List<Player>();

        public FirstSquareRole(Square s) : base(s)
        {
        }



        public override bool isFirstSquare()
        {
            return true;
        }


        public override void enter(Player player)
        {
            players.Add(player);
            player.SetSquare(square);
        }


        public override void leave(Player player)
        {
            players.Remove(player);
        }


        public override bool isOccupied()
        {
            return !players.Any();
        }
    }
}
