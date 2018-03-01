using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHouseGame
{
    public class TreasureRole : SquareRole
    {
        const int TREASURE = 200;
        public TreasureRole(Square s) : base(s)
        {
        }

        public override void UpdateMoney(Player player)
        {
            var currentAmount = player.GetAmount();
            player.SetAmount(currentAmount + TREASURE);
        }
    }
}
