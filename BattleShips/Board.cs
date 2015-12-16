using System;
using System.Drawing;
using System.Windows.Forms;

namespace BattleShips
{
    class Board
    {
        #region Fields
        private int _positionY;
        private int _positionX;
        private int _nbCellByColumn;
        private int _nbCellByLine;
        private int[,] _mapTmp;
        private Cell[,] _map;
        private Pen thinPen;
        private SolidBrush brush;

        private const int cellSize = 40;
        #endregion

        #region Properties
        public Cell[,] Map
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

        public int NbCellByLine
        {
            get
            {
                return _nbCellByLine;
            }

            set
            {
                _nbCellByLine = value;
            }
        }

        public int[,] MapTmp
        {
            get
            {
                return _mapTmp;
            }

            set
            {
                _mapTmp = value;
            }
        }

        public int NbCellByColumn
        {
            get
            {
                return _nbCellByColumn;
            }

            set
            {
                _nbCellByColumn = value;
            }
        }

        public int CellSize
        {
            get
            {
                return cellSize;
            }
        }

        public int PositionX
        {
            get
            {
                return _positionX;
            }

            set
            {
                _positionX = value;
            }
        }

        public Pen ThinPen
        {
            get
            {
                return thinPen;
            }

            set
            {
                thinPen = value;
            }
        }

        public SolidBrush Brush
        {
            get
            {
                return brush;
            }

            set
            {
                brush = value;
            }
        }
        #endregion

        #region Constructor
        public Board(int posX, int posY, int[,] board)
        {
            this.PositionX = posX;
            this.PositionY = posY;
            this.NbCellByColumn = board.GetLength(1);
            this.NbCellByLine = board.GetLength(0);
            this.MapTmp = board;

            this.createBoard();
        }
        #endregion

        #region Methods
        public void createBoard()
        {
            this.Map = new Cell[this.NbCellByColumn, this.NbCellByLine];

            for (int y = 0; y < this.NbCellByColumn; y++)
            {
                for (int x = 0; x < this.NbCellByLine; x++)
                {
                    this.Map[y, x] = new Cell((this.CellSize * x) + (x * 2) + PositionX, (this.CellSize * y) + (y * 2) + PositionY, this.CellSize, this.CellSize, this.MapTmp[x, y], new Pen(Color.Black, 1), new SolidBrush(Color.White));
                }
            }
        }

        public void drawGrid(PaintEventArgs e)
        {
            foreach (var cell in this.Map)
            {
                cell.draw(e);
            }
        }

        public void focusedCell(MouseEventArgs e)
        {
            
            foreach (var cell in this.Map)
            {
                if (cell.cursorIsOnCell(e))
                {
                    cell.BorderColor = new Pen(Color.Red, 2);
                }
                else if (cell.BorderColor.Color == Color.Red)
                {
                    cell.BorderColor = new Pen(Color.Black, 1);
                }
            }
        }
        #endregion
    }
}
