namespace Ces.SignatureExtractor.UI
{
    partial class frmMain
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
            pbOriginalImage = new PictureBox();
            pbFinalImage = new PictureBox();
            btnLoadImage = new Button();
            btnExtractSignature = new Button();
            btnSaveResult = new Button();
            btnClearOriginal = new Button();
            btnClearResult = new Button();
            btnCustomColor = new Button();
            chkUseOriginalColor = new CheckBox();
            tbBackgroundPrecision = new TrackBar();
            lblBackgroundPrecision = new Label();
            ((System.ComponentModel.ISupportInitialize)pbOriginalImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFinalImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbBackgroundPrecision).BeginInit();
            SuspendLayout();
            // 
            // pbOriginalImage
            // 
            pbOriginalImage.BorderStyle = BorderStyle.FixedSingle;
            pbOriginalImage.Location = new Point(12, 12);
            pbOriginalImage.Name = "pbOriginalImage";
            pbOriginalImage.Size = new Size(352, 374);
            pbOriginalImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbOriginalImage.TabIndex = 0;
            pbOriginalImage.TabStop = false;
            // 
            // pbFinalImage
            // 
            pbFinalImage.BorderStyle = BorderStyle.FixedSingle;
            pbFinalImage.Location = new Point(372, 12);
            pbFinalImage.Name = "pbFinalImage";
            pbFinalImage.Size = new Size(400, 374);
            pbFinalImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbFinalImage.TabIndex = 1;
            pbFinalImage.TabStop = false;
            // 
            // btnLoadImage
            // 
            btnLoadImage.Location = new Point(12, 392);
            btnLoadImage.Name = "btnLoadImage";
            btnLoadImage.Size = new Size(128, 40);
            btnLoadImage.TabIndex = 2;
            btnLoadImage.Text = "Load Image";
            btnLoadImage.UseVisualStyleBackColor = true;
            btnLoadImage.Click += btnLoadImage_Click;
            // 
            // btnExtractSignature
            // 
            btnExtractSignature.Location = new Point(372, 392);
            btnExtractSignature.Name = "btnExtractSignature";
            btnExtractSignature.Size = new Size(163, 40);
            btnExtractSignature.TabIndex = 3;
            btnExtractSignature.Text = "Extract Signature";
            btnExtractSignature.UseVisualStyleBackColor = true;
            btnExtractSignature.Click += btnExtractSignatur_Click;
            // 
            // btnSaveResult
            // 
            btnSaveResult.Location = new Point(609, 438);
            btnSaveResult.Name = "btnSaveResult";
            btnSaveResult.Size = new Size(163, 40);
            btnSaveResult.TabIndex = 4;
            btnSaveResult.Text = "Save Result";
            btnSaveResult.UseVisualStyleBackColor = true;
            btnSaveResult.Click += btnSaveResult_Click;
            // 
            // btnClearOriginal
            // 
            btnClearOriginal.Location = new Point(146, 392);
            btnClearOriginal.Name = "btnClearOriginal";
            btnClearOriginal.Size = new Size(135, 40);
            btnClearOriginal.TabIndex = 5;
            btnClearOriginal.Text = "Clear Original";
            btnClearOriginal.UseVisualStyleBackColor = true;
            btnClearOriginal.Click += btnClearOriginal_Click;
            // 
            // btnClearResult
            // 
            btnClearResult.Location = new Point(609, 392);
            btnClearResult.Name = "btnClearResult";
            btnClearResult.Size = new Size(163, 40);
            btnClearResult.TabIndex = 6;
            btnClearResult.Text = "Clear Result";
            btnClearResult.UseVisualStyleBackColor = true;
            btnClearResult.Click += btnClearResult_Click;
            // 
            // btnCustomColor
            // 
            btnCustomColor.BackColor = Color.Green;
            btnCustomColor.Cursor = Cursors.Hand;
            btnCustomColor.FlatAppearance.BorderSize = 0;
            btnCustomColor.FlatStyle = FlatStyle.Flat;
            btnCustomColor.Location = new Point(541, 393);
            btnCustomColor.Name = "btnCustomColor";
            btnCustomColor.Size = new Size(45, 38);
            btnCustomColor.TabIndex = 7;
            btnCustomColor.UseVisualStyleBackColor = false;
            btnCustomColor.Visible = false;
            btnCustomColor.Click += btnCustomColor_Click;
            // 
            // chkUseOriginalColor
            // 
            chkUseOriginalColor.AutoSize = true;
            chkUseOriginalColor.Checked = true;
            chkUseOriginalColor.CheckState = CheckState.Checked;
            chkUseOriginalColor.Location = new Point(373, 438);
            chkUseOriginalColor.Name = "chkUseOriginalColor";
            chkUseOriginalColor.Size = new Size(122, 19);
            chkUseOriginalColor.TabIndex = 8;
            chkUseOriginalColor.Text = "Use Original Color";
            chkUseOriginalColor.UseVisualStyleBackColor = true;
            chkUseOriginalColor.CheckedChanged += chkUseOriginalColor_CheckedChanged;
            // 
            // tbBackgroundPrecision
            // 
            tbBackgroundPrecision.LargeChange = 1;
            tbBackgroundPrecision.Location = new Point(373, 484);
            tbBackgroundPrecision.Maximum = 255;
            tbBackgroundPrecision.Name = "tbBackgroundPrecision";
            tbBackgroundPrecision.Size = new Size(400, 45);
            tbBackgroundPrecision.TabIndex = 9;
            tbBackgroundPrecision.TickFrequency = 5;
            tbBackgroundPrecision.Value = 200;
            tbBackgroundPrecision.Scroll += tbBackgroundPrecision_Scroll;
            // 
            // lblBackgroundPrecision
            // 
            lblBackgroundPrecision.AutoSize = true;
            lblBackgroundPrecision.Location = new Point(372, 463);
            lblBackgroundPrecision.Name = "lblBackgroundPrecision";
            lblBackgroundPrecision.Size = new Size(79, 15);
            lblBackgroundPrecision.TabIndex = 10;
            lblBackgroundPrecision.Text = "Precision: 200";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 530);
            Controls.Add(lblBackgroundPrecision);
            Controls.Add(tbBackgroundPrecision);
            Controls.Add(chkUseOriginalColor);
            Controls.Add(btnCustomColor);
            Controls.Add(btnClearResult);
            Controls.Add(btnClearOriginal);
            Controls.Add(btnSaveResult);
            Controls.Add(btnExtractSignature);
            Controls.Add(btnLoadImage);
            Controls.Add(pbFinalImage);
            Controls.Add(pbOriginalImage);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Signature Extractor";
            ((System.ComponentModel.ISupportInitialize)pbOriginalImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFinalImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbBackgroundPrecision).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private PictureBox pbOriginalImage;
        private PictureBox pbFinalImage;
        private Button btnLoadImage;
        private Button btnExtractSignature;
        private Button btnSaveResult;
        private Button btnClearOriginal;
        private Button btnClearResult;
        private Button btnCustomColor;
        private CheckBox chkUseOriginalColor;
        private TrackBar tbBackgroundPrecision;
        private Label lblBackgroundPrecision;
    }
}