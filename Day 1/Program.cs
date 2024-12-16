var inputFile = File.ReadAllLines("C:\\Users\\User\\Downloads\\day1input.txt");

// Lines are split into two columns
int[] firstColumn = new int[inputFile.Length];
int[] secondColumn = new int[inputFile.Length];

for (int i = 0; i < inputFile.Length; i++)
{
    string[] parts = inputFile[i].Split("   ");

    firstColumn[i] = int.Parse(parts[0]);
    secondColumn[i] = int.Parse(parts[1]);
}

// Get the difference between the column entries from low to high
Array.Sort(firstColumn);
Array.Sort(secondColumn);

int[] diffs = new int[1000];

for (int i = 0; i < firstColumn.Length; i++)
    diffs[i] = Math.Abs(firstColumn[i] - secondColumn[i]);

int diff = 0;
foreach (int i in diffs)
    diff = diff + i;

Console.WriteLine($"{diff}");

// 2nd part

/* Get entries in 2nd column that are identical to an entry in 1st column
*  Counter tracks matches, multiply original entry by counter
*/
int[] identicals = new int[1000];

int counter = 0;

for (int i = 0; i < firstColumn.Length; i++)
{
    for(int j = 0; j < secondColumn.Length; j++)
        if(firstColumn[i] == secondColumn[j]) counter += 1; 

    identicals[i] = firstColumn[i] * counter;
    counter = 0;
}

// Sum total of identicals
int total = 0;
foreach(int entry in identicals)
    total += entry;

Console.WriteLine($"{total}");