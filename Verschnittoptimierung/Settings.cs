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
        

    }
}
