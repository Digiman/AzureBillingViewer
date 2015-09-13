using App.Common.Helpers;

namespace App.Core.Helpers
{
    /// <summary>
    /// Класс для работы с данными об оплате и использовании за период (чтение из CSV файла).
    /// </summary>
    public static class BillingDataHelper
    {
        /// <summary>
        /// Сохранение данных о затратах по текущему периоду в XML-файл.
        /// </summary>
        /// <param name="filename">Имя файла и путь к нему для записи данных в него.</param>
        /// <param name="data">Данные для сохранения.</param>
        public static void SaveDataToXmlFile(string filename, BillingData data)
        {
            XmlWorker.SaveToFile(filename, data);
        }

        /// <summary>
        /// Чтение данных о расходах по текущему периолду из XML-файла.
        /// </summary>
        /// <param name="filename">Имя фацла и путь к нему.</param>
        /// <returns>Возвращает обработанные данные в виде структурированного объкта.</returns>
        public static BillingData LoadDataFromXmlFile(string filename)
        {
            return XmlWorker.LoadFromFile<BillingData>(filename);
        }
    }
}
