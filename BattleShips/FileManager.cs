using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace BattleShips
{
    public class FileManager
    {
        #region fields
        private string _filename;
        private int _boardWidth;
        private int _boardHeight;

        // Default values
        private string _defaultFilename = "BN-V02-2015-12-02-15-31-32.xml";
        private int _defaultBoardWidth = 10;
        private int _defaultBoardHeight = 10;
        #endregion

        #region properties
        public string Filename
        {
            get
            {
                return _filename;
            }

            set
            {
                _filename = value;
            }
        }

        public int BoardWidth
        {
            get
            {
                return _boardWidth;
            }

            set
            {
                _boardWidth = value;
            }
        }

        public int BoardHeight
        {
            get
            {
                return _boardHeight;
            }

            set
            {
                _boardHeight = value;
            }
        }

        #endregion

        #region constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public FileManager()
        {
            this.Filename = this._defaultFilename;
            this.BoardWidth = this._defaultBoardWidth;
            this.BoardHeight = this._defaultBoardHeight;
        }

        /// <summary>
        /// Custom constructor
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="boardWidth"></param>
        /// <param name="boardHeight"></param>
        public FileManager(string filename, int boardWidth, int boardHeight)
        {
            this.Filename = filename;
            this.BoardWidth = boardWidth;
            this.BoardHeight = boardHeight;
        }
        #endregion

        #region unused functions
        /// <summary>
        /// UNUSED, gets the player board depending on his id
        /// from a .txt or similar file.
        /// </summary>
        /// <param name="idPlayer"></param>
        /// <returns>Returns a 2d array of ints</returns>
        public int[][] getPlayerBoardFromTxt(int idPlayer)
        {
            // Create an array for the board
            int[][] playerBoard = new int[10][];
            // String to check
            string strCheckBegin = "[PLATEAU-P" + idPlayer + "]";
            string strCheckEnd = "[/PLATEAU-P" + idPlayer + "]";
            bool shouldRead = false;
            int index = 0;

            // Open the file to play and get it's filename
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Title = "Browse for a file to open";
            openDlg.Filter = "Battleship file (*.bnav) |*.bnav;";
            openDlg.ShowDialog();
            string selectedFileName = openDlg.FileName;

            // Check for blank filename
            if (selectedFileName != "")
            {
                // Get the lines of the file
                foreach (var line in File.ReadLines(selectedFileName))
                {
                    if (line.Contains(strCheckEnd))
                    {
                        shouldRead = false;
                    }
                    // We only read what is between the two tags
                    if (shouldRead)
                    {
                        // Get each value separated by a semicolon and store it in the array
                        var value = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                        Console.WriteLine(value);
                        index++;
                    }
                    if (line.Contains(strCheckBegin))
                    {
                        shouldRead = true;
                    }
                }
            }

            return playerBoard;
        }
        #endregion

        #region methods
        /// <summary>
        /// Gets a node's content
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public string getNode(string nodeName) {
            string result = "";

            // Check for blank filename
            if (this.Filename != "")
            {
                // Create and load a document
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(this.Filename);
                // Get the player's board with his id
                XmlNode node = xmlDoc.DocumentElement.SelectSingleNode(nodeName);
                result = node.InnerText;
            }
            else {
                return "ERROR";
            }

            return result;
        }

        

        /// <summary>
        /// Gets a player board via a ".xml" formatted file
        /// </summary>
        /// <param name="idPlayer"></param>
        /// <returns></returns>
        public int[,] getPlayerBoard(int idPlayer)
        {
            // Create an array for the board
            int[,] playerBoard = new int[this.BoardHeight, this.BoardWidth];
            string xmlString = "";
            string selectedFileName = this.Filename;

            // Get the player's node with his ID
            xmlString = this.getNode("PLATEAU-P" + idPlayer);

            // If we got the node
            if (xmlString != "") {
                // Get an array of string and fiter out the undesirable values
                string[] xmlStringArray = xmlString.Split(new char[] { ';', '\r', '\n', '\t'}, StringSplitOptions.RemoveEmptyEntries);
                // Convert the string array to int
                int[] tempIntArray = Array.ConvertAll(xmlStringArray, int.Parse);

                // Convert 1D array to 2D array
                int index = 0;
                for (int i = 0; i < this.BoardHeight; i++)
                {
                    for (int j = 0; j < this.BoardWidth; j++)
                    {
                        playerBoard[i,j] = tempIntArray[index];
                        index++;
                    }
                }
            }
            
            return playerBoard;
        }
        #endregion
    }
}
