using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verschnittoptimierung
{
    [Serializable()]
    public class Settings
    {
        public DateTime creationTime;

        // general settings (for benchmark)
        public int numberOfBoards;
        public int boardHeight;
        public int boardWidth;
        public int objectsBoardMin;
        public int objectsBoardMax;

        // fill settings
        public Boolean bestFit;
        public Boolean bottomLeftFilling;
        public Boolean largestSideInc;
        public Boolean largestSideDec;
        public Boolean sizeInc;
        public Boolean sizeDec;
        public Boolean min_xl_y;

        // evolutionary settings
        public int mue;
        public int mult;
        public float mutationRate;
        public Boolean tournamentPopulation;
        public Boolean tournamentGreedyProcOnly;
        public Boolean greedy1;
        public Boolean greedy2;
        public Boolean greedy3;
        public Boolean greedy4;
        public Boolean greedy5;
        public Boolean greedy6;
        public Boolean greedy7;
        public Boolean greedy8;
        public Boolean greedy9;
        public Boolean greedy10;
        public Boolean greedy11;
        public Boolean greedy12;
        public Boolean greedy13;
        public Boolean greedy14;
        public Boolean greedy15;
        public Boolean greedy16;
    }
}
