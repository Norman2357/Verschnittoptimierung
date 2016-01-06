using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verschnittoptimierung
{
    class ClassificationNumbers
    {
        public Base global;
        public ClassificationNumbers(Base global)
        {
            this.global = global;
        }

        public void GetAndShowAllClassificationNumbers()
        {
            // I. get all classification numbers
            GetPercentageFilledArea();
            GetNumberRectsPlaced();
            GetNumberRectsNotPlaced();


            // II. show all classification numbers at the display
            global.Verschnittoptimierung.cl_objectsTotal.Text = Convert.ToString(global.solution.numberOfRects);
            global.Verschnittoptimierung.cl_objectsPlaced.Text = Convert.ToString(global.solution.numberRectsPlaced);
            global.Verschnittoptimierung.cl_objectsLeft.Text = Convert.ToString(global.solution.numberRectsLeft);
            global.Verschnittoptimierung.cl_percentageAreaFilled.Text = Convert.ToString(global.solution.percentageFilledArea);



        }

        // calculate the percentage of board area being filled (if 100%, all rects are placed)
        public void GetPercentageFilledArea()
        {
            float filledArea = 0;
            for(int i = 0; i < global.solution.BoardList.Count; i++)
            {
                if(global.solution.BoardList[i].isCollectionBoard == false)
                {
                    for(int j = 0; j < global.solution.BoardList[i].RectList.Count; j++)
                    {
                        filledArea += global.solution.BoardList[i].RectList[j].size;
                    }
                }
            }
            float totalBoardArea = (global.solution.BoardList[0].height * global.solution.BoardList[0].width) * (global.solution.BoardList.Count - 1);

            float percentageFilledArea = (filledArea / totalBoardArea) * 100;

            // reduce the percentageFilledArea to 2 decimals after comma
            int helper = Convert.ToInt32(percentageFilledArea * 100);
            percentageFilledArea = helper / (float)100;

            global.solution.percentageFilledArea = percentageFilledArea;
        }

        // assuming that all rects that are not on the collection board are placed
        public void GetNumberRectsPlaced()
        {
            int numberRectsPlaced = 0;
            numberRectsPlaced = global.solution.numberOfRects - global.solution.BoardList[global.solution.BoardList.Count - 1].RectList.Count;
            global.solution.numberRectsPlaced = numberRectsPlaced;
        }
        public void GetNumberRectsNotPlaced()
        {
            global.solution.numberRectsLeft = global.solution.numberOfRects - global.solution.numberRectsPlaced;
        }

    }
}
