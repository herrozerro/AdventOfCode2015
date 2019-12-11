<Query Kind="Statements" />

Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath));

var s = File.ReadAllLines("..\\Data\\Day05.txt");
var niceCount = 0;

//s = new string[]{"ugknbfddgicrmopn", "aaa", "jchzalrnumimnmhp", "haegwjzuvuyypxyu", "dvszwmarrgswjxmb"};

var forbiddenStrings = new List<string>(){"ab", "cd", "pq", "xy"};
var vowels = new List<string>(){"a", "e", "i", "o", "u"};
var alphabetDouble = new List<string>() {
	"aa",
	"bb",
	"cc",
	"dd",
	"ee",
	"ff",
	"gg",
	"hh",
	"ii",
	"jj",
	"kk",
	"ll",
	"mm",
	"nn",
	"oo",
	"pp",
	"qq",
	"rr",
	"ss",
	"tt",
	"uu",
	"vv",
	"ww",
	"xx",
	"yy",
	"zz"
};
foreach (var l in s)
{
	//Does not contain ab, cd, pq, or xy,
	if (forbiddenStrings.Any(f => l.Contains(f)))
	{
		continue;
	}
	//contains at least one letter that appears twice in a row
	if (!alphabetDouble.Any(ad => l.Contains(ad)))
	{
		continue;
	}

	//contains at least three vowels
	var vCount = 0;
	foreach (var v in vowels)
	{
		vCount += l.Count(c => c.ToString() == v);
	}
	
	if (vCount < 3)
	{
		continue;
	}
	niceCount++;
}

niceCount.Dump();

//Part2
//s = new string[]{"qjhvhtzxzqqjkmpb", "xxyxx", "uurcxstgmygtbstg", "ieodomkazucvgmuy"};

niceCount=0;
foreach (var l in s)
{
	bool isNice = false;
	//var reg = new Regex(@"(.)\1");
	//It contains a pair of any two letters that appears at least twice 
	//in the string without overlapping, like xyxy (xy) or aabcdefgaa (aa), 
	//but not like aaa (aa, but it overlaps).
	for (int i = 0; i < l.Length - 1; i++)
	{
		var p = string.Join("",l.Skip(i).Take(2));
		var reg = new Regex(p);
		if (reg.Matches(l).Count() > 1)
		{
			isNice = true;
			break;
		}
	}
	if (!isNice)
	{
		continue;
	}
	
	isNice = false;
	//It contains at least one letter which repeats with exactly one letter 
	//between them, like xyx, abcdefeghi (efe), or even aaa.
	foreach (var ad in alphabetDouble)
	{
		var reg = new Regex($"{ad.First()}[a-z]{ad.First()}");
		if (reg.Matches(l).Count() > 0)
		{
			isNice = true;
			break;
		}
	}
	if (isNice)
	{
		niceCount++;
	}
}
niceCount.Dump();