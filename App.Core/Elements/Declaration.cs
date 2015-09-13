using System;
using App.Common.Extensions;

namespace App.Core.Elements
{
    /// <summary>
    /// Класс для описания списка заявлений по оплате по типам служб.
    /// </summary>
    public class Declaration
    {
        /// <summary>
        /// Расчетный период.
        /// </summary>
        public string SettlementPeriod { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Тип.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Ресурс.
        /// </summary>
        public string Resource { get; set; }

        /// <summary>
        /// Регион.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// SKU.
        /// </summary>
        /// <remarks>Указывает уникальный идентификатор системы для каждого ресурса Windows Azure.</remarks>
        public string SKU { get; set; }

        /// <summary>
        /// Единица.
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Израсходовано.
        /// </summary>
        public string Spent { get; set; }

        /// <summary>
        /// Включено.
        /// </summary>
        /// <remarks>Содержит объем ресурсов, бесплатно включаемых в текущий расчетный период.</remarks>
        public string Include { get; set; }

        /// <summary>
        /// Подлежит оплате.
        /// </summary>
        /// <remarks>Содержит объем ресурсов, подлежащих оплате в текущем расчетном периоде.</remarks>
        public string Payable { get; set; }

        /// <summary>
        /// В рамках обязательства.
        /// </summary>
        /// <remarks>Содержит выплаты за ресурсы, которые вычитаются из суммы обязательства, связанной с 6- или 12-месячным предложением. Обратите внимание на то, что выплаты за ресурсы вычитаются из суммы обязательства в хронологическом порядке.</remarks>
        public string AsPartOfACommitment { get; set; }

        /// <summary>
        /// Валюта.
        /// </summary>
        /// <remarks>Указывает валюту, используемую в текущем расчетном периоде.</remarks>
        public string Currency { get; set; }

        /// <summary>
        /// Превышение.
        /// </summary>
        /// <remarks>Содержит выплаты за ресурсы, которые превышают сумму обязательства, связанную с 6- или 12-месячным предложением.</remarks>
        public string Excess { get; set; }

        /// <summary>
        /// Тариф по обязательствам.
        /// </summary>
        /// <remarks>Содержит тариф по обязательствам, который зависит от общей суммы обязательства, связанной с 6- или 12-месячным предложением.</remarks>
        public string TariffCommitments { get; set; }

        /// <summary>
        /// Тариф.
        /// </summary>
        /// <remarks>Содержит тариф оплаты по мере использования для ресурса.</remarks>
        public string Tariff { get; set; }

        /// <summary>
        /// Значение.
        /// </summary>
        /// <remarks>Содержит итоговую денежную сумму для израсходованного ресурса.</remarks>
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
