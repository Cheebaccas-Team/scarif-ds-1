namespace Scarif_DS_1
{
    public class EditMod
    {
        /*
         
         
          public void WatermarkFile(string filePath, string filename, string watermark) {
                     //Coloca como marca de água no ficheiro indicado o texto passado em watermark
                     Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                     XFont font = new XFont("Arial", 24);
                     
                     // Open the file
                     PdfDocument inputDocument = PdfReader.Open(Path.Combine(filePath, filename), PdfDocumentOpenMode.Modify);
         
                     //For each Page in document
                     for (int idx = 0; idx < inputDocument.PageCount; idx++) {
         
                         PdfPage page = inputDocument.Pages[idx];
                         // Variation 1: Draw a watermark as a text string.
         
                         // Get an XGraphics object for drawing beneath the existing content.
                         var gfx = XGraphics.FromPdfPage(page, XGraphicsPdfPageOptions.Prepend);
         
                         // Get the size (in points) of the text.
                         var size = gfx.MeasureString(watermark, font);
         
                         // Define a rotation transformation at the center of the page.
                         gfx.TranslateTransform(page.Width / 2, page.Height / 2);
                         gfx.RotateTransform(-Math.Atan(page.Height / page.Width) * 180 / Math.PI);
                         gfx.TranslateTransform(-page.Width / 2, -page.Height / 2);
         
                         // Create a string format.
                         var format = new XStringFormat();
                         format.Alignment = XStringAlignment.Near;
                         format.LineAlignment = XLineAlignment.Near;
         
                         // Create a dimmed red brush.
                         XBrush brush = new XSolidBrush(XColor.FromArgb(128, 255, 0, 0));
         
                         // Draw the string.
                         gfx.DrawString(watermark, font, brush,
                             new XPoint((page.Width - size.Width) / 2, (page.Height - size.Height) / 2),
                             format);
                     }
                     inputDocument.Save(Path.Combine(filePath, filename));
                         
                 }
     }
     */
    }
}