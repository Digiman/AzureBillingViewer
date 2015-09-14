using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using AzureBillingAppV2.Models;

namespace AzureBillingAppV2.Forms
{
    /// <summary>
    /// Окно для отображения графика использования по периодам.
    /// </summary>
    public partial class SummaryGraphWnd : Form
    {
        /// <summary>
        /// Модель с данными для графика и другие вспомогательные данные.
        /// </summary>
        private GraphDataViewModel _model;

        /// <summary>
        /// Инициализация окна с данными для отображения их на графике.
        /// </summary>
        /// <param name="model">Модель с данными.</param>
        public SummaryGraphWnd(GraphDataViewModel model)
        {
            InitializeComponent();

            _model = model;

            OutputData(model);
        }

        /// <summary>
        /// Отображение данных по модели.
        /// </summary>
        /// <param name="model">Модель с данными для построения графика.</param>
        private void OutputData(GraphDataViewModel model)
        {
            chart1.Series.Clear();
            chart1.Series.Add(CreateDataSeries(model.SpentByPeriods));
            chart1.Series[0].IsValueShownAsLabel = true;
        }

        /// <summary>
        /// Формирование данных для графика, которые будут на нем отображены.
        /// </summary>
        /// <param name="results">Результаты для отображения.</param>
        /// <returns>Возвразает серию с данными в виде точек на графике с настроенным типом графика.</returns>
        private Series CreateDataSeries(Dictionary<string, double> results)
        {
            var series = new Series();

            foreach (var result in results)
            {
                series.Points.AddXY(result.Key, result.Value);
            }

            series.ChartType = SeriesChartType.Column;

            return series;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
