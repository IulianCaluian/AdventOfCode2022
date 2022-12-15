// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


string[] lines = File.ReadAllLines("input.txt");

int score = 0;

foreach (string line in lines)
{
   char op = line[0];

    char me = line[2];
    
    int scorePart = CalculateScore(op, me);
    Console.WriteLine($"{op} {me} {scorePart}");


    score += scorePart;
}

Console.WriteLine(score);




static int CalculateScore(char op, char me)
{

    //if (op == 'A' && me == 'X') return 1 + 3;
    //if (op == 'B' && me == 'X') return 1 + 0;
    //if (op == 'C' && me == 'X') return 1 + 6;

    //if (op == 'A' && me == 'Y') return 2 + 6;
    //if (op == 'B' && me == 'Y') return 2 + 3;
    //if (op == 'C' && me == 'Y') return 2 + 0;

    //if (op == 'A' && me == 'Z') return 3 + 0;
    //if (op == 'B' && me == 'Z') return 3 + 6;
    //if (op == 'C' && me == 'Z') return 3 + 3;


    if (op == 'A' && me == 'X') return 3 + 0;
    if (op == 'B' && me == 'X') return 1 + 0;
    if (op == 'C' && me == 'X') return 2 + 0;

    if (op == 'A' && me == 'Y') return 1 + 3;
    if (op == 'B' && me == 'Y') return 2 + 3;
    if (op == 'C' && me == 'Y') return 3 + 3;

    if (op == 'A' && me == 'Z') return 2 + 6;
    if (op == 'B' && me == 'Z') return 3 + 6;
    if (op == 'C' && me == 'Z') return 1 + 6;



    return 0;

}