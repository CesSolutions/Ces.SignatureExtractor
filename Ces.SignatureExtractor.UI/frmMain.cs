namespace Ces.SignatureExtractor.UI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }


        private OpenFileDialog openFileDialog = new OpenFileDialog();


        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            openFileDialog.Multiselect = false;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "Image File|*.JPG;*.PNG";

            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            pbOriginalImage.Image = null;
            pbOriginalImage.Image = Image.FromFile(openFileDialog.FileName);
        }

        private void btnClearOriginal_Click(object sender, EventArgs e)
        {
            pbOriginalImage.Image = null;
        }

        private void btnExtractSignatur_Click(object sender, EventArgs e)
        {
            var extractor = new Ces.SignatureExtractor.Extractor();

            this.pbFinalImage.Image = extractor.Extract(
                openFileDialog.FileName
                , false
                , Color.Red);
        }

        private void btnClearResult_Click(object sender, EventArgs e)
        {
            pbFinalImage.Image = null;
        }

        private void btnSaveResult_Click(object sender, EventArgs e)
        {
            if (pbFinalImage.Image == null)
                return;

            using SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = System.IO.Path.GetFileNameWithoutExtension(openFileDialog.FileName);
            saveFileDialog.Filter = "Png Image (.png)|*.png|JPEG Image (.jpeg)|*.jpeg";

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            pbFinalImage.Image.Save(saveFileDialog.FileName);
        }

        private void btnResultColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() != DialogResult.OK)
                return;

            btnResultColor.BackColor = colorDialog.Color;
        }

        private void chkUseOriginalColor_CheckedChanged(object sender, EventArgs e)
        {
            btnResultColor.Enabled = !chkUseOriginalColor.Checked;
        }
    }
}