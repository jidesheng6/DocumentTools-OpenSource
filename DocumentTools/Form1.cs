using Microsoft.WindowsAPICodePack.Shell.Interop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
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
                    if (this.WordFileListView.Items.Count > 0)
                    {
                        IEnumerable<string> ISelectSavePathstring = Util.ShwoSelectDialog(false, true, "", "");
                        string SelectSavePathstring = ISelectSavePathstring.FirstOrDefault();
                        if (SelectSavePathstring != default)
                        {
                            string TempSaveDocxPathString = Path.Combine(SelectSavePathstring, "TempDocx");
                            Directory.CreateDirectory(TempSaveDocxPathString);

                            this.SaveProgressBar.Maximum = WordFileListView.Items.Count;


                            for (int ItemIndex = 0; ItemIndex < WordFileListView.Items.Count; ItemIndex++)
                            {
                                this.SaveProgressBar.PerformStep();
                                this.StatusText.Text = $"正在转换第{ItemIndex + 1}个文档...";
                                string ListViewDispalyFileName = WordFileListView.Items[ItemIndex].Text;
                                Util.ConvertWord2Pdf(ListViewDispalyFileName, SelectSavePathstring, TempSaveDocxPathString);

                                //将PDF完整路径添加到ListView中

                                string DocumentNameWithNotExtsions = Path.GetFileNameWithoutExtension(ListViewDispalyFileName);
                                string PdfFileName = Path.Combine(SelectSavePathstring, DocumentNameWithNotExtsions + ".pdf");

                                WordFileListView.Items[ItemIndex].SubItems.Add(PdfFileName);
                                WordFileListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

                            }
                            this.BeginInvoke(new Action(() =>
                            {
                                this.SaveProgressBar.Value = 0;
                                this.StatusText.Text = "处理完毕";

                                DialogResult MessageBoxResult = MessageBox.Show("处理完毕，是否需要打开PDF目录？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (MessageBoxResult == DialogResult.Yes)
                                {
                                    Process.Start(SelectSavePathstring);
                                }
                            }));


                            //转换完毕以后要做的事情

                            if (this.OpenPdfOptions.Checked)
                            {
                                Task<List<string>> PdfFileList = UI.GetPdfFileNames();

                                foreach (string PdfFile in PdfFileList.Result)
                                {
                                    Process.Start(PdfFile);
                                }
                            }

                            if (this.RemoveTempDocx.Checked)
                            {
                                Directory.Delete(TempSaveDocxPathString, true);
                            }
                        }
                    }
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
                    if (this.PdfFileListView.Items.Count > 0)
                    {
                        IEnumerable<string> ISelectPathString = Util.ShwoSelectDialog(false, true, "", "");
                        string SelectPathString = ISelectPathString.FirstOrDefault();
                        if (SelectPathString != default)
                        {
                            for (int Index = 0; Index < this.PdfFileListView.Items.Count; Index++)
                            {
                                string TempFileName = this.PdfFileListView.Items[Index].Text;

                                this.PdfStatusText.Text = $"正在处理第{Index + 1}个文档...";
                                Util.ConvertPdf2Word(TempFileName, SelectPathString);

                                //添加转后的docx文件路径
                                string PdfFileNameWithNotExt = Path.GetFileNameWithoutExtension(TempFileName);
                                string SavedDocxFileName = Path.Combine(SelectPathString, PdfFileNameWithNotExt + ".docx");
                                PdfFileListView.Items[Index].SubItems.Add(SavedDocxFileName);
                                PdfFileListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                            }

                            this.PdfStatusText.Text = $"处理完毕";

                            this.BeginInvoke(new Action(() =>
                            {
                                DialogResult MessageBoxResult = MessageBox.Show("处理完毕，是否需要打开WORD目录？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (MessageBoxResult == DialogResult.Yes)
                                {
                                    Process.Start(SelectPathString);
                                }
                            }));
                        }
                    }
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
                }
            }
        }

        private void ConvertExcel2PdfButton_Click(object sender, EventArgs e)
        {

            Task.Run(() =>
            {
                try
                {
                    if (this.ExcelFileListView.Items.Count > 0)
                    {
                        IEnumerable<string> ISelectPathString = Util.ShwoSelectDialog(false, true, "", "");
                        string SelectPathString = ISelectPathString.FirstOrDefault();
                        if (SelectPathString != default)
                        {
                            for (int Index = 0; Index < this.ExcelFileListView.Items.Count; Index++)
                            {
                                string TempFileName = this.ExcelFileListView.Items[Index].Text;

                                Util.ConvertExcel2Pdf(TempFileName, SelectPathString);

                                //添加转后的pdf文件路径
                                string PdfFileNameWithNotExt = Path.GetFileNameWithoutExtension(TempFileName);
                                string SavedPdfFileName = Path.Combine(SelectPathString, PdfFileNameWithNotExt + ".pdf");
                                ExcelFileListView.Items[Index].SubItems.Add(SavedPdfFileName);
                                ExcelFileListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                            }


                            this.BeginInvoke(new Action(() =>
                            {
                                DialogResult MessageBoxResult = MessageBox.Show("处理完毕，是否需要打开PDF目录？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (MessageBoxResult == DialogResult.Yes)
                                {
                                    Process.Start(SelectPathString);
                                }
                            }));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            });
        }
    }
}
