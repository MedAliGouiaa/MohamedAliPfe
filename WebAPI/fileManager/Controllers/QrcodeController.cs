using Aspose.Pdf;
using fileManager.Migrations;
using fileManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace fileManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QrcodeController : ControllerBase
    {
        OfficeDBContext dbContext = new OfficeDBContext();

        [HttpPost]
        public async Task<ActionResult<FileData>> CreateQRCode(FileData Id)
        {
            var url = "http://localhost:48608/FileManager/"+Id;
           
            if (!dbContext.FileData.Any(f => f.Id == Id.Id))
            {
                return NotFound();
            }
            else
            {
                QRCodeGenerator QrGenerator = new QRCodeGenerator();
                QRCodeData QrCodeInfo = QrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
                QRCode QrCode = new QRCode(QrCodeInfo);
                Bitmap QrBitmap = QrCode.GetGraphic(60);
                byte[] BitmapArray = QrBitmap.BitmapToByteArray();
                var stream = new MemoryStream(BitmapArray);
                using System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
                image.Save("wwwroot/imageQrcode/qrimage" + Id.Id + ".png", ImageFormat.Png);  // Or Png
                Document doc = new Document();
                // Add a page to pages collection of document
                Page page = doc.Pages.Add();
                // Load the source image file to Stream object
                MemoryStream outstream = new MemoryStream();
                // Instantiate BitMap object with loaded image stream
                Bitmap b = new Bitmap(stream);

                // Set margins so image will fit, etc.
                page.PageInfo.Margin.Bottom = 0;
                page.PageInfo.Margin.Top = 0;
                page.PageInfo.Margin.Left = 0;
                page.PageInfo.Margin.Right = 0;

                page.CropBox = new Aspose.Pdf.Rectangle(0, 0, 150, 150);
                // Create an image object
                Aspose.Pdf.Image image1 = new Aspose.Pdf.Image();
                // Add the image into paragraphs collection of the section
                page.Paragraphs.Add(image1);
                // Set the image file stream
                image1.ImageStream = stream;

                // Save resultant PDF file
                doc.Save("wwwroot/imageQrcodePdf/qrimage"+Id.Id+".pdf", SaveFormat.Pdf);



                return Ok();
              


            }
           
            
        }
    }
  //Extension method to convert Bitmap to Byte Array
    public static class BitmapExtension
    {
        public static byte[] BitmapToByteArray(this Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
   
}

