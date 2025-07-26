namespace Ces.SignatureExtractor
{
    public class Extractor
    {
        public Extractor()
        {
        }

        /// <summary>
        /// استخراج خط امضا از تصویر اسکن شده. امضای اسکن شده نباید قرمز باشد
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="useOriginalColor"></param>
        /// <param name="customColor"></param>
        /// <param name="precision">اگر پس زمینه تصویر کدر بود این مقدار را کاهش دهید</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public System.Drawing.Bitmap Extract(
            string imagePath, 
            bool useOriginalColor = true, 
            System.Drawing.Color? customColor = null, 
            byte precision = 200)
        {
            if (useOriginalColor && !customColor.HasValue)
                throw new ArgumentNullException(nameof(customColor));

            // ایجاد تصویر جدید براساس فایل انتخاب شده توسط کاربر
            using var imgOriginal = new System.Drawing.Bitmap(System.Drawing.Image.FromFile(imagePath));

            // ایجاد تصویر نهایی که قرار است نتیجه در آن ترسیم شود
            // این تصویر خالی است و قرار است رسم روی آن انجام شود
            using var imgSignature = new System.Drawing.Bitmap(imgOriginal.Width, imgOriginal.Height);

            //ابتدا اثر امضا را در تصویر جدید رسم می‌کنیم
            for (int x = 0; x <= (imgOriginal.Width - 1); x++)
            {
                for (int y = 0; y <= imgOriginal.Height - 1; y++)
                {
                    var currentPixelColor = imgOriginal.GetPixel(x, y);

                    //دو خط کد پایینی به کمک چت جی‌پی‌تی تولید شده و کارکرد آن ایجاد لبه‌های
                    //نرم کنار خطوط امضا می باشد که همان مقدار آلفای رنگ است
                    //در جایگزینی رنگ بجای رنگ اصلی باید میزان روشنایی رنگ قبلی محاسبه شود
                    //اگر این متغیر بدست نیاید تمام امضا تک رنگ و با یک شدت خواهد بود که
                    //زیبایی امضا از بین خواهد رفت. بنابراین در زمان جایگزینی رنگ جدید
                    //باید شدت رنگ قبلی به رنگ جدید اعمال شود
                    //float brightness = (currentPixelColor.R + currentPixelColor.G + currentPixelColor.B) / 3f / 255f;
                    float brightness = currentPixelColor.GetBrightness();
                    byte alpha = (byte)(255 * (1.0f - brightness));

                    // ممکن است رنگ خودکار آبی و یا سفید و یا هر رنگ دیگه‌ای باشد
                    // بنابراین با توجه به اینکه نمونه امضا روی کاغذ سفید انجام خواهد شد
                    // بنابراین هر رنگی به غیر از سفید به عنوان داده‌های امضا محسوب خواهد
                    // شد و برنامه آن را به عنوان امضا از زمینه سفید جدا خواهد کرد
                    if (currentPixelColor.R >= 0 & currentPixelColor.R <= precision)
                        imgSignature.SetPixel(x, y,
                            useOriginalColor ?
                            System.Drawing.Color.FromArgb(alpha, currentPixelColor) :
                            System.Drawing.Color.FromArgb(alpha, customColor.Value));
                }
            }

            // حالا که امضا بدست آمد باید حاشیه های اضافه را حذف کرد و بنابراین
            // باید مرز امضا پیدا شود و مجددا امضای بدست آمده در ابعاد مورد نظر
            // رسم شود           
            var imgTopBoundry = 0;
            var imgBottomBoundry = 0;
            var imgLeftBoundry = 0;
            var imgRightBoundry = 0;

            //بدست آوردن مرز بالایی امضا
            for (int y = 0; y <= imgSignature.Height - 1; y++)
            {
                for (int x = 0; x <= imgSignature.Width - 1; x++)
                {
                    // اگر رنگ تشخیص داده شود پس مرز بالایی امضا می باشد
                    if (imgTopBoundry == 0)
                        if (imgSignature.GetPixel(x, y).ToString() != "Color [A=0, R=0, G=0, B=0]")
                            imgTopBoundry = y;

                    // اگر رنگ تشخیص داده شود پس مرز پایینی امضا می باشد
                    if (imgBottomBoundry == 0)
                        if (imgSignature.GetPixel(x, imgSignature.Height - 1 - y).ToString() != "Color [A=0, R=0, G=0, B=0]")
                            imgBottomBoundry = imgSignature.Height - 1 - y;

                    if (imgTopBoundry > 0 && imgBottomBoundry > 0)
                        break;
                }

                if (imgTopBoundry > 0 && imgBottomBoundry > 0)
                    break;
            }

            //بدست آوردن مرز چپ و راست امضا
            for (int x = 0; x <= imgSignature.Width - 1; x++)
            {
                for (int y = 0; y <= imgSignature.Height - 1; y++)
                {
                    // اگر رنگ تشخیص داده شود پس مرز چپ امضا می باشد
                    if (imgLeftBoundry == 0)
                        if (imgSignature.GetPixel(x, y).ToString() != "Color [A=0, R=0, G=0, B=0]")
                            imgLeftBoundry = x;

                    // اگر رنگ تشخیص داده شود پس مرز راست امضا می باشد
                    if (imgRightBoundry == 0)
                        if (imgSignature.GetPixel(imgSignature.Width - 1 - x, y).ToString() != "Color [A=0, R=0, G=0, B=0]")
                            imgRightBoundry = imgSignature.Width - 1 - x;

                    if (imgLeftBoundry > 0 && imgRightBoundry > 0)
                        break;
                }

                if (imgLeftBoundry > 0 && imgRightBoundry > 0)
                    break;
            }

            try
            {
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
            catch (Exception)
            {
                throw;
            }
        }
    }
}
