using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace diamond;

public class Pdf
{
   public static bool RequestCreatePdf()
   {
      Console.WriteLine("\nDo you wish to create a pdf with the diamond? yes / no");
      var createPdf = Console.ReadLine().ToLower();

      if (createPdf == "sim" || createPdf == "s" || createPdf == "yes" || createPdf == "y" )
      {
         return true;
      }

      return false;
   }
   public static void PdfGenerator(string lastLetter, string diamondPrinted)
   {
      var doc = new Document();
      PdfWriter.GetInstance(doc, new FileStream(@"../pdfs/DiamondWithLetter" + lastLetter + ".pdf", FileMode.Create));
      
      doc.Open();
      doc.Add(new Paragraph("Diamond created with letter " + lastLetter + "\n"));
      doc.Add(new Paragraph(diamondPrinted));
      doc.Close();
      
      Console.WriteLine("\nCreate PDF with success");
   }
}