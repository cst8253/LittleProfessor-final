bool isActive = true;
var random = new Random();

while (isActive) 
{
  Console.WriteLine("\nLet's play a game. Answer the following questions.");
  int questions = 0;
  int firstTry = 0;
  int secondTry = 0;
  int thirdTry = 0;

  while (questions < 5)
  {
    int number1 = random.Next(0, 11);
    int number2 = random.Next(0, 11);
    int tries = 0;
    int answer;
    questions++;
    
    do 
    {
      Console.Write($"\nQuestion {questions}: {number1} + {number2} = ");
      bool isValid = int.TryParse(Console.ReadLine(), out answer);

      if (isValid) 
      {
        tries++;

        if (answer == number1 + number2)
        {
          Console.WriteLine("Correct!");

          switch (tries)
          {
            case 1:
              firstTry++;
              break;
            case 2: 
              secondTry++;
              break;
            case 3:
              thirdTry++;
              break;
          }
        }
        else
        {
          Console.WriteLine("Incorrect.");

          if (tries == 3) {
            Console.WriteLine($"\nYou are out of tries. The correct answer was {number1 + number2}.");
          }
        }
      }
      else
      {
        Console.WriteLine("\nNot a valid response. Try Again.");
      } 
    } while (tries < 3 && answer != number1 + number2); 
  } 

  Console.WriteLine("\nYou have completed the game.");
  Console.WriteLine($"Questions answered on the first try: \t{firstTry}");
  Console.WriteLine($"Questions answered on the second try: \t{secondTry}");
  Console.WriteLine($"Questions answered on the third try: \t{thirdTry}");
  Console.WriteLine($"Total questions answered: \t\t{firstTry + secondTry + thirdTry} out of {questions}");

  Console.Write("\nWould you like to play again? (Y/y) ");
  string? response = Console.ReadLine();

  if (!string.IsNullOrEmpty(response) && response.ToLower() != "y") {
    isActive = false;
    Console.WriteLine("\nGoodbye.");
  }
}