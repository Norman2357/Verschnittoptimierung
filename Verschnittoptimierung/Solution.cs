using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verschnittoptimierung
{
    class Solution
    {
        public int SolutionID;
        public List<Board> BoardList;
        public int numberOfRects;
        public DateTime creationTime;

        // id of the benchmark used for this solution
        Benchmark benchmark;

        public Solution()
        {
            BoardList = new List<Board>();
        }
    }
}
