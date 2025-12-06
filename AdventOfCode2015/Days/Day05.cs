using System.Text.RegularExpressions;
using AdventOfCode2015.Abstractions;
using AdventOfCode2015.Utilities;

namespace AdventOfCode2015.Days;

public class Day05 : Day
{
    protected override long PartOneTestAnswer => 2;
    protected override long PartTwoTestAnswer => 2;

    private readonly List<string> _forbiddenStrings = ["ab", "cd", "pq", "xy"];
    private readonly List<string> _vowels = ["a", "e", "i", "o", "u"];

    private readonly List<string> _alphabetDouble = [
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
    ];
    
    protected override long SolvePart1(bool isTest = false)
    {
        var input = FileUtility.ReadLinesFromFile(Filename(isTest));
        var solution = 0;
        
        
        foreach (var l in input)
        {
            //Does not contain ab, cd, pq, or xy,
            if (_forbiddenStrings.Any(f => l.Contains(f)))
            {
                continue;
            }
            //contains at least one letter that appears twice in a row
            if (!_alphabetDouble.Any(ad => l.Contains(ad)))
            {
                continue;
            }

            //contains at least three vowels
            var vCount = 0;
            foreach (var v in _vowels)
            {
                vCount += l.Count(c => c.ToString() == v);
            }
	
            if (vCount < 3)
            {
                continue;
            }
            solution++;
        }

        
        return solution;
    }

    protected override long SolvePart2(bool isTest = false)
    {
        var input = FileUtility.ReadLinesFromFile(Filename(isTest));
        var solution = 0;
        
        foreach (var l in input)
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
            foreach (var ad in _alphabetDouble)
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
                solution++;
            }
        }
        
        return solution;
    }
}
