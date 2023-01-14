using Xunit;
using System.IO;
using System;
using FluentAssertions;

namespace diamond.Test;

public class TestPdfCreator
{
    [Theory(DisplayName = "Tests if asks about create the pdf and returns correct bool")]
    [InlineData("Sim\n", true, "Do you wish to create a pdf with the diamond? yes / no")]
    [InlineData("S\n", true, "Do you wish to create a pdf with the diamond? yes / no")]
    [InlineData("Yes\n", true, "Do you wish to create a pdf with the diamond? yes / no")]
    [InlineData("y\n", true, "Do you wish to create a pdf with the diamond? yes / no")]
    [InlineData("Não\n", false, "Do you wish to create a pdf with the diamond? yes / no")]
    [InlineData("n\n", false, "Do you wish to create a pdf with the diamond? yes / no")]
    [InlineData("x", false, "Do you wish to create a pdf with the diamond? yes / no")]
    [InlineData("/", false, "Do you wish to create a pdf with the diamond? yes / no")]
    public void TestWantToSendAnEmail(string entry, bool expected, string stringExpected)
    {
        using (var stringWriter = new StringWriter())
        {
            using (var stringReader = new StringReader(entry))
            {
                Console.SetOut(stringWriter); 
                Console.SetIn(stringReader);
                var response = Pdf.RequestCreatePdf();
                var consoleResponse = stringWriter.ToString().Trim().Split('\n');
                
                response.Should().Be(expected);
                consoleResponse[0].Should().Be(stringExpected);

            }
        }
    }
    
    [Theory(DisplayName = "Testa se o PDF foi criado com sucesso.")]
    [InlineData("C", 
        "  A  \n B B \nC   C\n B B \n  A  \n", 
        "Create PDF with success")]
    public void TestPdfGenerator(
        string lastLetter,
        string diamondPrinted,
        string stringExpected)
    {
        using (var stringWriter = new StringWriter())
        {
            Console.SetOut(stringWriter); 
            Pdf.PdfGenerator(lastLetter, diamondPrinted);
            var consoleResponse = stringWriter.ToString().Trim().Split('\n');
            
            consoleResponse[0].Should().Be(stringExpected);
        }
    }
}