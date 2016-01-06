using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verschnittoptimierung
{
    [Serializable()]
    public class Board
    {
        public int boardID;
        public Boolean isCollectionBoard;
        // edgeLeftUp and edgeRightDown are meant in relation to the display(!), meaning drawn from leftUp to rightDown
        // starting at the leftUp edge of the display
        public MyPoint edgeLeftUp;
        public MyPoint edgeRightDown;
        public int width;
        public int height;
        public int size;
        public List<Rect> RectList;

        public Board()
        {
            RectList = new List<Rect>();
        }
    }
}
