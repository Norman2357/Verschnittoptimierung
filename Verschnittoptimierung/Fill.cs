using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verschnittoptimierung
{
    public class Fill
    {
        public Fill()
        {

        }

        public void Greedy1()
        {
            Base global = Base.GetInstance();
            Solution solution = global.solution;

            // preparations
            
            // sort rects from max size to min size
            Tools tools = new Tools();
            tools.QuickSortBySizeRect(solution.BoardList[solution.BoardList.Count - 1].RectList, 0,
                solution.BoardList[solution.BoardList.Count - 1].RectList.Count);
            
            // for each rect on collectionBoard
            for(int i = 0; i < solution.BoardList[solution.BoardList.Count - 1].RectList.Count; i++)
            {
                // sort boards from max free space to least free space
                List<int> boardNrSorted = tools.SortBoardsBySize(solution.BoardList);

                // for each board try to place the rect
                for(int j = 0; j < boardNrSorted.Count - 1; j++)
                {
                    // try place the rect
                    // 1. is the space as area enough for the board? (without finding a specific place)
                        // calculate boardSizeEffective
                    int boardSizeEffective = solution.BoardList[j].size;
                    for(int k = 0; k < solution.BoardList[j].RectList.Count; k++)
                    {
                        boardSizeEffective -= solution.BoardList[j].RectList[k].size;
                    }
                    if(boardSizeEffective < solution.BoardList[solution.BoardList.Count - 1].RectList[i].size)
                    {
                        // rect is too large, cannot be placed on any of the boards.
                        // has to remain on the collectionBoard
                        break;
                    }

                    // 2. try to place the rect in the selected board
                        // clone the rect
                    Rect rect = new Rect();
                    rect.edgeLeftUp = new MyPoint();
                    rect.edgeRightDown = new MyPoint();
                    rect.rectID = solution.BoardList[solution.BoardList.Count - 1].RectList[i].rectID;
                    rect.size = solution.BoardList[solution.BoardList.Count - 1].RectList[i].size;
                    rect.width = solution.BoardList[solution.BoardList.Count - 1].RectList[i].width;
                    rect.height = solution.BoardList[solution.BoardList.Count - 1].RectList[i].height;
                    rect.edgeLeftUp.x = solution.BoardList[solution.BoardList.Count - 1].RectList[i].edgeLeftUp.x;
                    rect.edgeLeftUp.y = solution.BoardList[solution.BoardList.Count - 1].RectList[i].edgeLeftUp.y;
                    rect.edgeRightDown.x = solution.BoardList[solution.BoardList.Count - 1].RectList[i].edgeRightDown.x;
                    rect.edgeRightDown.y = solution.BoardList[solution.BoardList.Count - 1].RectList[i].edgeRightDown.y;

                    // set position of edgeLeftDown to 0|0
                    rect.edgeLeftUp.x = 0;
                    rect.edgeRightDown.y = 0;

                    // first vertical, then horizontal
                    for(int l = 1; l <= 2; l++)
                    {
                        if(l == 1)
                        {
                            // 1. vertical
                            if (rect.height < rect.width)
                            {
                                int helper = rect.height;
                                rect.height = rect.width;
                                rect.width = helper;
                            }
                        }
                        else
                        {
                            // 2. horizontal
                            if (rect.height > rect.width)
                            {
                                int helper = rect.height;
                                rect.height = rect.width;
                                rect.width = helper;
                            }
                        }
                    }
                    // basic coordinates
                    rect.edgeLeftUp.y = rect.edgeRightDown.y + rect.height;
                    rect.edgeRightDown.x = rect.edgeLeftUp.x + rect.width;

                    // check for collision
                    Collision collision = new Collision();
                    List<int> collisionList = collision.GetCollisions(solution.BoardList[j].RectList, rect);
                    if(collisionList.Count == 0)
                    {
                        // successful
                    }
                    else
                    {

                    }

                    if (successful + removedRectFromCollectionBoard)
                    {
                        // so that the new rect one on the same i is not forgotten
                        i--;
                        break;
                    }
                }
            }







            // create an empty rectList. this rect list will be the new collection board rect list after
            // completing the algorithm

            // get first object
            // as long as there are rects left on the collection board
            while (solution.BoardList[solution.BoardList.Count - 1].RectList.Count > 0)
            {
                Rect rect = solution.BoardList[solution.BoardList.Count - 1].RectList[0];
            }
            
        }

        // gets the best position for the rect on the board.
        // if a position was found, return true, else false
        public Boolean GetBestPosition(List<Rect> rectList, Rect rect)
        {

        }
    }
}
