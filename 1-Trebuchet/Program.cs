using System.Numerics;

var file = "Assets/1-Trebuchet-Input.txt";
var lines = File.ReadAllLines(file);
var sum = 0;

foreach (var line in lines)
{
    char[] chars = [.. line];
    var firstDigit = 0;
    var lastDigit = -1;
    var isFirstDigit = true;

    for (int i = 0; i < chars.Length; i++)
    {
        var character = chars[i].ToString();

        bool parsed = int.TryParse(character, out var number);

        if (!parsed)
            continue;

        if (isFirstDigit)
        {
            firstDigit = number;
            isFirstDigit = false;
        }
        else if (!isFirstDigit)
        {
            lastDigit = number;
        }
    }

    if (lastDigit is -1)
        lastDigit = firstDigit;

    var concatedNumber = String.Concat(firstDigit, lastDigit);

    Console.WriteLine("Concatenated number: {0}", concatedNumber);

    _ = int.TryParse(concatedNumber, out var numberToAdd);

    sum += numberToAdd;
}

Console.WriteLine("Final result: {0}", sum);