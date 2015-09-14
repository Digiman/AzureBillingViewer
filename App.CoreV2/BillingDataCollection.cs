using System.Collections.Generic;
using System.Linq;
using App.Common;
using App.Common.Abstarct;
using App.Common.Enums;
using App.Common.Helpers;
using App.Common.Tree;
using App.CoreV2.Elements;
using App.CoreV2.Extensions;

namespace App.CoreV2
{
    /// <summary>
    /// Коллекция, содержащая сведения о расходах по всем периодам действия подписки (по месяцам).
    /// </summary>
    public class BillingDataCollection : IBillingDataCollection <BillingData, SubscriptionStatus>
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
        /// Дерево, построенное на основе подписок и периодов в них.
        /// </summary>
        public BillingDataTree<BillingData, BillingDataCollection, SubscriptionStatus> Tree { get; set; }
        
        /// <summary>
        /// Инициализация "пустого" объекта.
        /// </summary>
        public BillingDataCollection()
        {
            BillingDatas = new List<BillingData>();
            History = new BillingHistory();
            Tree = new BillingDataTree<BillingData, BillingDataCollection, SubscriptionStatus>();
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

            Tree = new BillingDataTree<BillingData, BillingDataCollection, SubscriptionStatus>(this);
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
                        BillingDatas.Add(BillingDataFileReader.ReadDataFile(dataFile.Filename));
                    }
                    break;
                case FileTypes.XML:
                    foreach (var dataFile in history.BillingDataFiles)
                    {
                        BillingDatas.Add(BillingDataFileReader.ReadDataFile(dataFile.Filename));
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
            BillingDatas.Add(BillingDataFileReader.ReadDataFile(dataFile.Filename));
            
            // перестройка дерева с новыми данными
            Tree.RebuildTree(this);
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

        /// <summary>
        /// Получение списка периодов расходов в заданной подписке.
        /// </summary>
        /// <param name="subscription">Подписка, для которой следует найти все периоды расходов.</param>
        /// <returns>Возвращает список данных о расходах в заданной подписке.</returns>
        public List<BillingData> GetBillingDataBySubscription(SubscriptionStatus subscription)
        {
            return
                BillingDatas.Where(
                    item => item.SubscriptionStatuses.Count(s => s.SubscriptionId == subscription.SubscriptionId) > 0)
                    .ToList();
        }

        public void Export(string filename)
        {
            XmlWorker.SaveToFile(filename, BillingDatas);
        }
    }
}
