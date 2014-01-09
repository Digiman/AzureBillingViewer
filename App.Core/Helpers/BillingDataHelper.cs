using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using App.Core.Elements;

namespace App.Core.Helpers
{
    /// <summary>
    /// Класс для работы с данными об оплате и использовании за период (чтение из CSV файла).
    /// </summary>
    public static class BillingDataHelper
    {
        private static string[] _blockHeaders = {"Состояние подготовки", "Заявление", "Ежедневное использование"};

        /// <summary>
        /// Загрузка данных из CSV-файла.
        /// </summary>
        /// <param name="filename">Имя файла и путь к нему.</param>
        /// <returns>Возвращает объект, который представляет собой содержимое файла в обработанном виде.</returns>
        public static BillingData LoadDataFromCsvFile(string filename)
        {
            var data = new BillingData();

            // чтение по блокам файла с данными в формате CVS
            var lines = CsvFileReader.ReadByBlocks(filename);

            // 1. блок с данными о состоянии подписки
            data.SubscriptionStatuses = ParseSubscriptionStatusData(lines[0]);

            // 2. блок с данными о заявления к оплате по компонентам
            data.Declarations = ParseDeclarationsData(lines[1]);

            // 3. блок с данными об ежедневном использовании
            data.DayUsages = ParseDayUsagesData(lines[2]);

            return data;
        }

        private static List<SubscriptionStatus> ParseSubscriptionStatusData(List<string> list)
        {
            // удаляем первые две строки
            list.RemoveAt(0);
            list.RemoveAt(0);

            return list.Select(line => new SubscriptionStatus(ParseLine(line))).ToList();
        }

        private static List<Declaration> ParseDeclarationsData(List<string> list)
        {
            // удаляем первые две строки
            list.RemoveAt(0);
            list.RemoveAt(0);

            return list.Select(line => new Declaration(ParseLine(line))).ToList();
        }

        private static List<DayUsage> ParseDayUsagesData(List<string> list)
        {
            // удаляем первые две строки
            list.RemoveAt(0);
            list.RemoveAt(0);

            return list.Select(line => new DayUsage(ParseLine(line))).ToList();
        }

        /// <summary>
        /// Преобразование стоки в массив из CSV файла.
        /// </summary>
        /// <param name="line">Строка для разбиения на элементы.</param>
        /// <returns>Возвращает массив с данными о строках.</returns>
        private static string[] ParseLine(string line)
        {
            var result = line.Split(',');

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = result[i].Trim('\"', '=');
            }

            return result;
        }

        /// <summary>
        /// Сохранение данных о затратах по текущему периоду в XML-файл.
        /// </summary>
        /// <param name="filename">Имя файла и путь к нему для записи данных в него.</param>
        /// <param name="data">Данные для сохранения.</param>
        public static void SaveDataToXmlFile(string filename, BillingData data)
        {
            var serializer = new XmlSerializer(typeof(BillingData));

            TextWriter writer = new StreamWriter(filename);
            serializer.Serialize(writer, data);
            writer.Close();
        }

        /// <summary>
        /// Чтение данных о расходах по текущему периолду из XML-файла.
        /// </summary>
        /// <param name="filename">Имя фацла и путь к нему.</param>
        /// <returns>Возвращает обработанные данные в виде структурированного объкта.</returns>
        public static BillingData LoadDataFromXmlFile(string filename)
        {
            var serializer = new XmlSerializer(typeof (BillingData));

            TextReader reader = new StreamReader(filename);
            var data = (BillingData) serializer.Deserialize(reader);
            reader.Close();

            return data;
        }
    }
}
