using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verschnittoptimierung
{
    // using singleton-pattern, global base for reference handling
    class Base
    {
        private static Base instance;
        public int executionRunning;
        public List<Board> BoardList;
        public Verschnittoptimierung Verschnittoptimierung;
        public float generalBoardWidth;
        public float generalBoardHeight;
        public float mult;
        public int boardGap;

        private Base()
        {
            this.BoardList = new List<Board>();
            this.boardGap = 10;
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
