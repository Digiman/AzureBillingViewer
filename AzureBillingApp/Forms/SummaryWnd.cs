using System;
using System.Windows.Forms;
using AzureBillingApp.Models;

namespace AzureBillingApp.Forms
{
    /// <summary>
    /// Окно для отображения 
    /// </summary>
    public partial class SummaryWnd : Form
    {
        /// <summary>
        /// Инициалмизация окна с данными об использовании (суммарных).
        /// </summary>
        /// <param name="model">Модель с суммарными данными об использовании.</param>
        public SummaryWnd(SummaryViewModel model)
        {
            InitializeComponent();

            OutputData(model);
        }

        /// <summary>
        /// Вывод данных в окне из модели.
        /// </summary>
        /// <param name="model">Модель с данными.</param>
        private void OutputData(SummaryViewModel model)
        {
            // TODO: настроить отображение для всех полей на форме
            subscriptionCountTextBox.Text = model.SubscriptionCount.ToString();
            totalSpentTextBox.Text = model.TotalSpent.ToString();
            averageSpentTextBox.Text = model.AverageSpent.ToString("F");
            periodsCountTextBox.Text = model.PeriodsCount.ToString();
            servicesCountTextBox.Text = model.ServicesCount.ToString();

            currencyLabel.Text = model.Currency;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
