using System.Security.Cryptography;
using System.Text;
using AdventOfCode2015.Abstractions;
using AdventOfCode2015.Utilities;

namespace AdventOfCode2015.Days;

public class Day04 : Day
{
    protected override long PartOneTestAnswer => 609043;
    protected override long PartTwoTestAnswer => 6742839;

    protected override long SolvePart1(bool isTest = false)
    {
        var input = FileUtility.ReadFromFile(Filename(isTest));
        var solution = 0;

        var i = 0;
        using MD5 hash = MD5.Create();
        while (true)
        {
            var h = GetMd5Hash(hash, input + i);
            if (h.StartsWith("00000"))
            {
                solution = i;
                break;
            }
            i++;
        }

        return solution;
    }
    
    static string GetMd5Hash(MD5 md5Hash, string input)
    {

        // Convert the input string to a byte array and compute the hash.
        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

        // Create a new Stringbuilder to collect the bytes
        // and create a string.
        StringBuilder sBuilder = new StringBuilder();

        // Loop through each byte of the hashed data 
        // and format each one as a hexadecimal string.
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }

        // Return the hexadecimal string.
        return sBuilder.ToString();
    }

    protected override long SolvePart2(bool isTest = false)
    {
        var input = FileUtility.ReadFromFile(Filename(isTest));
        var solution = 0;

        var i = 0;
        using MD5 hash = MD5.Create();
        while (true)
        {
            var h = GetMd5Hash(hash, input + i);
            if (h.StartsWith("000000"))
            {
                solution = i;
                break;
            }
            i++;
        }

        return solution;
    }
}
