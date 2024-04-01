using PastExamsHub.Base.Domain.Common;
using PastExamsHub.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Domain.Entities
{
    public class File : DomainEntity
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public FileType Type { get; set; }
        public bool IsSolution { get; set; }

        public File()
        {
            Uid = Guid.NewGuid().ToString();
        }
        // Method to save the document
        public void SaveDocument(string fileName, string filePath, FileType contentType)
        {
            FileName = fileName;
            FilePath = filePath;
            Type = contentType;
        }

        // Method to render the document as a PDF
        public byte[] RenderAsPDF()
        {
            // You might need to use additional libraries like iTextSharp or PdfSharp for PDF conversion
            // This is a basic example assuming conversion logic exists.
            // For example, using iTextSharp:

            // Convert Content byte array to PDF bytes
            // This is a placeholder, you'd need to implement your specific PDF generation logic here
            // For example:
            /*
            using (MemoryStream ms = new MemoryStream())
            {
                // Assuming Content is a valid PDF file
                // Replace this with actual PDF conversion logic
                var pdf = new iTextSharp.text.Document();
                iTextSharp.text.pdf.PdfWriter.GetInstance(pdf, ms);
                pdf.Open();
                pdf.Add(new iTextSharp.text.Paragraph("Sample PDF content")); // Replace this with your content
                pdf.Close();

                return ms.ToArray();
            }
            */

            // This method needs to be implemented based on the PDF library you choose.
            throw new NotImplementedException("PDF rendering logic needs implementation.");
        }

        // Method to display an image
        //public string GetImageSrc()
        //{
            // For displaying images in HTML, you can convert the byte array to a base64 string
            // This assumes Content contains the bytes of an image file

        //    string base64 = Convert.ToBase64String(Content);
        //    return string.Format("data:{0};base64,{1}", ContentType, base64);
        //}
    }
}
