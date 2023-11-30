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
            this.btnExtractSignatur = new System.Windows.Forms.Button();
            this.btnSaveResult = new System.Windows.Forms.Button();
            this.btnClearOriginal = new System.Windows.Forms.Button();
            this.btnClearResult = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinalImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbOriginalImage
            // 
            this.pbOriginalImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbOriginalImage.Location = new System.Drawing.Point(44, 24);
            this.pbOriginalImage.Name = "pbOriginalImage";
            this.pbOriginalImage.Size = new System.Drawing.Size(237, 284);
            this.pbOriginalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbOriginalImage.TabIndex = 0;
            this.pbOriginalImage.TabStop = false;
            // 
            // pbFinalImage
            // 
            this.pbFinalImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFinalImage.Location = new System.Drawing.Point(287, 24);
            this.pbFinalImage.Name = "pbFinalImage";
            this.pbFinalImage.Size = new System.Drawing.Size(277, 284);
            this.pbFinalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFinalImage.TabIndex = 1;
            this.pbFinalImage.TabStop = false;
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(44, 314);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(237, 23);
            this.btnLoadImage.TabIndex = 2;
            this.btnLoadImage.Text = "Load Image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // btnExtractSignatur
            // 
            this.btnExtractSignatur.Location = new System.Drawing.Point(287, 314);
            this.btnExtractSignatur.Name = "btnExtractSignatur";
            this.btnExtractSignatur.Size = new System.Drawing.Size(277, 23);
            this.btnExtractSignatur.TabIndex = 3;
            this.btnExtractSignatur.Text = "Extract Signatur";
            this.btnExtractSignatur.UseVisualStyleBackColor = true;
            // 
            // btnSaveResult
            // 
            this.btnSaveResult.Location = new System.Drawing.Point(287, 372);
            this.btnSaveResult.Name = "btnSaveResult";
            this.btnSaveResult.Size = new System.Drawing.Size(277, 23);
            this.btnSaveResult.TabIndex = 4;
            this.btnSaveResult.Text = "Save Result";
            this.btnSaveResult.UseVisualStyleBackColor = true;
            // 
            // btnClearOriginal
            // 
            this.btnClearOriginal.Location = new System.Drawing.Point(44, 343);
            this.btnClearOriginal.Name = "btnClearOriginal";
            this.btnClearOriginal.Size = new System.Drawing.Size(237, 23);
            this.btnClearOriginal.TabIndex = 5;
            this.btnClearOriginal.Text = "Clear Original";
            this.btnClearOriginal.UseVisualStyleBackColor = true;
            this.btnClearOriginal.Click += new System.EventHandler(this.btnClearOriginal_Click);
            // 
            // btnClearResult
            // 
            this.btnClearResult.Location = new System.Drawing.Point(287, 343);
            this.btnClearResult.Name = "btnClearResult";
            this.btnClearResult.Size = new System.Drawing.Size(277, 23);
            this.btnClearResult.TabIndex = 6;
            this.btnClearResult.Text = "Clear Result";
            this.btnClearResult.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 638);
            this.Controls.Add(this.btnClearResult);
            this.Controls.Add(this.btnClearOriginal);
            this.Controls.Add(this.btnSaveResult);
            this.Controls.Add(this.btnExtractSignatur);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.pbFinalImage);
            this.Controls.Add(this.pbOriginalImage);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Signature Extractor";
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinalImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pbOriginalImage;
        private PictureBox pbFinalImage;
        private Button btnLoadImage;
        private Button btnExtractSignatur;
        private Button btnSaveResult;
        private Button btnClearOriginal;
        private Button btnClearResult;
    }
}