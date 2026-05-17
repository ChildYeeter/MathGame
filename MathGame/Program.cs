Console.Title = "Math Game";

while (true)
{
    Game test = new Game();
    test.Start();
}

public class Game
{
    public int score = 0;
    public List<int> results { get; set; } = new List<int>();

    public void Start()
    {
        Console.WriteLine("Welcome!! What game would you like to play?");
        Console.WriteLine("1)Addition\n2)Subtraction\n3)Division\n4)Multiplication\n5)View History");

        MathOperations choice = Console.ReadLine()?.ToLower() switch
        {
            "addition" or "1"       => new Addition(),
            "subtraction" or "2"    => new Subtraction(),
            "division" or "3"       => new Division(),
            "multiplication" or "4" => new Multiplication(),
            "view history" or "5"   => new History(),
            _                       => new Addition()
        };

        choice.Operation(this);
    }
}
public interface MathOperations
{
   public void Operation(Game game);
}

public class Addition : MathOperations
{
    Random rnd = new Random();
    public void Operation(Game game)
    {
        for (int i = 0; i < 5; i++)
        {
            int num1 = rnd.Next(1, 100);
            int num2 = rnd.Next(1, 100);

            Console.WriteLine($"{num1} + {num2} = ?");
            int answer = Convert.ToInt32(Console.ReadLine());

            if (answer == num1 + num2)
            {
                Console.WriteLine("Correct!");
                game.score += 1;
            }
            else
                Console.WriteLine("Wrong!");
        }

        game.results.Add(game.score);
    }
}

public class Subtraction : MathOperations
{
    Random rnd = new Random();
    public void Operation(Game game)
    {
        for (int i = 0; i < 5; i++)
        {
            int num1 = rnd.Next(1, 100);
            int num2 = rnd.Next(1, 100);

            Console.WriteLine($"{num1} - {num2} = ?");
            int answer = Convert.ToInt32(Console.ReadLine());

            if (answer == num1 - num2)
            {
                Console.WriteLine("Correct!");
                game.score += 1;
            }
            else
                Console.WriteLine("Wrong!");
        }
        game.results.Add(game.score);
    }
}


//needs working
public class Division : MathOperations
{
    Random rnd = new Random();
    public void Operation(Game game)
    {
        for (int i = 0; i < 5; i++)
        {
            int num1 = rnd.Next(0, 100)%2;
            int num2 = rnd.Next(1, 10)%2;

            Console.WriteLine($"{num1}/{num2} = ?");
            int answer = Convert.ToInt32(Console.ReadLine());

            if (answer == num1/num2)
            {
                Console.WriteLine("Correct!");
                game.score += 1;
            }
            else
                Console.WriteLine("Wrong!");
        }
        game.results.Add(game.score);
    }
}

public class Multiplication : MathOperations
{
    Random rnd = new Random();
    public void Operation(Game game)
    {
        for (int i = 0; i < 5; i++)
        {
            int num1 = rnd.Next(1, 100);
            int num2 = rnd.Next(1, 100);

            Console.WriteLine($"{num1} x {num2} = ?");
            int answer = Convert.ToInt32(Console.ReadLine());

            if (answer == num1 * num2)
            {
                Console.WriteLine("Correct!");
                game.score += 1;
            }
            else
                Console.WriteLine("Wrong!");
        }
        game.results.Add(game.score);
    }
}

public class History : MathOperations
{
    public void Operation( Game game)
    {
        foreach(int item in game.results)
        {
            int i = 1;
            Console.WriteLine($"{i}){item}");
        }
    }
}