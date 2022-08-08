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
            if(RCCPath.Text != "" && appealsPath.Text != "")
            {
                countButton.Enabled = true;
                return;
            }
            countButton.Enabled = false;
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
            //Подсчитать
            //Вывести в таблицу
        }

        private void saveAsRtf_Click(object sender, EventArgs e)
        {
            //Сгенерировать rtf и выдать
        }
    }
}