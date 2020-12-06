using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

var highest = 0;
using var file = new StreamReader(".\\input.txt");
var line = string.Empty;
var ids = new HashSet<int>();
while (!file.EndOfStream)
{
    var input = await file.ReadLineAsync();

    var id = GetId(input);

    ids.Add(id);
    if (id > highest)
    {
        highest = id;
    }
}
Console.WriteLine($"highes {highest}");

foreach (var i in Enumerable.Range(0, highest))
{
    if (!ids.Contains(i) && ids.Contains(i-1) && ids.Contains(i+1))
    {
        Console.WriteLine($"My id {i}");
    }
}

int GetId(string input)
{
    var range = (0, 127);
    for (var i = 0; i < 7; i++)
    {
        range = Get(input[i], range);
    }

    if (range.Item1 != range.Item2)
    {
        Console.WriteLine($"row {input} {range.Item1} : {range.Item2}");
    }

    var row = range.Item1;
    range = (0, 7);
    for (var i = 7; i < 10; i++)
    {
        range = Get(input[i], range);
    }

    if (range.Item1 != range.Item2)
    {
        Console.WriteLine($"col {input} {range.Item1} : {range.Item2}");
    }

    var col = range.Item1;

    return row * 8 + col;
}

(int min, int max) Get(char c, (int min, int max) range)
{
    if (c == 'F' || c == 'L')
    {
        return (range.min, (range.max - range.min) / 2 + range.min);
    }
    if (c == 'B' || c == 'R')
    {
        return ((range.max - range.min) / 2 + range.min + 1, range.max);
    }

    return (-1, -1);
}