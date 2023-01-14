using System.Net;
using System.Text.RegularExpressions;
using EASendMail;
namespace diamond
{
  public static class Email
  {
    public static bool RequestSendAnEmail()
    {
      Console.WriteLine("\nDo you wish to send the diamond by e-mail? yes / no");
      var sendEmail = Console.ReadLine().ToLower();

      if (sendEmail == "sim" || sendEmail == "s" || sendEmail == "yes" || sendEmail == "y" )
      {
        return true;
      }
      
      return false;
    }
    public static string GetEmailToSend()
    {
      Console.WriteLine("Enter the email to send it to.");
      while (true)
      {
        var email = Console.ReadLine().ToLower();
        try
        {
          if(Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
          {
            return email;
          }
          else Console.WriteLine("Invalid Email, try again.");
        }
        catch (System.Exception)
        {
          Console.WriteLine("Invalid Email, try again.");
        }
      }
    }

    public static void SendEmail(string letter, string diamond)
    {
      SmtpMail oMail = new SmtpMail("TryIt");
      var from = "felipetest753159@outlook.com";
      oMail.From = from;
      oMail.To = GetEmailToSend();
      oMail.Subject = "Diamon From A To " + letter + ":\n";
      oMail.TextBody = diamond;
      
      SmtpServer oServer = new SmtpServer("smtp.office365.com");

      oServer.User = from;
      oServer.Password = "f82018629171";
      oServer.Port = 587;

      oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

      try
      {
          Console.WriteLine("Sending Email...");

          SmtpClient oSmtp = new SmtpClient();
          oSmtp.SendMail(oServer, oMail);

          Console.WriteLine("Email delivered");
      }
      catch (Exception ex)
      {
          Console.WriteLine("Exception caught in SendEmail(): {0}",
              ex.ToString());
      }
    }
  }
}