using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace SudokuSolver
{
    public class SudokuMain
    {
        /// <summary>
        /// Globale int Arrays
        /// eingabeSudoku:
        /// -Array für das zu lösende Sudoku
        /// 
        /// ausgabeSudoku:
        /// -Zum einsetzen der Lösungen und Ausgeben der Lösung
        /// 
        /// indexArray:
        /// -enthält nummer für die string Arrays zur passenden XY cord
        /// </summary>
        public static int[,] eingabeSudoku = new int[9, 9];
        public static int[,] ausgabeSudoku = new int[9, 9];
        public static int[,] indexArray = new int[9, 9] {
            { 0, 1, 2, 3, 4, 5, 6, 7, 8 },
            { 9, 10, 11, 12, 13, 14, 15, 16, 17 },
            { 18, 19, 20, 21, 22, 23, 24, 25, 26 },
            { 27, 28, 29, 30, 31, 32, 33, 34, 35 },
            { 36, 37, 38, 39, 40, 41, 42, 43, 44 },
            { 45, 46, 47, 48, 49, 50, 51, 52, 53 },
            { 54, 55, 56, 57, 58, 59, 60, 61, 62 },
            { 63, 64, 65, 66, 67, 68, 69, 70, 71 },
            { 72, 73, 74, 75, 76, 77, 78, 79, 80 }
        };

        /// <summary>
        /// Globale string Arrays
        /// moeglichkeitenString[*]:
        /// -enthält mögliche Zahlen für Leere Felder
        /// -* = Nummer zur Passenden XY Cord für die Arrays aus indexString
        /// 
        /// indexString:
        /// -enthält XY Cords für die Arrays
        /// -1 zeichen = x cords
        /// -2 zeichen = y cords
        /// </summary>
        public static string[] moeglichkeitenString = new string[81];
        public static string[] indexString = new string[81] {
            "00", "01", "02", "03", "04", "05", "06", "07", "08",
            "10", "11", "12", "13", "14", "15", "16", "17", "18",
            "20", "21", "22", "23", "24", "25", "26", "27", "28",
            "30", "31", "32", "33", "34", "35", "36", "37", "38",
            "40", "41", "42", "43", "44", "45", "46", "47", "48",
            "50", "51", "52", "53", "54", "55", "56", "57", "58",
            "60", "61", "62", "63", "64", "65", "66", "67", "68",
            "70", "71", "72", "73", "74", "75", "76", "77", "78",
            "80", "81", "82", "83", "84", "85", "86", "87", "88"
        };

        /// <summary>
        /// Globale Variabeln
        /// </summary>
        public static int zahlVorhanden;
        public static int zahlGefunden;
        public static int loesungVersuch;
        public static int einzigartig;
        public static int squareFound;
        public static int pairFound;
        public static int felderFrei;

        /// <summary>
        /// Hauptprogramm:
        /// </summary>
        public static void Main(string[] args)
        {
            string fPath1 = @"sudokus\schwer1.txt";
            string fPath2 = @"txt\debug2.txt";
            string fPath3 = @"txt\sudostring.txt";
            TxtVerarbeitung.clear(fPath2);
            TxtVerarbeitung.clear(fPath3);
            zahlGefunden = 0;
            loesungVersuch = 0;
            /// <summary>
            /// Aufruf zum verarbeiten des eingangs Sudoku.
            /// Fehlende Stellen werden mit 0 angegeben.
            /// Bsp.: 0 1 2 3 0 4 5 0 6
            /// -SudokuVerarbeiten.cs
            /// </summary>
            SudokuVerarbeiten.get(fPath1);

            /// <summary>
            /// Frei Felder raussuchen:
            /// -LeereFelderSuchen.cs
            /// </summary>
            AnalyseLeereFelder.start();

            /// <summary>
            /// Sollten Freie Felder vorhanden sein,
            /// gehts zur Analyse um Zahlen zu Finden die nur einmal vorkommen.
            /// Wenn welche gefunden wurden, werden diese eingesetzt 
            /// und wieder neu danach geprüft.
            /// -MoeglichkeitenAnalyse.cs
            /// </summary>
            if (AnalyseMoeglichkeiten.start() == true)
            {
                AnalyseLeereFelder.start();
                AnalyseMoeglichkeiten.start();
            }


            /// <summary>
            /// Lösungsausgabe
            /// </summary>
            loesungAusgeben();
            TxtVerarbeitung.writeLine(fPath2, "Lösungen" + " " + SudokuMain.zahlGefunden);

            Console.ReadLine();
        }


        /// <summary>
        /// Ausgeben des Eingegeben Sudokus und der Lösung
        /// Sowie schreiben der Lösung in txt\lösung.txt
        /// -TxtVerarbeitung.cs
        /// </summary>
        public static void loesungAusgeben()
        {
            string fPath = @"txt\lösung.txt";
            string fPath2 = @"txt\sudostring.txt";
            TxtVerarbeitung.clear(fPath);
            string debug;
            int x = 0, y = 0;

            /// <summary>
            /// Ausgeben des zu lösenden Sudokus
            /// </summary>
            Console.WriteLine("Eingegebens Sudoku:");
            for (x = 0; x < 9; x++)
            {
                for (y = 0; y < 9; y++)
                {
                    Console.Write("{0} ", SudokuMain.eingabeSudoku[x, y]);
                    debug = Convert.ToString(SudokuMain.eingabeSudoku[x, y]);
                    TxtVerarbeitung.write(fPath2, debug);
                }
                Console.Write("\n");
            }
            TxtVerarbeitung.writeLine(fPath2, "\n");
            /// <summary>
            /// Ausgeben der Lösung
            /// </summary>
            Console.WriteLine("Lösung:");
            for (x = 0; x < 9; x++)
            {
                for (y = 0; y < 9; y++)
                {
                    Console.Write("{0} ", SudokuMain.ausgabeSudoku[x, y]);
                    debug = Convert.ToString(SudokuMain.ausgabeSudoku[x, y]);
                    TxtVerarbeitung.write(fPath2, debug);
                    if (y < 8)
                    {
                        TxtVerarbeitung.write(fPath, SudokuMain.ausgabeSudoku[x, y] + " ");
                    }
                    else
                    {
                        TxtVerarbeitung.write(fPath, Convert.ToString(SudokuMain.ausgabeSudoku[x, y]));
                    }
                }
                Console.Write("\n");
                TxtVerarbeitung.writeLine(fPath, "\n");
            }
        }

    }
}