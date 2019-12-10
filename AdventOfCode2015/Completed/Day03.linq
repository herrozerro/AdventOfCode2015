<Query Kind="Statements" />

Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath));

var s = File.ReadAllText("..\\Data\\Day03.txt");

//s = "^v^v^v^v^v";

var ls = new List<string>() {"0,0"};
var pos = new int[]{0,0};
foreach (var d in s)
{
	switch (d)
	{
		case '^':
			pos[1]++;
			ls.Add($"{pos[0]},{pos[1]}");
			break;
		case '>':
			pos[0]++;
			ls.Add($"{pos[0]},{pos[1]}");
			break;
		case 'v':
			pos[1]--;
			ls.Add($"{pos[0]},{pos[1]}");
			break;
		case '<':
			pos[0]--;
			ls.Add($"{pos[0]},{pos[1]}");
			break;
	}
}

ls.Distinct().Count().Dump();

var sanls = new List<string>() { "0,0" };
var sanpos = new int[] { 0, 0 };

var rls = new List<string>() { "0,0" };
var rpos = new int[] { 0, 0 };

var posls = new int[][] {sanpos, rpos};
var lsls = new List<List<string>>(){sanls, rls};

var t = 0;

foreach (var d in s)
{
	var turn = t % 2 == 0 ? 0 : 1;
	t++;
	var post = posls[turn];
	var lst = lsls[turn];
	
	switch (d)
	{
		case '^':
			post[1]++;
			lst.Add($"{post[0]},{post[1]}");
			break;
		case '>':
			post[0]++;
			lst.Add($"{post[0]},{post[1]}");
			break;
		case 'v':
			post[1]--;
			lst.Add($"{post[0]},{post[1]}");
			break;
		case '<':
			post[0]--;
			lst.Add($"{post[0]},{post[1]}");
			break;
	}
}
//lsls.Dump();
var finalls = lsls[0];
finalls.AddRange(lsls[1]);

finalls.Distinct().Count().Dump();