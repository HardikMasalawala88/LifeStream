using Microsoft.AspNetCore.Mvc;
using QRCoder;




namespace LifeStream.Controllers
{
    public class QRController : Controller
    {

        public IActionResult GenerateQR()
        {
            string qrText = "";//HttpUtility.UrlEncode();
            string qrBase64 = GenerateQRCode(qrText);
            ViewBag.QRCode = qrBase64; // Pass to View
            return View();
        }
        private string GenerateQRCode(string patientId)
        {
            string patientData = $"https://yourserver.com/api/patient?id={patientId}";

            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(patientData, QRCodeGenerator.ECCLevel.Q))
            using (PngByteQRCode qrCode = new PngByteQRCode(qrCodeData))
            {
                byte[] qrCodeImage = qrCode.GetGraphic(20);
                using (MemoryStream ms = new MemoryStream())
                {
                    return "data:image/png;base64," + Convert.ToBase64String(qrCodeImage);
                }
            }
            
            //using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            //{
            //    using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q))
            //    {
            //        QRCode qrCode = new QRCode(qrCodeData); // ✅ No 'using' here

            //        using (Bitmap qrBitmap = qrCode.GetGraphic(10))
            //        {
            //            using (MemoryStream ms = new MemoryStream())
            //            {
            //                qrBitmap.Save(ms, ImageFormat.Png);
            //                byte[] qrBytes = ms.ToArray();
            //                return "data:image/png;base64," + Convert.ToBase64String(qrBytes);
            //            }
            //        }
            //    }
            //}
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
