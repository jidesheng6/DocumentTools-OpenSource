using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DocumentTools
{
    internal class Util
    {
        /// <summary>
        /// 显示选择文件框，获取选中的文件名称列表
        /// </summary>
        /// <param name="MulitSelect">是否可以多选</param>
        /// <param name="isPickFolder">是否选择目录</param>
        /// <param name="FilterDisplayName">过滤显示的名称</param>
        /// <param name="FilterExtensionsName">实际过滤的文件名称列表</param>
        /// <returns></returns>
        public static IEnumerable<string> ShwoSelectDialog(bool MulitSelect, bool isPickFolder, string FilterDisplayName, string FilterExtensionsName)
        {
            IEnumerable<string> ReturnFileNameString = new List<string>();

            CommonOpenFileDialog FileSelectDialog = new CommonOpenFileDialog();

            FileSelectDialog.Multiselect = MulitSelect;
            FileSelectDialog.IsFolderPicker = isPickFolder;

            if (!isPickFolder)
            {
                CommonFileDialogFilter FileFilterItems = new CommonFileDialogFilter(FilterDisplayName, FilterExtensionsName);
                FileSelectDialog.Filters.Add(FileFilterItems);
            }

            CommonFileDialogResult FileSelectResult = FileSelectDialog.ShowDialog();

            if (FileSelectResult == CommonFileDialogResult.Ok)
            {
                ReturnFileNameString = FileSelectDialog.FileNames;
            }

            return ReturnFileNameString;
        }

        /// <summary>
        /// 显示保存文件对话框，用于保存单个文件
        /// </summary>
        /// <param name="FileFilterString">过滤保存文件的类型</param>
        /// <param name="DisplayTitleString">设置对话框的标题提示名称</param>
        /// <returns></returns>
        public static string ShowSaveFileDialog(string FileFilterString, string DisplayTitleString = "保存文件")
        {
            string SaveFileName = string.Empty;
            BodyForm.MainForm.SaveFileDialog.CheckPathExists = true;
            BodyForm.MainForm.SaveFileDialog.AddExtension = true;
            BodyForm.MainForm.SaveFileDialog.Title = DisplayTitleString;
            BodyForm.MainForm.SaveFileDialog.Filter = FileFilterString;
            DialogResult SaveFileDialogResult = BodyForm.MainForm.SaveFileDialog.ShowDialog();
            if (SaveFileDialogResult == DialogResult.OK)
            {
                SaveFileName = BodyForm.MainForm.SaveFileDialog.FileName;
            }
            return SaveFileName;
        }


        /// <summary>
        /// 获取当前时间，简单格式化
        /// </summary>
        /// <returns></returns>
        public static string GetNowDateTime()
        {
            DateTime NowDateTime = DateTime.Now;

            return NowDateTime.ToString("yyyy年/MM月/dd日 HH:mm:ss");
        }

        /// <summary>
        /// 将word文档转换为pdf文件
        /// </summary>
        /// <param name="documentFileName">doc/docx文档路径</param>
        /// <param name="savePdfTargetPath">导出pdf的路径</param>
        /// <param name="tempSaveDocxPath">临时存放转换的docx目录</param>
        public static void ConvertWord2Pdf(string documentFileName, string SavePdfName, string tempSaveDocxPath)
        {
            Aspose.Hook.Manager.StartHook();
            string DocumentName, SaveDocxName;

            //设置加载word文档的时候参数
            Aspose.Words.Loading.LoadOptions TempDocuemntLoadOption = new Aspose.Words.Loading.LoadOptions()
            {
                ConvertMetafilesToPng = true,
                MswVersion = Aspose.Words.Settings.MsWordVersion.Word2010,
            };

            //设置PDF保存参数
            Aspose.Words.Saving.PdfSaveOptions TempPdfaveOption = new Aspose.Words.Saving.PdfSaveOptions()
            {
                FontEmbeddingMode = Aspose.Words.Saving.PdfFontEmbeddingMode.EmbedAll,
                ImageColorSpaceExportMode = Aspose.Words.Saving.PdfImageColorSpaceExportMode.Auto,
                ImageCompression = Aspose.Words.Saving.PdfImageCompression.Auto,
                PageMode = Aspose.Words.Saving.PdfPageMode.UseOutlines,
                ZoomBehavior = Aspose.Words.Saving.PdfZoomBehavior.None,
                SaveFormat = Aspose.Words.SaveFormat.Pdf,
                UseHighQualityRendering = true,
            };

            //设置PDF保存带word中的目录
            TempPdfaveOption.OutlineOptions.DefaultBookmarksOutlineLevel = 0;
            TempPdfaveOption.OutlineOptions.CreateMissingOutlineLevels = false;
            TempPdfaveOption.OutlineOptions.ExpandedOutlineLevels = 3;
            TempPdfaveOption.OutlineOptions.HeadingsOutlineLevels = 9;
            TempPdfaveOption.HeaderFooterBookmarksExportMode = Aspose.Words.Saving.HeaderFooterBookmarksExportMode.All;


            //设置Docx保存参数
            Aspose.Words.Saving.OoxmlSaveOptions TempDocxSaveOption = new Aspose.Words.Saving.OoxmlSaveOptions()
            {
                SaveFormat = Aspose.Words.SaveFormat.Docx,

            };



            Aspose.Words.Document TempDocument = new Aspose.Words.Document(documentFileName, TempDocuemntLoadOption);

            DocumentName = System.IO.Path.GetFileNameWithoutExtension(documentFileName);

            SaveDocxName = System.IO.Path.Combine(tempSaveDocxPath, DocumentName + ".docx");


            //TempDocument.CompatibilityOptions.AutoSpaceLikeWord95 = true;
            //TempDocument.CompatibilityOptions.WrapTrailSpaces = true;
            //TempDocument.CompatibilityOptions.NoSpaceRaiseLower = true;
            //TempDocument.CompatibilityOptions.SuppressSpBfAfterPgBrk = true;
            //TempDocument.CompatibilityOptions.NoLeading = true;
            //TempDocument.CompatibilityOptions.NoExtraLineSpacing = true;
            //TempDocument.CompatibilityOptions.DoNotUseEastAsianBreakRules = true;
            //TempDocument.CompatibilityOptions.BalanceSingleByteDoubleByteWidth = true;


            TempDocument.UpdateFields();

            TempDocument.Save(SaveDocxName, TempDocxSaveOption);

            Aspose.Words.Document TempDocxDocument = new Aspose.Words.Document(SaveDocxName, TempDocuemntLoadOption);

            TempDocxDocument.UpdateFields();


            TempDocxDocument.Save(SavePdfName, TempPdfaveOption);
        }

        /// <summary>
        /// 将PDF文档转为DOCX文件
        /// </summary>
        /// <param name="pdfFileName">pdf文件名</param>
        /// <param name="saveDocumentTargetPath">导出docx的路径</param>
        public static void ConvertPdf2Word(string pdfFileName, string SavePdfName)
        {
            Aspose.Hook.Manager.StartHook();

            Aspose.Pdf.DocSaveOptions TempDocxSaveOption = new Aspose.Pdf.DocSaveOptions()
            {
                ExtractOcrSublayerOnly = true,
                Format = Aspose.Pdf.DocSaveOptions.DocFormat.DocX,
                Mode = Aspose.Pdf.DocSaveOptions.RecognitionMode.Textbox,
                RecognizeBullets = true,
            };

            Aspose.Pdf.Document TempPdfFileDocument = new Aspose.Pdf.Document(pdfFileName);

            TempPdfFileDocument.Save(SavePdfName, TempDocxSaveOption);

        }

        /// <summary>
        /// 将多个PDF文件合并为一个PDF文件
        /// </summary>
        /// <param name="pdfFileNames">要合并的PDF文档列表</param>
        /// <param name="mergrePdfFileName">合并后保存的PDF文件名称</param>
        public static void MergrePdfFIle(List<string> pdfFileNames, string mergrePdfFileName)
        {
            Aspose.Hook.Manager.StartHook();
            Aspose.Pdf.Facades.PdfFileEditor TempPdfEditor = new Aspose.Pdf.Facades.PdfFileEditor();
            TempPdfEditor.Concatenate(pdfFileNames.ToArray(), mergrePdfFileName);

        }

        /// <summary>
        /// 将Excel转为PDF文件
        /// </summary>
        /// <param name="ExcelFileName">Excel文件名称</param>
        /// <param name="SavePdfTargetPath">导出pdf的路径</param>
        public static void ConvertExcel2Pdf(string ExcelFileName, string SavePdfFileName)
        {
            Aspose.Hook.Manager.StartHook();


            Aspose.Cells.Workbook TempExcelDocument = new Aspose.Cells.Workbook(ExcelFileName);

            TempExcelDocument.Save(SavePdfFileName, Aspose.Cells.SaveFormat.Pdf);

        }

    }

}
