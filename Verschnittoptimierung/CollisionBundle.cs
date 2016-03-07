using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verschnittoptimierung
{
    public class CollisionBundle
    {
        // position of the rect
        public Position position;

        // contains the numbers of the already existing rects on the board that have a collision with the rect which should
        // be placed. the number means the position in the list (rectList) of the board

        public CollisionBundle(Position position, List<int> CollectionListNr)
        {
            this.position = new Position();
            this.position.edgeLeftUp = new MyPoint();
            this.position.edgeRightDown = new MyPoint();
            this.position.edgeLeftUp.x = position.edgeLeftUp.x;
            this.position.edgeLeftUp.y = position.edgeLeftUp.y;
            this.position.edgeRightDown.x = position.edgeRightDown.x;
            this.position.edgeRightDown.y = position.edgeRightDown.y;
        }
    }
}
