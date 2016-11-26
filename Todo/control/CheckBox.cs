using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.control {
    class CheckBox {

        // Size of the box
        private int size = 50;

        private Color colorBox;
        private Color colorTick;

        private Pen tickPen;
        private Pen boxPen;

        // The top left corner of the checkbox
        private Point startBox;

        private Point startSmallTick;
        private Point endSmallTick;

        private Point startLargeTick;
        private Point endLargeTick;

        // If the check box if checked or not
        private bool ticked;

        /**
         * Constructor for checkbox
         * **/
        public CheckBox(Point startPoint) {
            this.startBox = startPoint;
            this.ticked = true;
            this.boxPen = new Pen(Color.Black);
            this.tickPen = new Pen(Color.Green,3);
            tickPen.Alignment = PenAlignment.Center;
            calculateTickLocations();
        }

        public void setTickColor(Color color) {
            tickPen.Color = color;
        }

        public void setBoxColor(Color color) {
            boxPen.Color = color;
        }

        public void updateLocation(Point newPoint) {
            startBox = newPoint;
            calculateTickLocations(); // Need to recalculate the tick location
        }
        

        private void calculateTickLocations() {
            Point centerPoint = new Point(startBox.X + (size / 2),startBox.Y + (size / 2));

            startSmallTick.X = centerPoint.X - (size / 2);
            startSmallTick.Y = centerPoint.Y - (size);

            endSmallTick.Y = centerPoint.Y;
            endSmallTick.X = centerPoint.X;

            startLargeTick.X = centerPoint.X;
            startLargeTick.Y = centerPoint.Y;

            endLargeTick.X = (int)(centerPoint.X + size * 1.5);
            endLargeTick.Y = (int)(centerPoint.Y - size * 1.5);
        }

        public bool containsPoint(Point p) {
            return p.X > startBox.X && p.X < (startBox.X + size) && p.Y > startBox.Y && p.Y < (startBox.Y + size);
        }

        public void checkClickedOn(Point p) {
            ticked = containsPoint(p) ? !ticked : ticked;
        }

        public void draw(Graphics g) {
            g.DrawRectangle(this.boxPen,startBox.X, startBox.Y, size,size);
            
            if (ticked) {
                Console.WriteLine("Drawing tick");
                g.DrawLine(tickPen, startSmallTick, endSmallTick);
                g.DrawLine(tickPen, startLargeTick, endLargeTick);
            }
        }
    }
}
