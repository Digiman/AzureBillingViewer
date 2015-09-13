using System.Linq;

namespace App.Common.Extensions
{
    /// <summary>
    /// Расширения для класса String.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Корректировка вещественного числа в строке (замена точки на запятую).
        /// </summary>
        /// <param name="value">Корректируемое значение.</param>
        /// <returns>Возвращает скорректированную строку.</returns>
        public static string CorrectDouble(this string value)
        {
            if (value.Contains('.'))
                value = value.Replace('.', ',');
            return value;
        }

        /// <summary>
        /// Преобразование стоки в массив из CSV файла.
        /// </summary>
        /// <param name="line">Строка для разбиения на элементы.</param>
        /// <returns>Возвращает массив с данными о строках.</returns>
        public static string[] ParseLine(this string line)
        {
            var result = line.Split(',');

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = result[i].Trim('\"', '=');
            }

            return result;
        }
    }
}
