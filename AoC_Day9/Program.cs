// See https://aka.ms/new-console-template for more information
using System.Xml;

Console.WriteLine("Hello, World!");
string[] lines = File.ReadAllLines("input.txt");



SortedDictionary<int, SortedSet<int>> viz = new SortedDictionary<int, SortedSet<int>>();


int moves;

int hx, hy, tx, ty;
hx = hy = tx = ty = 0;
viz.Add(0, new SortedSet<int> { 0 });

foreach(var line in lines)
{
    string[] parts = line.Split(' ');

    char dir = parts[0][0];
    moves = Int32.Parse(parts[1]);

    for(int i = 0; i < moves; i++)
    {
        if (dir == 'U') hx--;
        if (dir == 'D') hx++;
        if (dir == 'L') hy--;
        if (dir == 'R') hy++;

        // Move tail:
        if (Math.Abs(hx - tx) == 2)
        {
            tx = (hx + tx) / 2;
            ty = hy;
        } 
        else if (Math.Abs(hy - ty) == 2)
        {
            tx = hx;
            ty = (hy + ty) / 2;
        }

        if (!viz.ContainsKey(tx))
            viz.Add(tx, new SortedSet<int>());

        var row = viz[tx];
        if (!row.Contains(ty))
            row.Add(ty);


    }



}


int rez = 0;
foreach(var row in viz)
{
    rez += row.Value.Count();
}

Console.WriteLine(rez);




