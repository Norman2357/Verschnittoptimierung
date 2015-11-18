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

            
            

            int displayWidth = global.Verschnittoptimierung.display.Width;
            int displayHeight = global.Verschnittoptimierung.display.Height;
            int displayBorder = 5;

            int boardWidth = 600;
            int boardHeight = 400;

            int boardWidthResized;
            int boardHeightResized;

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
            



        }

        public void DrawBoard()
        {
            MyPoint edgeLeftUp;
            MyPoint edgeRightDown;

            //global.Verschnittoptimierung.display.;
            using (Graphics g = global.Verschnittoptimierung.display.CreateGraphics())
            {
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    for (int i = 0; i < global.BoardList.Count(); i++)
                    {
                        edgeLeftUp = new MyPoint(global.BoardList[i].edgeLeftUp.x, global.BoardList[i].edgeLeftUp.y);
                        edgeRightDown = new MyPoint(global.BoardList[i].edgeRightDown.x, global.BoardList[i].edgeRightDown.y);

                        edgeLeftUp = Resize(edgeLeftUp);
                        edgeRightDown = Resize(edgeRightDown);

                        Brush brush = new SolidBrush(Color.DarkBlue);
                        
                        g.DrawRectangle(pen, edgeLeftUp.x, edgeLeftUp.y,
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
            global.mult = global.Verschnittoptimierung.display.Height/
                ((global.Verschnittoptimierung.display.Height
                - 3 * global.boardGap)
                / 2);
        }

    }
}
