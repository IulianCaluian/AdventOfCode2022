// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string[] lines = File.ReadAllLines("input.txt");


List<Tuple<string, long>> foldersWithSizes = new List<Tuple<string, long>>();

Stack<string> folders = new Stack<string>();
Stack<long> sizes = new Stack<long>();

string topFolderName = string.Empty;
long topFolderSize,curentFolderSize;
foreach(string line in lines)
{
    if (line.StartsWith("$ ls")) continue;

    if (line.StartsWith("$ cd .."))
    {
        topFolderName = folders.Pop();
        topFolderSize = sizes.Pop();

        foldersWithSizes.Add(new Tuple<string, long>(topFolderName, topFolderSize));

        curentFolderSize = sizes.Pop();
        sizes.Push(curentFolderSize + topFolderSize);

        continue;
    }

    if (line.StartsWith("$ cd "))
    {
        string foldName = line.Substring(5);
        folders.Push(foldName);
        sizes.Push(0);
        continue;
    }

    // File:
    if (line.StartsWith("dir"))
        continue;

    string sizeStr = line.Split(' ')[0];
    long size = long.Parse(sizeStr);

    curentFolderSize = sizes.Pop();
    sizes.Push(curentFolderSize + size);

}

while(folders.Count > 0)
{
    topFolderName = folders.Pop();
    topFolderSize = sizes.Pop();
    foldersWithSizes.Add(new Tuple<string, long>(topFolderName, topFolderSize));

    if (folders.Count > 0)
    {
        curentFolderSize = sizes.Pop();
        sizes.Push(curentFolderSize + topFolderSize);
    }
}

long rez = 0;
foreach(var pair in foldersWithSizes)
{
    if (pair.Item2 <= 100000)
        rez += pair.Item2;

    Console.WriteLine($"{pair.Item1}: {pair.Item2}");
}

Console.WriteLine(rez);


long total = foldersWithSizes.Where(f => f.Item1.Equals("/")).First().Item2;
long free = 70000000 - total;
long atLeast = 30000000 - free;

long minSz = total;

foreach (var pair in foldersWithSizes)
{
    if (pair.Item2 > atLeast)
    {
        if (pair.Item2 < minSz)
            minSz = pair.Item2;
    }

}

Console.WriteLine(minSz);

//public class Tree
//{
//    public Tree Father { get; set; }
//    public string Name { get; set; }    
//    public long size { get; set; }

//    public IEnumerable<Tree> Children { get; set; }

//    public Tree(Tree Father, string name, int type)
//    {
//        if (type == 0)
//            Children = new List<Tree>();


//    }
//}



