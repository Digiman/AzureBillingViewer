using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using App.Common.Enums;
using App.CoreV2.Elements;
using AzureBillingAppV2.Models;

namespace AzureBillingAppV2.Forms
{
    /// <summary>
    /// Окно для отображения подробных сведений за выбранный период.
    /// </summary>
    public partial class DetailsWnd : Form
    {
        /// <summary>
        /// Модель с данными.
        /// </summary>
        private readonly DetailsViewModel _model;

        /// <summary>
        /// Инициализация окна для просмотра подробностей о расчетном периоде.
        /// </summary>
        /// <param name="model">Модель с данными для отображения на форме.</param>
        public DetailsWnd(DetailsViewModel model)
        {
            InitializeComponent();

            _model = model;

            InitWindow();
        }

        /// <summary>
        /// Инициализация окна и вывод данных в его компоненты.
        /// </summary>
        private void InitWindow()
        {
            this.Text = String.Format("Подробности о периоде - {0}", _model.Name);

            LoadDataToFilters();

            // вывод сведений о подписках
            OutputSubscriptionData(_model.BillingData.SubscriptionStatuses);

            // вывод деклараций
            OutputDeclarationsData(_model.BillingData.Declarations, declarationsDataGrid);

            //dataGridView1.DataSource = _model.BillingData.DayUsages;
            OutputDayUsageData(_model.BillingData.DayUsages, dayUsagesDataGrid);
        }

        /// <summary>
        /// Загрузка данных в фильтры для выбора их из выпадающего списка.
        /// </summary>
        private void LoadDataToFilters()
        {
            comboBox1.Items.AddRange(_model.BillingData.GetUniqueStrings(DayUsageValues.Names).ToArray());
            comboBox2.Items.AddRange(_model.BillingData.GetUniqueStrings(DayUsageValues.Resourses).ToArray());
            comboBox3.Items.AddRange(_model.BillingData.GetUniqueStrings(DayUsageValues.SubRegions).ToArray());
            comboBox4.Items.AddRange(_model.BillingData.GetUniqueStrings(DayUsageValues.Services).ToArray());
            comboBox5.Items.AddRange(_model.BillingData.GetUniqueStrings(DayUsageValues.Components).ToArray());
        }

        #region Обработка событий кнопок на форме

        /// <summary>
        /// Нажатие кнопки "Закрыть" для закрытия текущего окна.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Нажатие кнопки "Фильтр" для применение фильтра по выбранным параметрам.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilterButton_Click(object sender, EventArgs e)
        {
            var filter = new DayUsageFilter();
            filter.Name = comboBox1.Text;
            filter.Resource = comboBox2.Text;
            filter.Subregion = comboBox3.Text;
            filter.Service = comboBox4.Text;
            filter.Component = comboBox5.Text;


            var filteredData = _model.ApplyFilter(filter);

            if (filteredData != null) OutputDayUsageData(filteredData, dayUsagesDataGrid);
        }

        /// <summary>
        /// Нажатие кнопки "Сброс" для сброса параметров фильтрации.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetButton_Click(object sender, EventArgs e)
        {
            // сброс текста в списках для фильтрации
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            
            OutputDayUsageData(_model.BillingData.DayUsages, dayUsagesDataGrid);
        }

        #endregion

        #region Отображение данных по периоду для каждого из блоков

        /// <summary>
        /// Отображение сведений о подписка в рамках текущего периода.
        /// </summary>
        /// <param name="subscriptionStatuses">Данные о подписках.</param>
        /// <remarks>Дело в том, что по сути то подписка будет одна. Поэтому здесь отображаются данны о подписке вместе с состоянием заказа, который собственно и представлен в виде расходов по расчетному периоду.</remarks>
        private void OutputSubscriptionData(List<SubscriptionStatus> subscriptionStatuses)
        {
            int i = 0;

            textBox1.Text = subscriptionStatuses[i].SubscriptionId;
            textBox2.Text = subscriptionStatuses[i].SubscriptionName;
            textBox3.Text = subscriptionStatuses[i].IdOrder;
            textBox4.Text = subscriptionStatuses[i].TitleOfPropostal;
            textBox5.Text = subscriptionStatuses[i].ServiceName;
        }

        /// <summary>
        /// Отображение сведений о подписках в рамках текущего периода.
        /// </summary>
        /// <param name="declarations">Сведения о выписанных заявлениях в расчетном периоде.</param>
        /// <param name="dgv">Компонент таблицы, куда выводить данные.</param>
        private void OutputDeclarationsData(List<Declaration> declarations, DataGridView dgv)
        {
            dgv.Rows.Clear();

            if (declarations.Count() == 0)
                return;

            dgv.RowCount = declarations.Count();
            dgv.ColumnCount = 14;

            dgv.RowHeadersVisible = false;
            dgv.Columns[0].HeaderText = "Расчетный период";
            dgv.Columns[0].Width = 80;
            dgv.Columns[1].HeaderText = "Имя";
            dgv.Columns[1].Width = 100;
            dgv.Columns[2].HeaderText = "Тип";
            dgv.Columns[2].Width = 150;
            dgv.Columns[3].HeaderText = "Ресурс";
            dgv.Columns[3].Width = 120;
            dgv.Columns[4].HeaderText = "Регион";
            dgv.Columns[4].Width = 120;
            dgv.Columns[5].HeaderText = "SKU";
            dgv.Columns[5].Width = 120;
            dgv.Columns[6].HeaderText = "Единица";
            dgv.Columns[6].Width = 120;
            dgv.Columns[7].HeaderText = "Израсходовано";
            dgv.Columns[7].Width = 120;
            dgv.Columns[8].HeaderText = "Включено";
            dgv.Columns[8].Width = 120;
            dgv.Columns[9].HeaderText = "Подлежит оплате";
            dgv.Columns[9].Width = 120;
            dgv.Columns[10].HeaderText = "Валюта";
            dgv.Columns[10].Width = 120;
            dgv.Columns[11].HeaderText = "Тариф";
            dgv.Columns[11].Width = 120;
            dgv.Columns[12].HeaderText = "Значение";
            dgv.Columns[12].Width = 120;

            int i = 0;
            foreach (var usage in declarations)
            {
                dgv[0, i].Value = usage.SettlementPeriod;
                dgv[1, i].Value = usage.Name;
                dgv[2, i].Value = usage.Type;
                dgv[3, i].Value = usage.Resource;
                dgv[4, i].Value = usage.Region;
                dgv[5, i].Value = usage.SKU;
                dgv[6, i].Value = usage.Unit;
                dgv[7, i].Value = usage.Spent;
                dgv[8, i].Value = usage.Include;
                dgv[9, i].Value = usage.Payable;
                dgv[10, i].Value = usage.Currency;
                dgv[11, i].Value = usage.Tariff;
                dgv[12, i].Value = usage.Value;

                i++;
            }
        }

        /// <summary>
        /// Вывод данных для ежедневного использования.
        /// Для поддержки новой версии (версии 2) файла с данными об использовании.
        /// </summary>
        /// <param name="data">Данные для вывода в таблицу.</param>
        /// <param name="dgv">Таблица (компонент формы), куда будут выводиться данные.</param>
        private void OutputDayUsageData(List<DayUsage> data, DataGridView dgv)
        {
            dgv.Rows.Clear();

            if (data.Count() == 0)
                return;

            dgv.RowCount = data.Count();
            dgv.ColumnCount = 16;

            dgv.RowHeadersVisible = false;
            dgv.Columns[0].HeaderText = "Дата использования";
            dgv.Columns[0].Width = 80;
            dgv.Columns[1].HeaderText = "Категория средства измерения";
            dgv.Columns[1].Width = 100;
            dgv.Columns[2].HeaderText = "Идентификатор средства измерения";
            dgv.Columns[2].Width = 150;
            dgv.Columns[3].HeaderText = "Подкатегория средства измерения";
            dgv.Columns[3].Width = 120;
            dgv.Columns[4].HeaderText = "Имя средства измерения";
            dgv.Columns[4].Width = 120;
            dgv.Columns[5].HeaderText = "Регион";
            dgv.Columns[5].Width = 120;
            dgv.Columns[6].HeaderText = "Единица";
            dgv.Columns[6].Width = 120;
            dgv.Columns[7].HeaderText = "Потребленный объем";
            dgv.Columns[7].Width = 120;
            dgv.Columns[8].HeaderText = "Расположение ресурса";
            dgv.Columns[8].Width = 120;
            dgv.Columns[9].HeaderText = "Потребленная служба";
            dgv.Columns[9].Width = 120;
            dgv.Columns[10].HeaderText = "Группа ресурсов";
            dgv.Columns[10].Width = 120;
            dgv.Columns[11].HeaderText = "Идентификатор экземпляра";
            dgv.Columns[11].Width = 120;
            dgv.Columns[12].HeaderText = "Тэги";
            dgv.Columns[12].Width = 120;
            dgv.Columns[13].HeaderText = "Дополнительнай информация";
            dgv.Columns[13].Width = 120;
            dgv.Columns[14].HeaderText = "Сведения о службе 1";
            dgv.Columns[14].Width = 120;
            dgv.Columns[15].HeaderText = "Сведения о службе 2";
            dgv.Columns[15].Width = 120;

            int i = 0;
            foreach (var usage in data)
            {
                dgv[0, i].Value = usage.DateOfUse;
                dgv[1, i].Value = usage.Name;
                dgv[2, i].Value = usage.ResourceGuid;
                dgv[3, i].Value = usage.Type;
                dgv[4, i].Value = usage.Resource;
                dgv[5, i].Value = usage.Region;
                dgv[6, i].Value = usage.Unit;
                dgv[7, i].Value = usage.Spent;
                dgv[8, i].Value = usage.SubRegion;
                dgv[9, i].Value = usage.Service;
                dgv[10, i].Value = usage.ResourceGroup;
                dgv[11, i].Value = usage.Component;
                dgv[12, i].Value = usage.Tags;
                dgv[13, i].Value = usage.AdditionalInfo;
                dgv[14, i].Value = usage.ServiceInfo1;
                dgv[15, i].Value = usage.ServiceInfo2;
                

                // NOTE: здесь размещается код для описания форматов подсветки цветами строк в таблице с ежедневным использованием
                switch (usage.Service)
                {
                    case "Web Sites":
                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
                        break;
                    case "Web Sites - Free":
                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.Aquamarine;
                        break;
                    case "Web Sites - Shared":
                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                        break;
                    case "Database":
                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.Aqua;
                        break;
                    case "Storage":
                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                        break;
                    case "Compute":
                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.Plum;
                        break;
                }

                // подсветка цветом строк по имени, то что не проходит по типу ресурсов (потому что именно сайты почему-то не попадают туда)
                switch (usage.Name)
                {
                    case "Веб-сайты":
                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.GreenYellow;
                        break;
                }

                i++;
            }
        }

        #endregion
    }
}
