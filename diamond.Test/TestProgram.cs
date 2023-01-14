using Xunit;
using System.IO;
using System;
using FluentAssertions;

namespace diamond.Test;

public class TestProgram
{
    [Theory(DisplayName = "Test if passing letter D, generate the amount of rows.")]
    [InlineData("d\nno\nno\n", 13)]
    // A linha abaixo somente pode ser execultada de estiver coom e-mail válido para envio.
    // ressalto que a Microsoft tem suspendido o e-mail depois de alguns envios.
    // [InlineData("d\nSim\nimarmende@gmail.com\nNão\n", 21)] 
    [InlineData("d\nno\nyes\n", 15)]
    public void TestConsoleIntefaceCountLines(string comandEntry, int linesCountExpected )
    {
        using (var stringWriter = new StringWriter())
        {
            using (var stringReader = new StringReader(comandEntry))
            {
                Console.SetOut(stringWriter); 
                Console.SetIn(stringReader); 
                Program.Main();
                var consoleResponse = stringWriter.ToString().Trim().Split('\n').Length;  
                consoleResponse.Should().Be(linesCountExpected);     
            }
        }
    }
}