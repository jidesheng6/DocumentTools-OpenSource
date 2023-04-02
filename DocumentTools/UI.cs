using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
//using System.Windows.Controls;
using System.Windows.Forms;

namespace DocumentTools
{
    internal class UI
    {
        /// <summary>
        /// 添加文件列表到Listview中，并返回项目数量
        /// </summary>
        /// <param name="DisplayFilterString"></param>
        /// <param name="FilterArgs"></param>
        /// <param name="ListViewControl"></param>
        /// <returns>文件数量</returns>
        public static Task<int> AddFilesToListView(string DisplayFilterString, string FilterArgs, ListView ListViewControl)
        {
            return Task.Run(() =>
            {
                IEnumerable<string> TempDocuemntFileNames = Util.ShwoSelectDialog(true, false, DisplayFilterString, FilterArgs);
                ListViewControl.BeginUpdate();
                foreach (string TempDocumentFileName in TempDocuemntFileNames)
                {
                    ListViewItem TempDocuemntFileNamesListView = new ListViewItem();
                    TempDocuemntFileNamesListView.Text = TempDocumentFileName;
                    TempDocuemntFileNamesListView.SubItems.Add(Util.GetNowDateTime());
                    ListViewControl.Items.Add(TempDocuemntFileNamesListView);
                    ListViewControl.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
                ListViewControl.EndUpdate();
                return ListViewControl.Items.Count;
            });

        }

        /// <summary>
        /// 获取Listview控件中最后一列的文本项目内容
        /// </summary>
        /// <param name="ListViewControl"></param>
        /// <returns></returns>
        public static Task<List<string>> GetListViewLastItemContent(ListView ListViewControl)
        {
            return Task.Run(() =>
            {
                List<string> FileNames = new List<string>();
                if (ListViewControl.Items.Count > 0)
                {
                    for (int Index = 0; Index < ListViewControl.Items.Count; Index++)
                    {
                        FileNames.Add(ListViewControl.Items[Index].SubItems[2].Text);
                    }
                }
                return FileNames;
            });
        }

        public static Task<int> AddWordFiles()
        {
            return AddFilesToListView("WORD文档", "*.doc;*.docx", BodyForm.MainForm.WordFileListView);
        }

        public static void AddPdfFiles()
        {
            AddFilesToListView("PDF文档", "*.pdf", BodyForm.MainForm.PdfFileListView);
        }

        public static void AddExcelFiles()
        {
            AddFilesToListView("EXCEL文档", "*.xls;*.xlsx", BodyForm.MainForm.ExcelFileListView);
        }

        //public static void ConvertStart(ListView ListViewControl, Label StatusLabelControl, CheckBox StatusCheckBox, ProgressBar ProgeressBarControl, string ConvertType, string ExtensionString)
        //{
        //    if (ListViewControl.Items.Count > 0)
        //    {
        //        IEnumerable<string> ISelectSavePathstring = Util.ShwoSelectDialog(false, true, "", "");
        //        string SelectSavePathstring = ISelectSavePathstring.FirstOrDefault();
        //        if (SelectSavePathstring != default)
        //        {
        //            for (int TempIndex = 0; TempIndex < ListViewControl.Items.Count; TempIndex++)
        //            {
        //                string ListViewFirstColumnText = ListViewControl.Items[TempIndex].Text;
        //                string FileNameWithOutExtension = Path.GetFileNameWithoutExtension(ListViewFirstColumnText);
        //                string ConvertedFileName = Path.Combine(SelectSavePathstring, FileNameWithOutExtension + ExtensionString);
        //                ListViewControl.Items[TempIndex].SubItems.Add(ConvertedFileName);
        //                ListViewControl.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        //                StatusLabelControl.Text = $"正在处理{TempIndex + 1}个文件...";
        //            }
        //            StatusLabelControl.Text = "处理完毕";
        //        }
        //    }
        //}


        public static Task<List<string>> GetPdfFileNames()
        {
            return GetListViewLastItemContent(BodyForm.MainForm.PdfFileListView);
        }


    }
}
