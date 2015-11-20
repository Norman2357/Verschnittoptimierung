using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verschnittoptimierung
{
    class Creation
    {
        Base global;
        
        float generalBoardWidth;
        float generalBoardHeight;

        float x;
        float y;


        public Creation()
        {
            this.global = Base.GetInstance();
            this.generalBoardWidth = global.generalBoardWidth;
            this.generalBoardHeight = global.generalBoardHeight;
        }

        public void CreateBoards()
        {
            try
            {
                // for testing, numberBoards = 5;
                // later: create objects first, then calculate area, then calculate number of required boards + extra board
                int numberBoards = 5;

                // set global board values in Base/global
                global.numberBoards = numberBoards;

                // create boards in Base/global
                for(int i=1; i <= numberBoards; i++)
                {
                    Board board = new Board();
                    board.boardID = i;
                    board.isCollectionBoard = false;

                    if (i == 1)
                    {
                        // point leftUp
                        x = 0 + global.boardGap;
                        y = 0 + global.boardGap;
                        board.edgeLeftUp = new MyPoint(x, y);
                        // point RightDown
                        x = board.edgeLeftUp.x + generalBoardWidth;
                        y = board.edgeLeftUp.y + generalBoardHeight;
                        board.edgeRightDown = new MyPoint(x, y);
                    }
                    // for even board numbers
                    else if((i%2)==0)
                    {
                        // point leftUp
                        x = global.BoardList[i-2].edgeLeftUp.x;
                        y = global.BoardList[i - 2].edgeRightDown.y + global.boardGap;
                        board.edgeLeftUp = new MyPoint(x, y);
                        // point RightDown
                        x = board.edgeLeftUp.x + generalBoardWidth;
                        y = board.edgeLeftUp.y + generalBoardHeight;
                        board.edgeRightDown = new MyPoint(x, y);
                    }
                    // for odd board numbers
                    else
                    {
                        // point leftUp
                        x = global.BoardList[i - 3].edgeLeftUp.x + generalBoardWidth + global.boardGap;
                        y = global.BoardList[i - 3].edgeLeftUp.y;
                        board.edgeLeftUp = new MyPoint(x, y);
                        // point RightDown
                        x = board.edgeLeftUp.x + generalBoardWidth;
                        y = board.edgeLeftUp.y + generalBoardHeight;
                        board.edgeRightDown = new MyPoint(x, y);
                    }
                    global.BoardList.Add(board);
                }
                // create extra board in Base/global
                Board extraBoard = new Board();
                extraBoard.boardID = global.BoardList[global.BoardList.Count()-1].boardID +1;
                extraBoard.isCollectionBoard = true;
              
                // point leftUp
                x = global.BoardList[global.BoardList.Count() - 1].edgeRightDown.x + global.boardGap * 4;
                y = global.BoardList[0].edgeLeftUp.y;
                extraBoard.edgeLeftUp = new MyPoint(x, y);
                // point RightDown
                x = extraBoard.edgeLeftUp.x + generalBoardWidth * 2;
                y = extraBoard.edgeLeftUp.y + generalBoardHeight;
                extraBoard.edgeRightDown = new MyPoint(x, y);

                global.BoardList.Add(extraBoard);

            // reposition button in display to activate horizontal autoscroll
            if (global.BoardList[global.BoardList.Count() - 1].edgeRightDown.x > global.Verschnittoptimierung.display.Width)
                {
                    global.Verschnittoptimierung.buttonInDisplay.Left = Convert.ToInt32(global.mult * (global.BoardList[global.BoardList.Count() - 1].edgeRightDown.x) + 30);
                    global.Verschnittoptimierung.buttonInDisplay.Visible = true;
                }
            }
            catch
            {

            }
        }
    }
}
