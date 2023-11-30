namespace CesSignatureExtractor
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

            if(openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            pbOriginalImage.Image = null;
            pbOriginalImage.Image = Image.FromFile(openFileDialog.FileName);
        }

        private void btnClearOriginal_Click(object sender, EventArgs e)
        {
            pbOriginalImage.Image = null;
        }
    }
}