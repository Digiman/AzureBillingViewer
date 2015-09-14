using App.Common.Helpers;
using App.CoreV2;
using AzureBillingAppV2.Models;

namespace AzureBillingAppV2.Helpers
{
    /// <summary>
    /// Вспомогательный класс для работы с коллекцией, состоящей из истории платежей по периодам.
    /// </summary>
    public static class BillingDataCollectionHelper
    {
        /// <summary>
        /// Формирование модели с данными, которые можно отобразить на графиках.
        /// </summary>
        /// <param name="collection">Коллекция с историей по периодам.</param>
        /// <returns>Возвращает модель, заполненную данными для построения графиков.</returns>
        public static GraphDataViewModel GenerateGraphDataViewModel(BillingDataCollection collection)
        {
            var model = new GraphDataViewModel();

            int i = 0;
            foreach (var history in collection.History.BillingDataFiles)
            {
                model.SpentByPeriods.Add(history.Name, collection.BillingDatas[i].GetSpentValue());
                i++;
            }

            return model;
        }

        /// <summary>
        /// Формирование модели с общими данными, по всей истории. 
        /// </summary>
        /// <param name="collection">Коллекция с историей по периодам.</param>
        /// <returns>Возвращает модель, заполенную данными.</returns>
        public static SummaryViewModel GenerateSummaryViewModel(BillingDataCollection collection)
        {
            var model = new SummaryViewModel();

            // NOTE: заполнение данными модели, которая используется в окне в общими данными
            model.TotalSpent = collection.GetTotalSpentValue();
            model.PeriodsCount = collection.BillingDatas.Count;
            model.AverageSpent = model.TotalSpent/model.PeriodsCount;
            model.SubscriptionCount = collection.GetSubscriptions().Count;

            model.Currency = collection.BillingDatas[0].Declarations[0].Currency;

            return model;
        }

        /// <summary>
        /// Выполнение сохранения коллекции в файл.
        /// </summary>
        /// <param name="collection">Коллекция с данными о периодах оплаты и историей.</param>
        /// <param name="filename">Имя файла и путь к нему для записи в него данных.</param>
        /// <remarks>По сути сохранению подвергается только файл с данными об истории.</remarks>
        public static void Save(BillingDataCollection collection, string filename)
        {
            HistoryFileWorker.SaveToFile(filename, collection.History);
        }
    }
}
