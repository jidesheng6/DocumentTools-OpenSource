namespace DocumentTools
{
    partial class BodyForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BodyForm));
            this.MainTabPage = new System.Windows.Forms.TabControl();
            this.TabPage_01 = new System.Windows.Forms.TabPage();
            this.MergePdfButton = new System.Windows.Forms.Button();
            this.RemoveTempDocx = new System.Windows.Forms.CheckBox();
            this.OpenPdfOptions = new System.Windows.Forms.CheckBox();
            this.StatusText = new System.Windows.Forms.Label();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.ChooseDocButton = new System.Windows.Forms.Button();
            this.WordFileListView = new System.Windows.Forms.ListView();
            this.TabPage_02 = new System.Windows.Forms.TabPage();
            this.PdfStatusText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Convert2DocButton = new System.Windows.Forms.Button();
            this.SelectPdfButton = new System.Windows.Forms.Button();
            this.PdfFileListView = new System.Windows.Forms.ListView();
            this.TabPage_03 = new System.Windows.Forms.TabPage();
            this.ExportEachSheet = new System.Windows.Forms.CheckBox();
            this.Excel2PdfStatusText = new System.Windows.Forms.Label();
            this.ConvertExcel2PdfButton = new System.Windows.Forms.Button();
            this.SelectExcelFileButton = new System.Windows.Forms.Button();
            this.ExcelFileListView = new System.Windows.Forms.ListView();
            this.TabPage_04 = new System.Windows.Forms.TabPage();
            this.SelectWord2ImageFileButton = new System.Windows.Forms.Button();
            this.ConvertWord2ImageStatus = new System.Windows.Forms.Label();
            this.SetGrayCheckBox = new System.Windows.Forms.CheckBox();
            this.ConvertWord2ImageButton = new System.Windows.Forms.Button();
            this.ConvertImageList = new System.Windows.Forms.ComboBox();
            this.DocumentsListView = new System.Windows.Forms.ListView();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.DpiItemList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PageExportCheck = new System.Windows.Forms.CheckBox();
            this.MainTabPage.SuspendLayout();
            this.TabPage_01.SuspendLayout();
            this.TabPage_02.SuspendLayout();
            this.TabPage_03.SuspendLayout();
            this.TabPage_04.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabPage
            // 
            this.MainTabPage.Controls.Add(this.TabPage_01);
            this.MainTabPage.Controls.Add(this.TabPage_02);
            this.MainTabPage.Controls.Add(this.TabPage_03);
            this.MainTabPage.Controls.Add(this.TabPage_04);
            this.MainTabPage.Location = new System.Drawing.Point(3, 12);
            this.MainTabPage.Name = "MainTabPage";
            this.MainTabPage.SelectedIndex = 0;
            this.MainTabPage.Size = new System.Drawing.Size(785, 507);
            this.MainTabPage.TabIndex = 0;
            // 
            // TabPage_01
            // 
            this.TabPage_01.Controls.Add(this.MergePdfButton);
            this.TabPage_01.Controls.Add(this.RemoveTempDocx);
            this.TabPage_01.Controls.Add(this.OpenPdfOptions);
            this.TabPage_01.Controls.Add(this.StatusText);
            this.TabPage_01.Controls.Add(this.ConvertButton);
            this.TabPage_01.Controls.Add(this.ChooseDocButton);
            this.TabPage_01.Controls.Add(this.WordFileListView);
            this.TabPage_01.Location = new System.Drawing.Point(4, 28);
            this.TabPage_01.Name = "TabPage_01";
            this.TabPage_01.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_01.Size = new System.Drawing.Size(777, 475);
            this.TabPage_01.TabIndex = 0;
            this.TabPage_01.Text = "WORD转PDF";
            this.TabPage_01.UseVisualStyleBackColor = true;
            // 
            // MergePdfButton
            // 
            this.MergePdfButton.Location = new System.Drawing.Point(550, 338);
            this.MergePdfButton.Name = "MergePdfButton";
            this.MergePdfButton.Size = new System.Drawing.Size(219, 50);
            this.MergePdfButton.TabIndex = 5;
            this.MergePdfButton.Text = "合并列表中的PDF文件";
            this.MergePdfButton.UseVisualStyleBackColor = true;
            this.MergePdfButton.Click += new System.EventHandler(this.MergePdfButton_Click);
            // 
            // RemoveTempDocx
            // 
            this.RemoveTempDocx.AutoSize = true;
            this.RemoveTempDocx.Location = new System.Drawing.Point(235, 347);
            this.RemoveTempDocx.Name = "RemoveTempDocx";
            this.RemoveTempDocx.Size = new System.Drawing.Size(268, 22);
            this.RemoveTempDocx.TabIndex = 6;
            this.RemoveTempDocx.Text = "处理完毕后移除TempDocx目录";
            this.RemoveTempDocx.UseVisualStyleBackColor = true;
            // 
            // OpenPdfOptions
            // 
            this.OpenPdfOptions.AutoSize = true;
            this.OpenPdfOptions.Location = new System.Drawing.Point(6, 347);
            this.OpenPdfOptions.Name = "OpenPdfOptions";
            this.OpenPdfOptions.Size = new System.Drawing.Size(223, 22);
            this.OpenPdfOptions.TabIndex = 5;
            this.OpenPdfOptions.Text = "处理完毕后打开PDF文件";
            this.OpenPdfOptions.UseVisualStyleBackColor = true;
            // 
            // StatusText
            // 
            this.StatusText.AutoSize = true;
            this.StatusText.ForeColor = System.Drawing.Color.ForestGreen;
            this.StatusText.Location = new System.Drawing.Point(293, 424);
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(161, 18);
            this.StatusText.TabIndex = 4;
            this.StatusText.Text = "正在等待处理中...";
            // 
            // ConvertButton
            // 
            this.ConvertButton.Location = new System.Drawing.Point(550, 406);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(221, 55);
            this.ConvertButton.TabIndex = 2;
            this.ConvertButton.Text = "开始处理";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // ChooseDocButton
            // 
            this.ChooseDocButton.Location = new System.Drawing.Point(6, 406);
            this.ChooseDocButton.Name = "ChooseDocButton";
            this.ChooseDocButton.Size = new System.Drawing.Size(221, 55);
            this.ChooseDocButton.TabIndex = 1;
            this.ChooseDocButton.Text = "选择文件";
            this.ChooseDocButton.UseVisualStyleBackColor = true;
            this.ChooseDocButton.Click += new System.EventHandler(this.ChooseDocButton_Click);
            // 
            // WordFileListView
            // 
            this.WordFileListView.HideSelection = false;
            this.WordFileListView.Location = new System.Drawing.Point(6, 6);
            this.WordFileListView.Name = "WordFileListView";
            this.WordFileListView.Size = new System.Drawing.Size(765, 326);
            this.WordFileListView.TabIndex = 0;
            this.WordFileListView.UseCompatibleStateImageBehavior = false;
            this.WordFileListView.View = System.Windows.Forms.View.List;
            // 
            // TabPage_02
            // 
            this.TabPage_02.Controls.Add(this.PdfStatusText);
            this.TabPage_02.Controls.Add(this.label1);
            this.TabPage_02.Controls.Add(this.Convert2DocButton);
            this.TabPage_02.Controls.Add(this.SelectPdfButton);
            this.TabPage_02.Controls.Add(this.PdfFileListView);
            this.TabPage_02.Location = new System.Drawing.Point(4, 28);
            this.TabPage_02.Name = "TabPage_02";
            this.TabPage_02.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_02.Size = new System.Drawing.Size(777, 475);
            this.TabPage_02.TabIndex = 1;
            this.TabPage_02.Text = "PDF转WORD";
            this.TabPage_02.UseVisualStyleBackColor = true;
            // 
            // PdfStatusText
            // 
            this.PdfStatusText.AutoSize = true;
            this.PdfStatusText.ForeColor = System.Drawing.Color.ForestGreen;
            this.PdfStatusText.Location = new System.Drawing.Point(293, 424);
            this.PdfStatusText.Name = "PdfStatusText";
            this.PdfStatusText.Size = new System.Drawing.Size(161, 18);
            this.PdfStatusText.TabIndex = 4;
            this.PdfStatusText.Text = "正在等待处理中...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Tomato;
            this.label1.Location = new System.Drawing.Point(6, 355);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(449, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "提示：PDF转WORD无法保证和源文档格式一致，谨慎使用";
            // 
            // Convert2DocButton
            // 
            this.Convert2DocButton.Location = new System.Drawing.Point(550, 406);
            this.Convert2DocButton.Name = "Convert2DocButton";
            this.Convert2DocButton.Size = new System.Drawing.Size(221, 55);
            this.Convert2DocButton.TabIndex = 2;
            this.Convert2DocButton.Text = "开始处理";
            this.Convert2DocButton.UseVisualStyleBackColor = true;
            this.Convert2DocButton.Click += new System.EventHandler(this.Convert2DocButton_Click);
            // 
            // SelectPdfButton
            // 
            this.SelectPdfButton.Location = new System.Drawing.Point(6, 406);
            this.SelectPdfButton.Name = "SelectPdfButton";
            this.SelectPdfButton.Size = new System.Drawing.Size(221, 55);
            this.SelectPdfButton.TabIndex = 1;
            this.SelectPdfButton.Text = "选择文件";
            this.SelectPdfButton.UseVisualStyleBackColor = true;
            this.SelectPdfButton.Click += new System.EventHandler(this.SelectPdfButton_Click);
            // 
            // PdfFileListView
            // 
            this.PdfFileListView.HideSelection = false;
            this.PdfFileListView.Location = new System.Drawing.Point(6, 6);
            this.PdfFileListView.Name = "PdfFileListView";
            this.PdfFileListView.Size = new System.Drawing.Size(765, 326);
            this.PdfFileListView.TabIndex = 0;
            this.PdfFileListView.UseCompatibleStateImageBehavior = false;
            // 
            // TabPage_03
            // 
            this.TabPage_03.Controls.Add(this.ExportEachSheet);
            this.TabPage_03.Controls.Add(this.Excel2PdfStatusText);
            this.TabPage_03.Controls.Add(this.ConvertExcel2PdfButton);
            this.TabPage_03.Controls.Add(this.SelectExcelFileButton);
            this.TabPage_03.Controls.Add(this.ExcelFileListView);
            this.TabPage_03.Location = new System.Drawing.Point(4, 28);
            this.TabPage_03.Name = "TabPage_03";
            this.TabPage_03.Size = new System.Drawing.Size(777, 475);
            this.TabPage_03.TabIndex = 2;
            this.TabPage_03.Text = "EXCEL转PDF";
            this.TabPage_03.UseVisualStyleBackColor = true;
            // 
            // ExportEachSheet
            // 
            this.ExportEachSheet.AutoSize = true;
            this.ExportEachSheet.Location = new System.Drawing.Point(6, 347);
            this.ExportEachSheet.Name = "ExportEachSheet";
            this.ExportEachSheet.Size = new System.Drawing.Size(286, 22);
            this.ExportEachSheet.TabIndex = 5;
            this.ExportEachSheet.Text = "导出每个Sheet到单独的PDF文件";
            this.ExportEachSheet.UseVisualStyleBackColor = true;
            // 
            // Excel2PdfStatusText
            // 
            this.Excel2PdfStatusText.AutoSize = true;
            this.Excel2PdfStatusText.ForeColor = System.Drawing.Color.ForestGreen;
            this.Excel2PdfStatusText.Location = new System.Drawing.Point(293, 424);
            this.Excel2PdfStatusText.Name = "Excel2PdfStatusText";
            this.Excel2PdfStatusText.Size = new System.Drawing.Size(161, 18);
            this.Excel2PdfStatusText.TabIndex = 4;
            this.Excel2PdfStatusText.Text = "正在等待处理中...";
            // 
            // ConvertExcel2PdfButton
            // 
            this.ConvertExcel2PdfButton.Location = new System.Drawing.Point(550, 406);
            this.ConvertExcel2PdfButton.Name = "ConvertExcel2PdfButton";
            this.ConvertExcel2PdfButton.Size = new System.Drawing.Size(221, 55);
            this.ConvertExcel2PdfButton.TabIndex = 3;
            this.ConvertExcel2PdfButton.Text = "开始处理";
            this.ConvertExcel2PdfButton.UseVisualStyleBackColor = true;
            this.ConvertExcel2PdfButton.Click += new System.EventHandler(this.ConvertExcel2PdfButton_Click);
            // 
            // SelectExcelFileButton
            // 
            this.SelectExcelFileButton.Location = new System.Drawing.Point(6, 406);
            this.SelectExcelFileButton.Name = "SelectExcelFileButton";
            this.SelectExcelFileButton.Size = new System.Drawing.Size(221, 55);
            this.SelectExcelFileButton.TabIndex = 2;
            this.SelectExcelFileButton.Text = "选择文件";
            this.SelectExcelFileButton.UseVisualStyleBackColor = true;
            this.SelectExcelFileButton.Click += new System.EventHandler(this.SelectExcelFileButton_Click);
            // 
            // ExcelFileListView
            // 
            this.ExcelFileListView.HideSelection = false;
            this.ExcelFileListView.Location = new System.Drawing.Point(6, 6);
            this.ExcelFileListView.Name = "ExcelFileListView";
            this.ExcelFileListView.Size = new System.Drawing.Size(765, 326);
            this.ExcelFileListView.TabIndex = 1;
            this.ExcelFileListView.UseCompatibleStateImageBehavior = false;
            // 
            // TabPage_04
            // 
            this.TabPage_04.Controls.Add(this.PageExportCheck);
            this.TabPage_04.Controls.Add(this.label3);
            this.TabPage_04.Controls.Add(this.DpiItemList);
            this.TabPage_04.Controls.Add(this.label2);
            this.TabPage_04.Controls.Add(this.SelectWord2ImageFileButton);
            this.TabPage_04.Controls.Add(this.ConvertWord2ImageStatus);
            this.TabPage_04.Controls.Add(this.SetGrayCheckBox);
            this.TabPage_04.Controls.Add(this.ConvertWord2ImageButton);
            this.TabPage_04.Controls.Add(this.ConvertImageList);
            this.TabPage_04.Controls.Add(this.DocumentsListView);
            this.TabPage_04.Location = new System.Drawing.Point(4, 28);
            this.TabPage_04.Name = "TabPage_04";
            this.TabPage_04.Size = new System.Drawing.Size(777, 475);
            this.TabPage_04.TabIndex = 3;
            this.TabPage_04.Text = "WORD转图片";
            this.TabPage_04.UseVisualStyleBackColor = true;
            // 
            // SelectWord2ImageFileButton
            // 
            this.SelectWord2ImageFileButton.Location = new System.Drawing.Point(6, 406);
            this.SelectWord2ImageFileButton.Name = "SelectWord2ImageFileButton";
            this.SelectWord2ImageFileButton.Size = new System.Drawing.Size(221, 55);
            this.SelectWord2ImageFileButton.TabIndex = 5;
            this.SelectWord2ImageFileButton.Text = "选择文件";
            this.SelectWord2ImageFileButton.UseVisualStyleBackColor = true;
            this.SelectWord2ImageFileButton.Click += new System.EventHandler(this.SelectWord2ImageFileButton_Click);
            // 
            // ConvertWord2ImageStatus
            // 
            this.ConvertWord2ImageStatus.AutoSize = true;
            this.ConvertWord2ImageStatus.ForeColor = System.Drawing.Color.ForestGreen;
            this.ConvertWord2ImageStatus.Location = new System.Drawing.Point(293, 424);
            this.ConvertWord2ImageStatus.Name = "ConvertWord2ImageStatus";
            this.ConvertWord2ImageStatus.Size = new System.Drawing.Size(161, 18);
            this.ConvertWord2ImageStatus.TabIndex = 4;
            this.ConvertWord2ImageStatus.Text = "正在等待处理中...";
            // 
            // SetGrayCheckBox
            // 
            this.SetGrayCheckBox.AutoSize = true;
            this.SetGrayCheckBox.Location = new System.Drawing.Point(6, 347);
            this.SetGrayCheckBox.Name = "SetGrayCheckBox";
            this.SetGrayCheckBox.Size = new System.Drawing.Size(160, 22);
            this.SetGrayCheckBox.TabIndex = 3;
            this.SetGrayCheckBox.Text = "转换为灰度图片";
            this.SetGrayCheckBox.UseVisualStyleBackColor = true;
            // 
            // ConvertWord2ImageButton
            // 
            this.ConvertWord2ImageButton.Location = new System.Drawing.Point(550, 406);
            this.ConvertWord2ImageButton.Name = "ConvertWord2ImageButton";
            this.ConvertWord2ImageButton.Size = new System.Drawing.Size(221, 55);
            this.ConvertWord2ImageButton.TabIndex = 2;
            this.ConvertWord2ImageButton.Text = "开始处理";
            this.ConvertWord2ImageButton.UseVisualStyleBackColor = true;
            this.ConvertWord2ImageButton.Click += new System.EventHandler(this.ConvertWord2ImageButton_Click);
            // 
            // ConvertImageList
            // 
            this.ConvertImageList.FormattingEnabled = true;
            this.ConvertImageList.Location = new System.Drawing.Point(648, 343);
            this.ConvertImageList.Name = "ConvertImageList";
            this.ConvertImageList.Size = new System.Drawing.Size(121, 26);
            this.ConvertImageList.TabIndex = 1;
            this.ConvertImageList.SelectedIndexChanged += new System.EventHandler(this.ConvertImageList_SelectedIndexChanged);
            // 
            // DocumentsListView
            // 
            this.DocumentsListView.HideSelection = false;
            this.DocumentsListView.Location = new System.Drawing.Point(6, 6);
            this.DocumentsListView.Name = "DocumentsListView";
            this.DocumentsListView.Size = new System.Drawing.Size(765, 326);
            this.DocumentsListView.TabIndex = 0;
            this.DocumentsListView.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(562, 347);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "转换格式";
            // 
            // DpiItemList
            // 
            this.DpiItemList.FormattingEnabled = true;
            this.DpiItemList.Location = new System.Drawing.Point(424, 343);
            this.DpiItemList.Name = "DpiItemList";
            this.DpiItemList.Size = new System.Drawing.Size(121, 26);
            this.DpiItemList.TabIndex = 7;
            this.DpiItemList.SelectedIndexChanged += new System.EventHandler(this.DpiItemList_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(284, 347);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "图像输出分辨率";
            // 
            // PageExportCheck
            // 
            this.PageExportCheck.AutoSize = true;
            this.PageExportCheck.Location = new System.Drawing.Point(172, 347);
            this.PageExportCheck.Name = "PageExportCheck";
            this.PageExportCheck.Size = new System.Drawing.Size(106, 22);
            this.PageExportCheck.TabIndex = 9;
            this.PageExportCheck.Text = "逐页导出";
            this.PageExportCheck.UseVisualStyleBackColor = true;
            // 
            // BodyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(788, 520);
            this.Controls.Add(this.MainTabPage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BodyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文档工具";
            this.Load += new System.EventHandler(this.BodyForm_Load);
            this.MainTabPage.ResumeLayout(false);
            this.TabPage_01.ResumeLayout(false);
            this.TabPage_01.PerformLayout();
            this.TabPage_02.ResumeLayout(false);
            this.TabPage_02.PerformLayout();
            this.TabPage_03.ResumeLayout(false);
            this.TabPage_03.PerformLayout();
            this.TabPage_04.ResumeLayout(false);
            this.TabPage_04.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabPage;
        private System.Windows.Forms.TabPage TabPage_01;
        private System.Windows.Forms.TabPage TabPage_02;
        private System.Windows.Forms.Button ChooseDocButton;
        internal System.Windows.Forms.ListView WordFileListView;
        private System.Windows.Forms.Button ConvertButton;
        private System.Windows.Forms.Label StatusText;
        private System.Windows.Forms.Button SelectPdfButton;
        private System.Windows.Forms.Button Convert2DocButton;
        internal System.Windows.Forms.ListView PdfFileListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PdfStatusText;
        private System.Windows.Forms.TabPage TabPage_03;
        internal System.Windows.Forms.ListView ExcelFileListView;
        private System.Windows.Forms.Button ConvertExcel2PdfButton;
        private System.Windows.Forms.Button SelectExcelFileButton;
        private System.Windows.Forms.Button MergePdfButton;
        internal System.Windows.Forms.SaveFileDialog SaveFileDialog;
        internal System.Windows.Forms.CheckBox OpenPdfOptions;
        internal System.Windows.Forms.CheckBox RemoveTempDocx;
        private System.Windows.Forms.Label Excel2PdfStatusText;
        internal System.Windows.Forms.CheckBox ExportEachSheet;
        private System.Windows.Forms.TabPage TabPage_04;
        private System.Windows.Forms.ComboBox ConvertImageList;
        private System.Windows.Forms.Button ConvertWord2ImageButton;
        internal System.Windows.Forms.ListView DocumentsListView;
        internal System.Windows.Forms.CheckBox SetGrayCheckBox;
        private System.Windows.Forms.Label ConvertWord2ImageStatus;
        private System.Windows.Forms.Button SelectWord2ImageFileButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.CheckBox PageExportCheck;
        internal System.Windows.Forms.ComboBox DpiItemList;
    }
}

