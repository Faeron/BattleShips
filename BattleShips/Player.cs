using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips
{
    public class Player
    {
        #region fields
        private string _playerId;
        private string _playerName;
        #endregion

        #region properties
        public string PlayerId
        {
            get
            {
                return _playerId;
            }

            set
            {
                _playerId = value;
            }
        }

        public string PlayerName
        {
            get
            {
                return _playerName;
            }

            set
            {
                _playerName = value;
            }
        }
        #endregion

        #region constructor
        public Player()
        {

        }
        #endregion

        #region methods
        #endregion
    }
}
