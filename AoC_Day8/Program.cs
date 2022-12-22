// See https://aka.ms/new-console-template for more information
using System.ComponentModel;

Console.WriteLine("Hello, World!");

string[] lines = File.ReadAllLines("input.txt");

int width = lines[0].Length;
int height = lines.Length;


int[,] viz = new int[height, width];
char[,]mUp =    new char[height, width];
char[,]mDown =  new char[height, width];
char[,]mLeft =  new char[height, width];
char[,]mRight = new char[height, width];

// Up:
for (int i = 0;i < height; i++)
    for (int j = 0;j < width;j++)
    {
        if (i == 0)
        {
            viz[i, j] = 1;
            mUp[i, j] = lines[i][j];
            continue;
        }

        mUp[i, j] = mUp[i - 1, j];
        if (lines[i][j] > mUp[i - 1, j])
        {
            viz[i, j] = 1;
            mUp[i,j] = lines[i][j];
        }
    }

// Down:

for (int i = height-1 ; i >= 0; i--)
    for (int j = 0; j < width; j++)
    {
        if ( i == height - 1 )
        {
            viz[i, j] = 1;
            mDown[i, j] = lines[i][j];
            continue;
        }

        mDown[i, j] = mDown[i+1,j];
        if (lines[i][j] > mDown[i + 1, j])
        {
            viz[i, j] = 1;
            mDown[i, j] = lines[i][j];
        }
    }

// Left:
// Down:
for (int j = 0; j < width; j++)
    for (int i = 0; i < height; i++)
        {
            if (j == 0)
            {
                viz[i, j] = 1;
            mLeft[i, j] = lines[i][j];
            continue;
            }

        mLeft[i,j] = mLeft[i,j - 1];

        if (lines[i][j] > mLeft[i,j - 1])
        {
            viz[i, j] = 1;
            mLeft [i, j] = lines[i][j];
        }
        }

for (int j = width -1; j >=0; j--)
    for (int i = 0; i < height; i++)
    {
        if (j == width - 1)
        {
            viz[i, j] = 1;
            mRight[i, j] = lines[i][j];
            continue;
        }

        mRight[i, j] = mRight[i, j +1];
        if (lines[i][j] > mRight[i, j + 1])
        {
            viz[i, j] = 1;
            mRight[i,j] = lines[i][j];
        }
      
    }

int rez = 0;
for (int i = 0; i < height; i++)
{
    for (int j = 0; j < width; j++)
    {
        if (viz[i, j] == 1)
            rez++;
        Console.Write(viz[i,j]);
    }
    Console.WriteLine();
}

Console.WriteLine(rez);