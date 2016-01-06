using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verschnittoptimierung
{
    [Serializable()]
    public class SerializableBenchmark
    {
        public List<Test2> benchmark;
        public SerializableBenchmark()
        {

        }
        /*
        private int benchmarkID;

        private List<Board> boardList;


        private int numberOfRects;

        private DateTime creationTime;

        // getter and setter methods
        public int GetBenchmarkID()
        {
            return this.benchmarkID;
        }
        public void SetBenchmarkID(int benchmarkID)
        {
            this.benchmarkID = benchmarkID;
        }
        public List<Board> GetBoardList()
        {
            return this.boardList;
        }
        public void SetBoardList(List<Board> boardList)
        {
            this.boardList = boardList;
        }
        public int GetNumberOfRects()
        {
            return this.numberOfRects;
        }
        public void SetNumberOfRects(int numberOfRects)
        {
            this.numberOfRects = numberOfRects;
        }
        public DateTime GetCreationTime()
        {
            return this.creationTime;
        }
        public void SetCreationTime(DateTime creationTime)
        {
            this.creationTime = creationTime;
        }
        /*
        private Test test;
        
        private DateTime creationTime;

        private List<Board> boardList;

        public void SetBoardList(List<Board> boardList)
        {
            this.boardList = boardList;
        }
        public List<Board> GetBoardList()
        {
            return this.boardList;
        }

        public void SetTest(Test test)
        {
            this.test = test;
        }
        */
        
    }
    public class Test
    {
        public MyPoint edgeLeftUp;
        
        public List<Rect> RectList;

        public DateTime creationTime;

    }

    public class Test2
    {
        public List<Rect> RectList;
    }

}
