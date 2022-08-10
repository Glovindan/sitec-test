using System.Diagnostics;
namespace sitec_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string getFilePathFromDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Текстовые файлы (*.txt)|*.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                return ofd.FileName;
            }
            return "";
        }

        private void isPathsSelected()
        {
            if (RCCPath.Text != "" && appealsPath.Text != "")
            {
                countButton.Enabled = true;
                return;
            }
            countButton.Enabled = false;
        }

        private Dictionary<string, int[]> executorData;
        private void countDocuments(string[] txtLines, int counterIndex)
        {
            foreach (string line in txtLines)
            {
                string[] splittedLine = line.Split("\t");
                string executorName;
                if (splittedLine[0] == "Климов Сергей Александрович")
                {
                    executorName = splittedLine[1].Split(";")[0].Replace(" (Отв.)", "");
                }
                else
                {
                    string[] executorNameSplitted = splittedLine[0].Split(" ");
                    executorName = String.Format("{0} {1}.{2}.",
                        executorNameSplitted[0], executorNameSplitted[1][0], executorNameSplitted[2][0]);
                }

                if (!this.executorData.ContainsKey(executorName))
                {
                    this.executorData.Add(executorName, new int[2]);
                }

                this.executorData[executorName][counterIndex]++;
            }
        }

        private void selectRCCPathButton_Click(object sender, EventArgs e)
        {
            string fileName = this.getFilePathFromDialog();
            RCCPath.Text = fileName;
            isPathsSelected();
        }
        
        private void selectAppealsPathButton_Click(object sender, EventArgs e)
        {
            string fileName = this.getFilePathFromDialog();
            appealsPath.Text = fileName;
            isPathsSelected();
        }

        private void countButton_Click(object sender, EventArgs e)
        {
            outputTable.Rows.Clear();
            outputTable.Refresh();
            this.executorData = new Dictionary<string, int[]>();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            //Запарсить текстовые файлы
            string[] RCCLines = System.IO.File.ReadAllLines(RCCPath.Text);
            string[] appealsLines = System.IO.File.ReadAllLines(appealsPath.Text);

            //Подсчитать
            countDocuments(RCCLines, 0);
            countDocuments(appealsLines, 1);

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0} s {1} ms",
                ts.Seconds, ts.Milliseconds);
            leadTimeValueLabel.Text = elapsedTime;

            //Вывести в таблицу
            foreach (var executorName in this.executorData.Keys)
            {
                var RCCCount = this.executorData[executorName][0];
                var appealsCount = this.executorData[executorName][1];
                var documentsTotal = RCCCount + appealsCount;

                var index = outputTable.Rows.Add();
                outputTable.Rows[index].Cells["ExecutorName"].Value = executorName;
                outputTable.Rows[index].Cells["RCCCount"].Value = RCCCount;
                outputTable.Rows[index].Cells["appealsCount"].Value = appealsCount;
                outputTable.Rows[index].Cells["documentsTotal"].Value = documentsTotal;
            }

            saveAsRtf.Enabled = true;
        }

        private void saveAsRtf_Click(object sender, EventArgs e)
        {
            int RCCTotal = 0;
            int appealsTotal = 0;
            int documentsTotal = 0;
            foreach (var item in this.executorData)
            {
                RCCTotal += item.Value[0];
                appealsTotal += item.Value[1];
                documentsTotal += item.Value[0] + item.Value[1];
            }

            SaveFileDialog sf = new SaveFileDialog();
            sf.FileName = "report.txt";

            if(sf.ShowDialog() == DialogResult.OK)
            {
                string savePath = sf.FileName;
                StreamWriter sw = File.CreateText(savePath);
                sw.WriteLine("Справка о неисполненных документах и обращениях граждан");
                sw.WriteLine("Не исполнено в срок {0} документов, из них: ", documentsTotal);
                sw.WriteLine("- количество неисполненных входящих документов: {0}", RCCTotal);
                sw.WriteLine("- количество неисполненных письменных обращений граждан: {0}", appealsTotal);

                var sortedColumn = outputTable.SortedColumn;
                string sortedColumnName = "Нет";
                if (sortedColumn != null)
                {
                    sortedColumnName = sortedColumn.HeaderText;
                }   
                sw.WriteLine("Сортировка: {0}", sortedColumnName);
                sw.WriteLine();

                for (int j = 0; j < outputTable.Columns.Count; j++)
                {
                    var value = outputTable.Columns[j].HeaderText;
                    string tabulation = "\t";
                    if (value != null && value.Length < 16)
                        tabulation = "\t\t";

                    sw.Write(outputTable.Columns[j].HeaderText + tabulation);
                }
                sw.WriteLine();

                for (int i = 0; i < outputTable.Rows.Count; i++)
                {
                    for (int j = 0; j < outputTable.Columns.Count; j++)
                    {
                        var value = outputTable.Rows[i].Cells[j].Value.ToString();
                        string tabulation = "\t\t";
                        if (value != null && value.Length < 16) 
                            tabulation = "\t\t\t";

                        sw.Write(value + tabulation);
                    }
                    sw.WriteLine();
                }

                sw.WriteLine();
                sw.WriteLine("Дата составления справки: {0}", DateTime.Now.ToString("dd.MM.yyyy"));
                sw.Close();
            }
        }

        private void outputTable_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if(e.Column.Name == "ExecutorName")
            {
                e.SortResult = String.Compare(e.CellValue1.ToString(), e.CellValue2.ToString());
                e.Handled = true;
                return;
            }

            int num1 = (int)e.CellValue1;
            int num2 = (int)e.CellValue2;

            if (num1 == num2)
            {
                if (e.Column.Name == "RCCCount")
                {
                    num1 = (int)outputTable.Rows[e.RowIndex1].Cells["appealsCount"].Value;
                    num2 = (int)outputTable.Rows[e.RowIndex2].Cells["appealsCount"].Value;
                }
                else
                {
                    num1 = (int)outputTable.Rows[e.RowIndex1].Cells["RCCCount"].Value;
                    num2 = (int)outputTable.Rows[e.RowIndex2].Cells["RCCCount"].Value;
                }
            }
            e.SortResult = num1.CompareTo(num2);
            e.Handled = true;
        }
    }
}