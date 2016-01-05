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
        
        public Verschnittoptimierung1 Verschnittoptimierung;

        public int numberBoards;
        public List<Board> BoardList;
        public float generalBoardWidth;
        public float generalBoardHeight;
        public float mult;
        public float boardHeightInterface;
        public int boardGap;

        public int executionRunning;

        public Benchmark benchmark;
        public Solution solution;

        public string contentToShow;
        // displayWidth set in beginning, should be 1100. later changed if required (for scrolling horizontally)
        public int displayWidth;

        private Base()
        {
            this.BoardList = new List<Board>();
            this.boardGap = 20;
            this.contentToShow = "";
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
