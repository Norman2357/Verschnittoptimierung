using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verschnittoptimierung
{
    [Serializable()]
    class Solution
    {
        public int SolutionID;
        public List<Board> BoardList;
        public int numberOfRects;
        public DateTime creationTime;
        // in %
        public int successRate;

        // id of the benchmark used for this solution
        Benchmark benchmark;

        public Solution()
        {
            BoardList = new List<Board>();
            successRate = 0;
        }
    }
}
