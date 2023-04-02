using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentTools
{

    public partial class BodyForm : Form
    {
        public static BodyForm MainForm;

        public BodyForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            MainForm = this;
        }
        private void BodyForm_Load(object sender, EventArgs e)
        {
            InitListView();
            this.MergePdfButton.Enabled = true;
        }

        private void InitListView()
        {
            // WordFileListView
            this.WordFileListView.View = View.Details;
            this.WordFileListView.FullRowSelect = true;
            this.WordFileListView.Columns.Add("文件名称", 300);
            this.WordFileListView.Columns.Add("添加时间", 300);
            this.WordFileListView.Columns.Add("转换后文件名称", 300);

            //PdfFileListView
            this.PdfFileListView.View = View.Details;
            this.PdfFileListView.FullRowSelect = true;
            this.PdfFileListView.Columns.Add("文件名称", 300);
            this.PdfFileListView.Columns.Add("添加时间", 300);
            this.PdfFileListView.Columns.Add("转换后文件名称", 300);

            //ExcelFileListView
            this.ExcelFileListView.View = View.Details;
            this.ExcelFileListView.FullRowSelect = true;
            this.ExcelFileListView.Columns.Add("文件名称", 300);
            this.ExcelFileListView.Columns.Add("添加时间", 300);
            this.ExcelFileListView.Columns.Add("转换后文件名称", 300);

        }

        private void ChooseDocButton_Click(object sender, EventArgs e)
        {
            Task<int> FileCount = UI.AddWordFiles();
            this.StatusText.Text = $"{FileCount.Result}个待转换文档";
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    UI.ConvertStart(this.WordFileListView, this.StatusText, ConvertFileType.Word2Pdf, ".pdf");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            });


        }

        private void SelectPdfButton_Click(object sender, EventArgs e)
        {
            UI.AddPdfFiles();
        }

        private void Convert2DocButton_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    UI.ConvertStart(this.PdfFileListView, this.PdfStatusText, ConvertFileType.Pdf2Word, ".docx");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            });


        }

        private void SelectExcelFileButton_Click(object sender, EventArgs e)
        {
            UI.AddExcelFiles();
        }

        private void MergePdfButton_Click(object sender, EventArgs e)
        {

            Task<List<string>> WaitMergePdfFileNames = UI.GetListViewLastItemContent(this.WordFileListView);
            if (WaitMergePdfFileNames.Result.Count > 0)
            {
                string SaveMergePdfFileName = Util.ShowSaveFileDialog("PDF文件|*.pdf", "设置要保存的PDF文件名称");
                if (SaveMergePdfFileName != string.Empty)
                {
                    Util.MergrePdfFIle(WaitMergePdfFileNames.Result, SaveMergePdfFileName);
                    MessageBox.Show("合并完毕","提示",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                }
            }
        }

        private void ConvertExcel2PdfButton_Click(object sender, EventArgs e)
        {

            Task.Run(() =>
            {
                try
                {
                    UI.ConvertStart(this.ExcelFileListView, this.Excel2PdfStatusText, ConvertFileType.Excel2Pdf, ".pdf");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            });
        }
    }
}
