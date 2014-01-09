using System.Collections.Generic;
using System.Linq;
using App.Core.Elements;

namespace App.Core
{
    /// <summary>
    /// Класс с данными об использовании за отчетный период, полученные из подробного файла в CSV формате.
    /// </summary>
    /// <seealso cref="http://www.windowsazure.com/ru-ru/support/understand-your-bill/"/>
    public class BillingData
    {
        /// <summary>
        /// Данные об использовании облачных слухб по дням.
        /// </summary>
        public List<DayUsage> DayUsages { get; set; }
        /// <summary>
        /// Декларации по службам, за которые производится оплата.
        /// </summary>
        public List<Declaration> Declarations { get; set; }
        /// <summary>
        /// Список подписок, вошедщих в текущий период оплаты.
        /// </summary>
        public List<SubscriptionStatus> SubscriptionStatuses { get; set; }

        /// <summary>
        /// Инициализация "пустого" объекта.
        /// </summary>
        public BillingData()
        {
            DayUsages = new List<DayUsage>();
            Declarations = new List<Declaration>();
            SubscriptionStatuses = new List<SubscriptionStatus>();
        }

        /// <summary>
        /// Очистка всех данных за отчетный период, которые были загружены в объект.
        /// </summary>
        public void Clear()
        {
            DayUsages.Clear();
            Declarations.Clear();
            SubscriptionStatuses.Clear();
        }

        /// <summary>
        /// Расчет полной потраченной на услуги суммы денег.
        /// </summary>
        /// <returns>Возвращает значение израсходованной суммы за отчетный период.</returns>
        public double GetSpentValue()
        {
            double sum = 0;

            foreach (var declaration in Declarations)
            {
                sum += declaration.CalculateSpentValue();
            }

            return sum;
        }

        public List<string> GetDayUsageNames()
        {
            var list = new List<string>();

            foreach (var dayUsage in DayUsages)
            {
                list.Add(dayUsage.Name);
            }

            list = list.Distinct().ToList();

            return list;
        }

        public List<string> GetDayUsageResources()
        {
            var list = new List<string>();

            foreach (var dayUsage in DayUsages)
            {
                list.Add(dayUsage.Resource);
            }

            list = list.Distinct().ToList();

            return list;
        }

        public List<string> GetDayUsageSubregions()
        {
            var list = new List<string>();

            foreach (var dayUsage in DayUsages)
            {
                list.Add(dayUsage.SubRegion);
            }

            list = list.Distinct().ToList();

            return list;
        }

        public List<string> GetDayUsageServices()
        {
            var list = new List<string>();

            foreach (var dayUsage in DayUsages)
            {
                list.Add(dayUsage.Service);
            }

            list = list.Distinct().ToList();

            return list;
        }

        public List<string> GetDayUsageComponents()
        {
            var list = new List<string>();

            foreach (var dayUsage in DayUsages)
            {
                list.Add(dayUsage.Component);
            }

            list = list.Distinct().ToList();

            return list;
        }
    }
}
