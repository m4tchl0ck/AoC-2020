using System;
using System.Collections.Generic;
using System.Linq;

var lines = new List<string>();


var input = Console.ReadLine();
while (!string.IsNullOrEmpty(input))
{
    lines.Add(input);
    input = Console.ReadLine();
}

Console.WriteLine($"Trees count for 1, 3 {CountTrees(1, 3, lines.ToArray())}");

var x1 = CountTrees(1, 1, lines.ToArray());
var x2 = CountTrees(1, 3, lines.ToArray());
var x3 = CountTrees(1, 5, lines.ToArray());
var x4 = CountTrees(1, 7, lines.ToArray());
var x5 = CountTrees(2, 1, lines.ToArray());

Console.WriteLine($"res {x1} * {x2} * {x3} * {x4} * {x5} = {x1 * x2 * x3 * x4 * x5}");


long CountTrees(int down, int right, string[] map)
{
    Console.WriteLine($"================{down}---{right}==========");
    var treesCount = 0;

    var line = 0;
    for (var i = 0; i < map.Length; i += down)
    {
        var inputc = map[i].ToCharArray();
        var ix = right * line % inputc.Length;
        var c = inputc[ix];
        if (c == '.')
        {
            inputc[ix] = 'O';
        }
        else if (c == '#')
        {
            inputc[ix] = 'X';
            treesCount++;
        }

        Console.WriteLine(new string(inputc));
        line++;
    }

    Console.WriteLine($"=================res-{treesCount}==========");

    return treesCount;
}

