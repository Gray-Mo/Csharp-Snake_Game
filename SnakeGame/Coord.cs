using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Coord
    {
        private int x;
        private int y;

        public int X { get { return x; } }
        public int Y { get { return y; } }

        public Coord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            if( obj == null || !GetType().Equals(obj.GetType()) )
                return false;

            Coord other = (Coord) obj;
            
            return other.x == x && other.y == y;
        }
        public void ApplyMovementDirections(Directions direction)
        {
            switch(direction)
            {
                case Directions.Left:
                    x--;
                    break;
                case Directions.Right:
                    x++;
                    break;
                case Directions.Up:
                    y--;
                    break;
                case Directions.Down:
                    y++;
                    break;
            }
        }
    }
}
