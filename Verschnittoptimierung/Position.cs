using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verschnittoptimierung
{
    public class Position
    {
        public MyPoint edgeLeftUp;
        public MyPoint edgeRightDown;

        public Position()
        {
            this.edgeLeftUp = new MyPoint();
            this.edgeRightDown = new MyPoint();
        }

        public Boolean IsEqualPositionAs(Position position)
        {
            if(position.edgeLeftUp.x == this.edgeLeftUp.x &&
               position.edgeLeftUp.y == this.edgeLeftUp.y &&
               position.edgeRightDown.x == this.edgeRightDown.x &&
               position.edgeRightDown.y == this.edgeRightDown.y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // sets the coordinates to the position given without linking a reference
        public void SetToPosition(Position position)
        {
            this.edgeLeftUp.x = position.edgeLeftUp.x;
            this.edgeLeftUp.y = position.edgeLeftUp.y;
            this.edgeRightDown.x = position.edgeRightDown.x;
            this.edgeRightDown.y = position.edgeRightDown.y;
        }
    }
}
