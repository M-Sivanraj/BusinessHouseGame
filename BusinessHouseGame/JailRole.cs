using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHouseGame
{
    public class JailRole : SquareRole
    {
        const int JAIL_FEE = 150;
        public JailRole(Square s) : base(s)
        {
        }

        public override void UpdateMoney(Player player)
        {
            var currentAmount = player.GetAmount();
            player.SetAmount(currentAmount - JAIL_FEE);
        }
    }
}
