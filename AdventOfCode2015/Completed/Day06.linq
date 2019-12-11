<Query Kind="Statements" />

Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath));

var s = File.ReadAllLines("..\\Data\\Day06.txt");

var grid = new int[1000,1000];

//s = new string[]{"turn on 0,0 through 9,0", "turn off 0,0 through 5,0", "toggle 0,0 through 9,9"};

foreach (var l in s)
{
	var reg = new Regex("[0-9]{1,3},[0-9]{1,3}");
	
	var ranges = reg.Matches(l).Select(r => r.Value).ToList();
	var fromRange = ranges[0].Split(',').Select(int.Parse).ToArray();
	var toRange = ranges[1].Split(',').Select(int.Parse).ToArray();
	
	for (int i = fromRange[0]; i <= toRange[0]; i++)
	{
		for (int j = fromRange[1]; j <= toRange[1]; j++)
		{
			if (l.StartsWith("turn on"))
			{
				grid[i,j] = 1;
			}
			if (l.StartsWith("turn off"))
			{
				grid[i,j] = 0;
			}
			if (l.StartsWith("toggle"))
			{
				grid[i,j] = grid[i,j] == 1 ? 0 : 1;
			}
		}
	}
}

int count = 0;
for (int i = 0; i < 1000; i++)
{
	for (int j = 0; j < 1000; j++)
	{
		//$"{i},{j}".Dump();
		count += grid[i,j];
	}
}
count.Dump();

//part 2
grid = new int[1000,1000];
foreach (var l in s)
{
	var reg = new Regex("[0-9]{1,3},[0-9]{1,3}");

	var ranges = reg.Matches(l).Select(r => r.Value).ToList();
	var fromRange = ranges[0].Split(',').Select(int.Parse).ToArray();
	var toRange = ranges[1].Split(',').Select(int.Parse).ToArray();

	for (int i = fromRange[0]; i <= toRange[0]; i++)
	{
		for (int j = fromRange[1]; j <= toRange[1]; j++)
		{
			if (l.StartsWith("turn on"))
			{
				grid[i, j] += 1;
			}
			if (l.StartsWith("turn off"))
			{
				grid[i, j] -= grid[i,j] == 0 ? 0 : 1;
			}
			if (l.StartsWith("toggle"))
			{
				grid[i, j] += 2;
			}
		}
	}
}



count = 0;
for (int i = 0; i < 1000; i++)
{
	for (int j = 0; j < 1000; j++)
	{
		//$"{i},{j}".Dump();
		count += grid[i, j];
	}
}

count.Dump();