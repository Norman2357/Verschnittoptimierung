using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verschnittoptimierung
{
    class Board
    {
        public int boardID;
        public Boolean isCollectionBoard;
        public MyPoint edgeLeftUp;
        public MyPoint edgeRightDown;
        public int width;
        public int height;
        public int size;
        public List<Rect> RectList;
    }
}
