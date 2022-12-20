// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string[] lines = File.ReadAllLines("input.txt");


string input = lines[0];

int poz = 0;
for(  ; poz < input.Length -3; poz++)
{
    if (allDiferent(input[poz], input[poz + 1], input[poz + 2], input[poz + 3]))
        break;
}

bool allDiferent(char v1, char v2, char v3, char v4)
{
    if (v1 == v2 || v1 == v3 || v1 == v4)
        return false;

    if (v2 == v3 || v2 == v4)
        return false;

    if (v3 == v4)
        return false;

    return true;
}



Console.WriteLine(poz + 4);


