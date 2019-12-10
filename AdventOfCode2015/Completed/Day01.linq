<Query Kind="Statements" />

Directory.SetCurrentDirectory (Path.GetDirectoryName (Util.CurrentQueryPath));

var s = File.ReadAllText("..\\Data\\Day01.txt");
var up = s.Count(v => v=='(');
var down = s.Count(v=> v==')');

(up-down).Dump();

var floor = 0;
var i = 0;
foreach (var c in s)
{
	i++;
	if (c == '(')
	{
		floor++;
	}
	else
	{
		floor--;
	}
	
	if (floor == -1)
	{
		i.Dump();
		break;
	}
}