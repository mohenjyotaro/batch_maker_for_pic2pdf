namespace batch_maker_for_pic2pdf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // 画像ファイルを含むフォルダを取得
                List<string> bookDirs = Directory.GetDirectories(this.textBox1.Text, "*", SearchOption.AllDirectories).ToList<string>().FindAll(x => {
                    // 50ページ以上ならOK
                    return Directory.GetFiles(x).Length > 50;
                });

                // バッチ文字列生成
                List<string> batchList = new List<string>();
                string exeFileName = "pic2pdf.exe";
                string iniFileName = "pic2pdf.ini";
                foreach (string dir in bookDirs)
                {
                    string pdfFileName = System.IO.Path.Combine("output", System.IO.Path.GetFileName(dir));
                    batchList.Add(string.Format("cmd /c \"{0}\" \"{1}\" \"{2}\" \"{3}\"", exeFileName, dir, pdfFileName, iniFileName));
                }

                // バッチファイル作成
                File.WriteAllLines(this.textBox3.Text, batchList.ToArray());

                MessageBox.Show("バッチファイル作成完了😁😁😁");
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}