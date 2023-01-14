using System;
namespace diamond {

  public class Diamond
  {
      public char LastLetter { get;  set;}

      public string ReceiveInput()
      {
        while (true)
        {
            Console.WriteLine("Enter a letter greater or equal to C:");
            var letter = Console.ReadLine();
            
            if (letter is null || letter.Length != 1) continue;

            LastLetter = Char.Parse(letter.ToUpper());

            if (!Char.IsLetter(LastLetter) || (int)LastLetter < 67 ) continue;

            return LastLetter.ToString();
        }
      }

      public string PrintToConsole()
      {
          int middle = 1;
          var resultString = new String[(LastLetter - 'A' + 1) * 2 - 1];

          for (int i = 0; i <= LastLetter - 'A'; i++)
          {
            var space = new String[5];

            space[0] = "".PadLeft(LastLetter - 'A' - i, ' ');
            space[1] = Convert.ToChar('A' + i).ToString();
            if (i != 0)
            {
              space[2] = "".PadLeft(middle, ' ');
              middle += 2;
              space[3] = Convert.ToChar('A' + i).ToString();
            }
            space[4] = "".PadLeft(LastLetter - 'A' - i, ' ');

            resultString[i] = String.Join("", space) + "\n";
            resultString[(LastLetter - 'A' + 1) * 2 - 2 - i] = String.Join("", space) + "\n";
          }

          var diamondReturn = String.Join("", resultString);
          Console.WriteLine(diamondReturn);

          return diamondReturn;
      }

  }

}

