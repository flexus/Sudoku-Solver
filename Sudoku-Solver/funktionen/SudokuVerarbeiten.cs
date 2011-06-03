using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace SudokuSolver
{
    class SudokuVerarbeiten
    {
        /// <summary>
        /// Einlesen der Sudoku Textdatei.
        /// </summary>
        /// <param name="fPath">Dateipfad</param>
        public static void get(string fPath)
        {
            /// <summary>
            /// Einlesen des Sudokus in den string input.
            /// </summary>
            int y = 0, x = 0;
            using (StreamReader sr = File.OpenText(fPath))
            {
                string input;
                while ((input = sr.ReadLine()) != null)
                {

                    /// <summary>
                    /// Aufsplitten der Zahlen in ein string Array.
                    /// </summary>
                    string[] convertEingabe = input.Split(new char[] { ' ' });
                    foreach (string eingabe in convertEingabe)
                    {
                        SudokuMain.eingabeSudoku[x, y] = Convert.ToInt32(eingabe);
                        y++;
                    }
                    x++;
                    y = 0;
                }
                sr.Close();
            }

            /// <summary>
            /// Übergeben ans Ausgabe Array.
            /// </summary>
            for (x = 0; x < 9; x++)
            {
                for (y = 0; y < 9; y++)
                {
                    SudokuMain.ausgabeSudoku[x, y] = SudokuMain.eingabeSudoku[x, y];
                }
            }
        }
    }
}
