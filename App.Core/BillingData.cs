using System.Collections.Generic;
using System.Linq;
using App.Core.Elements;
using App.Core.Enums;

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

        /// <summary>
        /// Получение списка уникальных строк.
        /// </summary>
        /// <param name="value">Значение, которые нужно выбрать (поле).</param>
        /// <returns>Возвращает список, состоящий из уникальных (не повторяющихся) строк.</returns>
        /// <remarks>Используется для фильтров (в выпадающих списках).</remarks>
        public List<string> GetUniqueStrings(DayUsageValues value)
        {
            var list = new List<string>();

            foreach (var dayUsage in DayUsages)
            {
                switch (value)
                {
                    case DayUsageValues.Names:
                        list.Add(dayUsage.Name);
                        break;
                    case DayUsageValues.Components:
                        list.Add(dayUsage.Component);
                        break;
                    case DayUsageValues.Resourses:
                        list.Add(dayUsage.Resource);
                        break;
                    case DayUsageValues.SubRegions:
                        list.Add(dayUsage.SubRegion);
                        break;
                    case DayUsageValues.Services:
                        list.Add(dayUsage.Service);
                        break;
                }
            }

            list = list.Distinct().ToList();

            return list;
        }
    }
}
