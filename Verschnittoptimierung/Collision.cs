using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verschnittoptimierung
{
    public class Collision
    {
        public Collision()
        {

        }

        // returns the position numbers of the rects in RectListBoard where collisions where detected
        // RectListBoard = list of the board where the collision is searched (and where the rect should be placed)
        // rect = the rect to be placed
        public List<int> GetCollisions(List<Rect> rectListBoard, Rect rect)
        {
            List<int> collisionList = new List<int>();

            // coordinates of the existing rect
            float x1;
            float x2;
            float y1;
            float y2;

            // coordinates of the new rect
            float u1;
            float u2;
            float v1;
            float v2;
            
            for(int i = 0; i < rectListBoard.Count; i++)
            {
                x1 = rectListBoard[i].edgeLeftUp.x;
                x2 = rectListBoard[i].edgeRightDown.x;
                y1 = rectListBoard[i].edgeRightDown.y;
                y2 = rectListBoard[i].edgeLeftUp.y;

                u1 = rect.edgeLeftUp.x;
                u2 = rect.edgeRightDown.x;
                v1 = rect.edgeRightDown.y;
                v2 = rect.edgeLeftUp.y;
                
                // collision detection
                if((
                   (u1 < x1 && x1 < u2) ||
                   (u1 < x2 && x2 < u2) ||
                   (x1 < u1 && u1 < x2) ||
                   (x1 < u2 && u2 < x2)) &&
                   (
                   (v1 < y1 && y1 < v2) ||
                   (v1 < y2 && y2 < v2) ||
                   (y1 < v1 && v1 < y2) ||
                   (y1 < v2 && v2 < y2))
                   )
                {
                    collisionList.Add(i);
                }
            }

            return collisionList;
        }
    }
}
