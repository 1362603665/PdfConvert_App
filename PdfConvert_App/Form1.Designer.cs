namespace PdfConvert_App
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            textPdfPath = new TextBox();
            label2 = new Label();
            textFilePath = new TextBox();
            label3 = new Label();
            comBoxFileType = new ComboBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            btn_Generate = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 11F);
            label1.Location = new Point(16, 34);
            label1.Name = "label1";
            label1.Size = new Size(108, 20);
            label1.TabIndex = 0;
            label1.Text = "Pdf文件路径：";
            // 
            // textPdfPath
            // 
            textPdfPath.Location = new Point(117, 33);
            textPdfPath.Name = "textPdfPath";
            textPdfPath.Size = new Size(301, 23);
            textPdfPath.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 11F);
            label2.Location = new Point(10, 71);
            label2.Name = "label2";
            label2.Size = new Size(114, 20);
            label2.TabIndex = 2;
            label2.Text = "生成文件地址：";
            // 
            // textFilePath
            // 
            textFilePath.Location = new Point(117, 70);
            textFilePath.Name = "textFilePath";
            textFilePath.Size = new Size(301, 23);
            textFilePath.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 11F);
            label3.Location = new Point(10, 106);
            label3.Name = "label3";
            label3.Size = new Size(114, 20);
            label3.TabIndex = 4;
            label3.Text = "生成文件类型：";
            // 
            // comBoxFileType
            // 
            comBoxFileType.FormattingEnabled = true;
            comBoxFileType.Items.AddRange(new object[] { "Word", "Excel" });
            comBoxFileType.Location = new Point(117, 103);
            comBoxFileType.Name = "comBoxFileType";
            comBoxFileType.Size = new Size(129, 25);
            comBoxFileType.TabIndex = 5;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // btn_Generate
            // 
            btn_Generate.Location = new Point(169, 159);
            btn_Generate.Name = "btn_Generate";
            btn_Generate.Size = new Size(92, 30);
            btn_Generate.TabIndex = 7;
            btn_Generate.Text = "开始生成";
            btn_Generate.UseVisualStyleBackColor = true;
            btn_Generate.Click += btn_Generate_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(439, 237);
            Controls.Add(btn_Generate);
            Controls.Add(comBoxFileType);
            Controls.Add(label3);
            Controls.Add(textFilePath);
            Controls.Add(label2);
            Controls.Add(textPdfPath);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Pdf转换_v1.0";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textPdfPath;
        private Label label2;
        private TextBox textFilePath;
        private Label label3;
        private ComboBox comBoxFileType;
        private ContextMenuStrip contextMenuStrip1;
        private Button btn_Generate;
    }
}
