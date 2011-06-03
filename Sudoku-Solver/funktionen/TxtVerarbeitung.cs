using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace SudokuSolver
{
    class TxtVerarbeitung
    {
        /// <summary>
        /// Schreiben in die aktuelle Zeile bzw Anhaengen.
        /// </summary>
        /// <param name="fPath">Dateipfad</param>
        /// <param name="txt">Text</param>
        public static void write(string fPath, string txt)
        {
            StreamWriter sw = new StreamWriter(fPath, true);
            sw.Write(txt);
            sw.Flush();
            sw.Close();
        }

        /// <summary>
        /// Löschen einer Datei.
        /// </summary>
        /// <param name="fPath">Dateipfad</param>
        public static void clear(string fPath)
        {
            if (File.Exists(fPath) == true)
            {
                File.Delete(fPath);
            }
        }

        /// <summary>
        /// Schreiben einer Zeile ans ende der Datei.
        /// </summary>
        /// <param name="fPath">Dateipfad</param>
        /// <param name="txt">Text</param>
        public static void writeLine(string fPath, string txt)
        {
            StreamWriter sw = new StreamWriter(fPath, true);
            sw.WriteLine(txt);
            sw.Flush();
            sw.Close();
        }

    }
}
