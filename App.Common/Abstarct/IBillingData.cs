using System.Collections.Generic;
using App.Common.Enums;

namespace App.Common.Abstarct
{
    public interface IBillingData
    {
        /// <summary>
        /// Очистка всех данных за отчетный период, которые были загружены в объект.
        /// </summary>
        void Clear();

        /// <summary>
        /// Расчет полной потраченной на услуги суммы денег.
        /// </summary>
        /// <returns>Возвращает значение израсходованной суммы за отчетный период.</returns>
        double GetSpentValue();

        /// <summary>
        /// Получение списка уникальных строк.
        /// </summary>
        /// <param name="value">Значение, которые нужно выбрать (поле).</param>
        /// <returns>Возвращает список, состоящий из уникальных (не повторяющихся) строк.</returns>
        /// <remarks>Используется для фильтров (в выпадающих списках).</remarks>
        List<string> GetUniqueStrings(DayUsageValues value);

        /// <summary>
        /// Получение сведения о периоде (из данных по декларациям).
        /// </summary>
        /// <returns>Возвращает название расчетного периода.</returns>
        string GetSettlementPeriod();
    }
}
