namespace AzureBillingApp.Forms
{
    partial class SummaryWnd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CloseButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.servicesCountTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.periodsCountTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.averageSpentTextBox = new System.Windows.Forms.TextBox();
            this.totalSpentTextBox = new System.Windows.Forms.TextBox();
            this.subscriptionCountTextBox = new System.Windows.Forms.TextBox();
            this.currencyLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(254, 245);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.Text = "Закрыть";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.servicesCountTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.periodsCountTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.averageSpentTextBox);
            this.groupBox1.Controls.Add(this.totalSpentTextBox);
            this.groupBox1.Controls.Add(this.subscriptionCountTextBox);
            this.groupBox1.Controls.Add(this.currencyLabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 227);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Общие сведения";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Количество служб";
            // 
            // servicesCountTextBox
            // 
            this.servicesCountTextBox.Location = new System.Drawing.Point(163, 124);
            this.servicesCountTextBox.Name = "servicesCountTextBox";
            this.servicesCountTextBox.ReadOnly = true;
            this.servicesCountTextBox.Size = new System.Drawing.Size(100, 20);
            this.servicesCountTextBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Количество периодов";
            // 
            // periodsCountTextBox
            // 
            this.periodsCountTextBox.Location = new System.Drawing.Point(163, 98);
            this.periodsCountTextBox.Name = "periodsCountTextBox";
            this.periodsCountTextBox.ReadOnly = true;
            this.periodsCountTextBox.Size = new System.Drawing.Size(100, 20);
            this.periodsCountTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Расходы в среднем";
            // 
            // averageSpentTextBox
            // 
            this.averageSpentTextBox.Location = new System.Drawing.Point(163, 72);
            this.averageSpentTextBox.Name = "averageSpentTextBox";
            this.averageSpentTextBox.ReadOnly = true;
            this.averageSpentTextBox.Size = new System.Drawing.Size(100, 20);
            this.averageSpentTextBox.TabIndex = 5;
            // 
            // totalSpentTextBox
            // 
            this.totalSpentTextBox.Location = new System.Drawing.Point(163, 45);
            this.totalSpentTextBox.Name = "totalSpentTextBox";
            this.totalSpentTextBox.ReadOnly = true;
            this.totalSpentTextBox.Size = new System.Drawing.Size(100, 20);
            this.totalSpentTextBox.TabIndex = 4;
            // 
            // subscriptionCountTextBox
            // 
            this.subscriptionCountTextBox.Location = new System.Drawing.Point(163, 19);
            this.subscriptionCountTextBox.Name = "subscriptionCountTextBox";
            this.subscriptionCountTextBox.ReadOnly = true;
            this.subscriptionCountTextBox.Size = new System.Drawing.Size(100, 20);
            this.subscriptionCountTextBox.TabIndex = 3;
            // 
            // currencyLabel
            // 
            this.currencyLabel.AutoSize = true;
            this.currencyLabel.Location = new System.Drawing.Point(269, 48);
            this.currencyLabel.Name = "currencyLabel";
            this.currencyLabel.Size = new System.Drawing.Size(35, 13);
            this.currencyLabel.TabIndex = 2;
            this.currencyLabel.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Израсходовано всего";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Всего подписок";
            // 
            // SummaryWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 275);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CloseButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "SummaryWnd";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сводная информация";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox servicesCountTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox periodsCountTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox averageSpentTextBox;
        private System.Windows.Forms.TextBox totalSpentTextBox;
        private System.Windows.Forms.TextBox subscriptionCountTextBox;
        private System.Windows.Forms.Label currencyLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}