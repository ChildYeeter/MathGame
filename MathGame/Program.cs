Console.Title = "Math Game";

Game game = new Game();
while (true)
{
    game.Start();
    if(game.choice is Quit)
    {
        Console.WriteLine("Press any key to quit!");
        Console.ReadKey(true);
        break;
    }
}
public class Game
{
    public int score = 0;
    public List<int> history = new List<int>();
    public MathOperations? choice;

    public void Start()
    {
        Console.WriteLine("Welcome!! What would you like to do?");
        Console.WriteLine("A - Addition\nS - Subtraction\nD - Division\nM - Multiplication\n\nH - View History\nQ - Quit");
        choice = Console.ReadLine()?.ToLower() switch
        {
            "a" => new Addition(),
            "s" => new Subtraction(),
            "m" => new Multiplication(),
            "d" => new Division(),
            "q" => new Quit(),
            "h" => new History(),
            _   => new Addition()
        };

        if (choice is Quit)
        {
            choice.Operation(this);
            return;
        }
        else if(choice is History)
        {
            choice.Operation(this);
            return;
        }
        else 
        {
            score = 0;
            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                choice.Operation(this);
            }
            history.Add(this.score);
        }

        Console.WriteLine("Score: " + this.score);
    }
}
public abstract class MathOperations
{
    public static Random rnd = new Random();
    public abstract void Operation(Game game);
}

public class Addition : MathOperations
{
    public override void Operation(Game game)
    {
        int num1 = rnd.Next(1, 10);
        int num2 = rnd.Next(1, 10);

        Console.WriteLine($"{num1} + {num2} = ?");
        int answer = Convert.ToInt32(Console.ReadLine());
        if(answer == num1 + num2)
        {
            game.score++;
        }
        
    }
}

public class Multiplication : MathOperations
{
    public override void Operation(Game game)
    {
        int num1 = rnd.Next(1, 10);
        int num2 = rnd.Next(1, 10);

        Console.WriteLine($"{num1} x {num2} = ?");
        int answer = Convert.ToInt32(Console.ReadLine());
        if (answer == num1 * num2)
        {
            game.score++;
        }

    }
}
public class Subtraction : MathOperations
{
    public override void Operation(Game game)
    {
        int num1 = rnd.Next(1, 10);
        int num2 = rnd.Next(1, 10);

        Console.WriteLine($"{num1} - {num2} = ?");
        int answer = Convert.ToInt32(Console.ReadLine());
        if (answer == num1 - num2)
        {
            game.score++;
        }

    }
}
public class Division : MathOperations
{
    public override void Operation(Game game)
    {
        int answer = rnd.Next(1, 11);
        int divisor = rnd.Next(1, 11);

        int dividend = answer * divisor;

        Console.WriteLine($"{dividend} / {divisor} = ?");
        int userAnswer = Convert.ToInt32(Console.ReadLine());

        if (userAnswer == answer)
        {
            game.score++;
        }
    }
}

public class Quit : MathOperations
{
    public override void Operation(Game game) { } 
}

public class History : MathOperations
{
    public override void Operation(Game game)
    {

        Console.Clear();
        Console.WriteLine("History:");
        Console.WriteLine("-------------------------------------------------------");
        foreach (int item in game.history)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("-------------------------------------------------------");
    }
}