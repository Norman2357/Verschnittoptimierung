using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verschnittoptimierung
{
    class Rect
    {
        public int rectID;
        // edgeLeftUp and edgeRightDown are positions on the board they are on; NOT positions on the display(!)
        public MyPoint edgeLeftUp;
        public MyPoint edgeRightDown;
        public int width;
        public int height;
        public int size;
    }
}
