using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver
{
    class AnalysePaare
    {
        public static void start()
        {
            string fPath = @"txt\debug2.txt";
            string debug;
            SudokuMain.loesungVersuch++;
            TxtVerarbeitung.writeLine(fPath, "################Analyse Pairs(try:" + SudokuMain.loesungVersuch + ")################");
            SudokuMain.zahlVorhanden = 0;

            for (int a = 0; a < 81; a++)
            {
                if (SudokuMain.moeglichkeitenString[a] != null)
                {
                    /// <summary>
                    /// x und y Position aus dem indexString holen
                    /// </summary>
                    int x = Convert.ToInt32(SudokuMain.indexString[a].Substring(0, 1));
                    int y = Convert.ToInt32(SudokuMain.indexString[a].Substring(1, 1));
                    string temp = SudokuMain.moeglichkeitenString[a];

                    if (SudokuMain.moeglichkeitenString[a].Length >= 1)
                    {
                        debug = "Feld: " + x + "" + y + ":" + temp;
                        TxtVerarbeitung.writeLine(fPath, debug);
                    }
                    if (SudokuMain.moeglichkeitenString[a].Length == 2)
                    {
                        debug = "Feld: " + x + "" + y + ":" + temp;
                        /// <summary>
                        /// Horizontal prüfen.
                        /// </summary>
                        for (int j = y; j < 9; j++)
                        {
                            int i = SudokuMain.indexArray[x, j];
                            if (SudokuMain.moeglichkeitenString[i].Contains(temp) == true && i != a && SudokuMain.moeglichkeitenString[i].Length == 2)
                            {
                                for (int p = 0; p < 9; p++)
                                {
                                    int z = SudokuMain.indexArray[x, p];
                                    if (z != a && z != i)
                                    {
                                        if (SudokuMain.moeglichkeitenString[z].Contains(temp.Substring(0, 1)) == true)
                                        {
                                            SudokuMain.moeglichkeitenString[z] = SudokuMain.moeglichkeitenString[z].Replace(temp.Substring(0, 1), "");
                                            SudokuMain.zahlVorhanden = 1;
                                            debug += " KILLED:" + temp.Substring(0, 1) + " in " + SudokuMain.indexString[z];
                                            TxtVerarbeitung.writeLine(fPath, debug);
                                        }
                                        if (SudokuMain.moeglichkeitenString[z].Contains(temp.Substring(1, 1)) == true)
                                        {
                                            SudokuMain.moeglichkeitenString[z] = SudokuMain.moeglichkeitenString[z].Replace(temp.Substring(1, 1), "");
                                            Console.WriteLine("killed2");
                                            debug += " KILLED:" + temp.Substring(1, 1) + " in " + SudokuMain.indexString[z];
                                            TxtVerarbeitung.writeLine(fPath, debug);
                                        }
                                    }
                                }
                            }
                        }

                        /// <summary>
                        /// vertikal prüfen.
                        /// </summary>
                        for (int j = x; j < 9; j++)
                        {
                            int i = SudokuMain.indexArray[j, y];
                            if (SudokuMain.moeglichkeitenString[i].Contains(temp) == true && a != i && SudokuMain.moeglichkeitenString[i].Length == 2)
                            {
                                for (int p = 0; p < 9; p++)
                                {
                                    int z = SudokuMain.indexArray[p, y];
                                    if (z != a && z != i)
                                    {
                                        if (SudokuMain.moeglichkeitenString[z].Contains(temp.Substring(0, 1)) == true)
                                        {
                                            SudokuMain.moeglichkeitenString[z] = SudokuMain.moeglichkeitenString[z].Replace(temp.Substring(0, 1), "");
                                            SudokuMain.zahlVorhanden = 1;
                                            debug += " KILLED: " + temp.Substring(0, 1) + " in " + SudokuMain.indexString[z];
                                            TxtVerarbeitung.writeLine(fPath, debug);
                                        }
                                        if (SudokuMain.moeglichkeitenString[z].Contains(temp.Substring(1, 1)) == true)
                                        {
                                            SudokuMain.moeglichkeitenString[z] = SudokuMain.moeglichkeitenString[z].Replace(temp.Substring(1, 1), "");
                                            SudokuMain.zahlVorhanden = 1;
                                            debug += " KILLED:" + temp.Substring(1, 1) + " in " + SudokuMain.indexString[z];
                                            TxtVerarbeitung.writeLine(fPath, debug);
                                        }
                                    }
                                }
                            }
                        }

                        //int temp2 = Convert.ToInt32(temp);

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

                    }
                }
            }
            if (SudokuMain.zahlVorhanden == 1)
            {
                SudokuMain.pairFound = 1;
            }
            TxtVerarbeitung.writeLine(fPath, "################Ende################");
            TxtVerarbeitung.writeLine(fPath, "");
        }

        /// <summary>
        /// Square 1 pruefen.
        /// </summary>
        public static void chkSquare1(string temp, int x)
        {
            for (int a = 0; a < 3; a++)
            {
                for (int b = 0; b < 3; b++)
                {
                    int i = SudokuMain.indexArray[a, b];
                    if (SudokuMain.moeglichkeitenString[i].Contains(temp) == true && i != x && SudokuMain.moeglichkeitenString[i].Length == 2)
                    {
                        Console.WriteLine("Feld: " + SudokuMain.indexString[i] + "=" + SudokuMain.moeglichkeitenString[i]);
                    }
                }
            }
        }

        /// <summary>
        /// Square 2 pruefen.
        /// </summary>
        public static void chkSquare2(string temp, int x)
        {
            for (int a = 0; a < 3; a++)
            {
                for (int b = 3; b < 6; b++)
                {

                }
            }
        }

        /// <summary>
        /// Square 3 pruefen.
        /// </summary>
        public static void chkSquare3(string temp, int x)
        {
            for (int a = 0; a < 3; a++)
            {
                for (int b = 6; b < 9; b++)
                {
                    int i = SudokuMain.indexArray[a, b];
                    int laenge = SudokuMain.moeglichkeitenString[i].Length;
                    string inhalt = SudokuMain.moeglichkeitenString[i];
                    if (SudokuMain.moeglichkeitenString[i].Contains(Convert.ToString(temp)) == true) // && i != x && SudokuMain.moeglichkeitenString[i].Length == 2)
                    {
                        Console.WriteLine("Feld: " + SudokuMain.indexString[i] + "=" + SudokuMain.moeglichkeitenString[i]);
                    }
                }
            }
        }

        /// <summary>
        /// Square 4 pruefen.
        /// </summary>
        public static void chkSquare4(string temp, int x)
        {
            for (int a = 3; a < 6; a++)
            {
                for (int b = 0; b < 3; b++)
                {

                }
            }
        }

        /// <summary>
        /// Square 5 pruefen.
        /// </summary>
        public static void chkSquare5(string temp, int x)
        {
            for (int a = 3; a < 6; a++)
            {
                for (int b = 3; b < 6; b++)
                {

                }
            }
        }

        /// <summary>
        /// Square 6 pruefen.
        /// </summary>
        public static void chkSquare6(string temp, int x)
        {
            for (int a = 3; a < 6; a++)
            {
                for (int b = 6; b < 9; b++)
                {

                }
            }
        }

        /// <summary>
        /// Square 7 pruefen.
        /// </summary>
        public static void chkSquare7(string temp, int x)
        {
            for (int a = 6; a < 9; a++)
            {
                for (int b = 0; b < 3; b++)
                {

                }
            }
        }

        /// <summary>
        /// Square 8 pruefen.
        /// </summary>
        public static void chkSquare8(string temp, int x)
        {
            for (int a = 6; a < 9; a++)
            {
                for (int b = 3; b < 6; b++)
                {

                }
            }
        }

        /// <summary>
        /// Square 9 pruefen.
        /// </summary>
        public static void chkSquare9(string temp, int x)
        {
            for (int a = 6; a < 9; a++)
            {
                for (int b = 6; b < 9; b++)
                {

                }
            }
        }

    }
}
