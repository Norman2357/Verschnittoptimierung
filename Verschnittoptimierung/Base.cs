using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

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

        public Benchmark benchmark;
        public Solution solution;

        public RunningProcess runningProcess;

        // solutionStatus: 0 = default, 1 = benchmark/solution created, 2 = fill, 3 = local opt., 4 = ev. alg.
        // reset to 0 when restarting, reset to 1 when a new benchmark/solution is created, reset to 2 when filled after
        // loc. opt / ev. alg
        public int solutionStatus;

        public string contentToShow;
        // displayWidth set in beginning, should be 1100. later changed if required (for scrolling horizontally)
        public int displayWidth;


        // two lists and a value for Fill
            // positions already tried (for one rect)
        public List<Position> positionsManaged = new List<Position>();
            // positions valid (for one rect)
        public List<Position> positionsValid = new List<Position>();
        public Position bestPosition;
        public Boolean bestPositionSet;

        // for Ev.Alg
        public Solution emptySolution;
        public List<int> chosenGreedies;
        public int mue;
        public int multForLambda;
        public int lambda;
        public float mutationRate;

        public List<PopulationElement> populationSmall;
        public List<PopulationElement> populationLarge;
        public PopulationElement bestPopulationElement;

        public int nextStepGreedyEvo;
        // nr similar to the displayed checkbox description
        public int selectedGreedy;

        // bonus
        public int changeCounter;

        private Base()
        {
            this.BoardList = new List<Board>();
            this.boardGap = 20;
            this.contentToShow = "";
            this.runningProcess = new RunningProcess();
            this.solutionStatus = 0;

            this.positionsManaged = new List<Position>();
            this.positionsValid = new List<Position>();
            this.bestPositionSet = false;

            this.chosenGreedies = new List<int>();
            this.populationSmall = new List<PopulationElement>();
            this.populationLarge = new List<PopulationElement>();
            
            this.changeCounter = 0;
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
