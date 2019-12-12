<Query Kind="Statements" />

Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath));

var s = File.ReadAllLines("..\\Data\\Day08.txt");
var total = 0;
var tunktot = 0;
foreach (var l in s)
{
	
	total += l.Length;
	
	var r1 = new Regex("(\\\\)");
	var r2 = new Regex("(\\\")");
	var r3 = new Regex(@"(\\x[0-9][0-9])");
	
	var l2 = l.Length;
	
	l2 = l2 - r1.Matches(l).Count();
	l2 = l2 - r2.Matches(l).Count();
	l2 = l2 - r3.Matches(l).Count() * 3; 
	
	tunktot += l2;
	
}

total.Dump();
tunktot.Dump();
(total - tunktot - 600).Dump();