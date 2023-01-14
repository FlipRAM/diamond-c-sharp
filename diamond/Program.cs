namespace diamond {

    public class Program
    {
        public static void Main()
        {
          var diamond = new Diamond();
          var lastLetter = diamond.ReceiveInput();
          var diamondPrinted = diamond.PrintToConsole();
          if (Email.RequestSendAnEmail())
          {
              Email.SendEmail(lastLetter, diamondPrinted);
          }

          if (Pdf.RequestCreatePdf())
          {
              Pdf.PdfGenerator(lastLetter, diamondPrinted);
          }
        }

    }

}