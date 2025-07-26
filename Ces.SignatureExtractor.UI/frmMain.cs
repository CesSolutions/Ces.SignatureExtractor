namespace Ces.SignatureExtractor.UI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }


        private OpenFileDialog _openFileDialog = new OpenFileDialog();
        private Color _customeColor;

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            _openFileDialog.Multiselect = false;
            _openFileDialog.RestoreDirectory = true;
            _openFileDialog.Filter = "Image File|*.JPG;*.PNG";

            if (_openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            pbOriginalImage.Image = null;
            pbOriginalImage.Image = Image.FromFile(_openFileDialog.FileName);
        }

        private void btnClearOriginal_Click(object sender, EventArgs e)
        {
            pbOriginalImage.Image = null;
        }

private void btnExtractSignatur_Click(object sender, EventArgs e)
{
var extractor = new Ces.SignatureExtractor.Extractor();

this.pbFinalImage.Image = extractor.Extract(
    _openFileDialog.FileName
    , chkUseOriginalColor.Checked
    , btnCustomColor.BackColor
    , (byte)tbBackgroundPrecision.Value);
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
            saveFileDialog.FileName = System.IO.Path.GetFileNameWithoutExtension(_openFileDialog.FileName);
            saveFileDialog.Filter = "Png Image (.png)|*.png|JPEG Image (.jpeg)|*.jpeg";

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            pbFinalImage.Image.Save(saveFileDialog.FileName);
        }

        private void btnCustomColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() != DialogResult.OK)
                return;

            _customeColor = colorDialog.Color;
            btnCustomColor.BackColor = _customeColor;
        }

        private void chkUseOriginalColor_CheckedChanged(object sender, EventArgs e)
        {
            btnCustomColor.Visible = !chkUseOriginalColor.Checked;
        }

        private void tbBackgroundPrecision_Scroll(object sender, EventArgs e)
        {
            lblBackgroundPrecision.Text = $"Precision: {tbBackgroundPrecision.Value}";
        }
    }
}