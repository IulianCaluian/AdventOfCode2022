// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Console.WriteLine(args);

string[] lines = File.ReadAllLines("input.txt");

int maxCal1 = 0;
int maxCal2 = 0;
int maxCal3 = 0;

int maxPoz = 0;

int cal = 0;
// int poz = 1;

foreach(string line in lines)
{
    if (string.IsNullOrEmpty(line))
    {
        if (cal >= maxCal1)
        {
            maxCal3 = maxCal2;
            maxCal2 = maxCal1;
            maxCal1 = cal;
           // maxPoz = poz;
           
        } else if (cal >= maxCal2)
        {
            maxCal3 = maxCal2;
            maxCal2 = cal;
        } else if (cal >= maxCal3)
        {
            maxCal3 = cal;
        }

        cal = 0;
       // poz++;

    } else
    {
        cal += Int32.Parse(line);
    }
}



if (cal >= maxCal1)
{
    maxCal3 = maxCal2;
    maxCal2 = maxCal1;
    maxCal1 = cal;
    // maxPoz = poz;

}
else if (cal >= maxCal2)
{
    maxCal3 = maxCal2;
    maxCal2 = cal;
}
else if (cal >= maxCal3)
{
    maxCal3 = cal;
}

Console.WriteLine(maxPoz + " " + (maxCal1 + maxCal2 + maxCal3));

GetNumber();

 int GetNumber()
{
    return 2;
}