using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver
{
    class AnalyseSquareEinzig
    {
        /// <summary>
        /// Überprüfen ob eine zahl von moeglichkeiten 
        /// eines Feldes nur einmal in ihrem 3x3 feld vorkommt
        /// </summary>
        public static void start()
        {
            /// <summary>
            /// Anfangen den moeglichkeitenString auszulesen.
            /// </summary>
            string fPath = @"txt\debug2.txt";
            string debug;
            SudokuMain.loesungVersuch++;
            TxtVerarbeitung.writeLine(fPath, "################Analyse Squares(try:" + SudokuMain.loesungVersuch + ")################");
            for (int a = 0; a < 81; a++)
            {
                if (SudokuMain.moeglichkeitenString[a] != null)
                {
                    if (SudokuMain.moeglichkeitenString[a].Length > 0)
                    {
                        /// <summary>
                        /// x und y Position aus dem indexString holen
                        /// </summary>
                        int x = Convert.ToInt32(SudokuMain.indexString[a].Substring(0, 1));
                        int y = Convert.ToInt32(SudokuMain.indexString[a].Substring(1, 1));

                        debug = "Feld: " + x + "" + y + ":" + SudokuMain.moeglichkeitenString[a];
                        TxtVerarbeitung.writeLine(fPath, debug);

                        /// <summary>
                        /// Starten der Prüfung.
                        /// </summary>
                        for (int i = 0; i < SudokuMain.moeglichkeitenString[a].Length; i++)
                        {
                            SudokuMain.zahlVorhanden = 0;
                            int temp = Convert.ToInt32(SudokuMain.moeglichkeitenString[a].Substring(i, 1));

                            /// <summary>
                            /// Square 1 (links oben) 
                            /// </summary>
                            if (x < 3 && y < 3) { chkSquare1(temp, a); }

                            /// <summary>
                            /// Square 2 (mitte oben)
                            /// </summary>
                            if (x < 3 && y > 2 && y < 6) { chkSquare2(temp, a); }

                            /// <summary>
                            /// Square 3 (rechts oben)
                            /// </summary>
                            if (x < 3 && y > 5) { chkSquare3(temp, a); }

                            /// <summary>
                            /// Square 4 (links mitte)
                            /// </summary>
                            if (x > 2 && x < 6 && y < 3) { chkSquare4(temp, a); }

                            /// <summary>
                            /// Square 5 (mitte)
                            /// </summary>
                            if (x > 2 && x < 6 && y > 2 && y < 6) { chkSquare5(temp, a); }

                            /// <summary>
                            /// Square 6 (rechts mitte)
                            /// </summary>
                            if (x > 2 && x < 6 && y > 5) { chkSquare6(temp, a); }

                            /// <summary>
                            /// Square 7 (links unten)
                            /// </summary>
                            if (x > 5 && y < 3) { chkSquare7(temp, a); }

                            /// <summary>
                            /// Square 8 (mitte unten)
                            /// </summary>
                            if (x > 5 && y > 2 && y < 6) { chkSquare8(temp, a); }

                            /// <summary>
                            /// Square 9 (rechts unten)
                            /// </summary>
                            if (x > 5 && y > 5) { chkSquare9(temp, a); }

                            /// <summary>
                            /// Sollte sie einzigartig sein im 3x3 feld wird sie direkt gesetzt
                            /// </summary>
                            if (SudokuMain.zahlVorhanden == 0)
                            {
                                SudokuMain.ausgabeSudoku[x, y] = temp;
                                SudokuMain.squareFound = 1;
                                debug = "Feld: " + x + "" + y + ":" + temp + " GESETZT";
                                TxtVerarbeitung.writeLine(fPath, debug);
                                SudokuMain.zahlGefunden++;
                            }
                        }
                    }
                }
            }
            TxtVerarbeitung.writeLine(fPath, "################Ende################");
            TxtVerarbeitung.writeLine(fPath, "");
        }

        /// <summary>
        /// Square 1 pruefen.
        /// </summary>
        public static void chkSquare1(int temp, int x)
        {
            for (int a = 0; a < 3; a++)
            {
                for (int b = 0; b < 3; b++)
                {
                    int i = SudokuMain.indexArray[a, b];
                    if (SudokuMain.moeglichkeitenString[i].Contains(Convert.ToString(temp)) == true && i != x)
                    {
                        SudokuMain.zahlVorhanden = 1;
                    }
                }
            }
        }

        /// <summary>
        /// Square 2 pruefen.
        /// </summary>
        public static void chkSquare2(int temp, int x)
        {
            for (int a = 0; a < 3; a++)
            {
                for (int b = 3; b < 6; b++)
                {
                    int i = SudokuMain.indexArray[a, b];
                    if (SudokuMain.moeglichkeitenString[i].Contains(Convert.ToString(temp)) == true && i != x)
                    {
                        SudokuMain.zahlVorhanden = 1;
                    }
                }
            }
        }

        /// <summary>
        /// Square 3 pruefen.
        /// </summary>
        public static void chkSquare3(int temp, int x)
        {
            for (int a = 0; a < 3; a++)
            {
                for (int b = 6; b < 9; b++)
                {
                    int i = SudokuMain.indexArray[a, b];
                    if (SudokuMain.moeglichkeitenString[i].Contains(Convert.ToString(temp)) == true && i != x)
                    {
                        SudokuMain.zahlVorhanden = 1;
                    }
                }
            }
        }

        /// <summary>
        /// Square 4 pruefen.
        /// </summary>
        public static void chkSquare4(int temp, int x)
        {
            for (int a = 3; a < 6; a++)
            {
                for (int b = 0; b < 3; b++)
                {
                    int i = SudokuMain.indexArray[a, b];
                    if (SudokuMain.moeglichkeitenString[i].Contains(Convert.ToString(temp)) == true && i != x)
                    {
                        SudokuMain.zahlVorhanden = 1;
                    }
                }
            }
        }

        /// <summary>
        /// Square 5 pruefen.
        /// </summary>
        public static void chkSquare5(int temp, int x)
        {
            for (int a = 3; a < 6; a++)
            {
                for (int b = 3; b < 6; b++)
                {
                    int i = SudokuMain.indexArray[a, b];
                    if (SudokuMain.moeglichkeitenString[i].Contains(Convert.ToString(temp)) == true && i != x)
                    {
                        SudokuMain.zahlVorhanden = 1;
                    }
                }
            }
        }

        /// <summary>
        /// Square 6 pruefen.
        /// </summary>
        public static void chkSquare6(int temp, int x)
        {
            for (int a = 3; a < 6; a++)
            {
                for (int b = 6; b < 9; b++)
                {
                    int i = SudokuMain.indexArray[a, b];
                    if (SudokuMain.moeglichkeitenString[i].Contains(Convert.ToString(temp)) == true && i != x)
                    {
                        SudokuMain.zahlVorhanden = 1;
                    }
                }
            }
        }

        /// <summary>
        /// Square 7 pruefen.
        /// </summary>
        public static void chkSquare7(int temp, int x)
        {
            for (int a = 6; a < 9; a++)
            {
                for (int b = 0; b < 3; b++)
                {
                    int i = SudokuMain.indexArray[a, b];
                    if (SudokuMain.moeglichkeitenString[i].Contains(Convert.ToString(temp)) == true && i != x)
                    {
                        SudokuMain.zahlVorhanden = 1;
                    }
                }
            }
        }

        /// <summary>
        /// Square 8 pruefen.
        /// </summary>
        public static void chkSquare8(int temp, int x)
        {
            for (int a = 6; a < 9; a++)
            {
                for (int b = 3; b < 6; b++)
                {
                    int i = SudokuMain.indexArray[a, b];
                    if (SudokuMain.moeglichkeitenString[i].Contains(Convert.ToString(temp)) == true && i != x)
                    {
                        SudokuMain.zahlVorhanden = 1;
                    }
                }
            }
        }

        /// <summary>
        /// Square 9 pruefen.
        /// </summary>
        public static void chkSquare9(int temp, int x)
        {
            for (int a = 6; a < 9; a++)
            {
                for (int b = 6; b < 9; b++)
                {
                    int i = SudokuMain.indexArray[a, b];
                    if (SudokuMain.moeglichkeitenString[i].Contains(Convert.ToString(temp)) == true && i != x)
                    {
                        SudokuMain.zahlVorhanden = 1;
                    }
                }
            }
        }



    }
}
