using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DocumentTools
{

    public partial class BodyForm : Form
    {
        public static BodyForm MainForm;
        private ListView TempListview;

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
            this.AllowDrop = true;
            this.PageExportCheck.Checked = true;
            this.PageExportCheck.Enabled = false;

            this.MergePdfButton.Enabled = false;
            this.TabPage_08.Parent = null;
            //Util.PlayMp3WithStream();

        }

        private void InitListView()
        {
            // WordFileListView
            this.WordFileListView.View = View.Details;
            this.WordFileListView.FullRowSelect = true;
            this.WordFileListView.AllowDrop = true;
            this.WordFileListView.Columns.Add("文件名称", 300);
            this.WordFileListView.Columns.Add("添加时间", 300);
            this.WordFileListView.Columns.Add("转换后文件名称", 300);
            this.WordFileListView.Name = "WordFileListView";

            this.WordFileListView.DragEnter += ListViewDragEnter;
            this.WordFileListView.DragDrop += ListviewDragDrop;

            //PdfFileListView
            this.PdfFileListView.View = View.Details;
            this.PdfFileListView.FullRowSelect = true;
            this.PdfFileListView.AllowDrop = true;
            this.PdfFileListView.Columns.Add("文件名称", 300);
            this.PdfFileListView.Columns.Add("添加时间", 300);
            this.PdfFileListView.Columns.Add("转换后文件名称", 300);
            this.PdfFileListView.Name = "PdfFileListView";

            this.PdfFileListView.DragEnter += ListViewDragEnter;
            this.PdfFileListView.DragDrop += ListviewDragDrop;

            //ExcelFileListView
            this.ExcelFileListView.View = View.Details;
            this.ExcelFileListView.FullRowSelect = true;
            this.ExcelFileListView.AllowDrop = true;
            this.ExcelFileListView.Columns.Add("文件名称", 300);
            this.ExcelFileListView.Columns.Add("添加时间", 300);
            this.ExcelFileListView.Columns.Add("转换后文件名称", 300);
            this.ExcelFileListView.Name = "ExcelFileListView";

            this.ExcelFileListView.DragEnter += ListViewDragEnter;
            this.ExcelFileListView.DragDrop += ListviewDragDrop;

            //DocumentsListView
            this.DocumentsListView.View = View.Details;
            this.DocumentsListView.FullRowSelect = true;
            this.DocumentsListView.AllowDrop = true;
            this.DocumentsListView.Columns.Add("文件名称", 300);
            this.DocumentsListView.Columns.Add("添加时间", 300);
            this.DocumentsListView.Columns.Add("转换后文件名称", 300);
            this.DocumentsListView.Name = "DocumentsListView";

            this.DocumentsListView.DragEnter += ListViewDragEnter;
            this.DocumentsListView.DragDrop += ListviewDragDrop;

            //PDF2ExcelFileView
            this.PDF2ExcelFileView.View = View.Details;
            this.PDF2ExcelFileView.FullRowSelect = true;
            this.PDF2ExcelFileView.AllowDrop = true;
            this.PDF2ExcelFileView.Columns.Add("文件名称", 300);
            this.PDF2ExcelFileView.Columns.Add("添加时间", 300);
            this.PDF2ExcelFileView.Columns.Add("转换后文件名称", 300);
            this.PDF2ExcelFileView.Name = "PDF2ExcelFileView";

            this.PDF2ExcelFileView.DragEnter += ListViewDragEnter;
            this.PDF2ExcelFileView.DragDrop += ListviewDragDrop;

            //MergePdfFileView
            this.MergePdfFileView.View = View.Details;
            this.MergePdfFileView.FullRowSelect = true;
            this.MergePdfFileView.AllowDrop = true;
            this.MergePdfFileView.Columns.Add("文件名称", 300);
            this.MergePdfFileView.Columns.Add("添加时间", 300);
            this.MergePdfFileView.Columns.Add("转换后文件名称", 300);
            this.MergePdfFileView.Name = "MergePdfFileView";

            this.MergePdfFileView.DragEnter += ListViewDragEnter;
            this.MergePdfFileView.DragDrop += ListviewDragDrop;

        }

        private void InitComboxValue()
        {
            DataTable ImageConverTypeData = new DataTable();
            ImageConverTypeData.Columns.Add("ImageTypeDisplayName");
            ImageConverTypeData.Columns.Add("ImageTypeValueName");

            ImageConverTypeData.Rows.Add("JPG", ".jpg");
            ImageConverTypeData.Rows.Add("PNG", ".png");
            ImageConverTypeData.Rows.Add("BMP", ".bmp");
            ImageConverTypeData.Rows.Add("TIFF", ".tif");

            this.ConvertImageList.DataSource = ImageConverTypeData;
            this.ConvertImageList.DisplayMember = "ImageTypeDisplayName";
            this.ConvertImageList.ValueMember = "ImageTypeValueName";

            this.ConvertImageList.DropDownStyle = ComboBoxStyle.DropDownList;


            DataTable DpiStorgeTable = new DataTable();
            DpiStorgeTable.Columns.Add("DpiDisplayName");
            DpiStorgeTable.Columns.Add("DpiValue");

            DpiStorgeTable.Rows.Add("150DPI", 150);
            DpiStorgeTable.Rows.Add("200DPI", 200);
            DpiStorgeTable.Rows.Add("250DPI", 250);
            DpiStorgeTable.Rows.Add("300DPI", 300);
            DpiStorgeTable.Rows.Add("350DPI", 350);
            DpiStorgeTable.Rows.Add("400DPI", 400);
            DpiStorgeTable.Rows.Add("450DPI", 450);
            DpiStorgeTable.Rows.Add("500DPI", 500);
            DpiStorgeTable.Rows.Add("550DPI", 550);
            DpiStorgeTable.Rows.Add("600DPI", 600);

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
                    MessageBox.Show("合并完毕", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
            TargetTextBox.Lines = Util.AddText2List(SourceTextBox.Text, DoubleTextAlignCheck.Checked, RemoveNumberCheck.Checked, RemoveSquareCheck.Checked, NameStorkeChcek.Checked);


        }

        private void SourceTextBox_TextChanged(object sender, EventArgs e)
        {
            //如果启用多行模式，则每次添加文本后，都在末尾添加\t控制字符
            if (MutilLineMode.Checked)
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
                    Task.Run(() =>
                    {
                        try
                        {
                            string MeregeDirectory = System.IO.Path.GetDirectoryName(MeregePdfFileName);
                            this.MeregePdfFileStatusText.Text = "正在合并中...";
                            Util.MergrePdfFIle(MeregePdfFiles.Result, MeregePdfFileName);
                            this.MeregePdfFileStatusText.Text = "合并完毕，右键名称可移除文件";
                            if (OpenMeregePdfFile.Checked)
                            {
                                Process.Start(MeregePdfFileName);
                            }
                            this.BeginInvoke(new Action(() =>
                            {
                                DialogResult OpenResult = MessageBox.Show("合并完毕，是否需要打开合并文件所在目录？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                                if (OpenResult == DialogResult.Yes)
                                {
                                    Process.Start(MeregeDirectory);
                                }
                            }));
                        }
                        catch (Exception ex)
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

        private void WordFileListView_MouseClick(object sender, MouseEventArgs e)
        {
            //右键项目才显示菜单
            if (e.Button == MouseButtons.Right)
            {
                this.ListViewRightMenu.Show(this.WordFileListView, e.Location);
            }
        }

        private void 删除本项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TempListview != null)
            {
                switch (TempListview.Name)
                {
                    case "WordFileListView":
                        UI.RemoveListViewItem(false, WordFileListView, WordFileListView.FocusedItem.Index);
                        break;
                    case "PdfFileListView":
                        UI.RemoveListViewItem(false, PdfFileListView, PdfFileListView.FocusedItem.Index);
                        break;
                    case "ExcelFileListView":
                        UI.RemoveListViewItem(false, ExcelFileListView, ExcelFileListView.FocusedItem.Index);
                        break;
                    case "DocumentsListView":
                        UI.RemoveListViewItem(false, DocumentsListView, DocumentsListView.FocusedItem.Index);
                        break;
                    case "PDF2ExcelFileView":
                        UI.RemoveListViewItem(false, PDF2ExcelFileView, PDF2ExcelFileView.FocusedItem.Index);
                        break;
                    case "MergePdfFileView":
                        UI.RemoveListViewItem(false, MergePdfFileView, MergePdfFileView.FocusedItem.Index);
                        break;
                    default: break;
                }
            }
        }

        private void ListViewRightMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //右键菜单被打开的时候，获取当前所在控件，作为listview给后续判断使用
            TempListview = ListViewRightMenu.SourceControl as ListView;
        }

        private void 清空列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TempListview != null)
            {
                switch (TempListview.Name)
                {
                    case "WordFileListView":
                        UI.RemoveListViewItem(true, WordFileListView);
                        break;
                    case "PdfFileListView":
                        UI.RemoveListViewItem(true, PdfFileListView);
                        break;
                    case "ExcelFileListView":
                        UI.RemoveListViewItem(true, ExcelFileListView);
                        break;
                    case "DocumentsListView":
                        UI.RemoveListViewItem(true, DocumentsListView);
                        break;
                    case "PDF2ExcelFileView":
                        UI.RemoveListViewItem(true, PDF2ExcelFileView);
                        break;
                    case "MergePdfFileView":
                        UI.RemoveListViewItem(true, MergePdfFileView);
                        break;
                    default: break;
                }
            }

        }

        private void PdfFileListView_MouseClick(object sender, MouseEventArgs e)
        {
            //右键项目才显示菜单
            if (e.Button == MouseButtons.Right)
            {
                this.ListViewRightMenu.Show(this.PdfFileListView, e.Location);
            }
        }

        private void ExcelFileListView_MouseClick(object sender, MouseEventArgs e)
        {
            //右键项目才显示菜单
            if (e.Button == MouseButtons.Right)
            {
                this.ListViewRightMenu.Show(this.ExcelFileListView, e.Location);
            }
        }

        private void PDF2ExcelFileView_MouseClick(object sender, MouseEventArgs e)
        {
            //右键项目才显示菜单
            if (e.Button == MouseButtons.Right)
            {
                this.ListViewRightMenu.Show(this.PDF2ExcelFileView, e.Location);
            }
        }

        private void MergePdfFileView_MouseClick(object sender, MouseEventArgs e)
        {
            //右键项目才显示菜单
            if (e.Button == MouseButtons.Right)
            {
                this.ListViewRightMenu.Show(this.MergePdfFileView, e.Location);
            }
        }

        private void DocumentsListView_MouseClick(object sender, MouseEventArgs e)
        {
            //右键项目才显示菜单
            if (e.Button == MouseButtons.Right)
            {
                this.ListViewRightMenu.Show(this.DocumentsListView, e.Location);
            }
        }

        private void SelectSourceButton_Click(object sender, EventArgs e)
        {
            
        }

        private void SetScannerSetting_Click(object sender, EventArgs e)
        {
        }

        private void BodyForm_DragEnter(object sender, DragEventArgs e)
        {
           
        }

        private void ListViewDragEnter(object sender,DragEventArgs e)
        {
            
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void ListviewDragDrop(object sender,DragEventArgs e)
        {
            ListView DragedListview = sender as ListView;
            string[] DropFiles = e.Data.GetData(DataFormats.FileDrop,false) as string[];
            switch(DragedListview.Name)
            {
                case "WordFileListView":
                    UI.AddFilesToListviewWithNotDialog(DropFiles,this.WordFileListView,new string[] { ".doc",".docx"});
                break;
                case "PdfFileListView":
                    UI.AddFilesToListviewWithNotDialog(DropFiles, this.PdfFileListView, new string[] { ".pdf" });
                    break;
                case "ExcelFileListView":
                    UI.AddFilesToListviewWithNotDialog(DropFiles, this.ExcelFileListView, new string[] { ".xls", ".xlsx" });
                    break;
                case "DocumentsListView":
                    UI.AddFilesToListviewWithNotDialog(DropFiles, this.DocumentsListView, new string[] { ".doc", ".docx",".pdf",".xls",".xlsx" });
                    break;
                case "PDF2ExcelFileView":
                    UI.AddFilesToListviewWithNotDialog(DropFiles, this.PDF2ExcelFileView, new string[] { ".pdf" });
                    break;
                case "MergePdfFileView":
                    UI.AddFilesToListviewWithNotDialog(DropFiles, this.MergePdfFileView, new string[] { ".pdf"});
                    break;
                default: break;
            }
        }
    }

}
