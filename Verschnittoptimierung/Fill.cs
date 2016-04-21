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

        public Solution Greedy(Boolean evolution, Solution solutionEvo)
        {
            Base global = Base.GetInstance();
            Solution solution;
            if(evolution)
            {
                solution = solutionEvo;
            }
            else
            {
                solution = global.solution;
            }

            ClassificationNumbers classificationNumbers = new ClassificationNumbers(global);

            // preparations
            if(!evolution)
            {
                global.runningProcess.state = 1;
            }
            Tools tools = new Tools();

            // START one time:
            if (evolution || global.runningProcess.firstStep)
            {
                // next rect to pick of the list: the first one (default)
                if(!evolution)
                {
                    global.runningProcess.nextStep = 0;
                }
                else
                {
                    global.nextStepGreedyEvo = 0;
                }

                global.positionsManaged = new List<Position>();
                global.positionsValid = new List<Position>();

                if((global.Verschnittoptimierung.radioButton_largestSideInc.Checked && !evolution) ||
                    (evolution && global.selectedGreedy == 1) ||
                    (evolution && global.selectedGreedy == 2) ||
                    (evolution && global.selectedGreedy == 9) ||
                    (evolution && global.selectedGreedy == 10)
                    )
                {
                    // sort rects from min largest side to max largest side
                    tools.QuickSortRectByLargestSizeInc(0,
                        solution.BoardList[solution.BoardList.Count - 1].RectList.Count - 1, solution.BoardList[solution.BoardList.Count - 1].RectList);
                }
                else if((global.Verschnittoptimierung.radioButton_largestSideDec.Checked && !evolution) ||
                    (evolution && global.selectedGreedy == 3) ||
                    (evolution && global.selectedGreedy == 4) ||
                    (evolution && global.selectedGreedy == 11) ||
                    (evolution && global.selectedGreedy == 12)
                    )
                {
                    // sort rects from min largest side to max largest side
                    tools.QuickSortRectByLargestSideDec(0,
                        solution.BoardList[solution.BoardList.Count - 1].RectList.Count - 1, solution.BoardList[solution.BoardList.Count - 1].RectList);
                }
                else if((global.Verschnittoptimierung.radioButton_sizeInc.Checked) ||
                    (evolution && global.selectedGreedy == 5) ||
                    (evolution && global.selectedGreedy == 6) ||
                    (evolution && global.selectedGreedy == 13) ||
                    (evolution && global.selectedGreedy == 14)
                    )
                {
                    // sort rects from min size to max size
                    tools.QuickSortRectBySizeInc(0,
                        solution.BoardList[solution.BoardList.Count - 1].RectList.Count - 1, solution.BoardList[solution.BoardList.Count - 1].RectList);
                }
                else if((global.Verschnittoptimierung.radioButton_sizeDec.Checked) ||
                    (evolution && global.selectedGreedy == 7) ||
                    (evolution && global.selectedGreedy == 8) ||
                    (evolution && global.selectedGreedy == 15) ||
                    (evolution && global.selectedGreedy == 16)
                    )
                {
                    // sort rects from max size to min size
                    tools.QuickSortRectBySizeDec(0,
                        solution.BoardList[solution.BoardList.Count - 1].RectList.Count - 1, solution.BoardList[solution.BoardList.Count - 1].RectList);
                }
                if(!evolution)
                {
                    global.runningProcess.firstStep = false;
                }
            }
            // END one time

            // for each rect on collectionBoard
            for (int i = (evolution ? global.nextStepGreedyEvo : global.runningProcess.nextStep);
                i < solution.BoardList[solution.BoardList.Count - 1].RectList.Count;)
            {
                if(!evolution)
                {
                    global.runningProcess.state = 1;
                }

                // sort boards from max free space to least free space
                List<int> boardNrSorted = tools.SortBoardsBySize(solution.BoardList);

                // for each board try to place the rect
                for (int j = 0; j < boardNrSorted.Count - 1; j++)
                {
                    // try place the rect
                    // 1. is the space as area enough for the board? (without finding a specific place)
                    // calculate boardSizeEffective
                    int boardSizeEffective = solution.BoardList[boardNrSorted[j]].size;
                    for (int k = 0; k < solution.BoardList[boardNrSorted[j]].RectList.Count; k++)
                    {
                        boardSizeEffective -= solution.BoardList[boardNrSorted[j]].RectList[k].size;
                    }
                    if (boardSizeEffective < solution.BoardList[solution.BoardList.Count - 1].RectList[i].size)
                    {
                        // rect is too large, cannot be placed on any of the boards.
                        // has to remain on the collectionBoard
                        if(!evolution)
                        {
                            classificationNumbers.GetAndShowAllClassificationNumbers();
                        }
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
                    /*
                    rect.edgeLeftUp.x = solution.BoardList[solution.BoardList.Count - 1].RectList[i].edgeLeftUp.x;
                    rect.edgeLeftUp.y = solution.BoardList[solution.BoardList.Count - 1].RectList[i].edgeLeftUp.y;
                    rect.edgeRightDown.x = solution.BoardList[solution.BoardList.Count - 1].RectList[i].edgeRightDown.x;
                    rect.edgeRightDown.y = solution.BoardList[solution.BoardList.Count - 1].RectList[i].edgeRightDown.y;
                    */

                    // reset values in global
                    global.positionsManaged = new List<Position>();
                    global.positionsValid = new List<Position>();
                    global.bestPositionSet = false;

                    // TODO: this part(vertical, then horizontal / or only one if equal) should be moved to GetValidPos()
                    // first vertical, then horizontal
                    if (rect.width == rect.height)
                    {
                        rect.edgeLeftUp.x = 0;
                        rect.edgeLeftUp.y = rect.height;
                        rect.edgeRightDown.x = rect.width;
                        rect.edgeRightDown.y = 0;

                        GetValidPositions(solution.BoardList[boardNrSorted[j]].RectList, rect, evolution);
                    }
                    else
                    {
                        // 1. vertical
                        if (rect.width > rect.height)
                        {
                            int helper = rect.width;
                            rect.width = rect.height;
                            rect.height = helper;
                        }
                        rect.edgeLeftUp.x = 0;
                        rect.edgeLeftUp.y = rect.height;
                        rect.edgeRightDown.x = rect.width;
                        rect.edgeRightDown.y = 0;

                        GetValidPositions(solution.BoardList[boardNrSorted[j]].RectList, rect, evolution);
                        // 2. horizontal
                        if (rect.height > rect.width)
                        {
                            int helper = rect.width;
                            rect.width = rect.height;
                            rect.height = helper;
                        }
                        rect.edgeLeftUp.x = 0;
                        rect.edgeLeftUp.y = rect.height;
                        rect.edgeRightDown.x = rect.width;
                        rect.edgeRightDown.y = 0;

                        GetValidPositions(solution.BoardList[boardNrSorted[j]].RectList, rect, evolution);
                    }
                    
                    // select the best position of the valid ones
                    SelectBestPosition(evolution);

                    Boolean rectPlaced = false;

                    if (global.bestPositionSet == true)
                    {
                        // 1. show valid positions 

                        // 2. show best position

                        // 3. place best position
                        rect.edgeLeftUp.x = global.bestPosition.edgeLeftUp.x;
                        rect.edgeLeftUp.y = global.bestPosition.edgeLeftUp.y;
                        rect.edgeRightDown.x = global.bestPosition.edgeRightDown.x;
                        rect.edgeRightDown.y = global.bestPosition.edgeRightDown.y;

                        solution.BoardList[boardNrSorted[j]].RectList.Add(rect);
                        //solution.BoardList[solution.BoardList.Count - 1].RectList.Remove(rect);
                        solution.BoardList[solution.BoardList.Count - 1].RectList.RemoveAt(i);

                        // ....
                        rectPlaced = true;
                        // show can't be called from here

                        if(!evolution)
                        {
                            Show show = new Show(global);
                            show.ShowSolution(global.solution);
                        }
                    }

                    // last rect tried?
                    if (solution.BoardList[solution.BoardList.Count - 1].RectList.Count == 0 ||
                        (solution.BoardList[solution.BoardList.Count - 1].RectList.Count - 1) < (evolution ? global.nextStepGreedyEvo : global.runningProcess.nextStep))
                    {
                        if(!evolution)
                        {
                            global.runningProcess.existing = false;
                            global.runningProcess.state = 0;
                            classificationNumbers.GetAndShowAllClassificationNumbers();
                        }
                        break;
                    }


                    if (rectPlaced)
                    {
                        if(!evolution)
                        {
                            global.runningProcess.state = 0;
                            classificationNumbers.GetAndShowAllClassificationNumbers();
                        }
                        break;
                    }
                    if (!rectPlaced)
                    {
                        if(!evolution)
                        {
                            global.runningProcess.nextStep++;
                        }
                        else
                        {
                            global.nextStepGreedyEvo++;
                        }
                        i++;

                        if ((solution.BoardList[solution.BoardList.Count - 1].RectList.Count - 1) < (evolution ? global.nextStepGreedyEvo : global.runningProcess.nextStep))
                        {
                            if(!evolution)
                            {
                                global.runningProcess.existing = false;
                                global.runningProcess.state = 0;
                                classificationNumbers.GetAndShowAllClassificationNumbers();
                            }
                            break;
                        }
                    }
                }

                if(!evolution && global.runningProcess.stepType == 0)
                {
                    global.runningProcess.state = 0;
                    classificationNumbers.GetAndShowAllClassificationNumbers();
                    break;
                }
            }
            if(!evolution)
            {
                global.runningProcess.state = 0;
                classificationNumbers.GetAndShowAllClassificationNumbers();
            }
            return solution;
        }











        // gets the best position for the rect on the board
        // the rect given to this method does not have to be initialized on 0/0
        public void GetValidPositions(List<Rect> rectList, Rect rect, Boolean evolution)
        {
            // position = position of rect 0/0
            Position position = new Position();
            position.edgeLeftUp.x = 0;
            position.edgeLeftUp.y = rect.height;
            position.edgeRightDown.x = rect.width;
            position.edgeRightDown.y = 0;
            
            // largest part of this method, recursive
            ManagePosition(rectList, rect, position, evolution);
        }

        // one step for a single position
        public void ManagePosition(List<Rect> rectList, Rect rect, Position position, Boolean evolution)
        {
            Base global = Base.GetInstance();
            // 1.1 position out of borders? (boardHeight<rectY etc.)
            // TODO: general board width/height not set, therefore using height/width of the first board in the solution
            if (position.edgeLeftUp.y > global.solution.BoardList[0].height || position.edgeRightDown.x > global.solution.BoardList[0].width)
            {
                return;
            }

            // 1.2 position already managed? (already tried in another recursive call)
            for(int i = 0; i < global.positionsManaged.Count; i++)
            {
                // if yes, stop this method
                if (position.IsEqualPositionAs(global.positionsManaged[i]))
                {
                    return;
                }
            }
            // if no (then the method reaches this point), add to positions managed
            global.positionsManaged.Add(position);

            // 2. collision?
            Collision collision = new Collision();
            Rect rectCopy = new Rect();
            rectCopy.edgeLeftUp.x = position.edgeLeftUp.x;
            rectCopy.edgeLeftUp.y = position.edgeLeftUp.y;
            rectCopy.edgeRightDown.x = position.edgeRightDown.x;
            rectCopy.edgeRightDown.y = position.edgeRightDown.y;
            rectCopy.height = rect.height;
            rectCopy.width = rect.width;
            rectCopy.rectID = rect.rectID;
            List<int> collisionListNr = collision.GetCollisions(rectList, rectCopy);

            if(collisionListNr.Count == 0)
            {
                // 3. add to valid positions
                global.positionsValid.Add(position);
                if(!evolution && global.Verschnittoptimierung.radioButton_FirstFitFilling.Checked ||
                    global.selectedGreedy <= 8
                    )
                {
                    return;
                }
            }
            else
            {
                // for all collisions
                for (int i = 0; i < collisionListNr.Count; i++)
                {
                    // move up and try again
                    // 1. move up
                    Position positionUp = new Position();
                    positionUp.SetToPosition(position);
                    positionUp.edgeRightDown.y = rectList[collisionListNr[i]].edgeLeftUp.y;
                    float height = position.edgeLeftUp.y - position.edgeRightDown.y;
                    positionUp.edgeLeftUp.y = positionUp.edgeRightDown.y + height;
                    // 2. try again
                    this.ManagePosition(rectList, rect, positionUp, evolution);

                    // move right and try again
                    // 1. move right
                    Position positionRight = new Position();
                    positionRight.SetToPosition(position);
                    positionRight.edgeLeftUp.x = rectList[collisionListNr[i]].edgeRightDown.x;
                    float width = position.edgeRightDown.x - position.edgeLeftUp.x;
                    positionRight.edgeRightDown.x = positionRight.edgeLeftUp.x + width;
                    // 2. try again
                    this.ManagePosition(rectList, rect, positionRight, evolution);
                }
            }
        }

        // selects the best position out of the ones found
        public void SelectBestPosition(Boolean evolution)
        {
            Position bestPosition;
            Base global = Base.GetInstance();
            if(global.positionsValid.Count > 0)
            {
                bestPosition = global.positionsValid[0];
                
                for (int i = 0; i < global.positionsValid.Count; i++)
                {
                    if(!evolution && global.Verschnittoptimierung.radioButton_min_xl_y.Checked ||
                    (evolution && global.selectedGreedy == 1) ||
                    (evolution && global.selectedGreedy == 3) ||
                    (evolution && global.selectedGreedy == 5) ||
                    (evolution && global.selectedGreedy == 7) ||
                    (evolution && global.selectedGreedy == 9) ||
                    (evolution && global.selectedGreedy == 11) ||
                    (evolution && global.selectedGreedy == 13) ||
                    (evolution && global.selectedGreedy == 15)
                    )
                    {
                        // 1. smallest x-value left
                        if (global.positionsValid[i].edgeLeftUp.x < bestPosition.edgeLeftUp.x)
                        {
                            bestPosition = global.positionsValid[i];
                        }
                        // 1.2 if equal and x-value right smaller
                        if (global.positionsValid[i].edgeLeftUp.x == bestPosition.edgeLeftUp.x &&
                            global.positionsValid[i].edgeRightDown.x < bestPosition.edgeRightDown.x)
                        {
                            bestPosition = global.positionsValid[i];
                        }
                        // 1.3 if equal both x and y-value smaller
                        if (global.positionsValid[i].edgeLeftUp.x == bestPosition.edgeLeftUp.x &&
                           global.positionsValid[i].edgeRightDown.x == bestPosition.edgeRightDown.x &&
                           global.positionsValid[i].edgeLeftUp.y < bestPosition.edgeLeftUp.y)
                        {
                            bestPosition = global.positionsValid[i];
                        }
                    }
                     
                    if(!evolution && global.Verschnittoptimierung.radioButton_min_xr_y.Checked ||
                        (evolution && global.selectedGreedy == 2) ||
                        (evolution && global.selectedGreedy == 4) ||
                        (evolution && global.selectedGreedy == 6) ||
                        (evolution && global.selectedGreedy == 8) ||
                        (evolution && global.selectedGreedy == 10) ||
                        (evolution && global.selectedGreedy == 12) ||
                        (evolution && global.selectedGreedy == 14) ||
                        (evolution && global.selectedGreedy == 16)
                        )
                    {
                        // 2. smallest x-value right
                        if (global.positionsValid[i].edgeRightDown.x < bestPosition.edgeRightDown.x)
                        {
                            bestPosition = global.positionsValid[i];
                        }
                        // 2.1 if x right equal and y-value smaller
                        if (global.positionsValid[i].edgeRightDown.x == bestPosition.edgeRightDown.x &&
                            global.positionsValid[i].edgeLeftUp.y < bestPosition.edgeLeftUp.y)
                        {
                            bestPosition = global.positionsValid[i];
                        }
                    }
                }
                global.bestPosition = bestPosition;
                global.bestPositionSet = true;
            }
            
        }
    }
}
