using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var result = 0;
using var file = new StreamReader(".\\input.txt");

var group = new HashSet<char>();
while (!file.EndOfStream)
{
    var input = (await file.ReadLineAsync()).ToCharArray();

    if (input.Length == 0)
    {
        result += group.Count;
        group.Clear();
    }
    else
    {
        foreach(var c in input)
        {
            group.Add(c);
        }
    }
}

result += group.Count;

Console.WriteLine($"Result {result}");