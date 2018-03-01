using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHouseGame
{
    public class LastSquareRole : SquareRole
    {
        public LastSquareRole(Square s) : base(s)
        {
        }

        public override bool isLastSquare()
        {
            return true;
        }
    }
}
