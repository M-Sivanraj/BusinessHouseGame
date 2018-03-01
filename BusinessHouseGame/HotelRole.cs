using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHouseGame
{
    public class HotelRole : SquareRole
    {
        const int HOTEL_PRICE = 200;
        public HotelRole(Square s) : base(s)
        {
        }

        public override void UpdateMoney(Player player)
        {
            var currentAmount = player.GetAmount();
            player.SetAmount(currentAmount - HOTEL_PRICE);
            player.SetAssetCount(player.GetAssetCount() + 1);
        }
    }
}
