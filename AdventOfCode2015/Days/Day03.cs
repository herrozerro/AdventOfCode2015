using AdventOfCode2015.Abstractions;
using AdventOfCode2015.Utilities;

namespace AdventOfCode2015.Days;

public class Day03 : Day
{
    protected override long PartOneTestAnswer => 4;
    protected override long PartTwoTestAnswer => 3;

    protected override long SolvePart1(bool isTest = false)
    {
        var input = FileUtility.ReadFromFile(Filename(isTest));
        var solution = 0;
        
        var ls = new List<string>() {"0,0"};
        var pos = new int[]{0,0};
        foreach (var d in input)
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
        
        solution = ls.Distinct().Count();
        
        return solution;
    }

    protected override long SolvePart2(bool isTest = false)
    {
        var input = FileUtility.ReadFromFile(Filename(isTest));
        var solution = 0;
        
        
        var sanls = new List<string>() { "0,0" };
        var sanpos = new int[] { 0, 0 };

        var rls = new List<string>() { "0,0" };
        var rpos = new int[] { 0, 0 };

        var posls = new int[][] {sanpos, rpos};
        var lsls = new List<List<string>>(){sanls, rls};

        var t = 0;

        foreach (var d in input)
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
        var finalls = lsls[0];
        finalls.AddRange(lsls[1]);

        solution = finalls.Distinct().Count();
        
        return solution;
    }
}
