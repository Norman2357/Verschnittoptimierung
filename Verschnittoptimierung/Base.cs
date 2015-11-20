using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Verschnittoptimierung
{
    // using singleton-pattern, global base for reference handling
    class Base
    {
        // for singleton-pattern
        private static Base instance;
        
        public Verschnittoptimierung Verschnittoptimierung;

        public int numberBoards;
        public List<Board> BoardList;
        public float generalBoardWidth;
        public float generalBoardHeight;
        public float mult;
        public int boardGap;

        public List<myObject> ObjectList;

        public int executionRunning;

        private Base()
        {
            this.BoardList = new List<Board>();
            this.ObjectList = new List<myObject>();
            this.boardGap = 20;
        }

        public static Base GetInstance()
        {
            if(instance == null)
            {
                instance = new Base();
            }
            return instance;
        }
        
    }
}
