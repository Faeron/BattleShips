using System;
using System.Drawing;
using System.Windows.Forms;

namespace BattleShips
{
    class Board
    {
        #region Fields
        private int _size;
        private int _positionY;
        private int _nbCell;
        private int _cellSize;
        int[][] _map = new int[10][];
        #endregion

        #region Properties
        public int[][] Map
        {
            get
            {
                return _map;
            }

            set
            {
                _map = value;
            }
        }

        public int Size
        {
            get
            {
                return _size;
            }

            set
            {
                _size = value;
            }
        }

        public int PositionY
        {
            get
            {
                return _positionY;
            }

            set
            {
                _positionY = value;
            }
        }

        public int NbCell
        {
            get
            {
                return _nbCell;
            }

            set
            {
                _nbCell = value;
            }
        }

        public int CellSize
        {
            get
            {
                return _cellSize;
            }

            set
            {
                _cellSize = value;
            }
        }
        #endregion

        #region Constructor
        public Board(int pos, int s, int nbCase)
        {
            this.PositionY = pos;
            this.Size = s;
            this.NbCell = nbCase;
            this.CellSize = this.Size / this.NbCell;
        }
        #endregion

        #region Methods
        public void drawGrid(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
            Pen thinPen = new Pen(Color.Black, 2);
            SolidBrush brush = new SolidBrush(Color.White);

            // Create rectangle.
            Rectangle rect = new Rectangle(this.PositionY, 20, this.Size, this.Size);

            // Draw rectangle to screen.
            e.Graphics.FillRectangle(brush, rect);
            e.Graphics.DrawRectangle(blackPen, this.PositionY - 2, 18, this.Size + 3, this.Size + 3);

            Console.WriteLine(this.CellSize);
            //e.Graphics.DrawLine(thinPen, x, y, 200, 200);

            //Draw column
            for (int x = 0; x < this.Size; x += this.CellSize)
            {
                e.Graphics.DrawLine(thinPen, x + this.PositionY, 20, x + this.PositionY, this.Size + 20);
            }

            //Draw line
            for (int y = 0; y < this.Size; y += this.CellSize)
            {
                //e.Graphics.DrawLine(thinPen, this.PositionY, y, 200, this.Size + 20);
            }
        }
        #endregion
    }
}
