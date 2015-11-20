using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Verschnittoptimierung
{
    class StepExecution
    {
        Base global;

        public StepExecution()
        {
            this.global = Base.GetInstance();
        }

        public void ExecuteStep(int stepType)
        {
            Base global = Base.GetInstance();

            // for testing only
            if(global.Verschnittoptimierung.comboBox1.Text.Equals("Create Board(s) + Objects"))
            {

            }

            switch(global.Verschnittoptimierung.comboBox1.Text)
            {
                case "Create Board(s) + Objects":
                    
                    // get board values from user interface
                    float generalBoardHeight = (float)(global.Verschnittoptimierung.boardHeight.Value);
                    float generalBoardWidth = (float)(global.Verschnittoptimierung.boardWidth.Value);
                    if(generalBoardHeight >= generalBoardWidth)
                    {
                        float h = generalBoardWidth;
                        generalBoardWidth = generalBoardHeight;
                        generalBoardHeight = h;
                    }

                    // set global board values in Base/global
                    global.generalBoardHeight = generalBoardHeight;
                    global.generalBoardWidth = generalBoardWidth;

                    // create and draw board(s)
                    CalculateMult();
                    Creation creation = new Creation();
                    creation.CreateBoards();
                    DrawBoards();
                    break;
                case "Fill":
                    break;
                case "Local Optimization":
                    break;
                case "Evolutionary Algorithm":
                    break;
                default:
                    break;    
            }
            
            /*
            //global.Verschnittoptimierung.display.;
            using (Graphics g = global.Verschnittoptimierung.display.CreateGraphics())
            {
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    Brush brush = new SolidBrush(Color.DarkBlue);
                    g.TranslateTransform(global.Verschnittoptimierung.display.AutoScrollPosition.X, global.Verschnittoptimierung.display.AutoScrollPosition.Y);
                    g.DrawRectangle(pen, 100, 100, 100, 200);
                }   
            }
            */
        }

        public void DrawBoards()
        {
            MyPoint edgeLeftUp;
            MyPoint edgeRightDown;


            for (int i = 0; i < global.BoardList.Count(); i++)
            {
                //global.Verschnittoptimierung.display.;
                using (Graphics g = global.Verschnittoptimierung.display.CreateGraphics())
            {
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    
                        edgeLeftUp = new MyPoint(global.BoardList[i].edgeLeftUp.x, global.BoardList[i].edgeLeftUp.y);
                        edgeRightDown = new MyPoint(global.BoardList[i].edgeRightDown.x, global.BoardList[i].edgeRightDown.y);

                        edgeLeftUp = Resize(edgeLeftUp);
                        edgeRightDown = Resize(edgeRightDown);

                        Brush brush = new SolidBrush(Color.AliceBlue);
                        g.TranslateTransform(global.Verschnittoptimierung.display.AutoScrollPosition.X, global.Verschnittoptimierung.display.AutoScrollPosition.Y);
                        
                        g.DrawRectangle(pen, edgeLeftUp.x, edgeLeftUp.y,
                            edgeRightDown.x - edgeLeftUp.x,
                            edgeRightDown.y - edgeLeftUp.y);

                        g.FillRectangle(brush, edgeLeftUp.x, edgeLeftUp.y,
                            edgeRightDown.x - edgeLeftUp.x,
                            edgeRightDown.y - edgeLeftUp.y);
                    }
                }
            }     
        }
        public void DrawRects()
        {

        }
        public MyPoint Resize(MyPoint point)
        {
            point.x *= global.mult;
            point.y *= global.mult;
            return point;            
        }
        public void CalculateMult()
        {
            float yBoardGeneral;
            // calculate y of board general (= height of one board on the screen)
            yBoardGeneral = (global.Verschnittoptimierung.display.Height - (3 * global.boardGap)) / 2;

            // calculate mult
            global.mult = yBoardGeneral / global.generalBoardHeight;
        }


        public void Test()
        {
            using (Graphics g = global.Verschnittoptimierung.display.CreateGraphics())
            {
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    Brush brush = new SolidBrush(Color.DarkBlue);
                    g.TranslateTransform(global.Verschnittoptimierung.display.AutoScrollPosition.X, global.Verschnittoptimierung.display.AutoScrollPosition.Y);
                    g.DrawRectangle(pen, 100, 100, 100, 200);
                }
            }
        }

    }
}
