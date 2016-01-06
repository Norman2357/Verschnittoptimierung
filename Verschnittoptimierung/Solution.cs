using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verschnittoptimierung
{
    [Serializable()]
    public class Solution
    {
        public int SolutionID;
        public int usedBenchmarkID;

        public int numberOfBoards;
        public int numberOfRects;
        public DateTime creationTime;
        // cl values
        public float percentageFilledArea;
        public int numberRectsPlaced;
        public int numberRectsLeft;

        public List<Board> BoardList;

        // id of the benchmark used for this solution
        public Benchmark benchmark;

        public Solution()
        {
            BoardList = new List<Board>();
            percentageFilledArea = 0;
        }
    }
}
