using Aspose.Pdf.Drawing;
using Aspose.Pdf.Operators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
            InitComboxValue();
            this.PageExportCheck.Checked = true;
            this.PageExportCheck.Enabled = false;

            this.MergePdfButton.Enabled = false;

            //Util.PlayMp3WithStream();
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

            //DocumentsListView
            this.DocumentsListView.View = View.Details;
            this.DocumentsListView.FullRowSelect = true;
            this.DocumentsListView.Columns.Add("文件名称", 300);
            this.DocumentsListView.Columns.Add("添加时间", 300);
            this.DocumentsListView.Columns.Add("转换后文件名称", 300);

            //PDF2ExcelFileView
            this.PDF2ExcelFileView.View = View.Details;
            this.PDF2ExcelFileView.FullRowSelect = true;
            this.PDF2ExcelFileView.Columns.Add("文件名称", 300);
            this.PDF2ExcelFileView.Columns.Add("添加时间", 300);
            this.PDF2ExcelFileView.Columns.Add("转换后文件名称", 300);

            //MergePdfFileView
            this.MergePdfFileView.View = View.Details;
            this.MergePdfFileView.FullRowSelect = true;
            this.MergePdfFileView.Columns.Add("文件名称", 300);
            this.MergePdfFileView.Columns.Add("添加时间", 300);
            this.MergePdfFileView.Columns.Add("转换后文件名称", 300);


        }

        private void InitComboxValue()
        {
            DataTable ImageConverTypeData = new DataTable();
            ImageConverTypeData.Columns.Add("ImageTypeDisplayName");
            ImageConverTypeData.Columns.Add("ImageTypeValueName");

            ImageConverTypeData.Rows.Add("JPG",".jpg");
            ImageConverTypeData.Rows.Add("PNG",".png");
            ImageConverTypeData.Rows.Add("BMP", ".bmp");
            ImageConverTypeData.Rows.Add("TIFF",".tif");

            this.ConvertImageList.DataSource = ImageConverTypeData;
            this.ConvertImageList.DisplayMember = "ImageTypeDisplayName";
            this.ConvertImageList.ValueMember = "ImageTypeValueName";

            this.ConvertImageList.DropDownStyle = ComboBoxStyle.DropDownList;


            DataTable DpiStorgeTable = new DataTable();
            DpiStorgeTable.Columns.Add("DpiDisplayName");
            DpiStorgeTable.Columns.Add("DpiValue");

            DpiStorgeTable.Rows.Add("150DPI",150);
            DpiStorgeTable.Rows.Add("200DPI",200);
            DpiStorgeTable.Rows.Add("250DPI",250);
            DpiStorgeTable.Rows.Add("300DPI",300);
            DpiStorgeTable.Rows.Add("350DPI",350);
            DpiStorgeTable.Rows.Add("400DPI",400);
            DpiStorgeTable.Rows.Add("450DPI",450);
            DpiStorgeTable.Rows.Add("500DPI",500);
            DpiStorgeTable.Rows.Add("550DPI",550);
            DpiStorgeTable.Rows.Add("600DPI",600);

            this.DpiItemList.DataSource = DpiStorgeTable;
            this.DpiItemList.DisplayMember = "DpiDisplayName";
            this.DpiItemList.ValueMember = "DpiValue";

            this.DpiItemList.DropDownStyle = ComboBoxStyle.DropDownList;
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

        private void ConvertImageList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void ConvertWord2ImageButton_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    UI.ConvertStart(this.DocumentsListView, this.ConvertWord2ImageStatus, ConvertFileType.Word2Image, this.ConvertImageList.SelectedValue.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            });
           
        }

        private void SelectWord2ImageFileButton_Click(object sender, EventArgs e)
        {
            UI.AddWord2ImageFiles();
        }

        private void DpiItemList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ConvertTextButton_Click(object sender, EventArgs e)
        {
            TargetTextBox.Lines =  Util.AddText2List(SourceTextBox.Text,DoubleTextAlignCheck.Checked,RemoveNumberCheck.Checked,RemoveSquareCheck.Checked,NameStorkeChcek.Checked);

            
        }

        private void SourceTextBox_TextChanged(object sender, EventArgs e)
        {
            //如果启用多行模式，则每次添加文本后，都在末尾添加\t控制字符
            if(MutilLineMode.Checked)
            {
                SourceTextBox.AppendText("\t");
            }
        }

        private void TargetTextBox_TextChanged(object sender, EventArgs e)
        {
            TargetTextNumberText.Text = $"处理后姓名有{TargetTextBox.Lines.Length}个";

        }

        private void MutilLineMode_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void SelectPDF2ExcelButton_Click(object sender, EventArgs e)
        {
            UI.AddPdf2ExcelFiles();
        }

        private void ConvertPDF2Excel_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    UI.ConvertStart(this.PDF2ExcelFileView, this.ConvertPDF2ExcelStatusText, ConvertFileType.Pdf2Excel, ".xlsx");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            });

        }

        private void MeregePdfFileButtonConvert_Click(object sender, EventArgs e)
        {
            Task<List<string>> MeregePdfFiles = UI.GetListViewFirstItemContent(this.MergePdfFileView);
            if (MeregePdfFiles.Result.Count > 0)
            {
                string MeregePdfFileName = Util.ShowSaveFileDialog("PDF文档|.pdf", "设置文件名称");
                if (MeregePdfFileName != string.Empty)
                {
                    Task.Run(() => {
                        try
                        {
                            string MeregeDirectory = System.IO.Path.GetDirectoryName(MeregePdfFileName);
                            this.MeregePdfFileStatusText.Text = "正在合并中...";
                            Util.MergrePdfFIle(MeregePdfFiles.Result, MeregePdfFileName);
                            this.MeregePdfFileStatusText.Text = "合并完毕";
                            if (OpenMeregePdfFile.Checked)
                            {
                                Process.Start(MeregePdfFileName);
                            }
                            this.BeginInvoke(new Action(() => {
                                DialogResult OpenResult = MessageBox.Show("合并完毕，是否需要打开合并文件所在目录？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                                if (OpenResult == DialogResult.Yes)
                                {
                                    Process.Start(MeregeDirectory);
                                }
                            }));
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                    });


                }
            }
        }

        private void MergePdfFileSelectButton_Click(object sender, EventArgs e)
        {
            UI.AddMeregePdfFiles();
        }
    }

}
