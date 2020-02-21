using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
    public int solution(int N)
    {
        var binary = Convert.ToString(N, 2);
        var binaryGapFinder = new BinaryGapFinder();
        return binaryGapFinder.FindBinaryGap(binary);
    }
}

public class BinaryGapFinder
{
    public int FindBinaryGap(string binary)
    {
        var bitArray = BitArray(binary);
        var gaps = GetGaps(bitArray);
        return gaps.OrderByDescending(x => x).FirstOrDefault();
    }

    private static IEnumerable<int> GetGaps(BitArray bitArray)
    {
        int count = 0;
        bool startedGap = false;
        foreach (bool bit in bitArray)
        {
            if (bit)
            {
                if (startedGap && count > 0)
                {
                    yield return count;
                    count = 0;
                }
                else
                    startedGap = true;
            }
            else if (startedGap)
            {
                count++;
            }
        }
    }

    private static BitArray BitArray(string binary)
    {
        return new BitArray(binary.Select(x => x == '1').ToArray());
    }
}