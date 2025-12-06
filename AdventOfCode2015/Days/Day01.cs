using AdventOfCode2015.Abstractions;
using AdventOfCode2015.Utilities;

namespace AdventOfCode2015.Days;

public class Day01 : Day
{
    protected override long PartOneTestAnswer => -1;
    protected override long PartTwoTestAnswer => 5;

    protected override long SolvePart1(bool isTest = false)
    {
        var input = FileUtility.ReadFromFile(Filename(isTest));
        var solution = 0;
        
        solution += input.Count(c => c == '(');
        solution += input.Count(c => c == ')') * -1;

        return solution;
    }

    protected override long SolvePart2(bool isTest = false)
    {
        var input = FileUtility.ReadFromFile(Filename(isTest));
        var solution = 0;
        
        var floor = 0;
        var i = 0;
        foreach (var c in input)
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

            if (floor != -1) continue;
                
            solution = i;
            break;
        }
        
        return solution;
    }
}
