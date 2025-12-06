using System.Text.RegularExpressions;
using AdventOfCode2015.Abstractions;
using AdventOfCode2015.Utilities;

namespace AdventOfCode2015.Days;

public class Day06 : Day
{
    protected override long PartOneTestAnswer => 998996;
    protected override long PartTwoTestAnswer => 1001996;

    protected override long SolvePart1(bool isTest = false)
    {
        var input = FileUtility.ReadLinesFromFile(Filename(isTest));
        var solution = 0;
        
        var grid = new int[1000,1000];
        
        foreach (var l in input)
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

        for (int i = 0; i < 1000; i++)
        {
            for (int j = 0; j < 1000; j++)
            {
                //$"{i},{j}".Dump();
                solution += grid[i,j];
            }
        }
        
        return solution;
    }

    protected override long SolvePart2(bool isTest = false)
    {
        var input = FileUtility.ReadLinesFromFile(Filename(isTest));
        var solution = 0;
        
        var grid = new int[1000,1000];
        foreach (var l in input)
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
        
        for (int i = 0; i < 1000; i++)
        {
            for (int j = 0; j < 1000; j++)
            {
                //$"{i},{j}".Dump();
                solution += grid[i, j];
            }
        }

        
        return solution;
    }
}
