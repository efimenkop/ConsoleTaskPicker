var options = GetOptions();

Console.WriteLine("Choose option:");

foreach (var option in options)
{
    Console.WriteLine(option.Title);
}

var selectedOptions = new HashSet<int>();

while (true)
{
    var key = Console.ReadKey();

    if (key.Key == ConsoleKey.E)
    {
        break;
    }

    Console.ReadLine();

    if (!int.TryParse(key.KeyChar.ToString(), out var selectedOption)
        || selectedOption < 0
        || selectedOption >= options.Length)
    {
        Console.WriteLine("\r\nIncorrect option!");
        continue;
    }

    selectedOptions.Add(selectedOption);
    Console.WriteLine($"\r\nOptions chosen: {string.Join(", ", selectedOptions.OrderBy(x => x))}. Press \"E\" to start");
}

Console.WriteLine("\r\nResults:");

if (selectedOptions.Count == 0)
{
    Console.WriteLine("\r\nNothing to execute!");
    return;
}

foreach (var selectedOption in selectedOptions.OrderBy(x => x))
{
    options[selectedOption].Execute();
}

Script[] GetOptions() =>
    new Script[]
    {
        new ("0. Do stuff" , () => Console.WriteLine("Execute script #0")),
        new("1. Do another stuff", () => Console.WriteLine("Execute script #1") ),
        new("2. Do something else", () => Console.WriteLine("Execute script #2") ),
        new("3. Do fancy thing", () => Console.WriteLine("Execute script #3") ),
    };

Console.WriteLine("\r\nGood bye!");

internal record Script(string Title, Action Execute);