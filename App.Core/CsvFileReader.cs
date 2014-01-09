using System;
using System.Collections.Generic;
using System.IO;

namespace App.Core
{
    /// <summary>
    /// Класс ддля реализации чтения данных из CSV файла.
    /// </summary>
    public static class CsvFileReader
    {
        /// <summary>
        /// Чтение данных из файла по его блокам.
        /// </summary>
        /// <param name="filename">Имя файла и путь к нему.</param>
        /// <returns>Возвращает список списков, каждый из которых содержит набор строк для каждого из трех блоков.</returns>
        public static List<List<string>> ReadByBlocks(string filename)
        {
            var file = new StreamReader(filename);

            var lines = new List<string>();

            while (!file.EndOfStream)
                lines.Add(file.ReadLine());

            file.Close();

            //-------------------------------------------------

            List<string>[] lines2 = new List<string>[3];
            lines2[0] = new List<string>();
            lines2[1] = new List<string>();
            lines2[2] = new List<string>();

            int i = 0;
            for (int j = 0; j < 3; j++)
            {
                while (i != lines.Count && !String.IsNullOrWhiteSpace(lines[i]))
                {
                    lines2[j].Add(lines[i]);
                    i++;
                }
                i++;
            }

            return new List<List<string>> {lines2[0], lines2[1], lines2[2]};
        }
    }
}
