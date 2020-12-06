using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var result = 0;
using var file = new StreamReader(".\\input.txt");

var group = new Dictionary<char, int>();
var personsCount = 0;
while (!file.EndOfStream)
{
    var input = (await file.ReadLineAsync()).ToCharArray();

    if (input.Length == 0)
    {
        result += group.Count(g => g.Value == personsCount);
        group.Clear();
        personsCount = 0;
    }
    else
    {
        personsCount++;
        foreach(var c in input)
        {
            if (!group.ContainsKey(c))
            {
                group[c] = 0;
            }
            group[c]++;
        }
    }
}

result += group.Count(g => g.Value == personsCount);

Console.WriteLine($"Result {result}");