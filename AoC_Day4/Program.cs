// See https://aka.ms/new-console-template for more information


Console.WriteLine("Hello, World!");


string[] lines = File.ReadAllLines("input.txt");

int score = 0;

for (int i = 0; i < lines.Length; i++ )
{
   var line = lines[i];

 //   Console.WriteLine(line);
    var parts = line.Split(new char[] { '-', ',' });
  //  Console.WriteLine(parts[0]);

    int a1 = Int32.Parse(parts[0]);
    int a2 = Int32.Parse(parts[1]);
    int b1 = Int32.Parse(parts[2]);
    int b2 = Int32.Parse(parts[3]);

    //if (CheckForOverlap(a1, a2, b1, b2))
    //    score++;

    if (CheckForPartialOverlap(a1, a2, b1, b2) ||
        CheckForPartialOverlap(b1, b2, a1, a2))
        score++;


}

static bool CheckForOverlap(int startA, int endA, int startB, int endB)
{
    if (startB <= startA && endA <= endB)
        return true;

    if (startA <= startB && endB <= endA)
        return true;

    return false;

}

static bool CheckForPartialOverlap(int startA, int endA, int startB, int endB)
{
    if (startB <= startA && startA <= endB)
        return true;

    if (startB <= endA && endA <= endB)
        return true;

    return false;

}



// Print the result
Console.WriteLine(score);