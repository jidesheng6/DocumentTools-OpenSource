using Aspose.Cells;
using Aspose.Cells.Rendering;
using Microsoft.WindowsAPICodePack.Dialogs;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text.RegularExpressions;
using System.Threading;
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
        /// 获取内嵌的资源对象
        /// </summary>
        /// <param name="ResourceName">资源名称，不需要带后缀</param>
        /// <returns></returns>
        private static object GetEmbedResourceObj(string ResourceName)
        {
            Assembly SelfAssmbly = Assembly.GetExecutingAssembly();
            ResourceManager TempManager = new ResourceManager("DocumentTools.Properties.Resources", SelfAssmbly);
            return TempManager.GetObject(ResourceName);
        }

        /// <summary>
        /// 播放MP3流
        /// </summary>
        public static void PlayMp3WithStream()
        {
            //这里必须这样写，不要用using语句来自动执行dispose，否则声音还没播放的时候就已经被dispose了
            MemoryStream EmbedResouceObj = new MemoryStream((byte[])GetEmbedResourceObj("zdsny"));
            StreamMediaFoundationReader TempStream = new StreamMediaFoundationReader(EmbedResouceObj);
            IWavePlayer Player = new WaveOut();
            Player.Init(TempStream);
            Player.Play();

        }

        /// <summary>
        /// 将word文档转换为pdf文件
        /// </summary>
        /// <param name="documentFileName">doc/docx文档路径</param>
        /// <param name="SavePdfName">导出pdf的路径</param>
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
                //Compliance = Aspose.Words.Saving.OoxmlCompliance.Iso29500_2008_Strict,
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
        /// <param name="SavePdfName">导出docx</param>
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
        /// <param name="SavePdfFileName">导出pdf的路径</param>
        public static void ConvertExcel2Pdf(string ExcelFileName, string SavePdfFileName, bool ExportEachSheet)
        {
            Aspose.Hook.Manager.StartHook();


            Aspose.Cells.Workbook TempExcelDocument = new Aspose.Cells.Workbook(ExcelFileName);

            if (ExportEachSheet)
            {
                PdfSaveOptions SavePdfOptions = new PdfSaveOptions()
                {
                    OnePagePerSheet = true,
                    CalculateFormula = true,
                };

                //将Excel中的每一个Sheet保存为单个PDF文件
                for (int i = 0; i < TempExcelDocument.Worksheets.Count; i++)
                {
                    TempExcelDocument.Worksheets[i].IsVisible = true;
                    for (int j = 0; j < TempExcelDocument.Worksheets.Count; j++)
                    {
                        if (j != i)
                        {
                            TempExcelDocument.Worksheets[j].IsVisible = false;
                        }
                    }
                    string TempSavedPdfileWithSheetName = SavePdfFileName.Replace(".pdf", $"_{TempExcelDocument.Worksheets[i].Name}.pdf");
                    TempExcelDocument.Save(TempSavedPdfileWithSheetName, SavePdfOptions);
                }
            }
            else
            {
                TempExcelDocument.Save(SavePdfFileName, Aspose.Cells.SaveFormat.Pdf);
            }
        }

        /// <summary>
        /// 将PDF转为Excel文件
        /// </summary>
        /// <param name="PdfFileName">PDF文件名称</param>
        /// <param name="SaveExcelFileName">导出excel的路径</param>
        public static void ConvertPdf2Excel(string PdfFileName, string SaveExcelFileName, bool MergeAllPages)
        {
            Aspose.Hook.Manager.StartHook();

            Aspose.Pdf.Document TempPdfDocuemnt = new Aspose.Pdf.Document(PdfFileName);
            Aspose.Pdf.ExcelSaveOptions TempExcelSaveOption = new Aspose.Pdf.ExcelSaveOptions()
            {
                Format = Aspose.Pdf.ExcelSaveOptions.ExcelFormat.XLSX,
                ExtractOcrSublayerOnly = true,
            };
            if (MergeAllPages)
            {
                TempExcelSaveOption.MinimizeTheNumberOfWorksheets = true;
            }
            else
            {
                TempExcelSaveOption.MinimizeTheNumberOfWorksheets = false;
            }

            TempPdfDocuemnt.Save(SaveExcelFileName, TempExcelSaveOption);
        }


        /// <summary>
        /// 将word文档转换为图片文件
        /// </summary>
        /// <param name="DocumentsFileName">文档名称</param>
        /// <param name="SavedImageFileName">保存后图片的名称</param>
        /// <param name="ConvertImageType">转换的目标图片类型</param>
        /// <param name="SetGrayMode">是否需要进行灰度处理</param>
        /// <param name="PageExport">是否需要逐页导出</param>
        /// <param name="DpiValue">导出的图像DPI分辨率</param>
        public static void ConvertWord2Image(string DocumentsFileName, string SavedImageFileName, string ConvertImageType, bool SetGrayMode, bool PageExport, int DpiValue = 150)
        {
            Aspose.Hook.Manager.StartHook();

            string FileType = Path.GetExtension(DocumentsFileName);

            //初始化一个临时参数，到时候重新初始化
            Aspose.Words.Saving.ImageSaveOptions TempWordImageSaveOption = new Aspose.Words.Saving.ImageSaveOptions(Aspose.Words.SaveFormat.Jpeg);

            Aspose.Words.Document TempWordDocument = null;
            Aspose.Cells.Workbook TempExcelDocument = null;
            Aspose.Cells.Rendering.ImageOrPrintOptions TempExcelImageOPtion = new Aspose.Cells.Rendering.ImageOrPrintOptions();
            Aspose.Pdf.Document TempPdfDocument = null;
            Aspose.Pdf.Devices.ImageDevice TempPdfImageDevice = null;
            Aspose.Pdf.Devices.TiffDevice TempPdfTifDevice = null;
            Aspose.Pdf.Devices.Resolution TempPdfImageResolution = new Aspose.Pdf.Devices.Resolution(DpiValue);

            switch (FileType)
            {
                case ".doc":
                    TempWordDocument = new Aspose.Words.Document(DocumentsFileName);
                    break;
                case ".docx":
                    TempWordDocument = new Aspose.Words.Document(DocumentsFileName);
                    break;
                case ".pdf":
                    TempPdfDocument = new Aspose.Pdf.Document(DocumentsFileName);
                    break;
                case ".xls":
                    TempExcelDocument = new Aspose.Cells.Workbook(DocumentsFileName);
                    break;
                case ".xlsx":
                    TempExcelDocument = new Aspose.Cells.Workbook(DocumentsFileName);
                    break;
                default: break;
            }

            //根据不同导出类型进行预初始化处理
            switch (ConvertImageType)
            {
                case ".jpg":
                    TempWordImageSaveOption = new Aspose.Words.Saving.ImageSaveOptions(Aspose.Words.SaveFormat.Jpeg);
                    TempWordImageSaveOption.JpegQuality = 100;
                    TempPdfImageDevice = new Aspose.Pdf.Devices.JpegDevice(TempPdfImageResolution, 100);
                    TempExcelImageOPtion.ImageType = Aspose.Cells.Drawing.ImageType.Jpeg;
                    TempExcelImageOPtion.Quality = 100;
                    break;
                case ".png":
                    TempWordImageSaveOption = new Aspose.Words.Saving.ImageSaveOptions(Aspose.Words.SaveFormat.Png);
                    TempPdfImageDevice = new Aspose.Pdf.Devices.PngDevice(TempPdfImageResolution);
                    TempExcelImageOPtion.ImageType = Aspose.Cells.Drawing.ImageType.Png;
                    break;
                case ".bmp":
                    TempWordImageSaveOption = new Aspose.Words.Saving.ImageSaveOptions(Aspose.Words.SaveFormat.Bmp);
                    TempPdfImageDevice = new Aspose.Pdf.Devices.BmpDevice(TempPdfImageResolution);
                    TempExcelImageOPtion.ImageType = Aspose.Cells.Drawing.ImageType.Bmp;
                    break;
                case ".tif":
                    TempWordImageSaveOption = new Aspose.Words.Saving.ImageSaveOptions(Aspose.Words.SaveFormat.Tiff);
                    //单独处理tif的转换
                    TempPdfTifDevice = new Aspose.Pdf.Devices.TiffDevice(TempPdfImageResolution);
                    TempExcelImageOPtion.ImageType = Aspose.Cells.Drawing.ImageType.Tiff;
                    break;
                default: break;
            }

            //word转图片的设置
            TempWordImageSaveOption.UseHighQualityRendering = true;
            TempWordImageSaveOption.Resolution = DpiValue;
            TempWordImageSaveOption.ColorMode = Aspose.Words.Saving.ColorMode.Normal;
            TempWordImageSaveOption.PixelFormat = Aspose.Words.Saving.ImagePixelFormat.Format24BppRgb;
            TempWordImageSaveOption.UseAntiAliasing = true;

            //excel转图片的设置
            TempExcelImageOPtion.CheckWorkbookDefaultFont = true;
            TempExcelImageOPtion.HorizontalResolution = DpiValue;
            TempExcelImageOPtion.VerticalResolution = DpiValue;
            TempExcelImageOPtion.PixelFormat = System.Drawing.Imaging.PixelFormat.Format24bppRgb;
            TempWordImageSaveOption.UseAntiAliasing = true;



            if (SetGrayMode)
            {
                //对图像进行灰度处理（只有word转图片才可以设置）
                TempWordImageSaveOption.ImageColorMode = Aspose.Words.Saving.ImageColorMode.Grayscale;
                TempWordImageSaveOption.ColorMode = Aspose.Words.Saving.ColorMode.Grayscale;
            }

            if (PageExport)
            {
                if (FileType == ".doc" || FileType == ".docx")
                {
                    //逐页导出WORD图片
                    for (int pageIndex = 0; pageIndex < TempWordDocument.PageCount; pageIndex++)
                    {
                        string MutilPageFileName = SavedImageFileName.Replace(ConvertImageType, $"_第{pageIndex + 1}页{ConvertImageType}");
                        TempWordImageSaveOption.PageSet = new Aspose.Words.Saving.PageSet(pageIndex);
                        TempWordDocument.Save(MutilPageFileName, TempWordImageSaveOption);
                    }
                }
                else if (FileType == ".pdf")
                {
                    //逐页导出PDF的图片，tif图片需要单独处理，他不是imagedeivice类型
                    for (int PdfPageIndex = 0; PdfPageIndex < TempPdfDocument.Pages.Count; PdfPageIndex++)
                    {
                        string MutilPageFileName = SavedImageFileName.Replace(ConvertImageType, $"_第{PdfPageIndex + 1}页{ConvertImageType}");
                        if (ConvertImageType != ".tif")
                        {
                            TempPdfImageDevice.Process(TempPdfDocument.Pages[PdfPageIndex + 1], MutilPageFileName);
                        }
                        else
                        {
                            TempPdfTifDevice.Process(TempPdfDocument, PdfPageIndex + 1, PdfPageIndex + 1, MutilPageFileName);
                        }
                    }
                }
                else
                {
                    //对excel文件进行sheet表逐个导出
                    for (int ExcelSheetIndex = 0; ExcelSheetIndex < TempExcelDocument.Worksheets.Count; ExcelSheetIndex++)
                    {
                        Worksheet TempWorkSheet = TempExcelDocument.Worksheets[ExcelSheetIndex];
                        string TempSavedImageileWithSheetName = SavedImageFileName.Replace(ConvertImageType, $"_{TempWorkSheet.Name}{ConvertImageType}");
                        Debug.WriteLine(TempSavedImageileWithSheetName);
                        SheetRender TempSheetRender = new SheetRender(TempWorkSheet, TempExcelImageOPtion);
                        TempSheetRender.ToImage(0, TempSavedImageileWithSheetName);
                    }
                }
            }
            else//合并一页导出，暂时不做
            {
                TempWordDocument.Save(SavedImageFileName, TempWordImageSaveOption);
            }



        }

        /// <summary>
        /// 通过正则表达式移除指定的字符
        /// </summary>
        /// <param name="SpecialCharacters"></param>
        /// <param name="InputText"></param>
        /// <returns></returns>
        private static string RemoveSpeciCharacter(string[] SpecialCharacters, string InputText)
        {
            foreach (string SpecialCharacter in SpecialCharacters)
            {
                bool MatchStatus = Regex.Match(InputText, SpecialCharacter, RegexOptions.Multiline).Success;
                if (MatchStatus)
                {
                    InputText = Regex.Replace(InputText, SpecialCharacter, "", RegexOptions.Multiline);
                }
            }
            return InputText;
        }

        /// <summary>
        /// 双字对齐，文本为2个字的文本则自动在中间插入空格
        /// </summary>
        /// <param name="InputText">待处理文本</param>
        /// <returns></returns>
        private static string DoubleTextAlign(string InputText)
        {
            if (InputText.Length == 2 && InputText != string.Empty)
            {
                InputText = InputText.Insert(1, "  ");
            }
            return InputText;
        }
        /// <summary>
        /// 正则匹配结果，如果匹配到了就返回true
        /// </summary>
        /// <param name="MachMode">表达式</param>
        /// <param name="InputText">输入的文本</param>
        /// <returns></returns>
        private static bool MatchRegexStatus(string MachMode, string InputText)
        {
            return Regex.Match(InputText, MachMode).Success;
        }

        /// <summary>
        /// 添加处理后的姓名到列表中
        /// </summary>
        /// <param name="InputText">源文本</param>
        /// <param name="DoubleTextAligin">是否双字对齐</param>
        /// <param name="RemoveNumber">是否移除数字</param>
        /// <param name="RemoveSquare">是否移除括号</param>
        /// <returns></returns>
        public static string[] AddText2List(string InputText, bool DoubleTextAligin, bool RemoveNumber, bool RemoveSquare, bool NameStorke)
        {
            List<string> TextList = new List<string>();

            string[] ReturnTextList;

            if (MatchRegexStatus("\\t", InputText))//表示匹配到的是传统word表格中直接复制的内容
            {
                InputText = Regex.Replace(InputText, "\t", "\n", RegexOptions.Multiline);//将\t全部换成\n换行符

                string[] TempInputTextByTap = InputText.Split(new char[] { '\n' });//使用\n来分割数组，确保每个文字都独立存储

                string[] AllSpaceChar = new string[] { "\\s", "○", "□", "£" };//设置基础特殊字符列表

                foreach (string TempText in TempInputTextByTap)//遍历分割数组，得到每个文字
                {
                    string TempInputTextNoSpace = RemoveSpeciCharacter(AllSpaceChar, TempText);//对每个文字进行删除特殊字符处理

                    if (RemoveNumber)
                    {
                        TempInputTextNoSpace = RemoveSpeciCharacter(new string[] { "[0-9]" }, TempInputTextNoSpace);//移除数字
                    }

                    if (DoubleTextAligin)
                    {
                        TempInputTextNoSpace = DoubleTextAlign(TempInputTextNoSpace);//双字对齐
                    }

                    if (RemoveSquare)
                    {
                        //删除括号
                        TempInputTextNoSpace = RemoveSpeciCharacter(new string[] { "\\(.+?\\)|\\（.+?\\）|\\(\\)|\\（\\）" }, TempInputTextNoSpace);
                    }

                    if (TempInputTextNoSpace != string.Empty)
                    {
                        //只有非空白文本才添加到数组中
                        TextList.Add(TempInputTextNoSpace);
                    }
                }
            }
            else
            {
                //以下是对常规列文本进行普通处理
                string[] TempNewLineText = InputText.Split(new char[] { '\n' });
                foreach (string TempText in TempNewLineText)
                {

                    if (TempText != string.Empty)
                    {
                        string AddListText = TempText;
                        if (RemoveNumber)
                        {
                            AddListText = RemoveSpeciCharacter(new string[] { "[0-9]" }, AddListText);//移除数字
                        }

                        if (DoubleTextAligin)
                        {
                            AddListText = DoubleTextAlign(AddListText);//双字对齐
                        }

                        if (RemoveSquare)
                        {
                            //删除括号
                            AddListText = RemoveSpeciCharacter(new string[] { "\\(.+?\\)|\\（.+?\\）|\\(\\)|\\（\\）" }, AddListText);
                        }

                        if (AddListText != string.Empty)
                        {
                            //只有非空白文本才添加到数组中
                            TextList.Add(AddListText);
                        }
                    }
                }
            }

            ReturnTextList = TextList.ToArray();

            if (NameStorke)
            {
                //按照姓氏笔画排序
                CultureInfo cultureInfo = new CultureInfo(133124);
                Thread.CurrentThread.CurrentCulture = cultureInfo;
                Array.Sort(ReturnTextList);
            }


            return ReturnTextList;

        }



    }

}
