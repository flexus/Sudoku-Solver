using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace SudokuSolver
{
    class AnalyseLeereFelder
    {

        /// <summary>
        /// Felder mit Nullen suchen und weitergeben an
        /// ChkMoeglichkeiten.
        /// -MoeglichkeitenFinden.cs
        /// </summary>
        public static void start()
        {
            SudokuMain.felderFrei = 0;
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (SudokuMain.ausgabeSudoku[x, y] == 0)
                    {

                        /// <summary>
                        /// Freie Felder werden weiter gegeben zum Prüfen.
                        /// </summary>
                        analyse(x, y, 1);
                        SudokuMain.felderFrei = 1;
                    }
                }
            }
        }

        /// <summary>
        /// Überprüfen der leeren Felder nach moeglichen Zahlen.
        /// </summary>
        public static void analyse(int x, int y, int temp)
        {
            int j;
            SudokuMain.zahlVorhanden = 0;
            while (temp <= 9)
            {

                /// <summary>
                /// Horizontal prüfen.
                /// </summary>
                for (j = 0; j < 9; j++)
                {
                    if (SudokuMain.ausgabeSudoku[x, j] == temp)
                    {
                        SudokuMain.zahlVorhanden = 1;
                    }
                }

                /// <summary>
                /// Vertikal prüfen.
                /// </summary>
                for (j = 0; j < 9; j++)
                {
                    if (SudokuMain.ausgabeSudoku[j, y] == temp)
                    {
                        SudokuMain.zahlVorhanden = 1;
                    }
                }

                /// <summary>
                /// Einzelne Squares testen(3x3 Felder).
                /// </summary>

                /// <summary>
                /// Square 1 (links oben) 
                /// </summary>
                if (x < 3 && y < 3)
                {
                    chkSquare1(temp);
                }

                /// <summary>
                /// Square 2 (mitte oben)
                /// </summary>
                if (x < 3 && y > 2 && y < 6)
                {
                    chkSquare2(temp);
                }

                /// <summary>
                /// Square 3 (rechts oben)
                /// </summary>
                if (x < 3 && y > 5)
                {
                    chkSquare3(temp);
                }

                /// <summary>
                /// Square 4 (links mitte)
                /// </summary>
                if (x > 2 && x < 6 && y < 3)
                {
                    chkSquare4(temp);
                }

                /// <summary>
                /// Square 5 (mitte)
                /// </summary>
                if (x > 2 && x < 6 && y > 2 && y < 6)
                {
                    chkSquare5(temp);
                }

                /// <summary>
                /// Square 6 (rechts mitte)
                /// </summary>
                if (x > 2 && x < 6 && y > 5)
                {
                    chkSquare6(temp);
                }

                /// <summary>
                /// Square 7 (links unten)
                /// </summary>
                if (x > 5 && y < 3)
                {
                    chkSquare7(temp);
                }

                /// <summary>
                /// Square 8 (mitte unten)
                /// </summary>
                if (x > 5 && y > 2 && y < 6)
                {
                    chkSquare8(temp);
                }

                /// <summary>
                /// Square 9 (rechts unten)
                /// </summary>
                if (x > 5 && y > 5)
                {
                    chkSquare9(temp);
                }

                /// <summary>
                /// Hat temp den Check bestanden,
                /// wird es dem String Array an der x y 
                /// entsprechenden stelle gespeichert.
                /// </summary>
                if (SudokuMain.zahlVorhanden == 0)
                {
                    SudokuMain.moeglichkeitenString[SudokuMain.indexArray[x, y]] += temp;
                }
                temp++;
                SudokuMain.zahlVorhanden = 0;
            }
        }

        /// <summary>
        /// Square 1 pruefen.
        /// </summary>
        public static void chkSquare1(int temp)
        {
            for (int a = 0; a < 3; a++)
            {
                for (int b = 0; b < 3; b++)
                {
                        if (SudokuMain.ausgabeSudoku[a, b] == temp) { SudokuMain.zahlVorhanden = 1; }
                }
            }
        }

        /// <summary>
        /// Square 2 pruefen.
        /// </summary>
        public static void chkSquare2(int temp)
        {
            for (int a = 0; a < 3; a++)
            {
                for (int b = 3; b < 6; b++)
                {

                        if (SudokuMain.ausgabeSudoku[a, b] == temp) { SudokuMain.zahlVorhanden = 1; }
                }
            }
        }

        /// <summary>
        /// Square 3 pruefen.
        /// </summary>
        public static void chkSquare3(int temp)
        {
            for (int a = 0; a < 3; a++)
            {
                for (int b = 6; b < 9; b++)
                {
                        if (SudokuMain.ausgabeSudoku[a, b] == temp) { SudokuMain.zahlVorhanden = 1; }
                }
            }
        }

        /// <summary>
        /// Square 4 pruefen.
        /// </summary>
        public static void chkSquare4(int temp)
        {
            for (int a = 3; a < 6; a++)
            {
                for (int b = 0; b < 3; b++)
                {
                        if (SudokuMain.ausgabeSudoku[a, b] == temp) { SudokuMain.zahlVorhanden = 1; }
                }
            }
        }

        /// <summary>
        /// Square 5 pruefen.
        /// </summary>
        public static void chkSquare5(int temp)
        {
            for (int a = 3; a < 6; a++)
            {
                for (int b = 3; b < 6; b++)
                {
                        if (SudokuMain.ausgabeSudoku[a, b] == temp) { SudokuMain.zahlVorhanden = 1; }
                }
            }
        }

        /// <summary>
        /// Square 6 pruefen.
        /// </summary>
        public static void chkSquare6(int temp)
        {
            for (int a = 3; a < 6; a++)
            {
                for (int b = 6; b < 9; b++)
                {
                        if (SudokuMain.ausgabeSudoku[a, b] == temp) { SudokuMain.zahlVorhanden = 1; }
                }
            }
        }

        /// <summary>
        /// Square 7 pruefen.
        /// </summary>
        public static void chkSquare7(int temp)
        {
            for (int a = 6; a < 9; a++)
            {
                for (int b = 0; b < 3; b++)
                {
                        if (SudokuMain.ausgabeSudoku[a, b] == temp) { SudokuMain.zahlVorhanden = 1; }
                }
            }
        }

        /// <summary>
        /// Square 8 pruefen.
        /// </summary>
        public static void chkSquare8(int temp)
        {
            for (int a = 6; a < 9; a++)
            {
                for (int b = 3; b < 6; b++)
                {
                        if (SudokuMain.ausgabeSudoku[a, b] == temp) { SudokuMain.zahlVorhanden = 1; }
                }
            }
        }

        /// <summary>
        /// Square 9 pruefen.
        /// </summary>
        public static void chkSquare9(int temp)
        {
            for (int a = 6; a < 9; a++)
            {
                for (int b = 6; b < 9; b++)
                {
                        if (SudokuMain.ausgabeSudoku[a, b] == temp) { SudokuMain.zahlVorhanden = 1; }
                }
            }
        }

    }
}
