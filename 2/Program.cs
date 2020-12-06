using System;
using System.Linq;

var i = 0;
var j = 0;
var input = Console.ReadLine();
while (!string.IsNullOrEmpty(input))
{
    var splited = input.Split(new char[] { '-', ' ', ':'}, StringSplitOptions.RemoveEmptyEntries);

    var min = Convert.ToInt32(splited[0]);
    var max = Convert.ToInt32(splited[1]);
    var cr = splited[2][0];
    var password = splited[3];

    var count = password.Count(c => c == cr);

    if (count >= min && count <= max)
    {
        i++;
    }

    var ix1 = min - 1;
    var ix2 = max - 1;

    if ((password[ix1] == cr && password[ix2] != cr) ||
        (password[ix1] != cr && password[ix2] == cr))
    {
        j++;
    }

    input = Console.ReadLine();
}

Console.WriteLine($"valid count 1st policy {i}");
Console.WriteLine($"valid count 2nd policy {j}");