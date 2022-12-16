// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using System.Net.Http.Headers;

Console.WriteLine("Hello, World!");


string[] lines = File.ReadAllLines("input.txt");

int score = 0;

for(int i = 0; i < lines.Length; /*i++ */ i+= 3)
{
    //  string first = line.Substring(0, line.Length / 2);

    //  string second = line.Substring(line.Length / 2, line.Length / 2);
    //     char c = FindCommon2(first, second);

    string first = lines[i] ;
    string second = lines[i+1];
    string third = lines[i + 2];

    char c = FindCommon3(first, second, third);

    score += FindScore(c);

}

static char FindCommon2(string first, string second)
{
    for(char c = 'a'; c <= 'z'; c++)
    {
        if (first.Contains(c) && second.Contains(c))
            return c;
    }

    for (char c = 'A'; c <= 'Z'; c++)
    {
        if (first.Contains(c) && second.Contains(c))
            return c;
    }
    throw new Exception();
}

static char FindCommon3(string first, string second, string third)
{
    for (char c = 'a'; c <= 'z'; c++)
    {
        if (first.Contains(c) && second.Contains(c) && third.Contains(c))
            return c;
    }

    for (char c = 'A'; c <= 'Z'; c++)
    {
        if (first.Contains(c) && second.Contains(c) && third.Contains(c))
            return c;
    }
    throw new Exception();
}

static int FindScore(char c)
{
    if (c >= 'a' && c <= 'z')
        return (c - 'a') + 1;

    if (c >= 'A' && c <= 'Z')
        return (c - 'A') + 27;

    return 0;
}

Console.WriteLine(score);