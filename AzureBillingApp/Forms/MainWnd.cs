using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using App.Core;
using App.Core.Helpers;
using App.Core.Tree;
using AzureBillingApp.Helpers;
using AzureBillingApp.Models;

namespace AzureBillingApp.Forms
{
    /// <summary>
    /// Главное окно приложения.
    /// </summary>
    public partial class MainWnd : Form
    {
        #region Данные формы

        /// <summary>
        /// Коллекция с рабочими данными приложения - историей платежей по периодам.
        /// </summary>
        private BillingDataCollection _collection;

        /// <summary>
        /// Модель с данными для отображения подробностей о выбранном периоде.
        /// </summary>
        private DetailsViewModel _detailsViewModel;

        /// <summary>
        /// Имя и путь для текузего открытоо файла с историей.
        /// </summary>
        private string _currentFilename = "";

        /// <summary>
        /// Изменилось ли состояние файла.
        /// </summary>
        /// <remarks>Меняется при добавлении нового периода в окне.</remarks>
        private bool _isChanging;

        private BillingDataTree _tree;

        #endregion

        /// <summary>
        /// Инициализация главного окна приложения.
        /// </summary>
        public MainWnd()
        {
            InitializeComponent();

            InitWindow();

            ChangeStatusText("Приложение готово к работе");
        }

        /// <summary>
        /// Инициализация окна и его компонентов.
        /// </summary>
        /// <param name="visible">Видимость компонентов.</param>
        /// <param name="wndText">Текст в окне, который отображает название окна.</param>
        private void InitWindow(bool visible = false, string wndText = "")
        {
            treeView1.Visible = visible;
            AddButton.Visible = visible;
            SummaryButton.Visible = visible;
            SummaryGraphButton.Visible = visible;
            groupBox1.Visible = visible;
            DetailsButton.Enabled = !visible;

            saveAsToolStripMenuItem.Enabled = visible;
            closeToolStripMenuItem.Enabled = visible;

            this.Text = AppendWindowText(wndText);
        }

        /// <summary>
        /// Функция для изменения текста в заголовке главного окна приложения.
        /// </summary>
        /// <param name="appendText">Текст для добавления.</param>
        /// <returns>Возвращает либо текст по умолчанию, если добавляемый текст пуст, либо расширенный текст для заголова.</returns>
        private string AppendWindowText(string appendText)
        {
            if (!String.IsNullOrEmpty(appendText))
                return String.Format("Azure Billing Viewer [{0}]", appendText);
            return "Azure Billing Viewer";
        }

        /// <summary>
        /// Изменение сообщения в статусной панели.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        private void ChangeStatusText(string message)
        {
            statusStrip1.Items[0].Text = message;
        }

        #region Отображение сведений в виде списка и подробностей

        /// <summary>
        /// Показ списка периодов из истории.
        /// </summary>
        private void ShowList()
        {
            treeView1.Nodes.Clear();

            /*
            // получение списка подписок для группировки периодов по ним в дереве
            var subscriptions = _collection.GetSubscriptions();

            foreach (var subscription in subscriptions)
            {
                var node = treeView1.Nodes.Add(subscription.SubscriptionName);

                var data = _collection.GetBillingDataBySubscription(subscription);

                foreach (var billingData in data)
                {
                    if (billingData.GetSettlementPeriod() != null)
                        node.Nodes.Add(billingData.GetSettlementPeriod());
                }
            }*/

            _tree = new BillingDataTree(_collection);

            foreach (var node in _tree.Root.Nodes)
            {
                var root = treeView1.Nodes.Add(node.Name);

                // добавление второго уровня дерева (собственно узлы с периодами)
                if (node.Nodes.Any())
                    InsertNodes(root, node.Nodes);
            }

            // старый код для добавления узло в виде названий периодов, которые включены в файл с данными
            /*foreach (var historyFile in _collection.History.BillingDataFiles)
            {
                treeView1.Nodes.Add(CreateNode(historyFile));so
            }*/
        }

        /// <summary>
        /// Рекурсивная вставка узлов в дерево TreeView из исходного дерева с данными.
        /// </summary>
        /// <param name="rootNode">Крневой узел дерева.</param>
        /// <param name="nodes">Узлы с данными для вставки.</param>
        private void InsertNodes(TreeNode rootNode, List<BillingDataNode> nodes)
        {
            foreach (var node in nodes)
            {
                var root = rootNode.Nodes.Add(node.Name);

                // если есть еще уровни вложенности, то рекурсивно добавляем их в дерево (хотя их уже не должно быть)
                if (node.Nodes.Any())
                    InsertNodes(root, node.Nodes);
            }
        }

        /// <summary>
        /// Создание узла для отображения его в списке.
        /// </summary>
        /// <param name="historyFile">Файл с данными из истории.</param>
        /// <returns>Возвращает новый узел для компонента TreeView.</returns>
        private TreeNode CreateNode(BillingDataFile historyFile)
        {
            return new TreeNode(historyFile.Name);
        }
        
        /// <summary>
        /// Отображение основных подробностей по выбраному периоду в главном окне. 
        /// </summary>
        private void ShowDetails()
        {
            // TODO: написать код для показа деталей (чати из них) в главном окне после выбора периода
            textBox1.Text = _detailsViewModel.Name;
            DetailsButton.Enabled = _detailsViewModel.BillingData != null;
        }

        #endregion

        #region Обработка событий главного меню
        
        /// <summary>
        /// Клик по элементу меню "Создать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _collection = new BillingDataCollection();

            InitWindow(true);

            ChangeStatusText("Создана пустая история платежей. Добавьте в нее периоды оплаты и данные о ней.");
        }

        /// <summary>
        /// Клик по элементу меню "Открыть"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "XML-файлы|*.xml";
            dlg.ShowDialog();
            if (!String.IsNullOrEmpty(dlg.FileName))
            {
                _currentFilename = dlg.FileName;

                var history = HistoryFileWorker.LoadFromFile(dlg.FileName);
                _collection = new BillingDataCollection(history);

                InitWindow(true, history.Name);

                ChangeStatusText("Загружены данные о истории платежей из файла.");

                ShowList();
            }
        }

        /// <summary>
        /// Клик по элементу меню "Сохранит как"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog();
            dlg.Filter = "XML-файлы|*.xml";
            dlg.ShowDialog();
            if (!String.IsNullOrEmpty(dlg.FileName))
            {
                BillingDataCollectionHelper.Save(_collection, dlg.FileName);

                ChangeStatusText("История успешно сохранена в файл.");
            }
        }

        /// <summary>
        /// Клик по элементу меню "Закрыть"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_isChanging)
            {
                if (MessageBox.Show("Сохранить изменения", "Сохранение изменений",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!String.IsNullOrEmpty(_currentFilename))
                        BillingDataCollectionHelper.Save(_collection, _currentFilename);
                    else
                        saveAsToolStripMenuItem_Click(null, null);
                }
            }

            if (_collection != null) _collection.Clear();

            InitWindow();

            ChangeStatusText("Завершена работа с историей платежей. Начните работу сначала.");
        }

        /// <summary>
        /// Клик по элементу меню "Выход"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        } 

        #endregion

        #region Обработка событий кнопок на форме

        /// <summary>
        /// Добавление нового периода оплаты вместе с файлом, который содержит сами данные.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            var wnd = new SelectBillingFileWnd();
            wnd.ShowDialog();
            if (wnd.DialogResult == DialogResult.OK)
            {
                _collection.Add(wnd.DataFile);

                _isChanging = true;

                ShowList();
            }
        }

        /// <summary>
        /// Вызов окна для просмотра общих сводных подробностей и использовании облачных ресурсов на основе файлов с данными по каждому периоду оплаты.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SummaryButton_Click(object sender, EventArgs e)
        {
            var model = BillingDataCollectionHelper.GenerateSummaryViewModel(_collection);

            var wnd = new SummaryWnd(model);
            wnd.ShowDialog();
        }

        /// <summary>
        /// Вызов окно для просмотра подробностей о суммарном использовании в виде графика.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SummaryGraphButton_Click(object sender, EventArgs e)
        {
            var model = BillingDataCollectionHelper.GenerateGraphDataViewModel(_collection);

            var wnd = new SummaryGraphWnd(model);
            wnd.ShowDialog();
        }

        /// <summary>
        /// Вызов окна для просмотра подробностей по выбраному периоду.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailsButton_Click(object sender, EventArgs e)
        {
            var wnd = new DetailsWnd(_detailsViewModel);
            wnd.ShowDialog();
        }

        #endregion

        #region Обработка событий формы

        /// <summary>
        /// Событие, предшествующее закрытию формы. Проводится проверка на возможность закрытия окна.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWnd_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Действительно выйти из приложения?", "Подтверждение выхода",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                e.Cancel = false;
                // TODO: предусмотреть возможность запроса диалога на сохранение, если были изменения
                if (_isChanging)
                {
                    if (MessageBox.Show("Сохранить изменения", "Сохранение изменений",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (!String.IsNullOrEmpty(_currentFilename))
                            BillingDataCollectionHelper.Save(_collection, _currentFilename);
                        else
                            saveAsToolStripMenuItem_Click(null, null);
                    }
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region Обработка событий списка с периодами (истории) компонента TreeView

        /// <summary>
        /// Выбор периода из списка.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // TODO: внести изменения в обработку выбора элементов в дереве по периодам

            //MessageBox.Show("Selected " + e.Node.Text);

            var node = _tree.GetNodeByName(_tree.Root, e.Node.Text);

            if (node != null)
            {
                _detailsViewModel = new DetailsViewModel();
                _detailsViewModel.BillingData = node.BillingData;
                _detailsViewModel.Name = node.Name;
            }

            /*var index =
                _collection.History.BillingDataFiles.IndexOf(
                    _collection.History.BillingDataFiles.Single(f => f.Name == e.Node.Text));
            
            _detailsViewModel = new DetailsViewModel();
            _detailsViewModel.BillingData = _collection.BillingDatas[index];
            _detailsViewModel.Name = e.Node.Text;
            */

            ShowDetails();
        }

        #endregion
    }
}
