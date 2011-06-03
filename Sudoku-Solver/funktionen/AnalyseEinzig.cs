using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver
{
    class AnalyseEinzig
    {
        public static void start()
        {
            SudokuMain.loesungVersuch++;
            SudokuMain.einzigartig = 0;
            SudokuMain.squareFound = 0;
            SudokuMain.pairFound = 0;
            string fPath = @"txt\debug2.txt";
            string debug = "";
            TxtVerarbeitung.writeLine(fPath, "################Analyse Einzig(try:" + SudokuMain.loesungVersuch + ")################");
            for (int a = 0; a < 81; a++)
            {
                if (SudokuMain.moeglichkeitenString[a] != null)
                {

                    /// <summary>
                    /// Wenn es nur eine Möglichkeit gibt wird diese eingetragen.
                    /// </summary>

                    if (SudokuMain.moeglichkeitenString[a].Length >= 1)
                    {
                        int x = Convert.ToInt32(SudokuMain.indexString[a].Substring(0, 1));
                        int y = Convert.ToInt32(SudokuMain.indexString[a].Substring(1, 1));
                        debug = "Feld: " + x + "" + y + ":" + SudokuMain.moeglichkeitenString[a];

                    }
                    if (SudokuMain.moeglichkeitenString[a].Length == 1)
                    {
                        int x = Convert.ToInt32(SudokuMain.indexString[a].Substring(0, 1));
                        int y = Convert.ToInt32(SudokuMain.indexString[a].Substring(1, 1));
                        SudokuMain.ausgabeSudoku[x, y] = Convert.ToInt32(SudokuMain.moeglichkeitenString[a]);
                        SudokuMain.einzigartig = 1;
                        debug += " GESETZT";
                        SudokuMain.zahlGefunden++;
                    }
                    if (SudokuMain.moeglichkeitenString[a].Length >= 1)
                    {
                        TxtVerarbeitung.writeLine(fPath, debug);
                    }

                }
            }
            TxtVerarbeitung.writeLine(fPath, "################Ende################");
            TxtVerarbeitung.writeLine(fPath, "");
        }
    }
}
