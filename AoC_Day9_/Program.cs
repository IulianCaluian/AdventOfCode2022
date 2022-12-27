// See https://aka.ms/new-console-template for more information


Console.WriteLine("Hello, World!");
string[] lines = File.ReadAllLines("input.txt");



SortedDictionary<int, SortedSet<int>> viz = new SortedDictionary<int, SortedSet<int>>();


int moves;


P[] rope = new P[10];

viz.Add(0, new SortedSet<int> { 0 });

foreach (var line in lines)
{
    string[] parts = line.Split(' ');

    char dir = parts[0][0];
    moves = Int32.Parse(parts[1]);

    for (int i = 0; i < moves; i++)
    {
        if (dir == 'U') rope[0].X--;
        if (dir == 'D') rope[0].X++;
        if (dir == 'L') rope[0].Y--;
        if (dir == 'R') rope[0].Y++;

        for (int j = 1; j <= 9; j++)
        {
            rope[j] = CalculateNewTail(rope[j - 1], rope[j]);
        }

        int tx = rope[9].X;
        int ty = rope[9].Y;

        if (!viz.ContainsKey(tx))
            viz.Add(tx, new SortedSet<int>());

        var row = viz[tx];
        if (!row.Contains(ty))
            row.Add(ty);




    }



}


int rez = 0;
foreach (var row in viz)
{
    rez += row.Value.Count();
}

Console.WriteLine(rez);


P CalculateNewTail(P H, P oldT)
{
    P newT = new P();
    newT.X = oldT.X;
    newT.Y = oldT.Y;

    // Move tail:
    if (Math.Abs(H.Y - oldT.Y) == 2 && Math.Abs(H.X - oldT.X) == 2)
    {
        newT.X = (H.X + oldT.X) / 2;
        newT.Y = (H.Y + oldT.Y) / 2;
    }
    else if (Math.Abs(H.X - oldT.X) == 2)
    {
        newT.X = (H.X + oldT.X) / 2;
        newT.Y = H.Y;
    }
    else if (Math.Abs(H.Y - oldT.Y) == 2)
    {
        newT.X = H.X;
        newT.Y = (H.Y + oldT.Y) / 2;
    }

    return newT;
}

public struct P
{
    public int X;
    public int Y;

    public P()
    {
        X = Y = 0;
    }

}







