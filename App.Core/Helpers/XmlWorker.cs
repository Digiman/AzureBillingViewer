using System.IO;
using System.Xml.Serialization;

namespace App.Core.Helpers
{
    /// <summary>
    /// Класс для реализации общих методов работы с XML файламии и данными в них.
    /// </summary>
    public static class XmlWorker
    {
        /// <summary>
        /// Загрузка сведений из файла.
        /// </summary>
        /// <param name="filename">Файл с данными для сериализации.</param>
        /// <returns>Возвращает данные из файла после дессериализации.</returns>
        public static T LoadFromFile<T>(string filename)
        {
            var serializer = new XmlSerializer(typeof(BillingHistory));

            var fs = new FileStream(filename, FileMode.Open);
            var data = (T)serializer.Deserialize(fs);
            fs.Close();

            return data;
        }

        /// <summary>
        /// Сохранение сведений в файл.
        /// </summary>
        /// <param name="filename">Имя файла для записи данных в него.</param>
        /// <param name="data">Объект с данными для сериализации.</param>
        public static void SaveToFile<T>(string filename, T data)
        {
            var serializer = new XmlSerializer(typeof(BillingHistory));

            TextWriter writer = new StreamWriter(filename);
            serializer.Serialize(writer, data);
            writer.Close();
        }
    }
}
