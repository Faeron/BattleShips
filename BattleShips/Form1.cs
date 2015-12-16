using System.Windows.Forms;

namespace BattleShips
{
    public partial class Form1 : Form
    {
        Game Game = new Game();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Game.OnPaint(e);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Game.focusedCell(e);
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            this.Refresh();
        }
    }
}
