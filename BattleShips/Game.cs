using System.Windows.Forms;

namespace BattleShips
{
    class Game
    {
        #region Fields
        Board _myBoard = new Board(20, 400, 10);
        Board _ennemyBoard = new Board(440, 400, 10);
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
            
        }
        #endregion

        #region Methods
        public void OnPaint(PaintEventArgs e)
        {
            MyBoard.drawGrid(e);
            EnnemyBoard.drawGrid(e);
        }
        #endregion
    }
}
