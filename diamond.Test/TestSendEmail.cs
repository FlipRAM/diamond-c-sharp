using Xunit;
using System.IO;
using System;
using FluentAssertions;

namespace diamond.Test;

public class TestEmail
{
    [Theory(DisplayName = "Test if asks to send an email and if return correct")]
    [InlineData("Sim\n", true, "Do you wish to send the diamond by e-mail? yes / no")]
    [InlineData("S\n", true, "Do you wish to send the diamond by e-mail? yes / no")]
    [InlineData("Yes\n", true, "Do you wish to send the diamond by e-mail? yes / no")]
    [InlineData("y\n", true, "Do you wish to send the diamond by e-mail? yes / no")]
    [InlineData("Não\n", false, "Do you wish to send the diamond by e-mail? yes / no")]
    [InlineData("n\n", false, "Do you wish to send the diamond by e-mail? yes / no")]
    [InlineData("x", false, "Do you wish to send the diamond by e-mail? yes / no")]
    [InlineData("/", false, "Do you wish to send the diamond by e-mail? yes / no")]
    public void TestWantToSendAnEmail(string entry, bool boolExpected, string stringExpected)
    {
        using (var stringWriter = new StringWriter())
        {
            using (var stringReader = new StringReader(entry))
            {
                Console.SetOut(stringWriter); 
                Console.SetIn(stringReader);
                // Email.RequestSendAnEmail();
                
                Email.RequestSendAnEmail().Should().Be(boolExpected);
                var consoleResponse = stringWriter.ToString().Trim().Split('\n');
                consoleResponse[0].Should().Be(stringExpected);

                stringReader.Close();
            }

          stringWriter.Close();
        }
    }
    
    [Theory(DisplayName = "Test if the email is correctly formated")]
    [InlineData("felipetest753159@outlook.com", "Enter the email to send it to.")]
    public void TestGetEmailToSendSuccess(string entry, string stringExpected)
    {
        using (var stringWriter = new StringWriter())
        {
            using (var stringReader = new StringReader(entry))
            {
                Console.SetOut(stringWriter); 
                Console.SetIn(stringReader);
                var response = Email.GetEmailToSend();
                var consoleResponse = stringWriter.ToString().Trim().Split('\n');
                
                response.Should().Be(entry);
                consoleResponse[0].Should().Be(stringExpected);

                stringReader.Close();
            }

            stringWriter.Close();
        }
    }
    
    [Theory(DisplayName = "Tests if email is formated wrong")]
    [InlineData("@gmail.com\nfelipetest753159", "felipetest753159", "Enter the email to send it to.", "Invalid Email, try again.")]
    [InlineData("xz@.com\nfelipetest753159", "felipetest753159", "Enter the email to send it to.", "Invalid Email, try again.")]
    [InlineData("xz@gmail.\nfelipetest753159", "felipetest753159", "Enter the email to send it to.", "Invalid Email, try again.")]
    [InlineData("@\nfelipetest753159", "felipetest753159", "Enter the email to send it to.", "Invalid Email, try again.")]
    public void TestGetEmailToSendFail(string emailEntry, string emailExpected, string stringInitialExpected, string stringFinalExpected)
    {
        using (var stringWriter = new StringWriter())
        {
            using (var stringReader = new StringReader(emailEntry))
            {
                Console.SetOut(stringWriter); 
                Console.SetIn(stringReader);
                var response = Email.GetEmailToSend();
                var consoleResponse = stringWriter.ToString().Trim().Split('\n');
                
                response.Should().Be(emailExpected);
                consoleResponse[0].Should().Be(stringInitialExpected);
                consoleResponse[1].Should().Be(stringFinalExpected);

                stringReader.Close();
            }
          stringWriter.Close();
        }
    }
    
    [Theory(DisplayName = "Tests function send")]
    [InlineData(
        "D", 
        "   A   \n  B B  \n C   C \nD     D\n C   C \n  B B  \n   A   \n",
        "feliperangel97@outlook.com", 
        "Sending Email...")]
    public void TestSendEmail(
        string lastLetter,
        string diamondPrinted,
        string entry,
        string responseExpected)
    {
        using (var stringWriter = new StringWriter())
        {
            using (var stringReader = new StringReader(entry))
            {
                Console.SetOut(stringWriter); 
                Console.SetIn(stringReader);
                Email.SendEmail(lastLetter, diamondPrinted);
                var consoleResponse = stringWriter.ToString().Trim().Split('\n');
                
                consoleResponse[1].Should().Be(responseExpected);

                stringReader.Close();
            }
          stringWriter.Close();
        }
    }
}