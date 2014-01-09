using System;
using System.Collections.Generic;
using System.Linq;
using App.Core;
using App.Core.Elements;

namespace AzureBillingApp.Models
{
    /// <summary>
    /// Модель для данных, котрые необходимо отобразить в подробностях за выбранный период.
    /// </summary>
    public class DetailsViewModel
    {
        /// <summary>
        /// Подробные сведения об использовании.
        /// </summary>
        public BillingData BillingData { get; set; }

        /// <summary>
        /// Название детализации (из истории).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Применение фильтра для сведений по ежедневному использованию.
        /// </summary>
        /// <param name="filter">Фильтр с данными для фильтрации.</param>
        /// <returns>Возвращает отфильтрованный список.</returns>
        public List<DayUsage> ApplyFilter(DayUsageFilter filter)
        {
            var result = BillingData.DayUsages;

            if (!String.IsNullOrEmpty(filter.Name))
                result = result.Where(d => d.Name == filter.Name).ToList();
            if (!String.IsNullOrEmpty(filter.Resource))
                result = result.Where(d => d.Resource == filter.Resource).ToList();
            if (!String.IsNullOrEmpty(filter.Component))
                result = result.Where(d => d.Component == filter.Component).ToList();
            if (!String.IsNullOrEmpty(filter.Subregion))
                result = result.Where(d => d.SubRegion == filter.Subregion).ToList();
            if (!String.IsNullOrEmpty(filter.Service))
                result = result.Where(d => d.Service == filter.Service).ToList();

            return result;
        }
    }
}
