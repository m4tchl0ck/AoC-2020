using System;
using System.Collections.Generic;

var values = new HashSet<int>();
var input = Console.ReadLine();
while (!string.IsNullOrEmpty(input))
{
    var num = Convert.ToInt32(input);
    values.Add(num);
    input = Console.ReadLine();
}

foreach (var val in values)
{
    var val2 = 2020 - val;

    if (values.Contains(val2))
    {
        Console.WriteLine($"{val} * {val2} = {val * val2}");
    }

    foreach (var val3 in values)
    {
        var val4 = 2020 - val - val3;

        if (values.Contains(val4))
        {
            Console.WriteLine($"{val} * {val3} * {val4} = {val * val3 * val4}");
        }
    }
}
