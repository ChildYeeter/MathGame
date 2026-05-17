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
        Console.WriteLine("A - Addition\nS - Subtraction\nD - Division\nM - Multiplication\nQ - Quit");
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
public interface MathOperations
{
    public void Operation(Game game);
}

public class Addition : MathOperations
{
    public void Operation(Game game)
    {
        Random rnd = new Random();
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
    public void Operation(Game game)
    {
        Random rnd = new Random();
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
    public void Operation(Game game)
    {
        Random rnd = new Random();
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
    public void Operation(Game game)
    {
        Random rnd = new Random();
        int num1 = rnd.Next(0, 100)*2;
        int num2 = rnd.Next(1,10)/2;

        Console.WriteLine($"{num1}/{num2} = ?");
        int answer = Convert.ToInt32(Console.ReadLine());
        if (answer == num1 / num2)
        {
            game.score++;
        }

    }
}

public class Quit : MathOperations
{
    public void Operation(Game game) { } 
}

public class History : MathOperations
{
    public void Operation(Game game)
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