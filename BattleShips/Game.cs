using System.Windows.Forms;

namespace BattleShips
{
    class Game
    {
        #region Fields
        Board _myBoard;
        Board _ennemyBoard;
        #endregion

        #region Properties
        internal Board MyBoard
        {
            get
            {
                return _myBoard;
            }

            set
            {
                _myBoard = value;
            }
        }

        internal Board EnnemyBoard
        {
            get
            {
                return _ennemyBoard;
            }

            set
            {
                _ennemyBoard = value;
            }
        }
        #endregion

        #region Constructor
        public Game()
        {
            int[,] mapTmp = new int[10, 10] {
                 { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 },
                 { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 },
                 { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 },
                 { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 },
                 { 1, 2, 2, 2, 3, 2, 1, 2, 1, 2 },
                 { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 },
                 { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 },
                 { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 },
                 { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 },
                 { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 }
            };

            this.MyBoard = new Board(20, 20, mapTmp);

            int[,] mapEnnemyTmp = new int[10, 10] {
                 { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 },
                 { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 },
                 { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 },
                 { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 },
                 { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 },
                 { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 },
                 { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 },
                 { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 },
                 { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 },
                 { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 }
            };

            this.EnnemyBoard = new Board(20, 450, mapEnnemyTmp);
        }
        #endregion

        #region Methods
        public void OnPaint(PaintEventArgs e)
        {
            MyBoard.drawGrid(e);
            EnnemyBoard.drawGrid(e);
        }

        public void focusedCell(MouseEventArgs e)
        {
            MyBoard.focusedCell(e);
            //EnnemyBoard.focusedCell(e);
        }
        #endregion
    }
}
