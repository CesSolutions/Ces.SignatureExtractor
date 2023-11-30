namespace CesSignatureExtractor
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
            this.pbOriginalImage = new System.Windows.Forms.PictureBox();
            this.pbFinalImage = new System.Windows.Forms.PictureBox();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.btnExtractSignature = new System.Windows.Forms.Button();
            this.btnSaveResult = new System.Windows.Forms.Button();
            this.btnClearOriginal = new System.Windows.Forms.Button();
            this.btnClearResult = new System.Windows.Forms.Button();
            this.btnResultColor = new System.Windows.Forms.Button();
            this.chkUseOriginalColor = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinalImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbOriginalImage
            // 
            this.pbOriginalImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbOriginalImage.Location = new System.Drawing.Point(12, 12);
            this.pbOriginalImage.Name = "pbOriginalImage";
            this.pbOriginalImage.Size = new System.Drawing.Size(400, 500);
            this.pbOriginalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbOriginalImage.TabIndex = 0;
            this.pbOriginalImage.TabStop = false;
            // 
            // pbFinalImage
            // 
            this.pbFinalImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFinalImage.Location = new System.Drawing.Point(418, 12);
            this.pbFinalImage.Name = "pbFinalImage";
            this.pbFinalImage.Size = new System.Drawing.Size(400, 500);
            this.pbFinalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFinalImage.TabIndex = 1;
            this.pbFinalImage.TabStop = false;
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(12, 518);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(400, 40);
            this.btnLoadImage.TabIndex = 2;
            this.btnLoadImage.Text = "Load Image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // btnExtractSignature
            // 
            this.btnExtractSignature.Location = new System.Drawing.Point(418, 518);
            this.btnExtractSignature.Name = "btnExtractSignature";
            this.btnExtractSignature.Size = new System.Drawing.Size(400, 40);
            this.btnExtractSignature.TabIndex = 3;
            this.btnExtractSignature.Text = "Extract Signature";
            this.btnExtractSignature.UseVisualStyleBackColor = true;
            this.btnExtractSignature.Click += new System.EventHandler(this.btnExtractSignatur_Click);
            // 
            // btnSaveResult
            // 
            this.btnSaveResult.Location = new System.Drawing.Point(418, 610);
            this.btnSaveResult.Name = "btnSaveResult";
            this.btnSaveResult.Size = new System.Drawing.Size(400, 40);
            this.btnSaveResult.TabIndex = 4;
            this.btnSaveResult.Text = "Save Result";
            this.btnSaveResult.UseVisualStyleBackColor = true;
            this.btnSaveResult.Click += new System.EventHandler(this.btnSaveResult_Click);
            // 
            // btnClearOriginal
            // 
            this.btnClearOriginal.Location = new System.Drawing.Point(12, 564);
            this.btnClearOriginal.Name = "btnClearOriginal";
            this.btnClearOriginal.Size = new System.Drawing.Size(400, 40);
            this.btnClearOriginal.TabIndex = 5;
            this.btnClearOriginal.Text = "Clear Original";
            this.btnClearOriginal.UseVisualStyleBackColor = true;
            this.btnClearOriginal.Click += new System.EventHandler(this.btnClearOriginal_Click);
            // 
            // btnClearResult
            // 
            this.btnClearResult.Location = new System.Drawing.Point(418, 564);
            this.btnClearResult.Name = "btnClearResult";
            this.btnClearResult.Size = new System.Drawing.Size(400, 40);
            this.btnClearResult.TabIndex = 6;
            this.btnClearResult.Text = "Clear Result";
            this.btnClearResult.UseVisualStyleBackColor = true;
            this.btnClearResult.Click += new System.EventHandler(this.btnClearResult_Click);
            // 
            // btnResultColor
            // 
            this.btnResultColor.BackColor = System.Drawing.Color.Green;
            this.btnResultColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResultColor.Enabled = false;
            this.btnResultColor.FlatAppearance.BorderSize = 0;
            this.btnResultColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResultColor.Location = new System.Drawing.Point(423, 477);
            this.btnResultColor.Name = "btnResultColor";
            this.btnResultColor.Size = new System.Drawing.Size(30, 30);
            this.btnResultColor.TabIndex = 7;
            this.btnResultColor.UseVisualStyleBackColor = false;
            this.btnResultColor.Click += new System.EventHandler(this.btnResultColor_Click);
            // 
            // chkUseOriginalColor
            // 
            this.chkUseOriginalColor.AutoSize = true;
            this.chkUseOriginalColor.Checked = true;
            this.chkUseOriginalColor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseOriginalColor.Location = new System.Drawing.Point(459, 484);
            this.chkUseOriginalColor.Name = "chkUseOriginalColor";
            this.chkUseOriginalColor.Size = new System.Drawing.Size(122, 19);
            this.chkUseOriginalColor.TabIndex = 8;
            this.chkUseOriginalColor.Text = "Use Original Color";
            this.chkUseOriginalColor.UseVisualStyleBackColor = true;
            this.chkUseOriginalColor.CheckedChanged += new System.EventHandler(this.chkUseOriginalColor_CheckedChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 661);
            this.Controls.Add(this.chkUseOriginalColor);
            this.Controls.Add(this.btnResultColor);
            this.Controls.Add(this.btnClearResult);
            this.Controls.Add(this.btnClearOriginal);
            this.Controls.Add(this.btnSaveResult);
            this.Controls.Add(this.btnExtractSignature);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.pbFinalImage);
            this.Controls.Add(this.pbOriginalImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Signature Extractor";
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinalImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pbOriginalImage;
        private PictureBox pbFinalImage;
        private Button btnLoadImage;
        private Button btnExtractSignature;
        private Button btnSaveResult;
        private Button btnClearOriginal;
        private Button btnClearResult;
        private Button btnResultColor;
        private CheckBox chkUseOriginalColor;
    }
}