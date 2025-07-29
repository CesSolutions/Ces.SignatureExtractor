using System.Drawing;
using System.Drawing.Imaging;

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
        //public System.Drawing.Bitmap Extract(
        //    string imagePath,
        //    bool useOriginalColor = true,
        //    System.Drawing.Color? customColor = null,
        //    byte precision = 200)
        //{
        //    if (useOriginalColor && !customColor.HasValue)
        //        throw new ArgumentNullException(nameof(customColor));

        //    // ایجاد تصویر جدید براساس فایل انتخاب شده توسط کاربر
        //    using var imgOriginal = new System.Drawing.Bitmap(System.Drawing.Image.FromFile(imagePath));

        //    // ایجاد تصویر نهایی که قرار است نتیجه در آن ترسیم شود
        //    // این تصویر خالی است و قرار است رسم روی آن انجام شود
        //    using var imgSignature = new System.Drawing.Bitmap(imgOriginal.Width, imgOriginal.Height);

        //    //ابتدا اثر امضا را در تصویر جدید رسم می‌کنیم
        //    for (int x = 0; x <= (imgOriginal.Width - 1); x++)
        //    {
        //        for (int y = 0; y <= imgOriginal.Height - 1; y++)
        //        {
        //            var currentPixelColor = imgOriginal.GetPixel(x, y);

        //            //دو خط کد پایینی به کمک چت جی‌پی‌تی تولید شده و کارکرد آن ایجاد لبه‌های
        //            //نرم کنار خطوط امضا می باشد که همان مقدار آلفای رنگ است
        //            //در جایگزینی رنگ بجای رنگ اصلی باید میزان روشنایی رنگ قبلی محاسبه شود
        //            //اگر این متغیر بدست نیاید تمام امضا تک رنگ و با یک شدت خواهد بود که
        //            //زیبایی امضا از بین خواهد رفت. بنابراین در زمان جایگزینی رنگ جدید
        //            //باید شدت رنگ قبلی به رنگ جدید اعمال شود
        //            float brightness = currentPixelColor.GetBrightness();
        //            byte alpha = (byte)(255 * (1.0f - brightness));

        //            // ممکن است رنگ خودکار آبی و یا سفید و یا هر رنگ دیگه‌ای باشد
        //            // بنابراین با توجه به اینکه نمونه امضا روی کاغذ سفید انجام خواهد شد
        //            // بنابراین هر رنگی به غیر از سفید به عنوان داده‌های امضا محسوب خواهد
        //            // شد و برنامه آن را به عنوان امضا از زمینه سفید جدا خواهد کرد
        //            if (currentPixelColor.R >= 0 & currentPixelColor.R <= precision)
        //                imgSignature.SetPixel(x, y,
        //                    useOriginalColor ?
        //                    System.Drawing.Color.FromArgb(alpha, currentPixelColor) :
        //                    System.Drawing.Color.FromArgb(alpha, customColor.Value));
        //        }
        //    }

        //    // حالا که امضا بدست آمد باید حاشیه های اضافه را حذف کرد و بنابراین
        //    // باید مرز امضا پیدا شود و مجددا امضای بدست آمده در ابعاد مورد نظر
        //    // رسم شود           
        //    var imgTopBoundry = -1;
        //    var imgBottomBoundry = -1;
        //    var imgLeftBoundry = -1;
        //    var imgRightBoundry = -1;

        //    //بدست آوردن مرز بالایی امضا
        //    for (int y = 0; y <= imgSignature.Height - 1; y++)
        //    {
        //        for (int x = 0; x <= imgSignature.Width - 1; x++)
        //        {
        //            var a = imgSignature.GetPixel(x, y);
        //            // اگر رنگ تشخیص داده شود پس مرز بالایی امضا می باشد
        //            if (imgTopBoundry == -1)
        //                if (imgSignature.GetPixel(x, y).R != 0
        //                    && imgSignature.GetPixel(x, y).G != 0
        //                    && imgSignature.GetPixel(x, y).B != 0)
        //                    imgTopBoundry = y;

        //            // اگر رنگ تشخیص داده شود پس مرز پایینی امضا می باشد
        //            if (imgBottomBoundry == -1)
        //                if (imgSignature.GetPixel(x, imgSignature.Height - 1 - y).R != 0
        //                    && imgSignature.GetPixel(x, y).G != 0
        //                    && imgSignature.GetPixel(x, y).B != 0)
        //                    imgBottomBoundry = imgSignature.Height - 1 - y;

        //            if (imgTopBoundry > 0 && imgBottomBoundry > 0)
        //                break;
        //        }

        //        if (imgTopBoundry > 0 && imgBottomBoundry > 0)
        //            break;
        //    }

        //    //بدست آوردن مرز چپ و راست امضا
        //    for (int x = 0; x <= imgSignature.Width - 1; x++)
        //    {
        //        for (int y = 0; y <= imgSignature.Height - 1; y++)
        //        {
        //            // اگر رنگ تشخیص داده شود پس مرز چپ امضا می باشد
        //            if (imgLeftBoundry == -1)
        //                if (imgSignature.GetPixel(x, y).R != 0
        //                    && imgSignature.GetPixel(x, y).G != 0
        //                    && imgSignature.GetPixel(x, y).B != 0)
        //                    imgLeftBoundry = x;

        //            // اگر رنگ تشخیص داده شود پس مرز راست امضا می باشد
        //            if (imgRightBoundry == -1)
        //                if (imgSignature.GetPixel(imgSignature.Width - 1 - x, y).R != 0
        //                    && imgSignature.GetPixel(x, y).G != 0
        //                    && imgSignature.GetPixel(x, y).B != 0)
        //                    imgRightBoundry = imgSignature.Width - 1 - x;

        //            if (imgLeftBoundry > 0 && imgRightBoundry > 0)
        //                break;
        //        }

        //        if (imgLeftBoundry > 0 && imgRightBoundry > 0)
        //            break;
        //    }

        //    try
        //    {
        //        // ایجاد تصویر جدید جهت رسم امضای نهایی
        //        // ابعاد تصویر با توجه به موقعیت های بدست آمده در حلقه ها تعیین خواهد شد            
        //        var imgResultBoundry = new System.Drawing.Bitmap(
        //            imgRightBoundry - imgLeftBoundry,
        //            imgBottomBoundry - imgTopBoundry);

        //        // ایجاد گرافیک جدید جهت رسم امضا
        //        using System.Drawing.Graphics gBoundry = System.Drawing.Graphics.FromImage(imgResultBoundry);
        //        gBoundry.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        //        gBoundry.DrawImage(
        //            imgSignature,
        //            new System.Drawing.Rectangle(0, 0, imgResultBoundry.Width, imgResultBoundry.Height),
        //            new System.Drawing.Rectangle(imgLeftBoundry, imgTopBoundry, imgResultBoundry.Width, imgResultBoundry.Height),
        //            System.Drawing.GraphicsUnit.Pixel);

        //        return imgResultBoundry;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public Bitmap Extract(string imagePath, bool useOriginalColor = true, Color? customColor = null, byte precision = 200)
        {
            if (!useOriginalColor && !customColor.HasValue)
                throw new ArgumentNullException(nameof(customColor));

            using var imgOriginal = new Bitmap(Image.FromFile(imagePath));
            var width = imgOriginal.Width;
            var height = imgOriginal.Height;

            // Final image for drawing extracted signature
            var imgSignature = new Bitmap(width, height, PixelFormat.Format32bppArgb);

            var rect = new Rectangle(0, 0, width, height);

            // Lock both images for direct pixel access
            var bmpDataOriginal = imgOriginal.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            var bmpDataSignature = imgSignature.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            int originalStride = bmpDataOriginal.Stride;
            int signatureStride = bmpDataSignature.Stride;

            unsafe
            {
                byte* ptrOriginal = (byte*)bmpDataOriginal.Scan0;
                byte* ptrSignature = (byte*)bmpDataSignature.Scan0;

                for (int y = 0; y < height; y++)
                {
                    byte* rowOriginal = ptrOriginal + (y * originalStride);
                    byte* rowSignature = ptrSignature + (y * signatureStride);

                    for (int x = 0; x < width; x++)
                    {
                        byte b = rowOriginal[x * 3 + 0];
                        byte g = rowOriginal[x * 3 + 1];
                        byte r = rowOriginal[x * 3 + 2];

                        float brightness = (0.299f * r + 0.587f * g + 0.114f * b) / 255f;
                        byte alpha = (byte)(255 * (1.0f - brightness));

                        // Ignore pixels close to white
                        if (r <= precision && g <= precision && b <= precision)
                        {
                            Color finalColor = useOriginalColor ? Color.FromArgb(r, g, b) : customColor.Value;

                            rowSignature[x * 4 + 0] = finalColor.B;
                            rowSignature[x * 4 + 1] = finalColor.G;
                            rowSignature[x * 4 + 2] = finalColor.R;
                            rowSignature[x * 4 + 3] = alpha; // Alpha
                        }
                        else
                        {
                            // Transparent
                            rowSignature[x * 4 + 0] = 0;
                            rowSignature[x * 4 + 1] = 0;
                            rowSignature[x * 4 + 2] = 0;
                            rowSignature[x * 4 + 3] = 0;
                        }
                    }
                }
            }

            imgOriginal.UnlockBits(bmpDataOriginal);
            imgSignature.UnlockBits(bmpDataSignature);

            // Now crop to signature bounds
            var bounds = GetNonTransparentBounds(imgSignature);
            if (bounds.Width <= 0 || bounds.Height <= 0)
                return new Bitmap(1, 1); // Empty result if nothing found

            var result = new Bitmap(bounds.Width, bounds.Height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.DrawImage(imgSignature, new Rectangle(0, 0, bounds.Width, bounds.Height), bounds, GraphicsUnit.Pixel);
            }

            return result;
        }

        private Rectangle GetNonTransparentBounds(Bitmap bitmap)
        {
            int top = -1, bottom = -1, left = -1, right = -1;

            BitmapData data = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);

            int stride = data.Stride;
            int width = bitmap.Width;
            int height = bitmap.Height;

            unsafe
            {
                byte* ptr = (byte*)data.Scan0;

                // Find top and bottom
                for (int y = 0; y < height; y++)
                {
                    byte* row = ptr + (y * stride);
                    for (int x = 0; x < width; x++)
                    {
                        byte alpha = row[x * 4 + 3];
                        if (alpha != 0)
                        {
                            if (top == -1) top = y;
                            bottom = y;
                            break;
                        }
                    }
                }

                // Find left and right
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        byte* row = ptr + (y * stride);
                        byte alpha = row[x * 4 + 3];
                        if (alpha != 0)
                        {
                            if (left == -1) left = x;
                            right = x;
                            break;
                        }
                    }
                }
            }

            bitmap.UnlockBits(data);

            if (top == -1 || left == -1)
                return Rectangle.Empty;

            return new Rectangle(left, top, right - left + 1, bottom - top + 1);
        }
    }
}
