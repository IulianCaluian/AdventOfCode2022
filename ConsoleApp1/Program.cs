// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



string[] lines = File.ReadAllLines("input.txt");

int X = 1;

int cycle = 0;
int iSig = 0;

int rez = 0;
char[,] crt = new char[6, 40];

foreach (string line in lines)
{
    string[] parts = line.Split(' ');
    string op = parts[0];

    if (op == "noop")
    {
        cycle++;
        iSig = CheckIfInterestingSignal(cycle, X);
        rez += iSig;
    }
    else if (op == "addx")
    {
        cycle++;
        iSig = CheckIfInterestingSignal(cycle, X);
        rez += iSig;
        cycle++;
        
   
        iSig = CheckIfInterestingSignal(cycle, X);
        rez += iSig;

        X += Int32.Parse(parts[1]);

    }

}
Console.WriteLine(rez);

for (int ro = 0; ro < 6; ro++)
{
    for (int co = 0; co < 40; co++)
       if (crt[ro,co] == '#')
        Console.Write(crt[ro,co]);
    else
            Console.Write('.');
    Console.WriteLine();
}


int CheckIfInterestingSignal(int c, int x)
{
    int sig = 0;

    if ((c - 20) % 40 == 0 && c <= 220)
    {
        sig = c * x;

        Console.WriteLine($"{c}*{x}");
    }


    if ( c <= 240)
    {
        int row = ((c -1) / 40 );
        int col = ((c - 1) % 40);

        if (x - 1 <= (col ) && (col ) <= x + 1)
            crt[row, col] = '#';
    }

  //  Console.WriteLine(x);
  //  Console.WriteLine($"{c} - {sig}");

    return sig;
}