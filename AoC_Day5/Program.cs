// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string[] lines = File.ReadAllLines("input.txt");

int score = 0;

List<Stack<char>> stacks = new List<Stack<char>>();
for (int i = 0; i <= 9; i++)
{
    stacks.Add(new Stack<char>());
}

for (int i = 7; i >= 0; i--)
{
    var line = lines[i];

    for (int j = 9; j >= 1; j-- )
    {
        char c = line[1 + (j - 1) * 4];

        if (c != ' ')
            stacks[j].Push(c);
    }
}

for (int i = 1; i <= 9; i++)
{
    ShowStack(stacks[i]);
    Console.WriteLine();
}

static void ShowStack(Stack<char> stc)
{
    foreach(var c in  stc.ToList())
    {
        Console.Write(c + " ");
    }
}




for (int i = 10; i < lines.Count(); i++)
{
    string[] parts = lines[i].Split(' ');
    int count = Int32.Parse(parts[1]);
    int from = Int32.Parse(parts[3]);
    int to = Int32.Parse(parts[5]);

    for (int j = 0; j < count; j++)
    {
        char pop = stacks[from].Pop();
        stacks[to].Push(pop);

    }

     
}
Console.WriteLine();

for (int i = 1; i <= 9; i++)
{
    Console.Write(stacks[i].Pop());
}