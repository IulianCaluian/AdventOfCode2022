// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



string[] lines = File.ReadAllLines("input.txt");

int X = 1;

int cycle = 0;
int iSig = 0;

foreach (string line in lines)
{
    string[] parts = line.Split(' ');
    string op = parts[0];

    if (op == "noop")
    {
        cycle++;
         CheckIfInterestingSignal(cycle, X);

    } else if (op == "addx")
    {
        cycle++;
        CheckIfInterestingSignal(cycle, X);
        cycle++;
        X += Int32.Parse(parts[1]);
        CheckIfInterestingSignal(cycle, X);

    }

}


int CheckIfInterestingSignal(int c, int x)
{
    int sig = 0;

    if ((c - 20) % 40 == 0)
        sig =  c * x;

    Console.WriteLine(x);
    Console.WriteLine($"{c} - {sig}");

    return sig;
}