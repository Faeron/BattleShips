using System;
using System.Drawing;
using System.Windows.Forms;

namespace BattleShips
{
    class Cell
    {
        #region Fields
        private int _cellType;
        private int _posX;
        private int _posY;
        private int _sizeX;
        private int _sizeY;
        private Pen _borderColor;
        private SolidBrush _innerColor;
        #endregion

        #region Properties
        public int PosX
        {
            get
            {
                return _posX;
            }

            set
            {
                _posX = value;
            }
        }

        public int PosY
        {
            get
            {
                return _posY;
            }

            set
            {
                _posY = value;
            }
        }

        public int SizeX
        {
            get
            {
                return _sizeX;
            }

            set
            {
                _sizeX = value;
            }
        }

        public int SizeY
        {
            get
            {
                return _sizeY;
            }

            set
            {
                _sizeY = value;
            }
        }

        public Pen BorderColor
        {
            get
            {
                return _borderColor;
            }

            set
            {
                _borderColor = value;
            }
        }

        public SolidBrush InnerColor
        {
            get
            {
                return _innerColor;
            }

            set
            {
                _innerColor = value;
            }
        }

        public int CellType
        {
            get
            {
                return _cellType;
            }

            set
            {
                _cellType = value;
            }
        }
        #endregion

        #region Constructor
        public Cell(int posX, int posY, int sizeX, int sizeY, int typeOfCell, Pen borderColor, SolidBrush innercolor)
        {
            this.PosX = posX;
            this.PosY = posY;
            this.SizeX = sizeX;
            this.SizeY = sizeY;
            this.CellType = typeOfCell;
            this.InnerColor = innercolor;
            this.BorderColor = borderColor;
        }
        #endregion

        #region Methods
        public void draw(PaintEventArgs e)
        {
            /*this.BorderColor = borderColor;
            this.InnerColor = innercolor;*/

            // Create rectangle.
            Rectangle rect = new Rectangle(this.PosY, this.PosX, this.SizeX, this.SizeX);

            // Draw rectangle to screen.
            e.Graphics.FillRectangle(this.InnerColor, rect);
            e.Graphics.DrawRectangle(this.BorderColor, this.PosY, this.PosX, this.SizeX, this.SizeY);
        }

        public bool cursorIsOnCell(MouseEventArgs e)
        {
            if (e.X > this.PosX && e.X < (this.PosX + this.SizeX))
            {
                if (e.Y > this.PosY && e.Y < (this.PosY + this.SizeY))
                {
                    return true;
                }
            }

            return false;
        }
        #endregion
    }
}
