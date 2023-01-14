using Xunit;
using System.IO;
using System;
using FluentAssertions;
using diamond;

namespace diamond.Test;

public class TestMakeDiamond
{

    [Theory(DisplayName = "Test if ReceiveInput() prints correctly.")]
    [InlineData("c\n", "Enter a letter greater or equal to C:", 1)]
    [InlineData("C\n", "Enter a letter greater or equal to C:", 1)]
    [InlineData(".\na\nc\n", "Enter a letter greater or equal to C:", 3)]
    public void TestGetLetter(string entry, string stringExpected, int linesCountExpected )
    {
        using (var stringWriter = new StringWriter())
        {
            using (var stringReader = new StringReader(entry))
            {
                Console.SetOut(stringWriter); 
                Console.SetIn(stringReader);
                var diamond = new Diamond();
                var response = diamond.ReceiveInput();
                var consoleResponse = stringWriter.ToString().Trim().Split('\n');  
                var countLinesResponse = stringWriter.ToString().Trim().Split('\n').Length;  

                consoleResponse[0].Should().Be(stringExpected);
                countLinesResponse.Should().Be(linesCountExpected);

                stringReader.Close();
            }

            stringWriter.Close();
        }
    }
    
    [Theory(DisplayName = "Tests if generates the correct diamond.")]
    [InlineData('C', "  A  \n B B \nC   C\n B B \n  A  \n", 5)]
    [InlineData('D', "   A   \n  B B  \n C   C \nD     D\n C   C \n  B B  \n   A   \n", 7)]
    [InlineData('E', "    A    \n   B B   \n  C   C  \n D     D \nE       E\n D     D \n  C   C  \n   B B   \n    A    \n", 9)]
    public void TestPrintDiamond(char letter, string diamondCorrect, int linesCountExpected )
    {
        using (var stringWriter = new StringWriter())
        {
            Console.SetOut(stringWriter); 
            var diamond = new Diamond();
            diamond.LastLetter = letter;
            var response = diamond.PrintToConsole();
            var countLinesResponse = stringWriter.ToString().Trim().Split('\n').Length;

            Console.WriteLine(stringWriter.ToString().Trim().Split('\n'));

            response.Should().Be(diamondCorrect);
            countLinesResponse.Should().Be(linesCountExpected);   

            stringWriter.Close();  
        }
    }
}