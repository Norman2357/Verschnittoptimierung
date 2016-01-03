using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verschnittoptimierung
{
    class Benchmark
    {
        public int BenchmarkID;
        public List<Board> BoardList;
        public int numberOfRects;
        public DateTime creationTime;

        public Benchmark()
        {
            BoardList = new List<Board>();
        }
    }
}
