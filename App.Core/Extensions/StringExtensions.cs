using System.Linq;

namespace App.Core.Extensions
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
    }
}
