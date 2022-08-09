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
            //Запарсить текстовые файлы и вывести время
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            string[] RCCLines = System.IO.File.ReadAllLines(RCCPath.Text);
            string[] appealsLines = System.IO.File.ReadAllLines(appealsPath.Text);

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}m {1:00}.{2:00}s",
                ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            leadTimeValueLabel.Text = elapsedTime;

            //Подсчитать
            this.executorData = new Dictionary<string, int[]> ();
            countDocuments(RCCLines, 0);
            countDocuments(appealsLines, 1);

            //Вывести в таблицу
            foreach(var executorName in this.executorData.Keys)
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
        }

        private void saveAsRtf_Click(object sender, EventArgs e)
        {
            //Сгенерировать rtf и выдать
        }
    }
}