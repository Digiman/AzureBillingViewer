using System;
using System.Windows.Forms;
using App.Core;

namespace AzureBillingApp.Forms
{
    /// <summary>
    /// Окно для выбора нового файла с данными о платежах за период, полученный с портала Azure.
    /// </summary>
    public partial class SelectBillingFileWnd : Form
    {
        /// <summary>
        /// Файл с данными, который был выбран и успешно сформирован.
        /// </summary>
        public BillingDataFile DataFile;

        public SelectBillingFileWnd()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.Cancel;
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(FileTextBox.Text) && !String.IsNullOrEmpty(NameTextBox.Text))
            {
                DataFile = new BillingDataFile {Name = NameTextBox.Text, Filename = FileTextBox.Text};
                if (!String.IsNullOrEmpty(DescriptionTextBox.Text)) DataFile.Description = DescriptionTextBox.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Необходимо указать название и выбрать файл с данными!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "CSV файлы|*.csv";
            dlg.ShowDialog();
            if (!String.IsNullOrEmpty(dlg.FileName))
            {
                FileTextBox.Text = dlg.FileName;
            }
        }
    }
}
