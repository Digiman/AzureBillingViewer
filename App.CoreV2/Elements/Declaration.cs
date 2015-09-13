using System;
using App.Common.Extensions;

namespace App.CoreV2.Elements
{
    /// <summary>
    /// Класс для описания списка заявлений по оплате по типам служб.
    /// </summary>
    /// <remarks>Соответствует версии 2 для файла с данными об использовании.</remarks>
    public class Declaration
    {
        /// <summary>
        /// Расчетный период.
        /// </summary>
        /// <remarks>Период потребления ресурса, за который выставляется счет.</remarks>
        public string SettlementPeriod { get; set; }

        /// <summary>
        /// Категория средства измерения.
        /// </summary>
        /// <remarks>Служба верхнего уровня, которая использовалась в течение расчетного периода.</remarks>
        public string Name { get; set; }

        /// <summary>
        /// Подкатегория средства измерения.
        /// </summary>
        /// <remarks>В этом столбце может быть указан тип службы, от которого зависит стоимость ее использования.</remarks>
        public string Type { get; set; }

        /// <summary>
        /// Имя средства измерения.
        /// </summary>
        /// <remarks>Определяет единицу измерения для использованного ресурса.</remarks>
        public string Resource { get; set; }

        /// <summary>
        /// Регион средства измерения.
        /// </summary>
        /// <remarks>В этом столбце указывается расположение центра обработки данных для определенных служб. От этого расположения может зависеть стоимость некоторых услуг.</remarks>
        public string Region { get; set; }

        /// <summary>
        /// SKU.
        /// </summary>
        /// <remarks>В этом столбце указан уникальный системный идентификатор для каждого ресурса Azure.</remarks>
        public string SKU { get; set; }

        /// <summary>
        /// Единица.
        /// </summary>
        /// <remarks>Здесь указываются единицы, в которых измеряется объем использования служб, Например, гигабайты, часы, десятки тысяч.</remarks>
        public string Unit { get; set; }

        /// <summary>
        /// Потребленный объем.
        /// </summary>
        /// <remarks>Здесь указан объем потребленного за расчетный период ресурса.</remarks>
        public string Spent { get; set; }

        /// <summary>
        /// Включенный объем.
        /// </summary>
        /// <remarks>В этом столбце указывается объем ресурса, предоставляемый бесплатно в рамках текущего расчетного периода.</remarks>
        public string Include { get; set; }

        /// <summary>
        /// Избыточный объем.
        /// </summary>
        /// <remarks>Если объем потребленного ресурса превышает включенный объем, в этом столбце отображается разница, которая подлежит оплате. В предложениях, предполагающих оплату по мере использования, здесь будет отображаться потребленный объем, так как в таких тарифных планах включенный объем не предусмотрен.</remarks>
        public string Payable { get; set; }

        /// <summary>
        /// В рамках обязательства.
        /// </summary>
        /// <remarks>В этом столбце отображается стоимость ресурсов, которая вычитается из стоимости вашего плана на 6 или 12 месяцев. Обратите внимание, что стоимость ваших ресурсов вычитается из стоимости вашего плана в хронологическом порядке.</remarks>
        public string AsPartOfACommitment { get; set; }

        /// <summary>
        /// Валюта.
        /// </summary>
        /// <remarks>В этой графе указывается валюта, используемая для текущего расчетного периода.</remarks>
        public string Currency { get; set; }

        /// <summary>
        /// Превышение.
        /// </summary>
        /// <remarks>В этом столбце отображается сумма, на которую стоимость использованных ресурсов превышает стоимость вашего плана на 6 или 12 месяцев.</remarks>
        public string Excess { get; set; }

        /// <summary>
        /// Тариф по обязательствам.
        /// </summary>
        /// <remarks>В этой графе указывается объем обязательств на основе общей стоимости вашего плана на 6 или 12 месяцев.</remarks>
        public string TariffCommitments { get; set; }

        /// <summary>
        /// Тариф.
        /// </summary>
        /// <remarks>В этом столбце отображается стоимость каждой оплачиваемой единицы.</remarks>
        public string Tariff { get; set; }

        /// <summary>
        /// Значение.
        /// </summary>
        /// <remarks>Здесь отображается результат умножения значения в столбце «Подлежит оплате» на значение в столбце «Тариф». Если число в столбце «Потреблено» меньше числа в столбце «Включено», в данном столбце ничего не указывается.</remarks>
        public string Value { get; set; }

        /// <summary>
        /// Инициализация "пустого" объекта.
        /// </summary>
        public Declaration()
        { }

        /// <summary>
        /// Инициализация объекта с данными полученными из разбора строки CSV файла.
        /// </summary>
        /// <param name="data">Массив строк из файла.</param>
        public Declaration(string[] data)
        {
            SettlementPeriod = data[0];
            Name = data[1];
            Type = data[2];
            Resource = data[3];
            Region = data[4];
            SKU = data[5];
            Unit = data[6];
            Spent = data[7];
            Include = data[8];
            Payable = data[9];
            AsPartOfACommitment = data[10];
            Currency = data[11];
            Excess = data[12];
            TariffCommitments = data[13];
            Tariff = data[14];
            Value = data[15];
        }

        public override string ToString()
        {
            return String.Format("Декларация за {0} отчетный период по службе {1}.", SettlementPeriod, Name);
        }

        /// <summary>
        /// Расчет потраченной суммы по декларации.
        /// </summary>
        /// <returns>Возвращает значение суммы, реально потраченной на услугу.</returns>
        public double CalculateSpentValue()
        {
            return Convert.ToDouble(Spent.CorrectDouble())*Convert.ToDouble(Tariff.CorrectDouble());
        }
    }
}
