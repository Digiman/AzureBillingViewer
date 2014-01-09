using System.Collections.Generic;
using System.Linq;
using App.Core.Elements;
using App.Core.Enums;
using App.Core.Extensions;
using App.Core.Helpers;

namespace App.Core
{
    /// <summary>
    /// Коллекция, содержащая сведения о расходах по всем периодам действия подписки (по месяцам).
    /// </summary>
    public class BillingDataCollection
    {
        /// <summary>
        /// Данные о расходах по каждому периоду.
        /// </summary>
        public List<BillingData> BillingDatas { get; set; }

        /// <summary>
        /// История расходов по периодам в виде списка файлов с данными о них.
        /// </summary>
        public BillingHistory History { get; set; }
        
        /// <summary>
        /// Инициализация "пустого" объекта.
        /// </summary>
        public BillingDataCollection()
        {
            BillingDatas = new List<BillingData>();
            History = new BillingHistory();
        }

        /// <summary>
        /// Инициализация объекта с данными, загружаемыми из истории.
        /// </summary>
        /// <param name="history">История платежей в виде списка файлов с подробными сведениями. Используется для загрузки данных их них.</param>
        public BillingDataCollection(BillingHistory history)
        {
            BillingDatas = new List<BillingData>();
            History = history;

            Load(history);
        }

        /// <summary>
        /// Загрузка подробных сведений по каждому из периодов, указанных в истории.
        /// </summary>
        /// <param name="history">История платежей в виде списка файлов с подробными сведениями. Используется для загрузки данных их них.</param>
        public void Load(BillingHistory history)
        {
            switch (history.FileType)
            {
                case FileTypes.CSV:
                    foreach (var dataFile in history.BillingDataFiles)
                    {
                        BillingDatas.Add(BillingDataHelper.LoadDataFromCsvFile(dataFile.Filename));
                    }
                    break;
                case FileTypes.XML:
                    foreach (var dataFile in history.BillingDataFiles)
                    {
                        BillingDatas.Add(BillingDataHelper.LoadDataFromXmlFile(dataFile.Filename));
                    }
                    break;
            }
        }

        /// <summary>
        /// Добавление нового периода из файла в коллекцию.
        /// Производит обновление истории и считывание данных из новго файла.
        /// </summary>
        /// <param name="dataFile">Файл с данными за отчетный период.</param>
        public void Add(BillingDataFile dataFile)
        {
            History.AddBillingFile(dataFile);
            BillingDatas.Add(BillingDataHelper.LoadDataFromCsvFile(dataFile.Filename));
        }

        /// <summary>
        /// Очистка коллекции с данными о истории оплат и самими даннми из истории.
        /// </summary>
        public void Clear()
        {
            BillingDatas.Clear();
            History.Clear();
        }

        /// <summary>
        /// Расчет полной суммы затрат по всем периодам.
        /// </summary>
        /// <returns>Возвращает значение суммы, которая ушла на оплату за все периоды в истории.</returns>
        public double GetTotalSpentValue()
        {
            double sum = 0;
            foreach (var billingData in BillingDatas)
            {
                sum += billingData.GetSpentValue();
            }

            return sum;
        }

        /// <summary>
        /// Получение списка всех уникальных подписок.
        /// </summary>
        /// <returns>Возвращает список уникальных подписок.</returns>
        public List<SubscriptionStatus> GetSubscriptions()
        {
            var result = new List<SubscriptionStatus>();

            foreach (var billingData in BillingDatas)
            {
                result.AddRange(billingData.SubscriptionStatuses);
            }

            result = result.Distinct(new SubscriptionStatusComparer()).ToList();

            return result;
        }
    }
}
