namespace App.CoreV2.Elements
{
    /// <summary>
    /// Класс ля описания ежедневного использования служб облака.
    /// </summary>
    /// <remarks>Соответствует новой версии формата документа с данными об использовании - версии 2.</remarks>
    public class DayUsage
    {
        /// <summary>
        /// Дата использования.
        /// </summary>
        /// <remarks>Дата создания ресурса.</remarks>
        public string DateOfUse { get; set; }

        /// <summary>
        /// Категория средства измерения.
        /// </summary>
        /// <remarks>Служба верхнего уровня, которая использовалась в течение расчетного периода.</remarks>
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор средства измерения.
        /// </summary>
        /// <remarks>Идентификатор средства измерения, по которому выставляется счет. Этот идентификатор используется для определения цены в счетах за использование.</remarks>
        public string ResourceGuid { get; set; }

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
        /// Единица.
        /// </summary>
        /// <remarks>Здесь указываются единицы, в которых измеряется объем использования служб, Например, гигабайты, часы, десятки тысяч.</remarks>
        public string Unit { get; set; }

        /// <summary>
        /// Потребленный объем.
        /// </summary>
        /// <remarks>Содержит объем ресурсов, израсходованных за этот день.</remarks>
        public string Spent { get; set; }

        /// <summary>
        /// Расположение ресурса.
        /// </summary>
        /// <remarks>
        /// В тех случаях, когда это уместно и доступно для служб, данный столбец указывает расположение центра обработки данных в регионе. Текущие субрегионы включают в себя следующее:
        ///     * Восточная Азия
        ///     * Юго-Восточная Азия
        ///     * Северная Европа
        ///     * Западная Европа
        ///     * Северо-Центральный регион США
        ///     * Юго-Центральный регион США
        /// Определяет центр обработки данных, где выполняется ресурс.
        /// </remarks>
        public string SubRegion { get; set; }

        /// <summary>
        /// Потребленная служба.
        /// </summary>
        /// <remarks>Этот столбец используется для указания отдельной службы на платформе Azure, имя которой может быть не указано в столбце «Имя». В этом столбце указывается конкретная служба, которая была использована.</remarks>
        public string Service { get; set; }

        /// <summary>
        /// Группа ресурсов.
        /// </summary>
        /// <remarks>Добавление нового столбца. Группа ресурсов, в которой выполняется развернутый ресурс. См. статью http://azure.microsoft.com/documentation/articles/resource-group-overview/. </remarks>
        public string ResourceGroup { get; set; }

        /// <summary>
        /// Идентификатор экземпляра.
        /// </summary>
        /// <remarks>Идентификатор выполняемого ресурса. Этот идентификатор содержит имя, заданное для ресурса при его создании.</remarks>
        public string Component { get; set; }

        /// <summary>
        /// Теги.
        /// </summary>
        /// <remarks>Добавление нового столбца. Новые типы ресурсов в Azure позволяет помечать ресурсы тегами. См. статью http://azure.microsoft.com/updates/organize-your-azure-resources-with-tags/. </remarks>
        public string Tags { get; set; }

        /// <summary>
        /// Дополнительная информация.
        /// </summary>
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// Сведения о службе 1.
        /// </summary>
        /// <remarks>
        /// В настоящее время этот столбец используется для указания предоставленного размера кэша или типа виртуальной машины.
        ///     * 128 МБ памяти кэша на 1 день
        ///     * 256 МБ памяти кэша на 1 день
        ///     * 512 МБ памяти кэша на 1 день
        ///     * 1024 МБ памяти кэша на 1 день
        ///     * 2048 МБ памяти кэша на 1 день
        ///     * 4096 МБ памяти кэша на 1 день
        /// Кроме того, в нем может содержаться информация об используемом домене для веб-сайта.
        /// </remarks>
        public string ServiceInfo1 { get; set; }

        /// <summary>
        /// Сведения о службе 2.
        /// </summary>
        /// <remarks>Этот столбец зарезервирован для будущего использования.</remarks>
        public string ServiceInfo2 { get; set; }

        /// <summary>
        /// Инициализация "пустого" объекта.
        /// </summary>
        public DayUsage()
        { }

        /// <summary>
        /// Инициализация объекта с данными, полученными при разборе строки файла CSV.
        /// </summary>
        /// <param name="data">Массив строк с данными из разобранной строки.</param>
        public DayUsage(string[] data)
        {
            DateOfUse = data[0];
            Name = data[1];
            ResourceGuid = data[2];
            Type = data[3];
            Resource = data[4];
            Region = data[5];
            Unit = data[6];
            Spent = data[7];
            SubRegion = data[8];
            Service = data[9];
            Component = data[10];
            ServiceInfo1 = data[11];
            ServiceInfo2 = data[12];
            AdditionalInfo = data[13];
        }
    }
}
