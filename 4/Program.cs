using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var lines = new List<string>();
using var file = new StreamReader(args[0]);
var line = string.Empty;
while (!file.EndOfStream)
{
    var input = await file.ReadLineAsync();
    if (!string.IsNullOrEmpty(input))
    {
        line += input + " ";
    }
    else
    {
        lines.Add(line);
        line = string.Empty;
    }
}
lines.Add(line);

var validCount = 0;
foreach (var l in lines)
{
    var splited = l.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    var fields = splited.ToDictionary(x => x.Split(':')[0]);

    if (fields.ContainsKey("byr") && valid_byr(fields["byr"].Substring(4)) &&
        fields.ContainsKey("iyr") && valid_iyr(fields["iyr"].Substring(4)) &&
        fields.ContainsKey("eyr") && valid_eyr(fields["eyr"].Substring(4)) &&
        fields.ContainsKey("hgt") && valid_hgt(fields["hgt"].Substring(4)) &&
        fields.ContainsKey("hcl") && valid_hcl(fields["hcl"].Substring(4)) &&
        fields.ContainsKey("ecl") && valid_ecl(fields["ecl"].Substring(4)) &&
        fields.ContainsKey("pid") && valid_pid(fields["pid"].Substring(4)))
    {
        validCount++;
    }
}

Console.WriteLine($"valid count {validCount}");

bool valid_byr(string value) => value.Length == 4 && int.TryParse(value, out var v) && v >= 1920 && v <= 2002;
bool valid_iyr(string value) => value.Length == 4 && int.TryParse(value, out var v) && v >= 2010 && v <= 2020;
bool valid_eyr(string value) => value.Length == 4 && int.TryParse(value, out var v) && v >= 2020 && v <= 2030;
bool valid_hgt(string value) => value.EndsWith("cm") ? int.TryParse(value.Substring(0, value.Length - 2), out var v) && v >= 150 && v <= 193 : value.EndsWith("in") ? int.TryParse(value.Substring(0, value.Length - 2), out var vv) && vv >= 59 && vv <= 76 : false; 
bool valid_hcl(string value) => System.Text.RegularExpressions.Regex.Match(value, "^#[0-9a-z]{6}$").Success;
bool valid_ecl(string value) => value == "amb" || value == "blu" || value == "brn" || value == "gry" || value == "grn" || value == "hzl" || value == "oth";
bool valid_pid(string value) => System.Text.RegularExpressions.Regex.Match(value, "^[0-9]{9}$").Success;