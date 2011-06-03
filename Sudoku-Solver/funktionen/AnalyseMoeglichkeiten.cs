using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace SudokuSolver
{
    class AnalyseMoeglichkeiten
    {

        public static bool start()
        {
            /// <summary>
            /// Prüfen ob es für Felder nur eine mögliche Zahl gibt.
            /// -AnalyseEinzig.cs
            /// </summary>
            AnalyseEinzig.start();
            if (SudokuMain.einzigartig == 1)
            {
                moeglichkeitenStringReset();
                return true;
            }

            /// <summary>
            /// Prüfen ob es für Felder eines 3x3 Feldes nur eine mögliche Zahl gibt.
            /// -AnalyseSquareEinzig.cs
            /// </summary>
            AnalyseSquareEinzig.start();
            if (SudokuMain.squareFound == 1)
            {
                moeglichkeitenStringReset();
                return true;
            }

            /// <summary>
            /// Prüfen ob es für Felder in einer reihe oder spalte
            /// paare gibt die gleich sind.
            /// -AnalysePaare.cs
            /// </summary>
            AnalysePaare.start();
            if (SudokuMain.pairFound == 1)
            {
                return true;
            }
            else
            {
                moeglichkeitenStringReset();
                return false;
            }
        }

        /// <summary>
        /// Zuruecksetzen moeglichkeitenString Arrays
        /// </summary>
        public static void moeglichkeitenStringReset()
        {
            /// <summary>
            /// Leeren des moeglichkeitenString Arrays.
            /// </summary>
            for (int x = 0; x < 81; x++)
            {
                SudokuMain.moeglichkeitenString[x] = "";
            }
        }


    }
}
