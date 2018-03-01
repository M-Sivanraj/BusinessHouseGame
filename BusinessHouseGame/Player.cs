using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHouseGame
{
    public class Player
    {
        private Square square = null;
        private String name;
        private int amount;
        private int assetCount;

        public Square GetSquare()
        {
            return square;
        }

        public void SetSquare(Square square)
        {
            this.square = square;
        }

        public int Position()
        {
            return square.getPosition();
        }

        public String GetName()
        {
            return name;
        }

        public int GetAmount()
        {
            return amount;
        }

        public void SetAmount(int amt)
        {
            amount = amt;
        }

        public int GetAssetCount()
        {
            return assetCount;
        }

        public void SetAssetCount(int amt)
        {
            assetCount = amt;
        }

        public Player(String strname, int amt)
        {
            name = strname;
            amount = amt;
        }

        public override String ToString()
        {
            return name;
        }

        public bool Wins()
        {
            return square.isLastSquare();
        }

        public void MoveForward(int moves)
        {
            square.leave(this);
            square = square.moveAndLand(moves);
            square.enter(this);
            square.calculate(this);
        }
    }
}


