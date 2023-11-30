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
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
                
            // ایجاد تصویر جدید براساس فایل انتخاب شده توسط کاربر
            var imgOriginal = new Bitmap(Image.FromFile(openFileDialog.FileName));

            // ایجاد تصویر نهایی که قرار است نتیجه در آن ترسیم شود
            var imgSignature = new Bitmap(imgOriginal.Width, imgOriginal.Height);

            // بدلیل آنکه استخراج تصویر با بررسی رنگ پیکسل های تصویر انجام می شود
            // بنابراین یک متغیر جهت نگهداری رنگ هر پیکسل تعریف میکنیم
            Color currentPixelColor = default;

            for (int x = 0; x <= (imgOriginal.Width - 1); x++)
            {
                for (int y = 0; y <= imgOriginal.Height - 1; y++)
                {
                    currentPixelColor = imgOriginal.GetPixel(x, y);

                    // ممکن است رنگ خودکار آبی و یا سفید و یا هر رنگ دیگه ای باشد
                    // بنابراین با توجه به اینکه نمونه امضا روی کاغذ سفید انجام خواهد شد
                    // بنابراین هر رنگی به غیر از سفید به عنوان داده های امضا محسوب خواهد
                    // شد و برنامه آن را به عنوان امضا از زمینه سفید جدا خواهد کرد                
                    if (currentPixelColor.R >= 0 & currentPixelColor.R <= 200)
                        imgSignature.SetPixel(x, y, currentPixelColor);
                }
            }

            // حالا که امضا بدست آمد باید حاشیه های اضافه را حذف کرد و بنابراین
            // باید مرز امضا پیدا شود و مجددا امضای بدست آمده در ابعاد مورد نظر
            // رسم شود
            var imgTopPoint = default(int);
            var imgBottomPoint = default(int);
            var imgLeftPoint = default(int);
            var imgRightPoint = default(int);

            for (int y = 0 ; y <= imgSignature.Height - 1; y++)
            {
                for (int x = 0; x <= imgSignature.Width - 1; x++)
                {
                    // اگر رنگ تشخیص داده شود پس مرز بالایی امضا می باشد
                    if (imgSignature.GetPixel(x, y).ToString() != "Color [A=0, R=0, G=0, B=0]")
                    {
                        // imgTopPoint = y
                        // اعداد برعکس بدست می ایند!!!!!!!
                        imgBottomPoint = y;
                        //break;
                    }
                }
            }

            for (int y = imgSignature.Height - 1; y >= 0; y -= 1)
            {
                for (int x = 0, loopTo4 = imgSignature.Width - 1; x <= loopTo4; x++)
                {
                    // اگر رنگ تشخیص داده شود پس مرز پایینی امضا می باشد
                    if (imgSignature.GetPixel(x, y).ToString() != "Color [A=0, R=0, G=0, B=0]")
                    {
                        // imgBottomPoint = y
                        imgTopPoint = y;                 
                    }
                }
            }

            for (int x = 0, loopTo5 = imgSignature.Width - 1; x <= loopTo5; x++)
            {
                for (int y = 0, loopTo6 = imgSignature.Height - 1; y <= loopTo6; y++)
                {
                    // اگر رنگ تشخیص داده شود پس مرز چپ امضا می باشد
                    if (imgSignature.GetPixel(x, y).ToString() != "Color [A=0, R=0, G=0, B=0]")
                    {
                        // imgLeftPoint = x
                        imgRightPoint = x;
                    }
                }
            }

            for (int x = imgSignature.Width - 1; x >= 0; x -= 1)
            {
                for (int y = 0, loopTo7 = imgSignature.Height - 1; y <= loopTo7; y++)
                {
                    // اگر رنگ تشخیص داده شود پس مرز راست امضا می باشد
                    if (imgSignature.GetPixel(x, y).ToString() != "Color [A=0, R=0, G=0, B=0]")
                    {
                        // imgRightPoint = x
                        imgLeftPoint = x;
                    }
                }
            }

            var imgBoundry =
                new Bitmap(
                    Math.Abs(imgLeftPoint - imgRightPoint),
                    Math.Abs(imgTopPoint - imgBottomPoint));

            Graphics gBoundry = Graphics.FromImage(imgBoundry);

            gBoundry.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            gBoundry.DrawImage(
                imgSignature,
                new Rectangle(0, 0, imgBoundry.Width, imgBoundry.Height),
                new Rectangle(imgLeftPoint, imgTopPoint, imgBoundry.Width, imgBoundry.Height),
                GraphicsUnit.Pixel);

            this.pbFinalImage.Image = imgBoundry;

            sw.Stop();
            this.Text = sw.ElapsedMilliseconds.ToString();
        }

        private void btnClearResult_Click(object sender, EventArgs e)
        {
            pbFinalImage.Image = null;
        }
    }
}