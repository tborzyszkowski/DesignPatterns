using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie
{
    class Board
    {
        private static Board Instance = null;
        private Field[,] boardFields;
        private List<AbstractCharacter> characters;
        private Board(List<AbstractCharacter> _characters) {
            boardFields = new Field[10,10];
            characters = _characters;
        }

        public static Board GetBoardInstance(List<AbstractCharacter> characters) {

            if (Instance == null) {
                Board Instance = new Board(characters);
            }
            return Instance;
        }
    }
}
