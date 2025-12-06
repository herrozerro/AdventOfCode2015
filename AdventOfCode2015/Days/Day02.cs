using AdventOfCode2015.Abstractions;
using AdventOfCode2015.Utilities;

namespace AdventOfCode2015.Days;

public class Day02 : Day
{
    // TODO: Set test values
    protected override long PartOneTestAnswer => 58;
    protected override long PartTwoTestAnswer => 34;

    protected override long SolvePart1(bool isTest = false)
    {
        var input = FileUtility.ReadLinesFromFile(Filename(isTest));
        var solution = 0;

        foreach (var e in input)
        {
            var l = int.Parse(e.Split('x')[0]);
            var w = int.Parse(e.Split('x')[1]);
            var h = int.Parse(e.Split('x')[2]);
	
            var h2 = l*w;
            var w2 = h*l;
            var l2 = w*h;

            var d = new int[]{h2,w2,l2};
            solution += d.Sum(x=>x*2) + d.Min();
        }
        
        return solution;
    }

    protected override long SolvePart2(bool isTest = false)
    {
        var input = FileUtility.ReadLinesFromFile(Filename(isTest));
        var solution = 0;
        
        foreach (var e in input)
        {
            var l = int.Parse(e.Split('x')[0]);
            var w = int.Parse(e.Split('x')[1]);
            var h = int.Parse(e.Split('x')[2]);

            var sides = new int[] { l, w, h };

            var ss1 = sides.OrderBy(x=>x).ToList()[0];
            var ss2 = sides.OrderBy(x=>x).ToList()[1];
	
            var len = (ss1*2) + (ss2 *2);
            var v = l*w*h;
		
            solution += len + v;
        }
        
        return solution;
    }
}
