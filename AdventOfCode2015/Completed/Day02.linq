<Query Kind="Statements" />

Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath));

var s = File.ReadAllLines("..\\Data\\Day02.txt");

//s = new string[]{"2x3x4","1x1x10"};

var total = 0;

foreach (var e in s)
{
	var l = int.Parse(e.Split('x')[0]);
	var w = int.Parse(e.Split('x')[1]);
	var h = int.Parse(e.Split('x')[2]);
	
	var h2 = l*w;
	var w2 = h*l;
	var l2 = w*h;

	var d = new int[]{h2,w2,l2};
	//d.Sum(x=>x*2).Dump();	
	total += d.Sum(x=>x*2) + d.Min();
}

total.Dump();

total = 0;
foreach (var e in s)
{
	var l = int.Parse(e.Split('x')[0]);
	var w = int.Parse(e.Split('x')[1]);
	var h = int.Parse(e.Split('x')[2]);

	var sides = new int[] { l, w, h };

	var ss1 = sides.OrderBy(x=>x).ToList()[0];
	var ss2 = sides.OrderBy(x=>x).ToList()[1];
	
	var len = (ss1*2) + (ss2 *2);
	var v = l*w*h;
		
	total += len + v;
}

total.Dump();