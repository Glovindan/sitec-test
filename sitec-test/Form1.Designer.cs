namespace sitec_test
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.selectRCCPathButton = new System.Windows.Forms.Button();
            this.selectAppealsPathButton = new System.Windows.Forms.Button();
            this.RCCPath = new System.Windows.Forms.TextBox();
            this.appealsPath = new System.Windows.Forms.TextBox();
            this.outputTable = new System.Windows.Forms.DataGridView();
            this.ExecutorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RCCCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appealsCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentsTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveAsRtf = new System.Windows.Forms.Button();
            this.leadTimeValueLabel = new System.Windows.Forms.Label();
            this.leadTimeLabel = new System.Windows.Forms.Label();
            this.countButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.outputTable)).BeginInit();
            this.SuspendLayout();
            // 
            // selectRCCPathButton
            // 
            this.selectRCCPathButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectRCCPathButton.Location = new System.Drawing.Point(363, 12);
            this.selectRCCPathButton.Name = "selectRCCPathButton";
            this.selectRCCPathButton.Size = new System.Drawing.Size(135, 29);
            this.selectRCCPathButton.TabIndex = 0;
            this.selectRCCPathButton.Text = "Выбрать файл";
            this.selectRCCPathButton.UseVisualStyleBackColor = true;
            this.selectRCCPathButton.Click += new System.EventHandler(this.selectRCCPathButton_Click);
            // 
            // selectAppealsPathButton
            // 
            this.selectAppealsPathButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectAppealsPathButton.Location = new System.Drawing.Point(363, 47);
            this.selectAppealsPathButton.Name = "selectAppealsPathButton";
            this.selectAppealsPathButton.Size = new System.Drawing.Size(135, 29);
            this.selectAppealsPathButton.TabIndex = 1;
            this.selectAppealsPathButton.Text = "Выбрать файл";
            this.selectAppealsPathButton.UseVisualStyleBackColor = true;
            this.selectAppealsPathButton.Click += new System.EventHandler(this.selectAppealsPathButton_Click);
            // 
            // RCCPath
            // 
            this.RCCPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.RCCPath.Location = new System.Drawing.Point(12, 12);
            this.RCCPath.Name = "RCCPath";
            this.RCCPath.PlaceholderText = "Путь к данным по РКК";
            this.RCCPath.Size = new System.Drawing.Size(345, 27);
            this.RCCPath.TabIndex = 2;
            // 
            // appealsPath
            // 
            this.appealsPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.appealsPath.Location = new System.Drawing.Point(12, 48);
            this.appealsPath.Name = "appealsPath";
            this.appealsPath.PlaceholderText = "Путь к данным по обращениям";
            this.appealsPath.Size = new System.Drawing.Size(345, 27);
            this.appealsPath.TabIndex = 3;
            // 
            // outputTable
            // 
            this.outputTable.AllowUserToAddRows = false;
            this.outputTable.AllowUserToDeleteRows = false;
            this.outputTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.outputTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.outputTable.BackgroundColor = System.Drawing.SystemColors.Window;
            this.outputTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.outputTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExecutorName,
            this.RCCCount,
            this.appealsCount,
            this.documentsTotal});
            this.outputTable.Location = new System.Drawing.Point(12, 82);
            this.outputTable.Name = "outputTable";
            this.outputTable.ReadOnly = true;
            this.outputTable.RowHeadersWidth = 51;
            this.outputTable.RowTemplate.Height = 29;
            this.outputTable.Size = new System.Drawing.Size(776, 321);
            this.outputTable.TabIndex = 4;
            // 
            // ExecutorName
            // 
            this.ExecutorName.HeaderText = "Ответственный исполнитель";
            this.ExecutorName.MinimumWidth = 6;
            this.ExecutorName.Name = "ExecutorName";
            this.ExecutorName.ReadOnly = true;
            this.ExecutorName.Width = 217;
            // 
            // RCCCount
            // 
            this.RCCCount.HeaderText = "Количество РКК";
            this.RCCCount.MinimumWidth = 6;
            this.RCCCount.Name = "RCCCount";
            this.RCCCount.ReadOnly = true;
            this.RCCCount.Width = 137;
            // 
            // appealsCount
            // 
            this.appealsCount.HeaderText = "Количество обращений";
            this.appealsCount.MinimumWidth = 6;
            this.appealsCount.Name = "appealsCount";
            this.appealsCount.ReadOnly = true;
            this.appealsCount.Width = 187;
            // 
            // documentsTotal
            // 
            this.documentsTotal.HeaderText = "Суммарно документов";
            this.documentsTotal.MinimumWidth = 6;
            this.documentsTotal.Name = "documentsTotal";
            this.documentsTotal.ReadOnly = true;
            this.documentsTotal.Width = 180;
            // 
            // saveAsRtf
            // 
            this.saveAsRtf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveAsRtf.Location = new System.Drawing.Point(627, 409);
            this.saveAsRtf.Name = "saveAsRtf";
            this.saveAsRtf.Size = new System.Drawing.Size(161, 29);
            this.saveAsRtf.TabIndex = 5;
            this.saveAsRtf.Text = "Сохранить отчет";
            this.saveAsRtf.UseVisualStyleBackColor = true;
            this.saveAsRtf.Click += new System.EventHandler(this.saveAsRtf_Click);
            // 
            // leadTimeValueLabel
            // 
            this.leadTimeValueLabel.AutoSize = true;
            this.leadTimeValueLabel.Location = new System.Drawing.Point(248, 413);
            this.leadTimeValueLabel.Name = "leadTimeValueLabel";
            this.leadTimeValueLabel.Size = new System.Drawing.Size(0, 20);
            this.leadTimeValueLabel.TabIndex = 6;
            // 
            // leadTimeLabel
            // 
            this.leadTimeLabel.AutoSize = true;
            this.leadTimeLabel.Location = new System.Drawing.Point(15, 413);
            this.leadTimeLabel.Name = "leadTimeLabel";
            this.leadTimeLabel.Size = new System.Drawing.Size(227, 20);
            this.leadTimeLabel.TabIndex = 6;
            this.leadTimeLabel.Text = "Время выполнения алгоритма:";
            // 
            // countButton
            // 
            this.countButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.countButton.Enabled = false;
            this.countButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.countButton.Location = new System.Drawing.Point(504, 12);
            this.countButton.Name = "countButton";
            this.countButton.Size = new System.Drawing.Size(284, 63);
            this.countButton.TabIndex = 7;
            this.countButton.Text = "Посчитать";
            this.countButton.UseVisualStyleBackColor = false;
            this.countButton.Click += new System.EventHandler(this.countButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.countButton);
            this.Controls.Add(this.leadTimeLabel);
            this.Controls.Add(this.leadTimeValueLabel);
            this.Controls.Add(this.saveAsRtf);
            this.Controls.Add(this.outputTable);
            this.Controls.Add(this.appealsPath);
            this.Controls.Add(this.RCCPath);
            this.Controls.Add(this.selectAppealsPathButton);
            this.Controls.Add(this.selectRCCPathButton);
            this.Name = "Form1";
            this.Text = "Ситек";
            ((System.ComponentModel.ISupportInitialize)(this.outputTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button selectRCCPathButton;
        private Button selectAppealsPathButton;
        private TextBox RCCPath;
        private TextBox appealsPath;
        private DataGridView outputTable;
        private DataGridViewTextBoxColumn ExecutorName;
        private DataGridViewTextBoxColumn RCCCount;
        private DataGridViewTextBoxColumn appealsCount;
        private DataGridViewTextBoxColumn documentsTotal;
        private Button saveAsRtf;
        private Label leadTimeValueLabel;
        private Label leadTimeLabel;
        private Button countButton;
    }
}