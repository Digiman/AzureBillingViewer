namespace App.Core.Helpers
{
    /// <summary>
    /// Класс для работы с историей (файлами XML, в которых хранятся данные о ней).
    /// </summary>
    public static class HistoryFileWorker
    {
        /// <summary>
        /// Загрузка сведений об оплатах из файла.
        /// </summary>
        /// <param name="filename">Файл с данными об истории оплат.</param>
        /// <returns>Возвращает данные в виде обработанного объекта с историей оплат.</returns>
        public static BillingHistory LoadFromFile(string filename)
        {
            return XmlWorker.LoadFromFile<BillingHistory>(filename);
        }

        /// <summary>
        /// Сохранение сведений об оплатах в файл.
        /// </summary>
        /// <param name="filename">Имя файла для записи данных в него.</param>
        /// <param name="history">Объект с данными об истории оплат (списка файлов).</param>
        public static void SaveToFile(string filename, BillingHistory history)
        {
            XmlWorker.SaveToFile<BillingHistory>(filename, history);
        }
    }
}
