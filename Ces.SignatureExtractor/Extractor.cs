namespace Ces.SignatureExtractor
{
    public class Extractor
    {
        public Extractor()
        {
        }

        public System.Drawing.Bitmap Extract(string imagePath, bool useOriginalColor = true, System.Drawing.Color? customColor = null)
        {
            if (useOriginalColor && !customColor.HasValue)
                throw new ArgumentNullException(nameof(customColor));

            // ایجاد تصویر جدید براساس فایل انتخاب شده توسط کاربر
            var imgOriginal = new System.Drawing.Bitmap(System.Drawing.Image.FromFile(imagePath));

            // ایجاد تصویر نهایی که قرار است نتیجه در آن ترسیم شود
            // این تصویر خالی است و قرار است رسم روی آن انجام شود
            var imgSignature = new System.Drawing.Bitmap(imgOriginal.Width, imgOriginal.Height);

            // بدلیل آنکه استخراج تصویر با بررسی رنگ پیکسل‌های تصویر انجام می شود
            // بنابراین یک متغیر جهت نگهداری رنگ هر پیکسل تعریف میکنیم
            System.Drawing.Color currentPixelColor = default;

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
                        imgSignature.SetPixel(x, y, useOriginalColor ? currentPixelColor : customColor.Value);
                }
            }

            // حالا که امضا بدست آمد باید حاشیه های اضافه را حذف کرد و بنابراین
            // باید مرز امضا پیدا شود و مجددا امضای بدست آمده در ابعاد مورد نظر
            // رسم شود           
            var imgTopBoundry = 0;
            var imgBottomBoundry = 0;
            var imgLeftBoundry = 0;
            var imgRightBoundry = 0;

            // مقدار متغیر جهت خروج از حلقه استفاده خواهد شد
            bool pointFound = false;

            for (int y = 0; y <= imgSignature.Height - 1; y++)
            {
                for (int x = 0; x <= imgSignature.Width - 1; x++)
                {
                    // اگر رنگ تشخیص داده شود پس مرز بالایی امضا می باشد
                    if (imgSignature.GetPixel(x, y).ToString() != "Color [A=0, R=0, G=0, B=0]")
                    {
                        imgTopBoundry = y;
                        pointFound = true;
                        break;
                    }
                }

                if (pointFound)
                    break;
            }

            pointFound = false;

            for (int y = imgSignature.Height - 1; y >= 0; y -= 1)
            {
                for (int x = 0; x <= imgSignature.Width - 1; x++)
                {
                    // اگر رنگ تشخیص داده شود پس مرز پایینی امضا می باشد
                    if (imgSignature.GetPixel(x, y).ToString() != "Color [A=0, R=0, G=0, B=0]")
                    {
                        imgBottomBoundry = y;
                        pointFound = true;
                        break;
                    }
                }

                if (pointFound)
                    break;
            }

            pointFound = false;

            for (int x = 0; x <= imgSignature.Width - 1; x++)
            {
                for (int y = 0; y <= imgSignature.Height - 1; y++)
                {
                    // اگر رنگ تشخیص داده شود پس مرز چپ امضا می باشد
                    if (imgSignature.GetPixel(x, y).ToString() != "Color [A=0, R=0, G=0, B=0]")
                    {
                        imgLeftBoundry = x;
                        pointFound = true;
                        break;
                    }
                }

                if (pointFound)
                    break;
            }

            pointFound = false;

            for (int x = imgSignature.Width - 1; x >= 0; x -= 1)
            {
                for (int y = 0; y <= imgSignature.Height - 1; y++)
                {
                    // اگر رنگ تشخیص داده شود پس مرز راست امضا می باشد
                    if (imgSignature.GetPixel(x, y).ToString() != "Color [A=0, R=0, G=0, B=0]")
                    {
                        imgRightBoundry = x;
                        pointFound = true;
                        break;
                    }
                }

                if (pointFound)
                    break;
            }

            // ایجاد تصویر جدید جهت رسم امضای نهایی
            // ابعاد تصویر با توجه به موقعیت های بدست آمده در حلقه ها تعیین خواهد شد
            var imgResultBoundry = new System.Drawing.Bitmap(
                imgRightBoundry - imgLeftBoundry,
                imgBottomBoundry - imgTopBoundry);

            // ایجاد گرافیک جدید جهت رسم امضا
            using System.Drawing.Graphics gBoundry = System.Drawing.Graphics.FromImage(imgResultBoundry);

            gBoundry.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            gBoundry.DrawImage(
                imgSignature,
                new System.Drawing.Rectangle(0, 0, imgResultBoundry.Width, imgResultBoundry.Height),
                new System.Drawing.Rectangle(imgLeftBoundry, imgTopBoundry, imgResultBoundry.Width, imgResultBoundry.Height),
                System.Drawing.GraphicsUnit.Pixel);

            return imgResultBoundry;
        }
    }
}
